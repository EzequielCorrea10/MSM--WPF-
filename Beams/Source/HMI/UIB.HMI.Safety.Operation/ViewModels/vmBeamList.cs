using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Janus.Rodeo.Windows.Library.UI.Controls;
using System;
using Janus.Rodeo.Windows.Library.UI.Controls.Helpers;
using System.Windows.Input;
using HSM.HMI.Safety.Operation.Views.Windows;
using System.Collections.ObjectModel;

namespace HSM.HMI.Safety.Operation.ViewModels
{
    public class vmBeamList: ModelViewBase
    {
        string _name;
        int? _posY;

        public vmBeamList(Beam beam)
: base()
        {
            Name = beam.Name;
            PosY = beam.PositionY;

        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (this._name != value)
                {
                    this._name = value;

                    this.OnPropertyChanged("Name");
                }
            }
        }

        public int? PosY
        {
            get { return this._posY; }
            set
            {
                if (this._posY != value)
                {
                    this._posY = value;

                    OnPropertyChanged("PosY");
                }
            }
        }


        public void OpenUpdateBeam(Beam beam)
        {
            List<Beam> beams = new List<Beam>();

            vmZoneDetail generalDetails = new vmZoneDetail(beam);
            ZoneDetail zoneDetail = new ZoneDetail(beam, beams);
            zoneDetail.ShowDialog();

        }
    }
}
