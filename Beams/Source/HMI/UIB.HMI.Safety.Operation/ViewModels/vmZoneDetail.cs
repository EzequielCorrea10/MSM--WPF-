using Janus.Rodeo.Windows.Library.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.HMI.Safety.Operation.ViewModels
{
    public class vmZoneDetail : ModelViewBase
    {
        #region Constructors
        string _zone_name;
        string _beams;

        public vmZoneDetail(string zone_name, string beams)
    : base()
        {
            ZoneName = zone_name;
            Beams = beams;
        }
        #endregion

        #region Properties

        public string ZoneName
        {
            get { return this._zone_name; }
            set
            {
                if (this._zone_name != value)
                {
                    this._zone_name = value;

                    this.OnPropertyChanged("ZoneName");

                }
            }
        }

        public string Beams
        {
            get { return this._beams; }
            set
            {
                if (this._beams != value)
                {
                    this._beams = value;

                    OnPropertyChanged("Beams");

                }
            }
        }
        #endregion
    }
}
