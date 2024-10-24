using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.DBToXML.Server.Model.Structures
{
    /// <summary>
    /// store all the catalog required on realtime and cannot change
    /// </summary>
    internal class Catalogs
    {
        /// <summary>
        /// list of clients in the systems
        /// </summary>
        public MSM.Sys.Server.Common.Catalogs.CT_Client[] _clients;

        /// <summary>
        /// list of clients in the systems
        /// </summary>
        public Dictionary<string, MSM.Sys.Server.Common.Catalogs.CT_Client> _dict_clients;
    }
}