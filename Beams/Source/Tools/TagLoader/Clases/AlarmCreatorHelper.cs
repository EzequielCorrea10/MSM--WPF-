using Janus.Rodeo.Windows.Library.Rd_Common;
using Janus.Rodeo.Windows.Library.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagLoader.Clases
{
    public class AlarmCreatorHelper : INotifyPropertyChanged
    {
        #region Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private List<RodeoAlarm> _lst;

        public List<RodeoAlarm> listToShow
        {
            get { return _lst; }
            set
            {
                _lst = value;
                OnPropertyChanged("listToShow");
            }
        }


        public AlarmCreatorHelper()
        {
            listToShow = new List<RodeoAlarm>();
        }

        public List<RodeoAlarm> GetAlarms()
        {
            listToShow.Clear();
            var alarmList = RodeoHandler.Alarm.Handler.RdAS_GetAllAlarms(Properties.Settings.Default.RodeoSector);
            List<Janus.Rodeo.Windows.Library.Rd_Common.RASAlarm> SortedList = alarmList.OrderBy(o => o.index).ToList();

            for (int i = 0; i < SortedList.Count; i++)
            {
                RodeoAlarm thisAlarm = new RodeoAlarm();
                thisAlarm.AlarmID = SortedList[i].index;
                thisAlarm.AlarmName = SortedList[i].alarm;

                SRdState stateValue = SortedList[i].state;
                string stateName;
                if (RodeoHandler.Alarm.Handler.RdAS_State2String((ushort)stateValue.current, out stateName) >= 0)
                {
                    thisAlarm.AlarmState = stateName;
                }
                else
                {
                    thisAlarm.AlarmState = string.Format("UNKNOWN: {0}", (ushort)stateValue.current);
                }

                DateTime update;
                if (SortedList[i].updateTime.s > 0)
                {
                    update = RdTime.rd_localtime_d(SortedList[i].updateTime.s);
                    update = update.AddMilliseconds(SortedList[i].updateTime.ms);
                }
                else
                {
                    update = new DateTime(1970, 1, 1, 0, 0, 0);
                }

                thisAlarm.Update = string.Format("{0:MM/dd hh:mm:ss tt}", update);

                DateTime timeUp;
                if (SortedList[i].updateTimeTOn.s > 0)
                {
                    timeUp = RdTime.rd_localtime_d(SortedList[i].updateTimeTOn.s);
                    timeUp = timeUp.AddMilliseconds(SortedList[i].updateTimeTOn.ms);
                }
                else
                {
                    timeUp = new DateTime(1970, 1, 1, 0, 0, 0);
                }

                thisAlarm.TimeOn = string.Format("{0:MM/dd hh:mm:ss tt}", timeUp);

                DateTime timeDown;
                if (SortedList[i].updateTimeTOff.s > 0)
                {
                    timeDown = RdTime.rd_localtime_d(SortedList[i].updateTimeTOff.s);
                    timeDown = timeDown.AddMilliseconds(SortedList[i].updateTimeTOff.ms);
                }
                else
                {
                    timeDown = new DateTime(1970, 1, 1, 0, 0, 0);
                }

                thisAlarm.TimeOff = string.Format("{0:MM/dd hh:mm:ss tt}", timeDown);

                listToShow.Add(thisAlarm);
            }

            return listToShow;
        }

        public List<RodeoAlarm> FilterAlarms(string data)
        {
            GetAlarms();
            if (data == "") { return listToShow; }
            return this.listToShow.Where(oList => oList.AlarmName.ToUpper().Contains(data)).ToList();
        }
    }
}
