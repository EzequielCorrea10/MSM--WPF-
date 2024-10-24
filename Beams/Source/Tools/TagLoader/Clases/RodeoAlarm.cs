using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagLoader.Clases
{
    public class RodeoAlarm
    {
        private uint _AlarmID;
        public uint AlarmID
        {
            get
            {
                return _AlarmID;
            }

            set
            {
                _AlarmID = value;
            }
        }
        private string _AlarmName;
        public string AlarmName
        {
            get
            {
                return _AlarmName;
            }

            set
            {
                _AlarmName = value;
            }
        }
        private string _AlarmState;
        public string AlarmState
        {
            get
            {
                return _AlarmState;
            }
            set
            {
                _AlarmState = value;
            }
        }
        private string _Update;
        public string Update
        {
            get
            {
                return _Update;
            }
            set
            {
                _Update = value;
            }
        }
        private string _TimeOn;
        public string TimeOn
        {
            get
            {
                return _TimeOn;
            }
            set
            {
                _TimeOn = value;
            }
        }
        private string _TimeOff;
        public string TimeOff
        {
            get
            {
                return _TimeOff;
            }
            set
            {
                _TimeOff = value;
            }
        }
    }
}
