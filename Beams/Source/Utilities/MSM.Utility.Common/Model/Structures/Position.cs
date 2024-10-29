using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCM.Utility.Common.Structures
{
    using HCM.Utility.Common.Handlers;
    using HCM.Utility.Common.Enumerations;
    using HCM.Utility.Common.Catalogs;

    /// <summary>
    /// Position
    /// </summary>
    public class Position : ICloneable
    {
        #region private attribute
        /// <summary>
        /// name
        /// </summary>
        private string _name;

        /// <summary>
        /// yard_name
        /// </summary>
        private string _yard_name;

        /// <summary>
        /// _yard
        /// </summary>
        private CT_Yard _yard;

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

        /// <summary>
        /// heading position
        /// </summary>
        private short? _heading;
        #endregion

        #region public properties
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        /// <summary>
        /// YardName
        /// </summary>
        public string YardName
        {
            get { return _yard_name; }
            private set { _yard_name = value; }
        }

        /// <summary>
        /// PosX
        /// </summary>
        public int PosX
        {
            get { return _pos_x; }
            set { _pos_x = value; }
        }

        /// <summary>
        /// AbsolutePosX
        /// </summary>
        public int AbsolutePosX
        {
            get { return _pos_x + (this._yard != null? this._yard.AbsolutePosX1 : 0); }
        }

        /// <summary>
        /// PosY
        /// </summary>
        public int PosY
        {
            get { return _pos_y; }
            set { _pos_y = value; }
        }

        /// <summary>
        /// AbsPosY
        /// </summary>
        public int AbsolutePosY
        {
            get { return _pos_y + (this._yard != null ? this._yard.AbsolutePosY1 : 0); }
        }

        /// <summary>
        /// PosZ
        /// </summary>
        public int? PosZ
        {
            get { return _pos_z; }
            set { _pos_z = value; }
        }

        /// <summary>
        /// Heading
        /// </summary>
        public short? Heading
        {
            get { return _heading; }
            set { _heading = value; }
        }

        public virtual string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(this._name))
                {
                    if (this._pos_z == null)
                        return string.Format("({0}) {1}", this._yard_name, EngineeringUnitHandler.GetDisplayPosition(new int[] { this._pos_x, this._pos_y }));
                    else
                        return string.Format("({0}) {1}", this._yard_name, EngineeringUnitHandler.GetDisplayPosition(new int[] { this._pos_x, this._pos_y, this._pos_z.Value }));
                }
                else
                    return this._name;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Position
        /// </summary>
        /// <param name="name"></param>
        /// <param name="yard_name"></param>
        /// <param name="pos_x"></param>
        /// <param name="pos_y"></param>
        public Position(string name, string yard_name, int pos_x, int pos_y)
        {
            this._name = name;
            this._yard_name = yard_name;

            this._yard = DBAccessBase.GetYards().FirstOrDefault(p=>p.Name == yard_name);

            this._pos_x = pos_x;
            this._pos_y = pos_y;
        }

        /// <summary>
        /// Position
        /// </summary>
        /// <param name="name"></param>
        /// <param name="yard_name"></param>
        /// <param name="pos_x"></param>
        /// <param name="pos_y"></param>
        /// <param name="pos_z"></param>
        public Position(string name, string yard_name, int pos_x, int pos_y, int? pos_z)
            : this(name, yard_name, pos_x, pos_y)
        {
            this._pos_z = pos_z;
        }

        /// <summary>
        /// Position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="heading"></param>
        /// <param name="yard_name"></param>
        public Position(int x, int y, int? z, short heading, string yard_name = HCM.Utility.Common.Constants.Configuration.Y_SEMIAUTOMATIC)
        {
            this._pos_x = x;
            this._pos_y = y;
            this._pos_z = z;
            this._heading = heading;
            this._yard = DBAccessBase.GetYards().FirstOrDefault(p => p.Name == yard_name);
        }

        /// <summary>
        /// Position
        /// </summary>
        /// <param name="source"></param>
        public Position(Position source)
            : this(source._name, source._yard_name, source._pos_x, source._pos_y, source._pos_z)
        { }

        /// <summary>
        /// Position
        /// </summary>
        /// <param name="source"></param>
        public Position(HCM.Utility.Common.Messages.MsgPosition source)
            : this(source.name, source.yard_name, source.pos_x, source.pos_y, source.pos_z)
        { }
        #endregion

        #region public methods
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="another"></param>
        /// <returns></returns>
        public bool EqualValues(Position another)
        {
            if (another == null)
            {
                return false;
            }

            if (this._yard_name != another._yard_name)
            {
                return false;
            }

            if (this._pos_x != another._pos_x)
            {
                return false;
            }

            if (this._pos_y != another._pos_y)
            {
                return false;
            }

            if (this._pos_z != another._pos_z)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="another"></param>
        /// <returns></returns>
        public bool EqualValues(HCM.Utility.Common.Messages.MsgPosition another)
        {
            if (another == null)
            {
                return false;
            }

            if (this._yard_name != another.yard_name)
            {
                return false;
            }

            if (this._pos_x != another.pos_x)
            {
                return false;
            }

            if (this._pos_y != another.pos_y)
            {
                return false;
            }

            if (this._pos_z != another.pos_z)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ICloneable Members

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}