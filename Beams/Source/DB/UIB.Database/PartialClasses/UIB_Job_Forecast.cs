using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.Database
{
    public partial class HSM_Job_Forecast
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
        private IEnumerable<HSM_Job> _Job;
        public IEnumerable<HSM_Job> Temp_HSM_Job
        {
            get
            {
                if (string.IsNullOrEmpty(HSMDataContext.default_connection_string))
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
                                dlo.LoadWith<HSM_Job>(o => o.HSM_Job_Forecasts);
                                dlo.LoadWith<HSM_Job>(o => o.HSM_Job_Type);
                                dlo.LoadWith<HSM_Job>(o => o.Rodeo_TO_Pieces);
                                db.LoadOptions = dlo;
                                db.DeferredLoadingEnabled = false;

                                this._Job = db.HSM_Jobs.Where(p => p.IdJob == this.IdJob).ToList();
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