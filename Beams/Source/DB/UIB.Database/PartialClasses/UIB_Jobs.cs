using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIB.Database
{
    public partial class UIB_Job
    {
        #region attributes

        /// <summary>
        /// Is expanded
        /// </summary>
        private bool _is_expanded;

        #endregion

        #region public properties
        /// <summary>
        /// Is Expanded
        /// </summary>
        public bool IsExpanded
        {
            get { return _is_expanded; }
            set { _is_expanded = value; }
        }

        /// <summary>
        /// CloseTime
        /// </summary>
        public DateTimeOffset? CloseTime
        {
            get
            {
                return (this.EndTime ?? this.CancelTime);
            }
        }

        /// <summary>
        /// PickupLocation
        /// </summary>
        //public string PickupLocation
        //{
        //    get
        //    {
        //        return (this.PickupFinalLocationName ?? this.PickupReqLocationName) ?? string.Empty;
        //    }
        //}

        /// <summary>
        /// EndLocation
        /// </summary>
        /// Storage Location: DropInitialLocationName + DropAssignLocationName + DropReqLocationName
        //public string StorageLocation
        //{
        //    get
        //    {
        //        return ((this.DropInitialLocationName ?? this.DropAssignLocationName) ?? this.DropReqLocationName) ?? string.Empty;
        //    }
        //}

        /// <summary>
        /// RedirectLocation
        /// </summary>
        //public string RedirectLocation
        //{
        //    get
        //    {
        //        return this.DropRedirectLocationName ?? string.Empty;
        //    }
        //}

        /// <summary>
        /// CycleTime
        /// </summary>
        public string CycleTime
        {
            get
            {
                if (this.StorageTime == null)
                {
                    return null;
                }

                TimeSpan time = (this.StorageTime.Value - this.RequestTime.Value);
                if (time.Days > 0)
                {
                    return string.Format("{0}.{1:D2}:{2:D2}:{3:D2}", time.Days, time.Hours, time.Minutes, time.Seconds);
                }
                else
                {
                    return string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds);
                }
            }
        }

        public DateTimeOffset? get_RequestTime()
        {
            return this.RequestTime;
        }

        public bool IsFuture
        {
            get
            {
                return this.Rodeo_TO_Statuse.Name.Equals("FUTURE", StringComparison.OrdinalIgnoreCase);
            }
        }

        public bool CanChangePriority
        {
            get
            {
                return ((this.IdJob > 0) &&
                        (this.Rodeo_TO_Statuse.Name.Equals("SCHEDULED", StringComparison.OrdinalIgnoreCase) ||
                         this.Rodeo_TO_Statuse.Name.Equals("FUTURE", StringComparison.OrdinalIgnoreCase)));
            }
        }

        public bool CanCancel
        {
            get
            {
                return (this.IdJob > 0 && this.CloseTime == null);
            }
        }

        #region steps adquisition methods
        private readonly object lockInstance = new object();
        private IEnumerable<Rodeo_TO_Piece> _TransportOrders;
        public IEnumerable<Rodeo_TO_Piece> Temp_Rodeo_TransportOrders
        {
            get
            {
                if (string.IsNullOrEmpty(UIBDataContext.default_connection_string))
                    return null;

                if (this._TransportOrders == null)
                {
                    lock (lockInstance)
                    {
                        if (this._TransportOrders == null)
                        {
                            using (UIBDataContext db = new UIBDataContext(UIBDataContext.default_connection_string))
                            {
                                DataLoadOptions dlo = new DataLoadOptions();
                                dlo.LoadWith<Rodeo_TO_Piece>(o => o.Rodeo_TransportOrder);
                                dlo.LoadWith<Rodeo_TO_Piece>(o => o.Rodeo_Yard_Pickup);
                                dlo.LoadWith<Rodeo_TO_Piece>(o => o.Rodeo_Yard_Drop);
                                dlo.LoadWith<Rodeo_TransportOrder>(o => o.Rodeo_Machine);
                                dlo.LoadWith<Rodeo_TransportOrder>(o => o.Rodeo_TO_Statuse);
                                dlo.LoadWith<Rodeo_TransportOrder>(o => o.Rodeo_TO_Type);

                                db.LoadOptions = dlo;
                                db.DeferredLoadingEnabled = false;

                                this._TransportOrders = db.Rodeo_TO_Pieces.Where(p => p.IdJob == this.IdJob).OrderBy(p => p.JobSequence).ToList();
                            }
                        }
                    }
                }
                return this._TransportOrders;
            }
        }

        private IEnumerable<UIB_Job_Forecast> _UIB_Job_Forecast;
        public IEnumerable<UIB_Job_Forecast> Temp_UIB_Job_Forecast
        {
            get
            {
                if (string.IsNullOrEmpty(UIBDataContext.default_connection_string))
                    return null;

                if (this._UIB_Job_Forecast == null)
                {
                    lock (lockInstance)
                    {
                        if (this._UIB_Job_Forecast == null)
                        {
                            using (UIBDataContext db = new UIBDataContext(UIBDataContext.default_connection_string))
                            {
                                DataLoadOptions dlo = new DataLoadOptions();
                                dlo.LoadWith<UIB_Job_Forecast>(o => o.UIB_Job);
                                dlo.LoadWith<UIB_Job_Forecast>(o => o.Rodeo_Yard_Begin);
                                dlo.LoadWith<UIB_Job_Forecast>(o => o.Rodeo_Yard_End);
                                db.LoadOptions = dlo;
                                db.DeferredLoadingEnabled = false;

                                this._UIB_Job_Forecast = db.UIB_Job_Forecasts.Where(p => p.IdJob == this.IdJob).OrderBy(p => p.Sequence).ToList();
                            }
                        }
                    }
                }
                return this._UIB_Job_Forecast;
            }
        }
        #endregion

        #endregion
    }
}