using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MSM.Utility.Controls.Behaviours
{
    public class TouchDeviceMouseOver : DependencyObject
    {
        #region enable property
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(TouchDeviceMouseOver), new UIPropertyMetadata(false, IsEnabledChanged));

        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }

        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = d as FrameworkElement;
            if (target == null) return;

            if ((bool)e.NewValue)
            {
                target_Loaded(target, new RoutedEventArgs());
            }
            else
            {
                target_Unloaded(target, new RoutedEventArgs());
            }
        }
        #endregion

        #region events
        static void target_Loaded(object sender, RoutedEventArgs e)
        {
            var target = sender as FrameworkElement;
            if (target == null) return;

            target.Unloaded += target_Unloaded;

            var element = sender as UIElement;
            if (element != null)
            {
                element.StylusDown += target_StylusDown;
                element.StylusUp += target_StylusUp;
            }
        }

        static void target_Unloaded(object sender, RoutedEventArgs e)
        {
            var target = sender as FrameworkElement;
            if (target == null) return;

            target.Unloaded -= target_Unloaded;

            var element = sender as UIElement;
            if (element != null)
            {
                element.StylusDown -= target_StylusDown;
                element.StylusUp -= target_StylusUp;
            }
        }

        private static void target_StylusDown(object sender, StylusEventArgs e)
        {
            var target = sender as FrameworkElement;
            if (target != null)
            {
                if (!VisualStateManager.GoToElementState(target, "MouseOver", true))
                {
                    VisualStateManager.GoToState(target, "MouseOver", true);
                }
            }
        }

        private static void target_StylusUp(object sender, StylusEventArgs e)
        {
            var target = sender as FrameworkElement;
            if (target != null)
            {
                if (!VisualStateManager.GoToElementState(target, "Normal", true))
                {
                    VisualStateManager.GoToState(target, "Normal", true);
                }
            }
        }
        #endregion
    }
}
