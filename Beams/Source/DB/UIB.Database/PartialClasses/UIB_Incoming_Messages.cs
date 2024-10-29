using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.Database
{
    /// <summary>
    /// partial class of HSM_Incoming_Message
    /// </summary>
    partial class HSM_Incoming_Message
    {
        #region steps adquisition methods
        private readonly object lockInstance = new object();
        private HSM_Job _Job;
        public HSM_Job Temp_HSM_Job
        {
            get
            {
                if (string.IsNullOrEmpty(HSMDataContext.default_connection_string))
                    return null;

                if (this.IdJob == null)
                    return null;

                if (this._Job == null)
                {
                    lock (lockInstance)
                    {
                        if (this._Job == null)
                        {
                            using (HSMDataContext db = new HSMDataContext(HSMDataContext.default_connection_string))
                            {
                                DataLoadOptions dlo = new DataLoadOptions();
                                dlo.LoadWith<HSM_Job>(o => o.HSM_Job_Type);
                                dlo.LoadWith<HSM_Job>(o => o.Rodeo_TO_Statuse);

                                db.LoadOptions = dlo;
                                db.DeferredLoadingEnabled = false;

                                this._Job = db.HSM_Jobs.FirstOrDefault(p => p.IdJob == this.IdJob);
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
