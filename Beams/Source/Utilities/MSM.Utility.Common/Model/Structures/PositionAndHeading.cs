using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Utility.Common.Structures
{
    using MSM.Utility.Common.Catalogs;

    /// <summary>
    /// PositionAndHeading
    /// </summary>
    public class PositionAndHeading : Position
    {
        #region private attribute
        /// <summary>
        /// heading
        /// </summary>
        private short _heading;
        #endregion

        #region public properties
        /// <summary>
        /// Heading
        /// </summary>
        public short Heading
        {
            get { return _heading; }
            set { _heading = value; }
        }

        #endregion

        #region constructors
        /// <summary>
        /// PositionAndHeading
        /// </summary>
        /// <param name="name"></param>
        /// <param name="yard_name"></param>
        /// <param name="pos_x"></param>
        /// <param name="pos_y"></param>
        public PositionAndHeading(string name, string yard_name, int pos_x, int pos_y)
            : base(name, yard_name, pos_x, pos_y)
        { }

        /// <summary>
        /// PositionAndHeading
        /// </summary>
        /// <param name="name"></param>
        /// <param name="yard_name"></param>
        /// <param name="pos_x"></param>
        /// <param name="pos_y"></param>
        /// <param name="pos_z"></param>
        /// <param name="heading"></param>
        public PositionAndHeading(string name, string yard_name, int pos_x, int pos_y, int? pos_z, short heading)
            : base(name, yard_name, pos_x, pos_y, pos_z)
        {
            this._heading = heading;
        }

        /// <summary>
        /// PositionAndHeading
        /// </summary>
        /// <param name="source"></param>
        /// <param name="heading"></param>
        public PositionAndHeading(Position source, short heading)
            : this(source.Name, source.YardName, source.PosX, source.PosY, source.PosZ, heading)
        { }

        /// <summary>
        /// PositionAndHeading
        /// </summary>
        /// <param name="source"></param>
        public PositionAndHeading(PositionAndHeading source)
            : this(source.Name, source.YardName, source.PosX, source.PosY, source.PosZ, source.Heading)
        { }
        
        /// <summary>
        /// PositionAndHeading
        /// </summary>
        /// <param name="source"></param>
        public PositionAndHeading(MSM.Utility.Common.Messages.MsgPositionAndHeading source)
            : this(string.Empty, source.yard_name, source.pos_x, source.pos_y, source.pos_z, source.heading_position)
        { }
        #endregion

        #region public methods
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="another"></param>
        /// <returns></returns>
        public bool EqualValues(PositionAndHeading another)
        {
            if (another == null)
            {
                return false;
            }

            if (this.Heading != another._heading)
            {
                return false;
            }

            return base.EqualValues((Position)another);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="another"></param>
        /// <returns></returns>
        public bool EqualValues(MSM.Utility.Common.Messages.MsgPositionAndHeading another)
        {
            if (another == null)
            {
                return false;
            }

            if (this.Heading != another.heading_position)
            {
                return false;
            }

            return base.EqualValues((MSM.Utility.Common.Messages.MsgPosition)another);
        }
        #endregion

        #region ICloneable Members

        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}