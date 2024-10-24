using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Utility.Common.Structures
{
    using MSM.Utility.Common.Catalogs;
    using MSM.Utility.Common.Handlers;

    /// <summary>
    /// Yard_Transfer
    /// </summary>
    public class Yard_Transfer
    {
        #region private attribute
        /// <summary>
        /// _yard_begin
        /// </summary>
        private CT_Yard _yard_begin;

        /// <summary>
        /// _yard_end
        /// </summary>
        private CT_Yard _yard_end;

        /// <summary>
        /// _location_group_begin
        /// </summary>
        private string _location_group_begin;

        /// <summary>
        /// _location_group_end
        /// </summary>
        private string _location_group_end;

        /// <summary>
        /// _machine_type
        /// </summary>
        private string _machine_type;
        #endregion

        #region public properties
        /// <summary>
        /// YardBegin
        /// </summary>
        public CT_Yard YardBegin
        {
            get { return _yard_begin; }
            set { _yard_begin = value; }
        }

        /// <summary>
        /// YardEnd
        /// </summary>
        public CT_Yard YardEnd
        {
            get { return _yard_end; }
            set { _yard_end = value; }
        }

        /// <summary>
        /// LocationGroupBegin
        /// </summary>
        public string LocationGroupBegin
        {
            get { return _location_group_begin; }
            set { _location_group_begin = value; }
        }

        /// <summary>
        /// LocationGroupEnd
        /// </summary>
        public string LocationGroupEnd
        {
            get { return _location_group_end; }
            set { _location_group_end = value; }
        }

        /// <summary>
        /// MachineType
        /// </summary>
        public string MachineType
        {
            get { return _machine_type; }
            set { _machine_type = value; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Yard_Transfer
        /// </summary>
        /// <param name="yard_begin"></param>
        /// <param name="yard_end"></param>
        /// <param name="location_group_begin"></param>
        /// <param name="location_group_end"></param>
        /// <param name="machine_type"></param>
        public Yard_Transfer(CT_Yard yard_begin, CT_Yard yard_end, string location_group_begin, string location_group_end, string machine_type)
        {
            this._yard_begin = yard_begin;
            this._yard_end = yard_end;
            this._location_group_begin = location_group_begin;
            this._location_group_end = location_group_end;
            this._machine_type = machine_type;
        }
        #endregion
    }
}