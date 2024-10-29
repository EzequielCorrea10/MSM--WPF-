using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.Database
{
    public partial class HSM_Failures_History
    {
        /// <summary>
        /// Gets is active
        /// </summary>
        public bool? IsActive
        {
            get { return (this.TimeOff == null); }
        }

        /// <summary>
        /// Gets is active
        /// </summary>
        public string IsActiveFormat
        {
            get { return (this.TimeOff == null) ? "YES" : "NO"; }
        }

        /// <summary>
        /// Gets is active
        /// </summary>
        public string IsForceFormat
        {
            get
            {
                if (this.IsCloseForced == true)
                {
                    return "YES";
                }

                return "NO";
            }
        }
    }
}
