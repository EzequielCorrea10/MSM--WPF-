﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.Database
{
    /// <summary>
    /// partial class of events
    /// </summary>
    partial class Rodeo_Event
    {
        #region public properties
        public bool HasJob
        {
            get { return this.Job != null; }
        }

        public bool HasTransportOrder
        {
            get { return this.TransportOrder != null; }
        }

        public bool HasTOStep
        {
            get { return this.TOStep != null; }
        }

        public bool HasAdditional
        {
            get
            {
                return !string.IsNullOrEmpty(this.PieceName) ||
                       !string.IsNullOrEmpty(this.LocationName) ||
                       !string.IsNullOrEmpty(this.MachineName);
            }
        }
        #endregion

        #region job / transport order / step adquisition methods
        private readonly object lockInstance = new object();
        private HSM_Job _Job;
        public HSM_Job Job
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
                            LoadData();
                        }
                    }
                }
                return this._Job;
            }
        }

        private Rodeo_TransportOrder _TransportOrder;
        public Rodeo_TransportOrder TransportOrder
        {
            get
            {
                if (string.IsNullOrEmpty(HSMDataContext.default_connection_string))
                    return null;

                if (this.IdTransportOrder == null)
                    return null;

                if (this._TransportOrder == null)
                {
                    lock (lockInstance)
                    {
                        if (this._TransportOrder == null)
                        {
                            LoadData();
                        }
                    }
                }
                return this._TransportOrder;
            }
        }

        private Rodeo_TO_Step _TOStep;
        public Rodeo_TO_Step TOStep
        {
            get
            {
                if (string.IsNullOrEmpty(HSMDataContext.default_connection_string))
                    return null;

                if (this.Step == null)
                    return null;

                if (this._TOStep == null)
                {
                    lock (lockInstance)
                    {
                        if (this._TOStep == null)
                        {
                            LoadData();
                        }
                    }
                }
                return this._TOStep;
            }
        }

        private void LoadData()
        {
            using (HSMDataContext db = new HSMDataContext(HSMDataContext.default_connection_string))
            {
                DataLoadOptions dlo = new DataLoadOptions();

                dlo.LoadWith<HSM_Job>(o => o.Rodeo_TO_Statuse);
                dlo.LoadWith<HSM_Job>(o => o.HSM_Job_Type);
                dlo.LoadWith<HSM_Job>(o => o.Rodeo_Yard);
                dlo.LoadWith<HSM_Job>(o => o.Rodeo_Yard1);
                dlo.LoadWith<HSM_Job>(o => o.Rodeo_Yard2);
                dlo.LoadWith<HSM_Job>(o => o.Rodeo_Yard3);
                dlo.LoadWith<HSM_Job>(o => o.Rodeo_Yard4);
                //dlo.LoadWith<HSM_Job>(o => o.Rodeo_Yard_DropRedirect);

                dlo.LoadWith<Rodeo_TransportOrder>(o => o.Rodeo_TO_Statuse);
                dlo.LoadWith<Rodeo_TransportOrder>(o => o.Rodeo_TO_Steps);
                dlo.LoadWith<Rodeo_TransportOrder>(o => o.Rodeo_TO_Type);
                dlo.LoadWith<Rodeo_TransportOrder>(o => o.Rodeo_Machine);
                dlo.LoadWith<Rodeo_TransportOrder>(o => o.Rodeo_Yard_Begin);
                dlo.LoadWith<Rodeo_TransportOrder>(o => o.Rodeo_Yard_End);

                dlo.LoadWith<Rodeo_TO_Step>(o => o.Rodeo_TO_Action);
                dlo.LoadWith<Rodeo_TO_Step>(o => o.Rodeo_TO_Statuse);
                dlo.LoadWith<Rodeo_TO_Step>(o => o.Rodeo_Yard_Begin);
                dlo.LoadWith<Rodeo_TO_Step>(o => o.Rodeo_Yard_End);
                dlo.LoadWith<Rodeo_TO_Step>(o => o.HSM_Path_Begin);
                dlo.LoadWith<Rodeo_TO_Step>(o => o.HSM_Path_End);

                db.LoadOptions = dlo;
                db.DeferredLoadingEnabled = false;

                if (IdJob != null)
                {
                    this._Job = db.HSM_Jobs.FirstOrDefault(p => p.IdJob == IdJob);
                }
                else
                {
                    this._Job = null;
                }

                if (IdTransportOrder != null)
                {
                    this._TransportOrder = db.Rodeo_TransportOrders.FirstOrDefault(p => p.IdTransportOrder == IdTransportOrder);

                    if (Step != null)
                    {
                        this._TOStep = db.Rodeo_TO_Steps.FirstOrDefault(p => p.IdTransportOrder == IdTransportOrder && p.Step == Step);
                    }
                    else
                    {
                        this._TOStep = null;
                    }
                }
                else
                {
                    this._TransportOrder = null;
                    this._TOStep = null;
                }
            }
        }
        #endregion
    }
}