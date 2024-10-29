using TagLoader.Clases;
//using TagLoader.Handlers;
using Janus.Rodeo.Windows.Library.Rd_Common;
using Janus.Rodeo.Windows.Library.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSM.Database;
using TagLoader.Handlers;

namespace TagLoader.ViewModels
{
    public class CT_StatusAlarm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CT_User
    {
        public Rodeo_Client Client { get; set; }
        //public string Client { get; set; }
        public RUMSession User { get; set; }
        public string UserName { get; set; }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        #region properties

        private AlarmCreatorHelper _alarmHelper;

        private List<RodeoAlarm> lstAlarms;
        public List<RodeoAlarm> LstAlarms
        {
            get { return lstAlarms; }
            set
            {
                lstAlarms = value;
                OnPropertyChanged("LstAlarms");
                OnPropertyChanged("InfoCountAlarms");
            }
        }

        private List<RodeoAlarm> lstFilterAlarms;
        public List<RodeoAlarm> LstFilterAlarms
        {
            get { return lstFilterAlarms; }
            set
            {
                lstFilterAlarms = value;
                OnPropertyChanged("LstFilterAlarms");
                OnPropertyChanged("InfoCountAlarms");
            }
        }

        private List<RodeoTag> lstTags;
        public List<RodeoTag> LstTags
        {
            get { return lstTags; }
            set
            {
                lstTags = value;
                OnPropertyChanged("LstTags");
                OnPropertyChanged("InfoCountTags");
            }
        }

        private List<RodeoTag> lstFilterTags;
        public List<RodeoTag> LstFilterTags
        {
            get { return lstFilterTags; }
            set
            {
                lstFilterTags = value;
                OnPropertyChanged("LstFilterTags");
                OnPropertyChanged("InfoCountTags");
            }
        }

        private RodeoTag currentTag;
        public RodeoTag CurrentTag
        {
            get { return currentTag; }
            set
            {
                if (currentTag != value)
                {
                    currentTag = value;
                    OnPropertyChanged("CurrentTag");
                    if (currentTag != null)
                    {
                        NewValue = currentTag.TagValue;
                        OnPropertyChanged("NewValue");
                    }
                }
            }
        }

        private RodeoAlarm currentAlarm;
        public RodeoAlarm CurrentAlarm
        {
            get { return currentAlarm; }
            set
            {
                if (currentAlarm != value)
                {
                    currentAlarm = value;
                    OnPropertyChanged("CurrentAlarm");
                    if (currentAlarm != null)
                    {
                        if (this.LstStatusAlarms.Any())
                        {
                            CurrentStatusAlarm = this.lstStatusAlarms.FirstOrDefault(p => p.Name == currentAlarm.AlarmState);
                            OnPropertyChanged("CurrentStatusAlarm");
                        }

                    }
                }
            }
        }

        private CT_StatusAlarm currentStatusAlarm;
        public CT_StatusAlarm CurrentStatusAlarm
        {
            get { return currentStatusAlarm; }
            set
            {
                if (currentStatusAlarm != value)
                {
                    currentStatusAlarm = value;
                    OnPropertyChanged("CurrentStatusAlarm");
                }
            }
        }

        private List<CT_StatusAlarm> lstStatusAlarms = new List<CT_StatusAlarm>();
        public List<CT_StatusAlarm> LstStatusAlarms
        {
            get { return lstStatusAlarms; }
            set
            {
                if (lstStatusAlarms != value)
                {
                    lstStatusAlarms = value;
                    OnPropertyChanged("LstStatusAlarms");
                }
            }
        }

        public string InfoCountTags
        {
            get
            {
                string info = "";
                if (this.LstTags != null)
                {
                    info = string.Format("Tags {0} of {1}", (this.LstFilterTags != null) ? this.LstFilterTags.Count() : 0, this.LstTags.Count());
                }

                return info;
            }
        }

        public string InfoCountAlarms
        {
            get
            {
                string info = "";
                if (this.LstAlarms != null)
                {
                    info = string.Format("Alarms {0} of {1}", (this.LstFilterAlarms != null) ? this.LstFilterAlarms.Count() : 0, this.LstAlarms.Count());
                }

                return info;
            }
        }

        private string txtFilter = string.Empty;
        public string TxtFilter
        {
            get { return txtFilter; }
            set
            {

                if (txtFilter != value)
                {
                    txtFilter = value;
                    OnPropertyChanged("TxtFilter");

                    if (this.UpdateWhileType)
                    {
                        this.FilterTags();
                    }
                }


            }
        }

        //private string txtFilter2 = string.Empty;
        //public string TxtFilter2
        //{
        //    get { return txtFilter2; }
        //    set
        //    {

        //        if (txtFilter2 != value)
        //        {
        //            txtFilter2 = value;
        //            OnPropertyChanged("TxtFilter2");

        //            if (this.UpdateWhileType)
        //            {
        //                this.FilterTags();
        //            }
        //        }


        //    }
        //}

        //private object cmbFilter = 1;
        //public object CmbFilter
        //{
        //    get { return cmbFilter; }
        //    set
        //    {

        //        if (cmbFilter != value)
        //        {
        //            cmbFilter = value;
        //            OnPropertyChanged("CmbFilter");

        //            if (this.UpdateWhileType)
        //            {
        //                this.FilterTags();
        //            }
        //        }


        //    }
        //}
        

        private string txtFilterAlarm = string.Empty;
        public string TxtFilterAlarm
        {
            get { return txtFilterAlarm; }
            set
            {

                if (txtFilterAlarm != value)
                {
                    txtFilterAlarm = value;
                    OnPropertyChanged("TxtFilterAlarm");

                    if (this.UpdateWhileTypeAlarm)
                    {
                        this.FilterAlarms();
                    }
                }


            }
        }

        private bool updateWhileType = true;
        public bool UpdateWhileType
        {
            get { return updateWhileType; }
            set
            {
                updateWhileType = value;
                OnPropertyChanged("UpdateWhileType");
            }
        }

        private bool updateWhileTypeAlarm = true;
        public bool UpdateWhileTypeAlarm
        {
            get { return updateWhileTypeAlarm; }
            set
            {
                updateWhileTypeAlarm = value;
                OnPropertyChanged("UpdateWhileTypeAlarm");
            }
        }

        private string newValue = string.Empty;
        public string NewValue
        {
            get { return newValue; }
            set
            {
                newValue = value;
                OnPropertyChanged("NewValue");
            }
        }

        private bool valueAsText = false;
        public bool ValueAsText
        {
            get { return valueAsText; }
            set
            {
                valueAsText = value;
                OnPropertyChanged("ValueAsText");
            }
        }

        private List<Rodeo_Client_Type> lstClientTypes;
        public List<Rodeo_Client_Type> LstClientTypes
        {
            get { return lstClientTypes; }
            set
            {
                lstClientTypes = value;
                OnPropertyChanged("LstClientTypes");
            }
        }

        private List<Rodeo_Client> lstClients;
        public List<Rodeo_Client> LstClients
        {
            get { return lstClients; }
            set
            {
                lstClients = value;
                OnPropertyChanged("LstClients");
            }
        }

        private List<CT_User> lstUsers;
        public List<CT_User> LstUsers
        {
            get { return lstUsers; }
            set
            {
                lstUsers = value;
                OnPropertyChanged("LstUsers");
            }
        }

        private Rodeo_Client_Type currentClientType;
        public Rodeo_Client_Type CurrentClientType
        {
            get { return currentClientType; }
            set
            {
                if (currentClientType != value)
                {
                    currentClientType = value;
                    OnPropertyChanged("CurrentClientType");

                    if (currentClientType != null)
                    {
                        this.LstClients = DBAccess.Catalogs._clients.Values.Where(c => c.IdClientType == currentClientType.IdClientType).ToList();

                        if (this.CurrentUser != null)
                        {
                            this.CurrentClient = this.LstClients.FirstOrDefault(c => c.IdClient == this.CurrentUser.Client.IdClient);
                            OnPropertyChanged("CurrentClient");
                        }
                    }
                    else
                    {
                        this.LstClients = new List<Rodeo_Client>();
                    }
                    OnPropertyChanged("LstClients");
                }
            }
        }

        private Rodeo_Client currentClient;
        public Rodeo_Client CurrentClient
        {
            get { return currentClient; }
            set
            {
                currentClient = value;
                OnPropertyChanged("CurrentClient");

            }
        }

        private CT_User currentUser;
        public CT_User CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser != value)
                {
                    currentUser = value;
                    OnPropertyChanged("CurrentUser");
                    if (currentUser != null)
                    {
                        this.UserName = currentUser.UserName;
                        //this.CurrentClientType = this.LstClientTypes.FirstOrDefault(c => c.IdClientType == currentUser.Client.IdClientType);
                        OnPropertyChanged("CurrentClientType");
                    }

                }
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string client;
        public string Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged("Password");
            }
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            this._alarmHelper = new AlarmCreatorHelper();

            this.LoadData();
        }
        #endregion

        #region private Methods
        private void LoadData()
        {
            DBAccess.LoadCatalogs();

            this.LstStatusAlarms.Add(new CT_StatusAlarm { Id = 1, Name = "NOT ACTIVE" });
            this.LstStatusAlarms.Add(new CT_StatusAlarm { Id = 2, Name = "ACTIVE / NOT ACK" });
            this.LstStatusAlarms.Add(new CT_StatusAlarm { Id = 4, Name = "ACTIVE / ACK" });
            this.LstStatusAlarms.Add(new CT_StatusAlarm { Id = 8, Name = "NOT ACTIVE / NOT ACK" });
            this.LstStatusAlarms.Add(new CT_StatusAlarm { Id = 16, Name = "RESET MAINT NOT ACTIVE" });
            this.LstStatusAlarms.Add(new CT_StatusAlarm { Id = 32, Name = "RESET MAINT ACTIVE" });
            this.LstStatusAlarms.Add(new CT_StatusAlarm { Id = 64, Name = "QUARANTINE ACTIVE" });
            this.LstStatusAlarms.Add(new CT_StatusAlarm { Id = 128, Name = "QUARANTINE NOT ACTIVE" });

            this.LstClientTypes = DBAccess.Catalogs._client_types.Values.ToList();

            if (this.LstClientTypes.Any())
                this.CurrentClientType = this.LstClientTypes.FirstOrDefault();

            this.GetAllSessions();
        }

        private void FilterTags()
        {
            if (this.LstTags == null)
                this.LstTags = new List<RodeoTag>();

            if (this.LstFilterTags == null)
                this.LstFilterTags = new List<RodeoTag>();

            string _filter = this.TxtFilter.ToUpper();
            string _txtFilter = string.Empty;
            string _txtFilter2 = string.Empty;
            if (this.TxtFilter.Contains("&&"))
            {
                _filter = _filter.Replace("&&", "&");
                _txtFilter = _filter.Split('&')[0].Trim();
                _txtFilter2 = _filter.Split('&')[1].Trim();

                this.LstFilterTags = this.LstTags.Where(t => t.TagName.ToUpper().Contains(_txtFilter) && t.TagName.ToUpper().Contains(_txtFilter2)).ToList();
            }
            else if (this.TxtFilter.Contains("||"))
            {
                _filter = _filter.Replace("||", "|");
                _txtFilter = _filter.Split('|')[0].Trim();
                _txtFilter2 = _filter.Split('|')[1].Trim();

                this.LstFilterTags = this.LstTags.Where(t => t.TagName.ToUpper().Contains(_txtFilter) || t.TagName.ToUpper().Contains(_txtFilter2)).ToList();
            }
            else
            {
                this.LstFilterTags = this.LstTags.Where(t => t.TagName.ToUpper().Contains(_filter)).ToList();
            }

            if (LstFilterTags.Any())
            {
                CurrentTag = LstFilterTags.FirstOrDefault();
            }
        }

        private void FilterAlarms()
        {
            if (this.LstAlarms == null)
                this.LstAlarms = new List<RodeoAlarm>();

            if (this.LstFilterAlarms == null)
                this.LstFilterAlarms = new List<RodeoAlarm>();

            this.LstFilterAlarms = this.LstAlarms.Where(t => t.AlarmName.ToUpper().Contains(this.TxtFilterAlarm.ToUpper())).ToList();

            if (LstFilterAlarms.Any())
            {
                CurrentAlarm = LstFilterAlarms.FirstOrDefault();
            }
        }

        private void LoadTagsFromRodeo()
        {
            List<RTSInfoTag> tagList = RodeoHandler.Tag.Handler.RtServer_GetTags(Properties.Settings.Default.RodeoSector);
            List<RTSInfoTag> SortedList = tagList.OrderBy(o => o.tag).ToList();
            //Get each tag value            

            LstTags = new List<RodeoTag>();

            for (int i = 0; i < SortedList.Count; i++)
            {
                RodeoTag thisTag = new RodeoTag();
                string tagname;
                char type;

                var tagname1 = SortedList[i].tag;
                tagname = tagname1.Replace("\0", "");
                type = GetRdType(SortedList[i].dataType);

                if (type == Rd_GeneralConstant.RdRTD_STRING)
                {

                    string val;
                    string val2;
                    RodeoHandler.Tag.GetText(tagname, out val2);
                    val = val2.Replace("\0", "");
                    thisTag.TagName = tagname;
                    thisTag.TagValue = val.ToString();
                    thisTag.TagLength = tagname.Length;
                }
                else if (type == Rd_GeneralConstant.RdRTD_RAW)
                {
                    byte[] val;
                    RodeoHandler.Tag.GetByte(tagname, out val);
                    thisTag.TagName = tagname;
                    thisTag.TagValue = string.Join(":", val);
                    thisTag.TagLength = tagname.Length;
                }
                else
                {
                    double val;
                    RodeoHandler.Tag.GetNumeric(tagname, out val);
                    thisTag.TagName = tagname;
                    thisTag.TagValue = val.ToString();
                    thisTag.TagLength = tagname.Length;
                }

                //if (tagname.Length > 59) { MessageBox.Show("Mas de 60!!!"); }
                LstTags.Add(thisTag);
            }

            //if (LstTags.Any())
            //{
            //    CurrentTag = LstTags.FirstOrDefault();
            //}
        }

        private char GetRdType(char ltype)
        {
            char val = 'E';

            switch (ltype)
            {
                //PREGUNTAR
                case 'r':
                    val = (char)Rd_GeneralConstant.RdRTD_REAL;
                    break;
                case 'R':
                    val = (char)Rd_GeneralConstant.RdRTD_DREAL;
                    break;
                case 'B':
                    val = (char)Rd_GeneralConstant.RdRTD_BIT;
                    break;
                case 'I':
                    val = (char)Rd_GeneralConstant.RdRTD_INT;
                    break;
                case 'l':
                    val = (char)Rd_GeneralConstant.RdRTD_LONG;
                    break;
                case 'L':
                    val = (char)Rd_GeneralConstant.RdRTD_DLONG;
                    break;
                case 'S':
                    val = (char)Rd_GeneralConstant.RdRTD_STRING;
                    break;
                case 'Y':
                    val = (char)Rd_GeneralConstant.RdRTD_BYTE;
                    break;
                case 'A':
                    val = (char)Rd_GeneralConstant.RdRTD_RAW;
                    break;
            }

            return val;
        }

        #endregion

        #region Public Methods
        public void UpdateTag()
        {
            try
            {
                if (CurrentTag != null)
                {
                    this.UpdateTag(CurrentTag);

                    this.GetTags();
                    ValueAsText = false;
                }
            }
            catch
            {

            }
        }

        public void UpdateTag(RodeoTag tag)
        {
            try
            {
                if (tag != null)
                {
                    double Num;
                    bool isNum = double.TryParse(NewValue, out Num);
                    if (isNum && ValueAsText == false)
                    {
                        RodeoHandler.Tag.SetValue(tag.TagName, Double.Parse(NewValue));
                    }
                    else
                    {
                        RodeoHandler.Tag.SetValue(tag.TagName, NewValue);
                    }
                }
            }
            catch
            {

            }
        }

        //public void SetEnableAll()
        //{
        //    if (!DBAccess.Catalogs._rd_cranes.Any())
        //        DBAccess.LoadCatalogs();

        //    foreach (RD_Crane crane in DBAccess.Catalogs._rd_cranes.Values)
        //    {
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.CR_ENABLED, Configurations.General.RodeoSector, crane.Id), true);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.CR_MODE, Configurations.General.RodeoSector, crane.Id), true);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.CR_HOOK_STATUS, Configurations.General.RodeoSector, crane.Id), (int)HookStatus.Scheduled);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.CR_HOIST_UP, Configurations.General.RodeoSector, crane.Id), false);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.CR_HOIST_DOWN, Configurations.General.RodeoSector, crane.Id), true);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.CR_HOIST_POSITION, Configurations.General.RodeoSector, crane.Id), 100);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.CR_HOOK_LAST_CHANGE_TIME, Configurations.General.RodeoSector, crane.Id), DateTimeOffset.UtcNow.Ticks);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.CR_HOOK, Configurations.General.RodeoSector, crane.Id), false);
        //    }

        //    foreach (CT_Location location in DBAccess.Catalogs._locations.Values)
        //    {
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_STATUS, Configurations.General.RodeoSector, location.Id), (int)LocationStatus.Enabled);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HAS_HOOK, Configurations.General.RodeoSector, location.Id), false);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK_STATUS, Configurations.General.RodeoSector, location.Id), (int)HookStatus.Scheduled);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK_TIME, Configurations.General.RodeoSector, location.Id), DateTimeOffset.UtcNow.Ticks);
        //        RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK, Configurations.General.RodeoSector, location.Id), string.Empty);
        //    }

        //    int hook = 1;
        //    foreach (var loc in DBAccess.Catalogs._rd_locations.Values.Where(l=>l.Type == Database.LocationTypes.Rack))
        //    {
        //        loc.Update();
        //        if (loc.Enabled)
        //        {
        //            if (RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK, Configurations.General.RodeoSector, loc.Id), ((HookId)hook).ToString()))
        //            {
        //                hook++;
        //            }
        //        }
        //    }

        //    //RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK, Configurations.General.RodeoSector, 11), "A");
        //    //RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK, Configurations.General.RodeoSector, 12), "B");
        //    //RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK, Configurations.General.RodeoSector, 13), "C");
        //    //RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK, Configurations.General.RodeoSector, 14), "D");
        //    //RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK, Configurations.General.RodeoSector, 15), "E");
        //    //RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK, Configurations.General.RodeoSector, 16), "F");
        //    //RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK, Configurations.General.RodeoSector, 17), "G");
        //    //RodeoHandler.Tag.SetValue(string.Format(TagNames.LOCATION_HOOK, Configurations.General.RodeoSector, 18), "H");
        //}

        public void GetTags()
        {
            this.LoadTagsFromRodeo();

            this.FilterTags();
        }

        public void GetAlarms()
        {
            if (this.LstAlarms == null)
                this.LstAlarms = new List<RodeoAlarm>();

            LstAlarms = _alarmHelper.GetAlarms();

            this.FilterAlarms();
        }

        public void UpdateAlarm()
        {
            if (this.CurrentAlarm != null)
            {
                this.UpdateAlarm(this.CurrentAlarm, this.currentStatusAlarm.Name);

                this.GetAlarms();
            }
        }

        public void UpdateAlarm(RodeoAlarm alarm, string state)
        {
            try
            {
                if (alarm != null)
                {
                    int alarmState = RodeoHandler.Alarm.Handler.RdAS_String2State(state);
                    if (alarmState < 0)
                    {
                        alarmState = Rd_GeneralConstant.RdAS_AUSENTE;
                    }

                    SRdTimems[] timmens = new SRdTimems[3];
                    timmens[0] = RdGeneral.Rd_TiempoActual();
                    timmens[1] = timmens[0];
                    timmens[1].s -= 100;
                    timmens[2] = timmens[0];
                    timmens[2].s -= 100;

                    int result = RodeoHandler.Alarm.Handler.RdAS_SetState(Properties.Settings.Default.RodeoSector, -1, alarm.AlarmName, new SRdState() { current = alarmState }, timmens, "JANUS");

                    System.Threading.Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void DeactiveAlarm()
        {
            if (this.CurrentAlarm != null)
            {
                this.UpdateAlarm(this.currentAlarm, "NOT ACTIVE");

                this.GetAlarms();
            }

        }

        public void ActiveAlarm()
        {
            if (this.CurrentAlarm != null)
            {
                if (this.CurrentAlarm != null)
                {
                    this.UpdateAlarm(this.currentAlarm, "ACTIVE / NOT ACK");

                    this.GetAlarms();
                }
            }

        }

        public void EmergencyLoad()
        {
            //RD_CHASTL_Sys sys = new RD_CHASTL_Sys();
            //sys.Update();

            ////string mesg = "";

            //List<HookInfo> lstHooks = new List<HookInfo>();
            //foreach (var i in sys.LstHookInfo)
            //{
            //    lstHooks.Add(new HookInfo { Hook = i.Hook, Location = i.IdLocation, HookRunID = i.HookRunID });
            //}

            //winEmergencyLoad win = new winEmergencyLoad(lstHooks);
            //win.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            //win.Show();
        }


        public string Login()
        {
            int result = -1;
            if (!string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.Password) && this.CurrentClient != null)
            {
                result = RodeoHandler.User.Handler.RdUsr_Login(Properties.Settings.Default.RodeoSector, this.UserName, this.Password, ushort.Parse(this.CurrentClient.IdClient.ToString()), 1);

                if (result == 0)
                {
                    this.GetAllSessions();
                    this.UserName = string.Empty;
                    this.Password = string.Empty;
                    //this.CurrentClient = null;
                }
            }

            return string.Format("Login return {0}", result);
        }

        public string Logout()
        {
            int result = -1;
            //if (!string.IsNullOrEmpty(this.UserName) && this.CurrentClient != null)
            if (this.CurrentUser != null)
            {
                result = RodeoHandler.User.Handler.RdUsr_Logout(Properties.Settings.Default.RodeoSector, this.CurrentUser.UserName, this.CurrentUser.User.id_client, this.CurrentUser.User.id_session);

                if (result == 0)
                {
                    this.GetAllSessions();
                    this.UserName = string.Empty;
                    this.Password = string.Empty;
                    this.CurrentClient = null;
                }
            }

            return string.Format("Logout return {0}", result);
        }

        public void GetAllSessions()
        {
            var res = RodeoHandler.User.Handler.RdUsr_GetAllSessions(Properties.Settings.Default.RodeoSector);

            CT_User user;
            List<CT_User> users = new List<CT_User>();

            foreach (var item in res)
            {
                user = new CT_User();
                user.User = item;
                user.UserName = item.user;
                user.Client = DBAccess.Catalogs._clients.Values.FirstOrDefault(c => c.IdClient == item.id_client);
                users.Add(user);
            }

            this.LstUsers = users;
        }

        #endregion

        #region Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
