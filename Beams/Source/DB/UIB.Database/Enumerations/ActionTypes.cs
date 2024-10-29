using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCM.Database
{
    /// <summary>
    /// types of actions for Database
    /// </summary>
    internal enum ActionTypes : int
    {
        /// <summary>
        /// Insert
        /// </summary>
        Insert = 1,

        /// <summary>
        /// Delete
        /// </summary>
        Delete = 2,

        /// <summary>
        /// Update
        /// </summary>
        Update = 3
    }
}
