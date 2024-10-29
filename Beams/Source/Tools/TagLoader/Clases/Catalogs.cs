using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSM.Database;

namespace TagLoader.Clases
{
    internal class Catalogs
    {
        /// <summary>
        /// list of to client types in the systems
        /// </summary>
        public Dictionary<int, Rodeo_Client_Type> _client_types;

        /// <summary>
        /// list of to clients in the systems
        /// </summary>
        public Dictionary<int, Rodeo_Client> _clients;

    }
}
