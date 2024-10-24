using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.HMI.Safety.Operation.Structures
{
    /// <summary>
    /// Fence
    /// </summary>
    internal class Fence
    {
        #region attributes
        /// <summary>
        /// _pos_x1
        /// </summary>
        private int _pos_x1;

        /// <summary>
        /// _pos_y1
        /// </summary>
        private int _pos_y1;

        /// <summary>
        /// _pos_x2
        /// </summary>
        private int _pos_x2;

        /// <summary>
        /// _pos_y2
        /// </summary>
        private int _pos_y2;

        /// <summary>
        /// _drawn_thickness
        /// </summary>
        private int _drawn_thickness;
        #endregion 

        #region public properties
        /// <summary>
        /// PosX1
        /// </summary>
        public int PosX1
        {
            get { return _pos_x1; }
            set { _pos_x1 = value; }
        }

        /// <summary>
        /// PosY1
        /// </summary>
        public int PosY1
        {
            get { return _pos_y1; }
            set { _pos_y1 = value; }
        }

        /// <summary>
        /// PosX2
        /// </summary>
        public int PosX2
        {
            get { return _pos_x2; }
            set { _pos_x2 = value; }
        }

        /// <summary>
        /// PosY2
        /// </summary>
        public int PosY2
        {
            get { return _pos_y2; }
            set { _pos_y2 = value; }
        }

        /// <summary>
        /// DrawnThickness
        /// </summary>
        public int DrawnThickness
        {
            get { return _drawn_thickness; }
            set { _drawn_thickness = value; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Fence"/> class.
        /// </summary>
        /// <param name="pos_x1"></param>
        /// <param name="pos_y1"></param>
        /// <param name="pos_x2"></param>
        /// <param name="pos_y2"></param>
        /// <param name="drawn_thickness"></param>
        public Fence(int pos_x1, int pos_y1, int pos_x2, int pos_y2, int drawn_thickness)
        {
            this._pos_x1 = pos_x1;
            this._pos_y1 = pos_y1;
            this._pos_x2 = pos_x2;
            this._pos_y2 = pos_y2;
            this._drawn_thickness = drawn_thickness;
        }
        #endregion
    }
}
