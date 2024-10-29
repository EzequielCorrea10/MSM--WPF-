using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.Utility.Common.Catalogs
{
    using HSM.Utility.Common.Structures;

    /// <summary>
    /// CT_Location
    /// </summary>
    public class CT_Yard : CT_Base
    {
        #region attributes
        /// <summary>
        /// _absolute_pos_x1
        /// </summary>
        private int _absolute_pos_x1;

        /// <summary>
        /// _absolute_pos_x2
        /// </summary>
        private int _absolute_pos_x2;

        /// <summary>
        /// _len_pos_x
        /// </summary>
        private int _len_pos_x;

        /// <summary>
        /// _absolute_pos_y1
        /// </summary>
        private int _absolute_pos_y1;

        /// <summary>
        /// _absolute_pos_y2
        /// </summary>
        private int _absolute_pos_y2;

        /// <summary>
        /// _len_pos_y
        /// </summary>
        private int _len_pos_y;

        /// <summary>
        /// _plcValue
        /// </summary>
        private int _plc_value;

        /// <summary>
        /// _transfers
        /// </summary>
        private Yard_Transfer[] _transfers;
        #endregion

        #region public properties
        /// <summary>
        /// AbsolutePosX1
        /// </summary>
        public int AbsolutePosX1
        {
            get { return _absolute_pos_x1; }
            private set { _absolute_pos_x1 = value; }
        }

        /// <summary>
        /// AbsolutePosX2
        /// </summary>
        public int AbsolutePosX2
        {
            get { return _absolute_pos_x2; }
            private set { _absolute_pos_x2 = value; }
        }

        /// <summary>
        /// LenPosX
        /// </summary>
        public int LenPosX
        {
            get { return _len_pos_x; }
            private set { _len_pos_x = value; }
        }

        /// <summary>
        /// AbsolutePosY1
        /// </summary>
        public int AbsolutePosY1
        {
            get { return _absolute_pos_y1; }
            private set { _absolute_pos_y1 = value; }
        }

        /// <summary>
        /// AbsolutePosY2
        /// </summary>
        public int AbsolutePosY2
        {
            get { return _absolute_pos_y2; }
            private set { _absolute_pos_y2 = value; }
        }

        /// <summary>
        /// LenPosY
        /// </summary>
        public int LenPosY
        {
            get { return _len_pos_y; }
            private set { _len_pos_y = value; }
        }

        /// <summary>
        /// PlcValue
        /// </summary>
        public int PlcValue
        {
            get { return _plc_value; }
            private set { _plc_value = value; }
        }

        /// <summary>
        /// YardTransfers
        /// </summary>
        public Yard_Transfer[] YardTransfers
        {
            get { return _transfers; }
            internal set { _transfers = value; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CT_Yard"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="absolute_pos_x1"></param>
        /// <param name="absolute_pos_x2"></param>
        /// <param name="absolute_pos_y1"></param>
        /// <param name="absolute_pos_y2"></param>
        /// <param name="plc_value"></param>
        public CT_Yard(int id, string name, string description, int absolute_pos_x1, int absolute_pos_x2, int absolute_pos_y1, int absolute_pos_y2, int plc_value)
            : base(id, name, description)
        {
            this._absolute_pos_x1 = absolute_pos_x1;
            this._absolute_pos_x2 = absolute_pos_x2;
            this._len_pos_x = this._absolute_pos_x2 - this._absolute_pos_x1;
            this._absolute_pos_y1 = absolute_pos_y1;
            this._absolute_pos_y2 = absolute_pos_y2;
            this._len_pos_y = this._absolute_pos_y2 - this._absolute_pos_y1;
            this._plc_value = plc_value;

            this._transfers = new Yard_Transfer[] { };
        }
        #endregion
    }
}