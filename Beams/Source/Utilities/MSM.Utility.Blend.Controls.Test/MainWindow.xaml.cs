using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSM.Utility.Blend.Controls.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public double _rotation = 90;
        public double Rotation
        {
            get { return _rotation; }
            set
            {
                //if (value != _rotation)
                {
                    _rotation = value;
                    //cgrabb.Rotation = value;
                    OnPropertyChanged("Rotation");
                }
            }
        }

        public bool _hasPiece;
        public bool HasPiece
        {
            get { return _hasPiece; }
            set
            {
                //if (value != _hasPiece)
                {
                    _hasPiece = value;
                    //cgrabb.PieceCaught = value;
                    OnPropertyChanged("HasPiece");
                }
            }
        }

        public bool _wrapped;
        public bool Wrapped
        {
            get { return _wrapped; }
            set
            {
                //if (value != _wrapped)
                {
                    _wrapped = value;
                    //cgrabb.PieceWrapped = value;
                    OnPropertyChanged("Wrapped");
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            //chook.PieceWrapped = true;
            //chook.PieceCaught = true;
        }

        #region Property Changed
        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
