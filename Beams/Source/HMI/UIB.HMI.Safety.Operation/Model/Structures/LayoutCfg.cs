using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCM.HMI.Safety.Operation.Structures
{
    /// <summary>
    /// Layoutcfg
    /// </summary>
    internal class LayoutCfg
    {
        #region attributes
        /// <summary>
        /// Name
        /// </summary>
        private string _name;
        /// <summary>
        /// _pos_x
        /// </summary>
        private int _pos_x;

        /// <summary>
        /// _pos_y
        /// </summary>
        private int _pos_y;

        #endregion

        #region public properties
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        /// PosY
        /// </summary>
        public int PosY
        {
            get { return _pos_y; }
            set { _pos_y = value; }
        }


        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutCfg"/> class.
        /// </summary>
        /// <param name="pos_x"></param>
        /// <param name="pos_y"></param>
        public LayoutCfg(string name, int pos_x, int pos_y)
        {
            this._name = name;
            this._pos_x = pos_x;
            this._pos_y = pos_y;
        }
        #endregion
    }
}
