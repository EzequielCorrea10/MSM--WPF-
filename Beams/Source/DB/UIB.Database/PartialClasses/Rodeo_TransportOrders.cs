using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Database
{
    public partial class Rodeo_TransportOrder
    {
        #region attributes

        /// <summary>
        /// Is expanded
        /// </summary>
        private bool _is_expanded;

        #endregion

        #region public properties
        /// <summary>
        /// AlreadyActive
        /// </summary>
        public bool AlreadyActive
        {
            get
            {
                return this.Rodeo_TO_Statuse.Name.Equals("FUTURE", StringComparison.OrdinalIgnoreCase) ||
                       this.Rodeo_TO_Statuse.Name.Equals("SENT", StringComparison.OrdinalIgnoreCase) ||
                       this.Rodeo_TO_Statuse.Name.Equals("ACTIVE", StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// CanCancel
        /// </summary>
        public bool CanCancel
        {
            get
            {
                return (this.EndTime == null);
            }
        }

        /// <summary>
        /// Is Expanded
        /// </summary>
        public bool IsExpanded
        {
            get { return _is_expanded; }
            set { _is_expanded = value; }
        }

        #region steps adquisition methods
        private readonly object lockInstance = new object();
        private IEnumerable<Rodeo_TO_Step> _Steps;
        public IEnumerable<Rodeo_TO_Step> Temp_Rodeo_TO_Steps
        {
            get
            {
                if (string.IsNullOrEmpty(MSMDataContext.default_connection_string))
                    return null;

                if (this._Steps == null)
                {
                    lock (lockInstance)
                    {
                        if (this._Steps == null)
                        {
                            using (MSMDataContext db = new MSMDataContext(MSMDataContext.default_connection_string))
                            {
                                DataLoadOptions dlo = new DataLoadOptions();
                                dlo.LoadWith<Rodeo_TO_Step>(o => o.Rodeo_TO_Action);
                                dlo.LoadWith<Rodeo_TO_Step>(o => o.Rodeo_TO_Statuse);
                                dlo.LoadWith<Rodeo_TO_Step>(o => o.Rodeo_Yard_Begin);
                                dlo.LoadWith<Rodeo_TO_Step>(o => o.Rodeo_Yard_End);
                                dlo.LoadWith<Rodeo_TO_Step>(o => o.MSM_Path_Begin);
                                dlo.LoadWith<Rodeo_TO_Step>(o => o.MSM_Path_End);

                                db.LoadOptions = dlo;
                                db.DeferredLoadingEnabled = false;

                                this._Steps = db.Rodeo_TO_Steps.Where(p => p.IdTransportOrder == this.IdTransportOrder).OrderBy(p => p.Step).ToList();
                            }
                        }
                    }
                }
                return this._Steps;
            }
        }
        #endregion

        #endregion
    }
}