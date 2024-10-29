using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCM.Utility.Controls
{
    using Janus.Rodeo.Windows.Library.UI.Controls;
    using Janus.Rodeo.Windows.Library.UI.Controls.Widgets;

    public class jExpander : Expander
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="jExpander"/> class.
        /// </summary>
        public jExpander()
        { }
        #endregion

        #region properties
        public static readonly DependencyProperty CommandFilterProperty = DependencyProperty.Register("CommandFilter", typeof(ICommand), typeof(jExpander), new UIPropertyMetadata(null));

        public ICommand CommandFilter
        {
            get
            {
                return (ICommand)GetValue(CommandFilterProperty);
            }
            set
            {
                SetValue(CommandFilterProperty, value);
            }
        }
        #endregion
    }
}