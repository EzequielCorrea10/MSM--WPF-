using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Database
{
    /// <summary>
    /// partial class of MSM_Incoming_Message
    /// </summary>
    partial class MSM_Incoming_Message
    {
        #region steps adquisition methods
        private readonly object lockInstance = new object();
        private MSM_Job _Job;
        public MSM_Job Temp_MSM_Job
        {
            get
            {
                if (string.IsNullOrEmpty(MSMDataContext.default_connection_string))
                    return null;

                if (this.IdJob == null)
                    return null;

                if (this._Job == null)
                {
                    lock (lockInstance)
                    {
                        if (this._Job == null)
                        {
                            using (MSMDataContext db = new MSMDataContext(MSMDataContext.default_connection_string))
                            {
                                DataLoadOptions dlo = new DataLoadOptions();
                                dlo.LoadWith<MSM_Job>(o => o.MSM_Job_Type);
                                dlo.LoadWith<MSM_Job>(o => o.Rodeo_TO_Statuse);

                                db.LoadOptions = dlo;
                                db.DeferredLoadingEnabled = false;

                                this._Job = db.MSM_Jobs.FirstOrDefault(p => p.IdJob == this.IdJob);
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
