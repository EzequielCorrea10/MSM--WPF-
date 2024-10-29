using Janus.Rodeo.Windows.Library.Rd_Log;
using Janus.Rodeo.Windows.Library.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSM.HMI.Safety.Operation.ViewModels
{
    public class Beam
    {

        #region private attribute

        /// <summary>
        /// _name
        /// </summary>
        private string _name;

        /// <summary>
        /// _name
        /// </summary>
        private string _zone;

        #endregion

        #region public properties

        /// <summary>
        /// Verify if Pickup is allowed
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Length
        /// </summary>
        public string Zone
        {
            get { return _zone; }
            set { _zone = value; }
        }


        #endregion

        #region constructors
        /// <summary>
        /// Initializes a machine
        /// </summary>
        /// <param name="machine"></param>
        public Beam(string name, string zone)
        {
            _name = name;
            _zone = zone;
        }
        #endregion

    }
}
