using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.Utility.Common.Structures
{
    using HSM.Utility.Common.Handlers;
    using HSM.Utility.Common.Enumerations;

    /// <summary>
    /// PosOffset
    /// </summary>
    public class PosOffset : ICloneable
    {
        #region private attribute
        /// <summary>
        /// position
        /// </summary>
        private short _position;

        /// <summary>
        /// x position
        /// </summary>
        private int _pos_x;

        /// <summary>
        /// y position
        /// </summary>
        private int _pos_y;

        /// <summary>
        /// z position
        /// </summary>
        private int? _pos_z;
        #endregion

        #region public properties
        /// <summary>
        /// PosX
        /// </summary>
        public short Position
        {
            get { return _position; }
            private set { _position = value; }
        }

        /// <summary>
        /// PosX
        /// </summary>
        public int PosX
        {
            get { return _pos_x; }
            private set { _pos_x = value; }
        }

        /// <summary>
        /// PosY
        /// </summary>
        public int PosY
        {
            get { return _pos_y; }
            private set { _pos_y = value; }
        }

        /// <summary>
        /// PosZ
        /// </summary>
        public int? PosZ
        {
            get { return _pos_z; }
            private set { _pos_z = value; }
        }

        public string DisplayName
        {
            get
            {
                if (this._pos_z == null)
                    return string.Format("{0}", EngineeringUnitHandler.GetDisplayPosition(new int[] { this._pos_x, this._pos_y }));
                else
                    return string.Format("{0}", EngineeringUnitHandler.GetDisplayPosition(new int[] { this._pos_x, this._pos_y, this._pos_z.Value }));
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// PosOffset
        /// </summary>
        /// <param name="pos_x"></param>
        /// <param name="pos_y"></param>
        public PosOffset(short position, int pos_x, int pos_y)
        {
            this._position = position;
            this._pos_x = pos_x;
            this._pos_y = pos_y;
        }

        /// <summary>
        /// PosOffset
        /// </summary>
        /// <param name="pos_x"></param>
        /// <param name="pos_y"></param>
        /// <param name="pos_z"></param>
        public PosOffset(short position, int pos_x, int pos_y, int? pos_z)
            : this(position, pos_x, pos_y)
        {
            this._pos_z = pos_z;
        }

        /// <summary>
        /// PosOffset
        /// </summary>
        /// <param name="source"></param>
        public PosOffset(PosOffset source)
            : this(source._position, source._pos_x, source._pos_y, source._pos_z)
        { }
        #endregion

        #region ICloneable Members

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}