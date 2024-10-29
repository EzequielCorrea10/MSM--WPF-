using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCM.Database
{
    /// <summary>
    /// partial class of step
    /// </summary>
    partial class Rodeo_TO_Step
    {
        #region public properties
        public int XPos
        {
            get
            {
                return this.XPosEnd ?? this.XPosBegin;
            }
        }

        public int YPos
        {
            get
            {
                return this.YPosEnd ?? this.YPosBegin;
            }
        }

        public int? ZPos
        {
            get
            {
                return this.ZPosEnd ?? this.ZPosBegin;
            }
        }

        public int Heading
        {
            get
            {
                return this.HeadingEnd ?? this.HeadingBegin;
            }
        }
        #endregion
    }
}
