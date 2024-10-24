using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Database
{
    public partial class MSM_Job_Forecast
    {
        #region attributes
        /// <summary>
        /// Is expanded
        /// </summary>
        private bool _is_expanded;
        #endregion

        #region public properties
        /// <summary>
        /// PosY1
        /// </summary>
        public bool IsExpanded
        {
            get { return _is_expanded; }
            set { _is_expanded = value; }
        }

        #region steps adquisition methods       
        private readonly object lockInstance = new object();
        private IEnumerable<MSM_Job> _Job;
        public IEnumerable<MSM_Job> Temp_MSM_Job
        {
            get
            {
                if (string.IsNullOrEmpty(MSMDataContext.default_connection_string))
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
                                dlo.LoadWith<MSM_Job>(o => o.MSM_Job_Forecasts);
                                dlo.LoadWith<MSM_Job>(o => o.MSM_Job_Type);
                                dlo.LoadWith<MSM_Job>(o => o.Rodeo_TO_Pieces);
                                db.LoadOptions = dlo;
                                db.DeferredLoadingEnabled = false;

                                this._Job = db.MSM_Jobs.Where(p => p.IdJob == this.IdJob).ToList();
                            }
                        }
                    }
                }
                return this._Job;
            }
        }
        #endregion

        #endregion
    }
}