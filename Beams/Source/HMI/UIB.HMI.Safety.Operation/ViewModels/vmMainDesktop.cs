using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MSM.HMI.Safety.Operation.ViewModels
{
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using Janus.Rodeo.Windows.Library.Rd_Log;

    using MSM.Utility.Configuration;
    using MSM.Utility.Common;

    internal class vmMainDesktop : vmMainCommon
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="vmMainDesktop"/> class.
        /// </summary>
        public vmMainDesktop(bool can_close)
            : base(can_close)
        { }
        #endregion
    }
}
