﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.HMI.Safety.Operation.Enumerations
{
    /// <summary>
    /// Description Types
    /// </summary>
    public enum ActionRequired
    {
        /// <summary>
        /// Non action
        /// </summary>
        NonAction = 0,

        /// <summary>
        /// Manual action
        /// </summary>
        ManualAction = 1,

        /// <summary>
        /// Auto action
        /// </summary>
        AutoAction = 2,

    }
}