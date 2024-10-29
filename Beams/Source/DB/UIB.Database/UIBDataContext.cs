using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Messaging;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Transactions;
using System.Threading;
using System.Security.AccessControl;
using System.Security.Principal;

namespace HSM.Database
{
    using Janus.Rodeo.Windows.Library.Rd_Log;

    /// <summary>
    /// partial class
    /// </summary>
    partial class HSMDataContext
    {
        #region private structures
        private struct changes
        {
            public string type;
            public object transaction;
            public object entity;
        }
        #endregion

        #region public attributes
        public static string default_connection_string;
        #endregion

        #region submit changes with sending request
        public void SubmitChanges(string msqueue)
        {
            // Get the changes
            List<changes> transactions = new List<changes>();

            try
            {
                if (!string.IsNullOrEmpty(msqueue))
                {
                    //Transmitting the transaction to slave server using the rigth sequence
                    try
                    {
                        object service = this.GetType().GetProperty("Services", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this);

                        Type t = typeof(DataContext).Assembly.GetType("System.Data.Linq.ChangeProcessor");
                        ConstructorInfo ctor = t.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];

                        object[] args = new object[2] { service, this };
                        object processor = ctor.Invoke(args);

                        var objects = processor.GetType().GetMethod("GetOrderedList", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(processor, null) as IEnumerable<object>;
                        foreach (var item in objects)
                        {
                            bool? IsNew = item.GetType().GetProperty("IsNew", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(item) as bool?;
                            if (IsNew ?? false == true)
                            {
                                item.GetType().GetMethod("SynchDependentData", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(item, null);
                                object current = item.GetType().GetProperty("Current", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(item);
                                transactions.Add(new changes() { type = "INS", transaction = current, entity = item });
                            }
                            else
                            {
                                bool? IsDeleted = item.GetType().GetProperty("IsDeleted", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(item) as bool?;
                                if (IsDeleted ?? false == true)
                                {
                                    item.GetType().GetMethod("SynchDependentData", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(item, null);
                                    object current = item.GetType().GetProperty("Current", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(item);
                                    transactions.Add(new changes() { type = "DEL", transaction = current, entity = item });
                                }
                                else
                                {
                                    bool? IsPossiblyModified = item.GetType().GetProperty("IsPossiblyModified", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(item) as bool?;
                                    if (IsPossiblyModified ?? false == true)
                                    {
                                        bool? IsModified = item.GetType().GetProperty("IsModified", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(item) as bool?;
                                        if (IsModified ?? false == true)
                                        {
                                            item.GetType().GetMethod("SynchDependentData", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(item, null);
                                            object current = item.GetType().GetProperty("Current", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(item);
                                            transactions.Add(new changes() { type = "UPD", transaction = current, entity = item });
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        RdTrace.Exception(ex);
                    }
                }

                base.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                foreach (changes item in transactions)
                {
                    switch (item.type)
                    {
                        case "INS":
                            SendInserts(item.transaction, msqueue);
                            break;
                        case "DEL":
                            SendDeletes(item.transaction, msqueue);
                            break;
                        case "UPD":
                            SendUpdates(item.transaction, msqueue);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
        }
        #endregion

        #region submit replication transaction
        public string SubmitReplication(string message, int max_retries, out string tablename)
        {
            tablename = string.Empty;

            string[] content = message.Split('|');
            if (content.Count() <= 1)
            {
                return "WRONG_FORMAT";
            }

            int type;
            if (!int.TryParse(content[0], out type))
            {
                return "WRONG_FORMAT";
            }

            int iteration = 0;
            bool processed = false;
            string error = string.Empty;

            while (!processed && iteration < max_retries)
            {
                try
                {
                    switch (type)
                    {
                        //Typo 1: Insert
                        case (int)ActionTypes.Insert:
                            this.ReceiveInserts(content[1], out tablename);
                            break;
                        //Typo 2: Delete
                        case (int)ActionTypes.Delete:
                            this.ReceiveDeletes(content[1], out tablename);
                            break;
                        //Typo 3: Update Entity
                        case (int)ActionTypes.Update:
                            this.ReceiveUpdates(content[1], out tablename);
                            break;
                        //Not Defined
                        default:
                            error = "TYPE_NOT_DEFINED";
                            break;
                    }

                    processed = true;
                }
                catch (Exception ex)
                {
                    iteration++;

                    if (iteration == max_retries)
                    {
                        error = "EXCEPTION";

                        RdTrace.Exception(ex, "Exception executing transaction DB request");
                    }
                    else
                    {
                        Thread.Sleep(10);
                    }
                }
            }

            return error;
        }
        #endregion

        #region private sending message
        private void SendInserts(object item, string msqueue)
        {
            string message = string.Format("{0}|{1}", (int)ActionTypes.Insert, LinqSerializer.GetString<object>(item));
            this.SendCompleted(message, msqueue);
        }

        private void SendDeletes(object item, string msqueue)
        {
            string message = string.Format("{0}|{1}", (int)ActionTypes.Delete, LinqSerializer.GetString<object>(item));
            this.SendCompleted(message, msqueue);
        }

        private void SendUpdates(object item, string msqueue)
        {
            string message = string.Format("{0}|{1}", (int)ActionTypes.Update, LinqSerializer.GetString<object>(item));
            this.SendCompleted(message, msqueue);
        }

        private void SendCompleted(string message, string msqueue)
        {
            try
            {
                if (msqueue.StartsWith(@".\Private$") && !MessageQueue.Exists(msqueue))
                {
                    MessageQueue queue = MessageQueue.Create(msqueue, false);

                    SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                    var acceveryone = everyone.Translate(typeof(NTAccount)) as NTAccount;
                    queue.SetPermissions(acceveryone.Value, MessageQueueAccessRights.FullControl, AccessControlEntryType.Allow);

                    SecurityIdentifier anonymous = new SecurityIdentifier(WellKnownSidType.AnonymousSid, null);
                    var accanonymous = anonymous.Translate(typeof(NTAccount)) as NTAccount;
                    queue.SetPermissions(accanonymous.Value, MessageQueueAccessRights.FullControl, AccessControlEntryType.Allow);
                }
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }

            using (MessageQueue rmQ = new MessageQueue(msqueue))
            {
                rmQ.Send(message);
                rmQ.Close();
            }
        }
        #endregion

        #region private receive message
        private void ReceiveInserts(string message, out string tablename)
        {
            List<string> listElements = LinqSerializer.GetElements(message);
            object dbObject = LinqSerializer.GetObject(message);

            this.InsertCompleted(dbObject, listElements, out tablename);
        }

        private void ReceiveDeletes(string message, out string tablename)
        {
            List<string> listElements = LinqSerializer.GetElements(message);
            object dbObject = LinqSerializer.GetObject(message);

            this.DeleteCompleted(dbObject, listElements, out tablename);
        }

        private void ReceiveUpdates(string message, out string tablename)
        {
            List<string> listElements = LinqSerializer.GetElements(message);
            object dbObject = LinqSerializer.GetObject(message);

            this.UpdateCompleted(dbObject, listElements, out tablename);
        }

        private void InsertCompleted(object item, List<string> listElements, out string nameOfTable)
        {
            nameOfTable = this.GetNameOfTable(item.GetType());

            List<string> listIdentities = this.GetIdentityNameOfEntity(item);
            if (listIdentities.Count > 0 && listElements.Any(p => listIdentities.Contains(p)))
            {
                try
                {
                    string cmd = string.Format("DBCC CHECKIDENT('{0}', RESEED, {1})", nameOfTable, item.GetType().GetProperty(listIdentities.First()).GetValue(item)) + "\n";
                    cmd += string.Format("SET IDENTITY_INSERT {0} ON", nameOfTable) + "\n";
                    cmd += this.GetInsertTransaction(listElements, item, nameOfTable) + "\n";
                    cmd += string.Format("SET IDENTITY_INSERT {0} OFF", nameOfTable);

                    using (var scope = new TransactionScope())
                    {
                        this.ExecuteCommand(cmd);

                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    this.ExecuteCommand(string.Format("SET IDENTITY_INSERT {0} OFF", nameOfTable));
                    throw ex;
                }
            }
            else
            {
                this.GetTable(item.GetType()).InsertOnSubmit(item);
                this.SubmitChanges();
            }
        }

        private void DeleteCompleted(object item, List<string> listElements, out string nameOfTable)
        {
            nameOfTable = GetNameOfTable(item.GetType());
            List<string> listKeys = this.GetKeyNameOfEntity(item.GetType(), ref listElements);
            object oItem = GetObjectInDatabase(listKeys, item, nameOfTable);
            if (oItem != null)
            {
                this.GetTable(item.GetType()).DeleteOnSubmit(oItem);
                this.SubmitChanges();
            }
        }

        private void UpdateCompleted(object item, List<string> listElements, out string nameOfTable)
        {
            nameOfTable = GetNameOfTable(item.GetType());
            List<string> listKeys = this.GetKeyNameOfEntity(item.GetType(), ref listElements);
            List<string> listIdentities = this.GetIdentityAndRemoveNameOfEntity(item.GetType(), ref listElements);
            object oItem = GetObjectInDatabase(listKeys, item, nameOfTable);

            foreach (string columnElement in listElements)
            {
                if (listIdentities.Contains(columnElement) || listKeys.Contains(columnElement))
                {
                    continue;
                }

                object property = item.GetType().GetProperty(columnElement).GetValue(item);
                if (property != null && !(property is string || property is DateTime || property is DateTimeOffset))
                {
                    Type type = property.GetType();
                    if (type.IsClass && type.Assembly.GetName().Name == typeof(HSMDataContext).Assembly.GetName().Name)
                    {
                        string message_extended = LinqSerializer.GetString<object>(property);
                        string tablename;

                        this.ReceiveUpdates(message_extended, out tablename);
                        continue;
                    }
                }

                oItem.GetType().GetProperty(columnElement).SetValue(oItem, property);
            }

            this.SubmitChanges();
        }
        #endregion

        #region execution secondary transaction
        private string GetInsertTransaction(List<string> listElements, object item, string nameOfTable)
        {
            string insertString = "INSERT INTO " + nameOfTable + " (";
            string valuesString = "VALUES (";

            int i = 0;
            foreach (string columnString in listElements)
            {
                if (i > 0)
                {
                    insertString += ", ";
                    valuesString += ", ";
                }

                object columnValue = item.GetType().GetField("_" + columnString, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(item);
                if (columnValue != null)
                {
                    if (columnValue is DateTime)
                    {
                        valuesString += "'" + ((DateTime)columnValue).ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
                    }
                    else if (columnValue is DateTimeOffset)
                    {
                        valuesString += "'" + ((DateTimeOffset)columnValue).ToString("yyyy-MM-dd HH:mm:ss.fff zzz") + "'";
                    }
                    else
                    {
                        valuesString += "'" + columnValue.ToString() + "'";
                    }
                }
                else
                {
                    valuesString += "NULL";
                }
                insertString += columnString;
                i++;
            }
            insertString += ")";
            valuesString += ")";

            return string.Format("{0} {1}", insertString, valuesString);
        }

        private string GetNameOfTable(Type oType)
        {
            var table = oType.GetCustomAttributes(false).FirstOrDefault(o => o.GetType() == typeof(TableAttribute));
            string name = ((TableAttribute)table).Name;
            return name;
        }

        private object GetObjectInDatabase(List<string> listKeys, object item, string nameOfTable)
        {
            string whereString = "";
            string and = " AND ";
            foreach (string columnString in listKeys)
            {
                if (listKeys.IndexOf(columnString) == (listKeys.Count - 1))
                    and = "";

                object columnValue = item.GetType().GetField(columnString, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(item);
                if (columnValue is DateTime)
                {
                    whereString += columnString.Remove(0, 1) + " = '" + ((DateTime)columnValue).ToString("yyyy-MM-dd HH:mm:ss.fff") + "'" + and;
                }
                else if (columnValue is DateTimeOffset)
                {
                    whereString += columnString.Remove(0, 1) + " = '" + ((DateTimeOffset)columnValue).ToString("yyyy-MM-dd HH:mm:ss.fff zzz") + "'" + and;
                }
                else
                {
                    whereString += columnString.Remove(0, 1) + " = '" + columnValue.ToString() + "'" + and;
                }
            }
            var result = this.ExecuteQuery(item.GetType(), string.Format("SELECT * FROM {0} WHERE {1}", nameOfTable, whereString));
            object oItem = null;
            foreach (var theObject in result)
            {
                oItem = theObject;
                break;
            }
            return oItem;
        }

        private List<string> GetKeyNameOfEntity(Type oType, ref List<string> listElements)
        {
            List<string> listKeys = new List<string>();
            foreach (PropertyInfo info in oType.GetProperties())
            {
                var column = info.GetCustomAttributes(false).Where(x => x.GetType() == typeof(ColumnAttribute))
                                                            .FirstOrDefault(x => ((ColumnAttribute)x).IsPrimaryKey);
                if (column != null)
                {
                    string nameOfTheColumn = ((ColumnAttribute)column).Storage;
                    listKeys.Add(nameOfTheColumn);
                    listElements.Remove(nameOfTheColumn.Remove(0, 1));
                }
            }
            return listKeys;
        }

        private List<string> GetIdentityNameOfEntity(object oItem)
        {
            Type oType = oItem.GetType();
            List<string> listIdentities = new List<string>();
            foreach (PropertyInfo info in oType.GetProperties())
            {
                var column = info.GetCustomAttributes(false).Where(x => x.GetType() == typeof(ColumnAttribute))
                                                                         .FirstOrDefault(x => ((ColumnAttribute)x).IsDbGenerated);
                if (column != null)
                {
                    ((ColumnAttribute)column).IsDbGenerated = false;

                    string nameOfTheColumn = ((ColumnAttribute)column).Storage;
                    listIdentities.Add(nameOfTheColumn.Remove(0, 1));
                }
            }
            return listIdentities;
        }

        private List<string> GetIdentityAndRemoveNameOfEntity(Type oType, ref List<string> listElements)
        {
            List<string> listIdentities = new List<string>();
            foreach (PropertyInfo info in oType.GetProperties())
            {
                var column = info.GetCustomAttributes(false).Where(x => x.GetType() == typeof(ColumnAttribute))
                                                            .FirstOrDefault(x => ((ColumnAttribute)x).IsDbGenerated);
                if (column != null)
                {
                    string nameOfTheColumn = ((ColumnAttribute)column).Storage;
                    listIdentities.Add(nameOfTheColumn.Remove(0, 1));
                    listElements.Remove(nameOfTheColumn.Remove(0, 1));
                }
            }
            return listIdentities;
        }
        #endregion
    }

}
