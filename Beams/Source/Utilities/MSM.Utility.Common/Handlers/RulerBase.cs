using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCM.Utility.Common.Handlers
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using Janus.Rodeo.Windows.Library.UI.Common;
    using Janus.Rodeo.Windows.Library.Rd_Cfg;

    using HCM.Utility.Common.Catalogs;
    using HCM.Utility.Common.Structures;

    /// <summary>
    /// Class to include the rule of the process
    /// </summary>
    public abstract class RulerBase
    {
        #region public attributes
        /// <summary>
        /// _alarm_definition
        /// </summary>
        private static Dictionary<string, SRdCfgAlarm> _alarm_definitions = new Dictionary<string, SRdCfgAlarm>();
        #endregion

        #region public properties
        /// <summary>
        /// _alarm_definition
        /// </summary>
        public static Dictionary<string, SRdCfgAlarm> AlarmDefinitions
        {
            get { return _alarm_definitions; }
        }
        #endregion

        #region protected static attributes
        /// <summary>
        /// use to lock the logical
        /// </summary>
        protected static readonly object lockInstance = new object();
        #endregion

        #region public yards methods
        /// <summary>
        /// GetYard
        /// </summary>
        /// <param name="yards"></param>
        /// <param name="yard"></param>
        /// <returns></returns>
        public static CT_Yard GetYard(CT_Yard[] yards, double yard)
        {
            for (int i = 0; i < yards.Length; i++)
            {
                if (yards[i].PlcValue == yard)
                {
                    return yards[i];
                }
            }

            return null;
        }

        /// <summary>
        /// GetYard
        /// </summary>
        /// <param name="yards"></param>
        /// <param name="absolute_pos_x"></param>
        /// <param name="absolute_pos_y"></param>
        /// <returns></returns>
        public static CT_Yard GetYard(CT_Yard[] yards, double absolute_pos_x, double absolute_pos_y)
        {
            for (int i = 0; i < yards.Length; i++)
            {
                if (yards[i].AbsolutePosX1 <= absolute_pos_x && yards[i].AbsolutePosX2 >= absolute_pos_x &&
                    yards[i].AbsolutePosY1 <= absolute_pos_y && yards[i].AbsolutePosY2 >= absolute_pos_y)
                {
                    return yards[i];
                }
            }

            return null;
        }
        #endregion    

        #region public alarm methods
        /// <summary>
        /// Load Alarms
        /// </summary>
        public static void LoadAlarms(string sector, List<string> only_alarms)
        {
            RodeoHandler.RodeoSector = sector;

            SRdCfgAlarm[] all_alarms;
            if (!RodeoHandler.Alarm.GetCfgAlarms(out all_alarms))
            {
                throw new Exception(string.Format("Error getting cfg Alarm for island {0}", sector));
            }

            int i;
            for (i = 0; i < all_alarms.Length; i++)
            {
                if (only_alarms.Contains(all_alarms[i].alarm))
                {
                    if (!AlarmDefinitions.ContainsKey(all_alarms[i].alarm))
                    {
                        AlarmDefinitions.Add(all_alarms[i].alarm, all_alarms[i]);
                        RdTrace.Debug("Alarm {0} exist, it will be monitored", all_alarms[i].alarm);
                    }
                }
            }
        }

        /// <summary>
        /// Send Alarm
        /// </summary>
        /// <returns></returns>
        public static bool SendAlarm(string alarm, bool reset = false)
        {
            try
            {
                if (_alarm_definitions.ContainsKey(alarm))
                {
                    SRdState state;
                    bool active = false;
                    if (!RodeoHandler.Alarm.GetAlarm(_alarm_definitions[alarm].id, alarm, out state))
                    {
                        RdTrace.Debug("it cannot read the alarm {0}", alarm);
                        return false;
                    }
                    else
                    {
                        active = (state.current == Rd_GeneralConstant.RdAS_PRESENTE_RECONOCIDA || state.current == Rd_GeneralConstant.RdAS_PRESENTE_NO_RECONOCIDA) ? true : false;
                        if (!active && !reset)
                        {
                            return RodeoHandler.Alarm.ActiveAlarm(_alarm_definitions[alarm].id, alarm);
                        }
                        else if (active && reset)
                        {
                            return RodeoHandler.Alarm.ResetAlarm(_alarm_definitions[alarm].id, alarm);
                        }
                    }
                }
                else
                {
                    RdTrace.Debug("Alarm {0} is not declared", alarm);
                }

                return true;
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }

            return false;
        }
        #endregion    

        #region public validations rules
        /// <summary>
        /// ExistUser
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool ExistUser(string username)
        {
            return RodeoHandler.User.ExistUser(username);
        }
        #endregion
    }
}
