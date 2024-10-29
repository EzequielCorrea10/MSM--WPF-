using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCM.Database
{
    /// <summary>
    /// partial class of HCM_Incoming_Message
    /// </summary>
    partial class HCM_Incoming_Message
    {
        #region steps adquisition methods
        private readonly object lockInstance = new object();
        private HCM_Job _Job;
        public HCM_Job Temp_HCM_Job
        {
            get
            {
                if (string.IsNullOrEmpty(HCMDataContext.default_connection_string))
                    return null;

                if (this.IdJob == null)
                    return null;

                if (this._Job == null)
                {
                    lock (lockInstance)
                    {
                        if (this._Job == null)
                        {
                            using (HCMDataContext db = new HCMDataContext(HCMDataContext.default_connection_string))
                            {
                                DataLoadOptions dlo = new DataLoadOptions();
                                dlo.LoadWith<HCM_Job>(o => o.HCM_Job_Type);
                                dlo.LoadWith<HCM_Job>(o => o.Rodeo_TO_Statuse);

                                db.LoadOptions = dlo;
                                db.DeferredLoadingEnabled = false;

                                this._Job = db.HCM_Jobs.FirstOrDefault(p => p.IdJob == this.IdJob);
                            }
                        }
                    }
                }
                return this._Job;
            }
        }
        #endregion
    }
}
