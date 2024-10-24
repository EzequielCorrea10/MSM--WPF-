using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.DBToXML.Server.Model
{
    /// <summary>
    ///  Event when status cycle executed
    /// </summary>
    internal class OnCycleExecutedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnCycleExecutedEventArgs"/> class.
        /// </summary>
        /// <param name="eventDateTime"></param>
        public OnCycleExecutedEventArgs(
            DateTimeOffset eventDateTime)
        {
            this.EventDateTime = eventDateTime;
        }

        /// <summary>
        /// Gets EventDateTime.
        /// </summary>
        public DateTimeOffset EventDateTime { get; private set; }

        /// <summary>
        /// Gets ToString().
        /// </summary>
        public override string ToString()
        {
            return string.Format("EventDateTime: {0}", this.EventDateTime);
        }
    }
}
