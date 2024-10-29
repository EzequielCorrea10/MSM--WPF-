using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.Utility.Common.Handlers
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.UI.Common.Helpers;

    using HSM.Database;
    using HSM.Utility.Common.Enumerations;
    using HSM.Utility.Common.Catalogs;
    using HSM.Utility.Common.Structures;
    using HSM.Utility.Configuration;
    using Janus.Rodeo.Windows.Library.UI.Common;
    using System.IO;

    /// <summary>
    /// Class to exchange information with database
    /// </summary>
    public abstract class DBAccessBase
    {
        #region private static attributes
        private static List<CT_Yard> _yards;
        #endregion

        #region protected static attributes
        /// <summary>
        /// use to lock the logical
        /// </summary>
        protected static readonly object lockInstance = new object();
        #endregion

        #region public access method
        /// <summary>
        /// Get Machines
        /// </summary>
        /// <param name="local"></param>
        public static IEnumerable<CT_Yard> GetYards(bool local = true, bool reload = false)
        {
            if (_yards == null || reload)
            {
                List<CT_Yard> yards = new List<CT_Yard>();

                if (local)
                {
                    foreach (Rodeo_Yard xmlYard in XmlDatabase.ReadXml<Rodeo_Yard>(Configurations.Catalogs.Folder).Where(p => p.Active == true))
                    {
                        yards.Add(new CT_Yard(xmlYard.IdYard, xmlYard.Name, xmlYard.FullDescription, xmlYard.X1AbsolutePos, xmlYard.X2AbsolutePos, xmlYard.Y1AbsolutePos, xmlYard.Y2AbsolutePos, xmlYard.PlcValue));
                    }

                    //List<HSM_Location_Group> location_groups = XmlDatabase.ReadXml<HSM_Location_Group>(Configurations.Catalogs.Folder).Where(p => p.Active == true).ToList();
                    //List<Rodeo_Machine_Type> machine_types = XmlDatabase.ReadXml<Rodeo_Machine_Type>(Configurations.Catalogs.Folder).Where(p => p.Active == true).ToList();

                    //Dictionary<int, List<Yard_Transfer>> yard_transfers = new Dictionary<int, List<Yard_Transfer>>();
                    //foreach (Rodeo_Yard_Transfer xmlYardTransfer in XmlDatabase.ReadXml<Rodeo_Yard_Transfer>(Configurations.Catalogs.Folder).Where(p => p.Active == true))
                    //{
                    //    CT_Yard yard_begin = yards.FirstOrDefault(p => p.Id == xmlYardTransfer.IdYardBegin);
                    //    if (yard_begin == null)
                    //    {
                    //        RdTrace.Message("Transfer is discarded because from yard {0} is not found", xmlYardTransfer.IdYardBegin);
                    //        continue;
                    //    }

                    //    CT_Yard yard_end = yards.FirstOrDefault(p => p.Id == xmlYardTransfer.IdYardEnd);
                    //    if (yard_end == null)
                    //    {
                    //        RdTrace.Message("Transfer is discarded because to yard {0} is not found", xmlYardTransfer.IdYardEnd);
                    //        continue;
                    //    }

                    //    HSM_Location_Group location_group_begin = location_groups.FirstOrDefault(p => p.IdLocationGroup == xmlYardTransfer.IdLocationGroupBegin);
                    //    if (location_group_begin == null)
                    //    {
                    //        RdTrace.Message("Transfer is discarded because from location group {0} is not found", xmlYardTransfer.IdLocationGroupBegin);
                    //        continue;
                    //    }

                    //    HSM_Location_Group location_group_end = location_groups.FirstOrDefault(p => p.IdLocationGroup == xmlYardTransfer.IdLocationGroupEnd);
                    //    if (location_group_end == null)
                    //    {
                    //        RdTrace.Message("Transfer is discarded because to location group {0} is not found", xmlYardTransfer.IdLocationGroupEnd);
                    //        continue;
                    //    }

                    //    Rodeo_Machine_Type machine_type = machine_types.FirstOrDefault(p => p.IdMachineType == xmlYardTransfer.IdMachineType);
                    //    if (machine_type == null)
                    //    {
                    //        RdTrace.Message("Machine Type {0} is not active", xmlYardTransfer.IdMachineType);
                    //        continue;
                    //    }

                    //    if (!yard_transfers.ContainsKey(xmlYardTransfer.IdYardBegin))
                    //    {
                    //        yard_transfers.Add(xmlYardTransfer.IdYardBegin, new List<Yard_Transfer>());
                    //    }

                    //    yard_transfers[xmlYardTransfer.IdYardBegin].Add(new Yard_Transfer(yard_begin, yard_end, location_group_begin.Name, location_group_end.Name, machine_type.Name));

                    //    yard_begin.YardTransfers = yard_transfers[xmlYardTransfer.IdYardBegin].ToArray();
                    //}
                }
                else
                {
                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        DataLoadOptions dlo = new DataLoadOptions();
                        //dlo.LoadWith<Rodeo_Yard>(p => p.Rodeo_Yard_Transfers_Begin);
                        //dlo.LoadWith<Rodeo_Yard>(p => p.Rodeo_Yard_Transfers_End);
                        //dlo.LoadWith<Rodeo_Yard_Transfer>(p => p.HSM_Location_Group_Begin);
                        //dlo.LoadWith<Rodeo_Yard_Transfer>(p => p.HSM_Location_Group_End);
                        //dlo.LoadWith<Rodeo_Yard_Transfer>(p => p.Rodeo_Machine_Type);
                        DB.LoadOptions = dlo;
                        DB.DeferredLoadingEnabled = false;

                        foreach (Rodeo_Yard yard in DB.Rodeo_Yards.Where(p => p.Active == true))
                        {
                            yards.Add(new CT_Yard(yard.IdYard, yard.Name, yard.FullDescription, yard.X1AbsolutePos, yard.X2AbsolutePos, yard.Y1AbsolutePos, yard.Y2AbsolutePos, yard.PlcValue));
                        }

                        //Dictionary<int, List<Yard_Transfer>> yard_transfers = new Dictionary<int, List<Yard_Transfer>>();
                        //foreach (Rodeo_Yard_Transfer yard_transfer in DB.Rodeo_Yard_Transfers.Where(p => p.Active == true))
                        //{
                        //    CT_Yard yard_begin = yards.FirstOrDefault(p => p.Id == yard_transfer.IdYardBegin);
                        //    if (yard_begin == null)
                        //    {
                        //        RdTrace.Message("Transfer is discarded because from yard {0} is not found", yard_transfer.IdYardBegin);
                        //        continue;
                        //    }

                        //    CT_Yard yard_end = yards.FirstOrDefault(p => p.Id == yard_transfer.IdYardEnd);
                        //    if (yard_end == null)
                        //    {
                        //        RdTrace.Message("Transfer is discarded because to yard {0} is not found", yard_transfer.IdYardEnd);
                        //        continue;
                        //    }

                        //    if (!yard_transfers.ContainsKey(yard_transfer.IdYardBegin))
                        //    {
                        //        yard_transfers.Add(yard_transfer.IdYardBegin, new List<Yard_Transfer>());
                        //    }

                        //    yard_transfers[yard_transfer.IdYardBegin].Add(new Yard_Transfer(yard_begin, yard_end, yard_transfer.HSM_Location_Group_Begin.Name, yard_transfer.HSM_Location_Group_End.Name, yard_transfer.Rodeo_Machine_Type.Name));

                        //    yard_begin.YardTransfers = yard_transfers[yard_transfer.IdYardBegin].ToArray();
                        //}
                    }
                }

                return (_yards = yards);
            }
            else
                return _yards;
        }
        #endregion

        #region public events method
        /// <summary>
        /// Insert Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="clientname"></param>
        /// <param name="username"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        public static void InsertEvents(string event_type, string clientname, string username, string data, DateTimeOffset event_time)
        {
            InsertEvents(event_type, clientname, username, data, event_time, null, null, null, string.Empty, string.Empty, string.Empty);
        }

        /// <summary>
        /// Insert Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="clientname"></param>
        /// <param name="username"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        /// <param name="id_job"></param>
        /// <param name="id_transport_order"></param>
        /// <param name="step"></param>
        /// <param name="piecename"></param>
        /// <param name="locationname"></param>
        /// <param name="machinename"></param>
        public static async void InsertEvents(string event_type, string clientname, string username, string data, DateTimeOffset event_time,
                                              long? id_job, long? id_transport_order, short? step, string piecename, string locationname, string machinename)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (string.IsNullOrEmpty(username) || username == HSM.Utility.Common.Constants.Configuration.SYSTEM_USERNAME)
                    {
                        RdTrace.Message("Event Type {0} was not registered, Client={1}, User={2}, Data={3}", event_type, clientname, username, data);
                        return;
                    }

                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        Rodeo_Event_Type dbEventType = DB.Rodeo_Event_Types.FirstOrDefault(p => p.Name == event_type);
                        if (dbEventType == null)
                        {
                            RdTrace.Message("Event Type {0} was not found, Client={1}, User={2}, Data={3}", event_type, clientname, username, data);
                            return;
                        }

                        Rodeo_Event dbEvent = new Rodeo_Event();
                        dbEvent.IdEventType = dbEventType.IdEventType;

                        if (!string.IsNullOrEmpty(clientname))
                        {
                            Rodeo_Client dbRodeoClient = DB.Rodeo_Clients.FirstOrDefault(p => p.Name == clientname);
                            if (dbRodeoClient == null)
                            {
                                RdTrace.Message("Client {0} was not found, Event type={1}, User={2}, Data={3}", clientname, event_type, username, data);
                            }
                            else
                            {
                                dbEvent.IdClient = dbRodeoClient.IdClient;
                            }
                        }

                        if (!string.IsNullOrEmpty(username))
                        {
                            dbEvent.UsernameExecute = username;
                        }

                        dbEvent.Data = data;
                        dbEvent.EventTime = event_time;
                        dbEvent.InsDateTime = DateTimeOffset.Now;

                        if (id_job != null)
                        {
                            dbEvent.IdJob = id_job;
                        }

                        if (id_transport_order != null)
                        {
                            dbEvent.IdTransportOrder = id_transport_order;
                        }

                        if (step != null)
                        {
                            dbEvent.Step = step;
                        }

                        if (!string.IsNullOrEmpty(piecename))
                        {
                            dbEvent.PieceName = piecename;
                        }

                        if (!string.IsNullOrEmpty(locationname))
                        {
                            dbEvent.LocationName = locationname;
                        }

                        if (!string.IsNullOrEmpty(machinename))
                        {
                            dbEvent.MachineName = machinename;
                        }

                        DB.Rodeo_Events.InsertOnSubmit(dbEvent);
                        DB.SubmitChanges(Configurations.General.ReplicationQueue);
                    }
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        /// <summary>
        /// Insert Zone Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="id_zone"></param>
        /// <param name="request_value"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        public static async void InsertZoneEvents(string event_type, int id_zone, int request_value, string data, DateTimeOffset event_time)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        HSM_Zone_Event_Type dbZoneEventType = DB.HSM_Zone_Event_Types.FirstOrDefault(p => p.Name == event_type);
                        if (dbZoneEventType == null)
                        {
                            RdTrace.Message("Event Type {0} was not found, idZone={1}, Request Value={2}, Data={3}", event_type, id_zone, request_value, data);
                            return;
                        }

                        HSM_Zone_Event dbZoneEvent = new HSM_Zone_Event();
                        dbZoneEvent.IdZoneEventType = dbZoneEventType.IdZoneEventType;
                        dbZoneEvent.IdZone = id_zone;

                        HSM_Request dbRequest = DB.HSM_Requests.FirstOrDefault(p => p.PlcValue == request_value);
                        if (dbRequest == null)
                        {
                            RdTrace.Message("Request Value {0} was not found, Event type={1}, idZone={2}, Data={3}", request_value, event_type, id_zone, data);
                        }
                        else
                        {
                            dbZoneEvent.IdRequest = dbRequest.IdRequest;
                        }

                        dbZoneEvent.Data = data;
                        dbZoneEvent.EventTime = event_time;
                        dbZoneEvent.InsDateTime = DateTimeOffset.Now;

                        DB.HSM_Zone_Events.InsertOnSubmit(dbZoneEvent);
                        DB.SubmitChanges(Configurations.General.ReplicationQueue);
                    }
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        /// <summary>
        /// Insert Zone Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="zonename"></param>
        /// <param name="request_value"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        public static async void InsertZoneEvents(string event_type, string zonename, int request_value, string data, DateTimeOffset event_time)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        HSM_Zone_Event_Type dbZoneEventType = DB.HSM_Zone_Event_Types.FirstOrDefault(p => p.Name == event_type);
                        if (dbZoneEventType == null)
                        {
                            RdTrace.Message("Event Type {0} was not found, Zone={1}, Request Value={2}, Data={3}", event_type, zonename, request_value, data);
                            return;
                        }

                        HSM_Zone_Event dbZoneEvent = new HSM_Zone_Event();
                        dbZoneEvent.IdZoneEventType = dbZoneEventType.IdZoneEventType;

                        HSM_Zone dbZone = DB.HSM_Zones.FirstOrDefault(p => p.Name == zonename);
                        if (dbZone == null)
                        {
                            RdTrace.Message("Zone {0} was not found, Event Type={1}, Request Value={2}, Data={3}", zonename, event_type, request_value, data);
                            return;
                        }
                        dbZoneEvent.IdZone = dbZone.IdZone;

                        HSM_Request dbRequest = DB.HSM_Requests.FirstOrDefault(p => p.PlcValue == request_value);
                        if (dbRequest == null)
                        {
                            RdTrace.Message("Request Value {0} was not found, Event type={1}, Zone={2}, Data={3}", request_value, event_type, zonename, data);
                        }
                        else
                        {
                            dbZoneEvent.IdRequest = dbRequest.IdRequest;
                        }

                        dbZoneEvent.Data = data;
                        dbZoneEvent.EventTime = event_time;
                        dbZoneEvent.InsDateTime = DateTimeOffset.Now;

                        DB.HSM_Zone_Events.InsertOnSubmit(dbZoneEvent);
                        DB.SubmitChanges(Configurations.General.ReplicationQueue);
                    }
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        /// <summary>
        /// Insert Zone Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="id_zone"></param>
        /// <param name="id_request"></param>
        /// <param name="clientname"></param>
        /// <param name="username"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        public static async void InsertZoneEvents(string event_type, int id_zone, int? id_request, string clientname, string username, string data, DateTimeOffset event_time)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        HSM_Zone_Event_Type dbZoneEventType = DB.HSM_Zone_Event_Types.FirstOrDefault(p => p.Name == event_type);
                        if (dbZoneEventType == null)
                        {
                            RdTrace.Message("Event Type {0} was not found, idZone={1}, idRequest={2}, Data={3}", event_type, id_zone, id_request, data);
                            return;
                        }

                        HSM_Zone_Event dbZoneEvent = new HSM_Zone_Event();
                        dbZoneEvent.IdZoneEventType = dbZoneEventType.IdZoneEventType;
                        dbZoneEvent.IdZone = id_zone;

                        if (id_request != null)
                        {
                            dbZoneEvent.IdRequest = id_request;
                        }

                        if (!string.IsNullOrEmpty(clientname))
                        {
                            Rodeo_Client dbRodeoClient = DB.Rodeo_Clients.FirstOrDefault(p => p.Name == clientname);
                            if (dbRodeoClient == null)
                            {
                                RdTrace.Message("Client {0} was not found", clientname);
                            }
                            else
                            {
                                dbZoneEvent.IdClient = dbRodeoClient.IdClient;
                            }
                        }

                        if (!string.IsNullOrEmpty(username))
                        {
                            dbZoneEvent.UsernameExecute = username;
                        }

                        dbZoneEvent.Data = data;
                        dbZoneEvent.EventTime = event_time;
                        dbZoneEvent.InsDateTime = DateTimeOffset.Now;

                        DB.HSM_Zone_Events.InsertOnSubmit(dbZoneEvent);
                        DB.SubmitChanges(Configurations.General.ReplicationQueue);
                    }
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        /// <summary>
        /// Insert Zone Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="zonename"></param>
        /// <param name="id_request"></param>
        /// <param name="clientname"></param>
        /// <param name="username"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        public static async void InsertZoneEvents(string event_type, string zonename, int? id_request, string clientname, string username, string data, DateTimeOffset event_time)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        HSM_Zone_Event_Type dbZoneEventType = DB.HSM_Zone_Event_Types.FirstOrDefault(p => p.Name == event_type);
                        if (dbZoneEventType == null)
                        {
                            RdTrace.Message("Event Type {0} was not found, Zone={1}, idRequest={2}, Data={3}", event_type, zonename, id_request, data);
                            return;
                        }

                        HSM_Zone_Event dbZoneEvent = new HSM_Zone_Event();
                        dbZoneEvent.IdZoneEventType = dbZoneEventType.IdZoneEventType;

                        HSM_Zone dbZone = DB.HSM_Zones.FirstOrDefault(p => p.Name == zonename);
                        if (dbZone == null)
                        {
                            RdTrace.Message("Zone {0} was not found, Event Type={1}, idRequest={2}, Data={3}", zonename, event_type, id_request, data);
                            return;
                        }
                        dbZoneEvent.IdZone = dbZone.IdZone;

                        if (id_request != null)
                        {
                            dbZoneEvent.IdRequest = id_request;
                        }

                        if (!string.IsNullOrEmpty(clientname))
                        {
                            Rodeo_Client dbRodeoClient = DB.Rodeo_Clients.FirstOrDefault(p => p.Name == clientname);
                            if (dbRodeoClient == null)
                            {
                                RdTrace.Message("Client {0} was not found, Event Type={1}, idRequest={2}, Data={3}", zonename, event_type, id_request, data);
                            }
                            else
                            {
                                dbZoneEvent.IdClient = dbRodeoClient.IdClient;
                            }
                        }

                        if (!string.IsNullOrEmpty(username))
                        {
                            dbZoneEvent.UsernameExecute = username;
                        }

                        dbZoneEvent.Data = data;
                        dbZoneEvent.EventTime = event_time;
                        dbZoneEvent.InsDateTime = DateTimeOffset.Now;

                        DB.HSM_Zone_Events.InsertOnSubmit(dbZoneEvent);
                        DB.SubmitChanges(Configurations.General.ReplicationQueue);
                    }
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        /// <summary>
        /// Insert Piece Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="piecename"></param>
        /// <param name="id_machine"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        public static async void InsertPieceEvents(string event_type, string piecename, int? id_machine, string data, DateTimeOffset event_time)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        HSM_Piece_Event_Type dbPieceEventType = DB.HSM_Piece_Event_Types.FirstOrDefault(p => p.Name == event_type);
                        if (dbPieceEventType == null)
                        {
                            RdTrace.Message("Event Type {0} was not found, Ingot={1}, idMachine={2}, Data={3}", event_type, piecename, id_machine, data);
                            return;
                        }

                        Rodeo_Piece dbPiece = DB.Rodeo_Pieces.FirstOrDefault(p => p.PieceName == piecename);
                        if (dbPiece == null)
                        {
                            RdTrace.Message("Ingot {0} was not found, Event Type={1}, idMachine={2}, Data={3}", piecename, event_type, id_machine, data);
                            return;
                        }

                        HSM_Piece_Event dbPieceEvent = new HSM_Piece_Event();
                        dbPieceEvent.PieceName = piecename;
                        dbPieceEvent.IdPieceEventType = dbPieceEventType.IdPieceEventType;

                        if (id_machine != null)
                        {
                            dbPieceEvent.IdMachine = id_machine;
                        }

                        dbPieceEvent.Data = data;
                        dbPieceEvent.EventTime = event_time;
                        dbPieceEvent.InsDateTime = DateTimeOffset.Now;

                        DB.HSM_Piece_Events.InsertOnSubmit(dbPieceEvent);
                        DB.SubmitChanges(Configurations.General.ReplicationQueue);
                    }
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        /// <summary>
        /// Insert Machine Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="id_machine"></param>
        /// <param name="piecename"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        public static async void InsertMachineEvents(string event_type, int id_machine, string piecename, string data, DateTimeOffset event_time)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        HSM_Machine_Event_Type dbMachineEventType = DB.HSM_Machine_Event_Types.FirstOrDefault(p => p.Name == event_type);
                        if (dbMachineEventType == null)
                        {
                            RdTrace.Message("Event Type {0} was not found, idMachine={1}, Ingot={2}, Data={3}", event_type, id_machine, piecename, data);
                            return;
                        }

                        HSM_Machine_Event dbMachineEvent = new HSM_Machine_Event();
                        dbMachineEvent.IdMachineEventType = dbMachineEventType.IdMachineEventType;
                        dbMachineEvent.IdMachine = id_machine;

                        if (!string.IsNullOrEmpty(piecename))
                        {
                            Rodeo_Piece dbPiece = DB.Rodeo_Pieces.FirstOrDefault(p => p.PieceName == piecename);
                            if (dbPiece == null)
                            {
                                RdTrace.Message("Ingot {0} was not found, Event Type={1}, idMachine={2}, Data={3}", piecename, event_type, id_machine, data);
                            }
                            else
                            {
                                dbMachineEvent.PieceName = piecename;
                            }

                        }

                        dbMachineEvent.Data = data;
                        dbMachineEvent.EventTime = event_time;
                        dbMachineEvent.InsDateTime = DateTimeOffset.Now;

                        DB.HSM_Machine_Events.InsertOnSubmit(dbMachineEvent);
                        DB.SubmitChanges(Configurations.General.ReplicationQueue);
                    }
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        /// <summary>
        /// Insert Machine Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="machinename"></param>
        /// <param name="piecename"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        public static async void InsertMachineEvents(string event_type, string machinename, string piecename, string data, DateTimeOffset event_time)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        HSM_Machine_Event_Type dbMachineEventType = DB.HSM_Machine_Event_Types.FirstOrDefault(p => p.Name == event_type);
                        if (dbMachineEventType == null)
                        {
                            RdTrace.Message("Event Type {0} was not found, Machine={1}, Ingot={2}, Data={3}", event_type, machinename, piecename, data);
                            return;
                        }

                        HSM_Machine_Event dbMachineEvent = new HSM_Machine_Event();
                        dbMachineEvent.IdMachineEventType = dbMachineEventType.IdMachineEventType;

                        Rodeo_Machine dbMachine = DB.Rodeo_Machines.FirstOrDefault(p => p.Name == machinename);
                        if (dbMachine == null)
                        {
                            RdTrace.Message("Machine {0} was not found, Event Type={1}, Ingot={2}, Data={3}", machinename, event_type, piecename, data);
                            return;
                        }

                        dbMachineEvent.IdMachine = dbMachine.IdMachine;

                        if (!string.IsNullOrEmpty(piecename))
                        {
                            Rodeo_Piece dbPiece = DB.Rodeo_Pieces.FirstOrDefault(p => p.PieceName == piecename);
                            if (dbPiece == null)
                            {
                                RdTrace.Message("Ingot {0} was not found, Event Type={1}, Machine={2}, Data={3}", piecename, event_type, machinename, data);
                            }
                            else
                            {
                                dbMachineEvent.PieceName = piecename;
                            }
                        }

                        dbMachineEvent.Data = data;
                        dbMachineEvent.EventTime = event_time;
                        dbMachineEvent.InsDateTime = DateTimeOffset.Now;

                        DB.HSM_Machine_Events.InsertOnSubmit(dbMachineEvent);
                        DB.SubmitChanges(Configurations.General.ReplicationQueue);
                    }
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        /// <summary>
        /// Insert Rail Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="rail_car_name"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        public static async void InsertRailEvents(string event_type, string rail_car_name, string data, DateTimeOffset event_time)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        /*HSM_Rail_Event_Type dbRailEventType = DB.HSM_Rail_Event_Types.FirstOrDefault(p => p.Name == event_type);
                        if (dbRailEventType == null)
                        {
                            RdTrace.Message("Event Type {0} was not found, Rail Car={1}, Data={2}", event_type, rail_car_name, data);
                            return;
                        }

                        HSM_Rail_Event dbRailEvent = new HSM_Rail_Event();
                        dbRailEvent.IdRailEventType = dbRailEventType.IdRailEventType;

                        if (!string.IsNullOrEmpty(rail_car_name))
                        {
                            dbRailEvent.RailCarID = rail_car_name;
                        }

                        dbRailEvent.Data = data;
                        dbRailEvent.EventTime = event_time;
                        dbRailEvent.InsDateTime = DateTimeOffset.Now;

                        DB.HSM_Rail_Events.InsertOnSubmit(dbRailEvent);
                        DB.SubmitChanges(Configurations.General.ReplicationQueue);*/
                    }
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        /// <summary>
        /// Insert Truck Events
        /// </summary>
        /// <param name="event_type"></param>
        /// <param name="id_location"></param>
        /// <param name="truck_name"></param>
        /// <param name="data"></param>
        /// <param name="event_time"></param>
        public static async void InsertTruckEvents(string event_type, int id_location, string truck_name, string data, DateTimeOffset event_time)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
                    {
                        /*   HSM_Truck_Event_Type dbTruckEventType = DB.HSM_Truck_Event_Types.FirstOrDefault(p => p.Name == event_type);
                           if (dbTruckEventType == null)
                           {
                               RdTrace.Message("Event Type {0} was not found, Location={1}, Truck={2}, Data={3}", event_type, id_location, truck_name, data);
                               return;
                           }

                           MSS_Truck_Event dbTruckEvent = new HSM_Truck_Event();
                           dbTruckEvent.IdTruckEventType = dbTruckEventType.IdTruckEventType;
                           dbTruckEvent.IdLocation = id_location;

                           if (!string.IsNullOrEmpty(truck_name))
                           {
                               dbTruckEvent.TruckID = truck_name;
                           }

                           dbTruckEvent.Data = data;
                           dbTruckEvent.EventTime = event_time;
                           dbTruckEvent.InsDateTime = DateTimeOffset.Now;

                           DB.HSM_Truck_Events.InsertOnSubmit(dbTruckEvent);
                           DB.SubmitChanges(Configurations.General.ReplicationQueue);*/
                    }
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }
        #endregion

        #region public methods
        /// <summary>
        /// Adjust the value of angle to theorical value
        /// </summary>
        /// <param name="angle"></param>
        public static void AdjustAngle(ref int angle)
        {
            if (angle < 0)
            {
                if (angle <= -360)
                {
                    angle %= 360;
                }
                angle += 360;
            }
            else if (angle >= 360)
            {
                angle %= 360;
            }
        }

        /// <summary>
        /// Get Theorical Angle
        /// </summary>
        /// <param name="real_angle"></param>
        /// <returns></returns>
        public static int GetTheoricalAngle(int real_angle)
        {
            AdjustAngle(ref real_angle);

            if (real_angle < 45)
            {
                return 0;
            }
            else if (real_angle < 135)
            {
                return 90;
            }
            else if (real_angle < 225)
            {
                return 180;
            }
            else if (real_angle < 315)
            {
                return 270;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region protected methods
        /// <summary>
        /// Get the catalog folder
        /// </summary>
        /// <returns></returns>
        protected string GetCatalogFolder()
        {
            //string value;
            //if (!RodeoHandler.Tag.GetText(string.Format(HSM.Utility.Common.Constants.TagNames.CRANE_NAME, Configurations.General.RodeoSector), out value))
            //{
            //    throw new Exception("Crane name tag does not exist");
            //}

            return Configurations.Catalogs.Folder;
        }

        /// <summary>
        /// CleanInvalidXmlChars
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected string CleanInvalidXmlChars(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                // From xml spec valid chars: 
                // #x9 | #xA | #xD | [#x20-#xD7FF] | [#xE000-#xFFFD] | [#x10000-#x10FFFF]     
                // any Unicode character, excluding the surrogate blocks, FFFE, and FFFF. 
                string re = @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]";
                return System.Text.RegularExpressions.Regex.Replace(text, re, " ");
            }
            return text;
        }
        #endregion
    }
}
