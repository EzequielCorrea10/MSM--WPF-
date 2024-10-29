using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace HCM.HMI.Safety.Operation.Behaviours
{
    using HCM.HMI.Safety.Operation.ViewModels;

    public class TouchConstants
    {
        public const double MIN_SCALE = 1;
        public const double MAX_SCALE = 10;

        public const string MOUSE_EVENT_NAME = "MOUSE_{0}";
        public const string TOUCH_EVENT_NAME = "TOUCH_{0}";
        public const string MANIPULATION_EVENT_NAME = "MANIPULATION_{0}";
    }

    public class TouchScrolling : DependencyObject
    {
        #region private attributes
        static ConcurrentDictionary<object, MouseCapture> _captures = new ConcurrentDictionary<object, MouseCapture>();

        internal class MouseCapture
        {
            public double HorizontalOffset { get; set; }
            public double VerticalOffset { get; set; }
            public Point Point { get; set; }
            public ManipulationDelta DeltaManipulation { get; set; }
        }
        #endregion

        #region enable property
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(TouchScrolling), new UIPropertyMetadata(false, IsEnabledChanged));

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
            var target = d as ScrollViewer;
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

        #region zoom property
        internal static readonly DependencyProperty ScaleZoomProperty = DependencyProperty.RegisterAttached("ScaleZoom", typeof(ScaleTransform), typeof(TouchScrolling), new PropertyMetadata(null));
        internal static ScaleTransform GetScaleZoom(UIElement element)
        {
            return (ScaleTransform)element.GetValue(ScaleZoomProperty);
        }

        internal static void SetScaleZoom(UIElement element, ScaleTransform value)
        {
            element.SetValue(ScaleZoomProperty, value);
        }

        internal ScaleTransform ScaleZoom
        {
            get { return (ScaleTransform)this.GetValue(ScaleZoomProperty); }
            set { this.SetValue(ScaleZoomProperty, value); }
        }
        #endregion

        #region events
        static void target_Loaded(object sender, RoutedEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            //target.Unloaded += target_Unloaded;
            //target.IsManipulationEnabled = true;

            target.PreviewMouseLeftButtonDown += target_PreviewMouseButtonDown;
            target.PreviewMouseMove += target_PreviewMouseMove;
            target.PreviewMouseLeftButtonUp += target_PreviewMouseButtonUp;

            //target.PreviewTouchDown += target_PreviewTouchDown;
            //target.PreviewTouchMove += target_PreviewTouchMove;
            //target.PreviewTouchUp += target_PreviewTouchUp;

            //target.ManipulationStarted += target_OnManipulationStarted;
            //target.ManipulationDelta += target_OnManipulationDelta;
            //target.ManipulationCompleted += target_OnManipulationCompleted;

            target.PreviewMouseRightButtonDown += target_PreviewMouseRightButtonDown;
            target.PreviewMouseDoubleClick += Target_PreviewMouseDoubleClick;
        }

        static void target_Unloaded(object sender, RoutedEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            //target.Unloaded -= target_Unloaded;
            //target.IsManipulationEnabled = false;

            target.PreviewMouseLeftButtonDown -= target_PreviewMouseButtonDown;
            target.PreviewMouseMove -= target_PreviewMouseMove;
            target.PreviewMouseLeftButtonUp -= target_PreviewMouseButtonUp;

            //target.PreviewTouchDown -= target_PreviewTouchDown;
            //target.PreviewTouchMove -= target_PreviewTouchMove;
            //target.PreviewTouchUp -= target_PreviewTouchUp;

            //target.ManipulationStarted -= target_OnManipulationStarted;
            //target.ManipulationDelta -= target_OnManipulationDelta;
            //target.ManipulationCompleted -= target_OnManipulationCompleted;

            target.PreviewMouseRightButtonDown -= target_PreviewMouseRightButtonDown;
            target.MouseDoubleClick -= Target_PreviewMouseDoubleClick;
        }

        static void target_PreviewMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.MOUSE_EVENT_NAME, target.Name);

            MouseCapture capture = _captures.GetOrAdd(key, new MouseCapture());
            capture.HorizontalOffset = target.HorizontalOffset;
            capture.VerticalOffset = target.VerticalOffset;
            capture.Point = e.GetPosition(target);
        }

        static void target_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.TOUCH_EVENT_NAME, target.Name);

            MouseCapture capture = _captures.GetOrAdd(key, new MouseCapture());
            capture.HorizontalOffset = target.HorizontalOffset;
            capture.VerticalOffset = target.VerticalOffset;
            capture.Point = e.GetTouchPoint(target).Position;
        }

        static void target_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            string key = string.Format(TouchConstants.MOUSE_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryGetValue(key, out capture))
            {
                var point = e.GetPosition(target);

                var dx = point.X - capture.Point.X;
                var dy = point.Y - capture.Point.Y;
                if (Math.Abs(dx) > 5 || Math.Abs(dy) > 5)
                {
                    target.CaptureMouse();
                }

                target.ScrollToHorizontalOffset(capture.HorizontalOffset - dx);
                target.ScrollToVerticalOffset(capture.VerticalOffset - dy);
            }
        }

        static void target_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.TOUCH_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryGetValue(key, out capture))
            {
                var point = e.GetTouchPoint(target).Position;

                var dx = point.X - capture.Point.X;
                var dy = point.Y - capture.Point.Y;
                if (Math.Abs(dx) > 5 || Math.Abs(dy) > 5)
                {
                    target.CaptureTouch(e.TouchDevice);
                }

                target.ScrollToHorizontalOffset(capture.HorizontalOffset - dx);
                target.ScrollToVerticalOffset(capture.VerticalOffset - dy);
            }
        }

        static void target_PreviewMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            target.ReleaseMouseCapture();

            string key = string.Format(TouchConstants.MOUSE_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryRemove(key, out capture))
            { }
        }

        static void target_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            target.ReleaseTouchCapture(e.TouchDevice);

            string key = string.Format(TouchConstants.TOUCH_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryRemove(key, out capture))
            { }
        }

        static void target_OnManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            ScaleTransform scaleZoom = GetScaleZoom(target);
            if (scaleZoom != null)
            {
                string key = string.Format(TouchConstants.MANIPULATION_EVENT_NAME, target.Name);

                MouseCapture capture = _captures.GetOrAdd(key, new MouseCapture());
                capture.Point = e.ManipulationOrigin;
            }
        }

        static private void target_OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.MANIPULATION_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryGetValue(key, out capture))
            {
                capture.DeltaManipulation = e.DeltaManipulation;

                if (Math.Abs(capture.DeltaManipulation.Scale.X - 1) > 0.1 || Math.Abs(capture.DeltaManipulation.Scale.Y - 1) > 0.1)
                {
                    CalculateZoom(target, capture);
                }
                else if (capture.DeltaManipulation.Translation.X != 0 || capture.DeltaManipulation.Translation.Y != 0)
                {
                    target.ScrollToHorizontalOffset(target.HorizontalOffset - capture.DeltaManipulation.Translation.X);
                    target.ScrollToVerticalOffset(target.VerticalOffset - capture.DeltaManipulation.Translation.Y);

                    capture.Point = new Point(capture.Point.X + capture.DeltaManipulation.Translation.X,
                                              capture.Point.Y + capture.DeltaManipulation.Translation.Y);
                }
            }
        }

        static void target_OnManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.MANIPULATION_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryRemove(key, out capture))
            { }
        }

        static void target_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            ResetZoom(target, e.GetPosition(target));
        }

        static void Target_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            if (e.RightButton != MouseButtonState.Pressed)
            {
                return;
            }

            ResetZoom(target, e.GetPosition(target));
        }
        #endregion

        #region private method
        static void CalculateZoom(ScrollViewer target, MouseCapture capture)
        {
            try
            {
                ScaleTransform scaleZoom = GetScaleZoom(target);
                if (scaleZoom != null)
                {
                    if (capture.DeltaManipulation.Scale.X > 1 && capture.DeltaManipulation.Scale.Y > 1)
                    {
                        if (scaleZoom.ScaleX >= TouchConstants.MAX_SCALE && scaleZoom.ScaleY >= TouchConstants.MAX_SCALE)
                        {
                            return;
                        }
                    }

                    var original_point_x = (capture.Point.X + target.HorizontalOffset) / scaleZoom.ScaleX;
                    var original_point_y = (capture.Point.Y + target.VerticalOffset) / scaleZoom.ScaleY;

                    scaleZoom.ScaleX *= capture.DeltaManipulation.Scale.X;
                    scaleZoom.ScaleY *= capture.DeltaManipulation.Scale.Y;

                    if (scaleZoom.ScaleX < TouchConstants.MIN_SCALE)
                    {
                        scaleZoom.ScaleX = TouchConstants.MIN_SCALE;
                    }
                    else if (scaleZoom.ScaleX > TouchConstants.MAX_SCALE)
                    {
                        scaleZoom.ScaleX = TouchConstants.MAX_SCALE;
                    }

                    if (scaleZoom.ScaleY < TouchConstants.MIN_SCALE)
                    {
                        scaleZoom.ScaleY = TouchConstants.MIN_SCALE;
                    }
                    else if (scaleZoom.ScaleY > TouchConstants.MAX_SCALE)
                    {
                        scaleZoom.ScaleY = TouchConstants.MAX_SCALE;
                    }

                    var new_point_x = (original_point_x * scaleZoom.ScaleX);
                    var new_point_y = (original_point_y * scaleZoom.ScaleY);

                    target.ScrollToHorizontalOffset(new_point_x - capture.Point.X);
                    target.ScrollToVerticalOffset(new_point_y - capture.Point.Y);
                }
            }
            catch { }
        }

        static void ResetZoom(ScrollViewer target, Point point)
        {
            try
            {
                ScaleTransform scaleZoom = GetScaleZoom(target);

                vmLayout data = target.DataContext as vmLayout;

                if (data.GeneralLayout)
                {
                    if (scaleZoom != null)
                    {
                        var original_point_x = (point.X + target.HorizontalOffset) / scaleZoom.ScaleX;
                        var original_point_y = (point.Y + target.VerticalOffset) / scaleZoom.ScaleY;

                        scaleZoom.ScaleX = 1;
                        scaleZoom.ScaleY = 1;

                        var new_point_x = (original_point_x * scaleZoom.ScaleX);
                        var new_point_y = (original_point_y * scaleZoom.ScaleY);

                        target.ScrollToHorizontalOffset(new_point_x - point.X);
                        target.ScrollToVerticalOffset(new_point_y - point.X);
                    }

                }
                else 
                {                   
                    var original_border_x0 = target.HorizontalOffset / scaleZoom.ScaleX;
                    var original_border_x1 = (target.HorizontalOffset + target.Width) / scaleZoom.ScaleX;
                    var original_border_y1 = (target.VerticalOffset + target.Height) / scaleZoom.ScaleY;

                    scaleZoom.ScaleX = 1;
                    scaleZoom.ScaleY = 1;    

                    var new_border_x0 = (original_border_x0 * scaleZoom.ScaleX);
                    
                    var new_border_x1 = (original_border_x1 * scaleZoom.ScaleX);

                    var diff_x = (new_border_x1 - new_border_x0);
                    int yardId = 0;
                    //foreach (vmYard yard in data.Yards) 
                    //{
                    //    if (yard.Enabled) 
                    //    {
                    //        yardId = yard.Properties.Id;
                    //        break;                        
                    //    }                                            
                    //}

                    target.ScrollToHorizontalOffset(new_border_x0 + (diff_x - target.Width) / 2);
                    double y_post = (target.ActualHeight * (yardId - 1));
                    target.ScrollToVerticalOffset(y_post);
                }

                
            }
            catch { }
        }
        #endregion
    }

    public class TouchDrawing : DependencyObject
    {
        #region private attributes
        static ConcurrentDictionary<object, MouseCapture> _captures = new ConcurrentDictionary<object, MouseCapture>();

        internal class MouseCapture
        {
            public double HorizontalOffset { get; set; }
            public double VerticalOffset { get; set; }
            public Point InitialPoint { get; set; }
            public Point EndPoint { get; set; }
        }
        #endregion

        #region enable property
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(TouchDrawing), new UIPropertyMetadata(false, IsEnabledChanged));

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
            var target = d as ScrollViewer;
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

        #region temporary drawing property
      //  internal static readonly DependencyProperty TemporaryDrawingProperty = DependencyProperty.RegisterAttached("TemporaryDrawing", typeof(vmZoneTemporaryDrawing), typeof(TouchDrawing), new PropertyMetadata(null));

        //internal static vmZoneTemporaryDrawing GetTemporaryDrawing(DependencyObject element)
        //{
        //    return (vmZoneTemporaryDrawing)element.GetValue(TemporaryDrawingProperty);
        //}

        //internal static void SetTemporaryDrawing(DependencyObject element, vmZoneTemporaryDrawing value)
        //{
        //    element.SetValue(TemporaryDrawingProperty, value);
        //}

        //internal vmZoneTemporaryDrawing TemporaryDrawing
        //{
        //    get { return (vmZoneTemporaryDrawing)GetValue(TemporaryDrawingProperty); }
        //    set { SetValue(TemporaryDrawingProperty, value); }
        //}
        #endregion

        #region size property
        internal static readonly DependencyProperty LayoutWidthProperty = DependencyProperty.RegisterAttached("LayoutWidth", typeof(double), typeof(TouchDrawing), new PropertyMetadata((double)0));
        internal static double GetLayoutWidth(UIElement element)
        {
            return (double)element.GetValue(LayoutWidthProperty);
        }

        internal static void SetLayoutWidth(UIElement element, double value)
        {
            element.SetValue(LayoutWidthProperty, value);
        }

        internal double LayoutWidth
        {
            get { return (double)this.GetValue(LayoutWidthProperty); }
            set { this.SetValue(LayoutWidthProperty, value); }
        }

        internal static readonly DependencyProperty LayoutHeightProperty = DependencyProperty.RegisterAttached("LayoutHeight", typeof(double), typeof(TouchDrawing), new PropertyMetadata((double)0));
        internal static double GetLayoutHeight(UIElement element)
        {
            return (double)element.GetValue(LayoutHeightProperty);
        }

        internal static void SetLayoutHeight(UIElement element, double value)
        {
            element.SetValue(LayoutHeightProperty, value);
        }
        internal double LayoutHeight
        {
            get { return (double)this.GetValue(LayoutHeightProperty); }
            set { this.SetValue(LayoutHeightProperty, value); }
        }

        internal static readonly DependencyProperty LayoutGeneralWidthProperty = DependencyProperty.RegisterAttached("LayoutGeneralWidth", typeof(double), typeof(TouchDrawing), new PropertyMetadata((double)0));
        internal static double GetLayoutGeneralWidth(UIElement element)
        {
            return (double)element.GetValue(LayoutGeneralWidthProperty);
        }

        internal static void SetLayoutGeneralWidth(UIElement element, double value)
        {
            element.SetValue(LayoutGeneralWidthProperty, value);
        }

        internal double LayoutGeneralWidth
        {
            get { return (double)this.GetValue(LayoutGeneralWidthProperty); }
            set { this.SetValue(LayoutGeneralWidthProperty, value); }
        }

        internal static readonly DependencyProperty LayoutGeneralHeightProperty = DependencyProperty.RegisterAttached("LayoutGeneralHeight", typeof(double), typeof(TouchDrawing), new PropertyMetadata((double)0));
        internal static double GetLayoutGeneralHeight(UIElement element)
        {
            return (double)element.GetValue(LayoutGeneralHeightProperty);
        }

        internal static void SetLayoutGeneralHeight(UIElement element, double value)
        {
            element.SetValue(LayoutGeneralHeightProperty, value);
        }
        internal double LayoutGeneralHeight
        {
            get { return (double)this.GetValue(LayoutGeneralHeightProperty); }
            set { this.SetValue(LayoutGeneralHeightProperty, value); }
        }

        internal static readonly DependencyProperty LayoutGeneralProperty = DependencyProperty.RegisterAttached("LayoutGeneral", typeof(bool), typeof(TouchDrawing), new PropertyMetadata((bool)false));
        internal static bool GetLayoutGeneral(UIElement element)
        {
            return (bool)element.GetValue(LayoutGeneralProperty);
        }

        internal static void SetLayoutGeneral(UIElement element, bool value)
        {
            element.SetValue(LayoutGeneralProperty, value);
        }
        internal bool LayoutGeneral
        {
            get { return (bool)this.GetValue(LayoutGeneralProperty); }
            set { this.SetValue(LayoutGeneralProperty, value); }
        }
        #endregion

        #region zoom property
        internal static readonly DependencyProperty LayoutScaleProperty = DependencyProperty.RegisterAttached("LayoutScale", typeof(ScaleTransform), typeof(TouchDrawing), new PropertyMetadata(null));
        internal static ScaleTransform GetLayoutScale(UIElement element)
        {
            return (ScaleTransform)element.GetValue(LayoutScaleProperty);
        }

        internal static void SetLayoutScale(UIElement element, ScaleTransform value)
        {
            element.SetValue(LayoutScaleProperty, value);
        }

        internal ScaleTransform LayoutScale
        {
            get { return (ScaleTransform)this.GetValue(LayoutScaleProperty); }
            set { this.SetValue(LayoutScaleProperty, value); }
        }
        #endregion

        #region events
        static void target_Loaded(object sender, RoutedEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            //target.Unloaded += target_Unloaded;

            target.PreviewMouseLeftButtonDown += target_PreviewMouseButtonDown;
            target.PreviewMouseMove += target_PreviewMouseMove;
            target.PreviewMouseLeftButtonUp += target_PreviewMouseButtonUp;

            target.PreviewTouchDown += target_PreviewTouchDown;
            target.PreviewTouchMove += target_PreviewTouchMove;
            target.PreviewTouchUp += target_PreviewTouchUp;
        }

        static void target_Unloaded(object sender, RoutedEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            //target.Unloaded -= target_Unloaded;

            target.PreviewMouseLeftButtonDown -= target_PreviewMouseButtonDown;
            target.PreviewMouseMove -= target_PreviewMouseMove;
            target.PreviewMouseLeftButtonUp -= target_PreviewMouseButtonUp;

            target.PreviewTouchDown -= target_PreviewTouchDown;
            target.PreviewTouchMove -= target_PreviewTouchMove;
            target.PreviewTouchUp -= target_PreviewTouchUp;
        }

        static void target_PreviewMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.MOUSE_EVENT_NAME, target.Name);

            MouseCapture capture = _captures.GetOrAdd(key, new MouseCapture());
            capture.HorizontalOffset = target.HorizontalOffset;
            capture.VerticalOffset = target.VerticalOffset;
            capture.InitialPoint = capture.EndPoint = e.GetPosition(target);

            CalculatePosition(target, capture);
        }

        static void target_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.TOUCH_EVENT_NAME, target.Name);

            MouseCapture capture = _captures.GetOrAdd(key, new MouseCapture());
            capture.HorizontalOffset = target.HorizontalOffset;
            capture.VerticalOffset = target.VerticalOffset;
            capture.InitialPoint = capture.EndPoint = e.GetTouchPoint(target).Position;
        }

        static void target_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            string key = string.Format(TouchConstants.MOUSE_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryGetValue(key, out capture))
            {
                capture.EndPoint = e.GetPosition(target);

                var dx = capture.EndPoint.X - capture.InitialPoint.X;
                var dy = capture.EndPoint.Y - capture.InitialPoint.Y;
                if (Math.Abs(dx) > 5 || Math.Abs(dy) > 5)
                {
                    target.CaptureMouse();
                }

                target.ScrollToHorizontalOffset(capture.HorizontalOffset);
                target.ScrollToVerticalOffset(capture.VerticalOffset);

                CalculatePosition(target, capture);
            }
        }

        static void target_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.TOUCH_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryGetValue(key, out capture))
            {
                capture.EndPoint = e.GetTouchPoint(target).Position;

                var dx = capture.EndPoint.X - capture.InitialPoint.X;
                var dy = capture.EndPoint.Y - capture.InitialPoint.Y;
                if (Math.Abs(dx) > 5 || Math.Abs(dy) > 5)
                {
                    target.CaptureTouch(e.TouchDevice);
                }

                target.ScrollToHorizontalOffset(capture.HorizontalOffset);
                target.ScrollToVerticalOffset(capture.VerticalOffset);

                CalculatePosition(target, capture);
            }
        }

        static void target_PreviewMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            target.ReleaseMouseCapture();

            string key = string.Format(TouchConstants.MOUSE_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryRemove(key, out capture))
            { }
        }

        static void target_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            target.ReleaseTouchCapture(e.TouchDevice);

            string key = string.Format(TouchConstants.TOUCH_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryRemove(key, out capture))
            { }
        }
        #endregion

        #region private method
        static void CalculatePosition(ScrollViewer target, MouseCapture capture)
        {
            try
            {
                double layout_height;
                double layout_width;
                if (GetLayoutGeneral(target))
                {
                    layout_height = GetLayoutGeneralHeight(target);
                    //layout_width = GetLayoutGeneralWidth(target);
                }
                else
                {
                    layout_height = GetLayoutHeight(target);
                    layout_width = GetLayoutWidth(target);
                }

                layout_width = GetLayoutWidth(target);


                if (layout_width > 0 && layout_height > 0)
                {
                    //vmZoneTemporaryDrawing temporary_drawing = GetTemporaryDrawing(target);
                    ScaleTransform scaleZoom = GetLayoutScale(target);
                    //if (temporary_drawing != null && scaleZoom != null)
                    //{
                    //    double initial_pos_x ;
                    //    double initial_pos_y ;
                    //    double end_pos_x  ;
                    //    double end_pos_y;

                    //    if (scaleZoom.ScaleX < 1 || scaleZoom.ScaleY < 1)
                    //    {
                    //        initial_pos_x = HCM.HMI.Safety.Operation.Converters.LayoutLeftConverter.GetRealPosition((capture.InitialPoint.X + scaleZoom.Value.OffsetX / (scaleZoom.ScaleX )), layout_width);
                    //        initial_pos_y = HCM.HMI.Safety.Operation.Converters.LayoutTopConverter.GetRealPosition((capture.InitialPoint.Y + scaleZoom.Value.OffsetY  / (scaleZoom.ScaleY )) , layout_height);
                    //        end_pos_x = HCM.HMI.Safety.Operation.Converters.LayoutLeftConverter.GetRealPosition((capture.EndPoint.X + scaleZoom.Value.OffsetX / (scaleZoom.ScaleX )) , layout_width);
                    //        end_pos_y = HCM.HMI.Safety.Operation.Converters.LayoutTopConverter.GetRealPosition((capture.EndPoint.Y + scaleZoom.Value.OffsetY / (scaleZoom.ScaleY )) , layout_height);

                    //    }
                    //    else 
                    //    {
                    //        initial_pos_x = HCM.HMI.Safety.Operation.Converters.LayoutLeftConverter.GetRealPosition((capture.InitialPoint.X + capture.HorizontalOffset) / scaleZoom.ScaleX, layout_width);
                    //        initial_pos_y = HCM.HMI.Safety.Operation.Converters.LayoutTopConverter.GetRealPosition((capture.InitialPoint.Y + capture.VerticalOffset) / scaleZoom.ScaleY, layout_height);
                    //        end_pos_x = HCM.HMI.Safety.Operation.Converters.LayoutLeftConverter.GetRealPosition((capture.EndPoint.X + capture.HorizontalOffset) / scaleZoom.ScaleX, layout_width);
                    //        end_pos_y = HCM.HMI.Safety.Operation.Converters.LayoutTopConverter.GetRealPosition((capture.EndPoint.Y + capture.VerticalOffset) / scaleZoom.ScaleY, layout_height);

                    //    }

                    //    //double initial_pos_x = HCM.HMI.Safety.Operation.Converters.LayoutLeftConverter.GetRealPosition((capture.InitialPoint.X + capture.HorizontalOffset) / scaleZoom.ScaleX, layout_width);
                    //    //double initial_pos_y = HCM.HMI.Safety.Operation.Converters.LayoutTopConverter.GetRealPosition((capture.InitialPoint.Y + capture.VerticalOffset) / scaleZoom.ScaleY, layout_height);
                    //    //double end_pos_x = HCM.HMI.Safety.Operation.Converters.LayoutLeftConverter.GetRealPosition((capture.EndPoint.X + capture.HorizontalOffset) / scaleZoom.ScaleX, layout_width);
                    //    //double end_pos_y = HCM.HMI.Safety.Operation.Converters.LayoutTopConverter.GetRealPosition((capture.EndPoint.Y + capture.VerticalOffset) / scaleZoom.ScaleY, layout_height);

                    //    if (Math.Abs(initial_pos_x - end_pos_x) < 10 && Math.Abs(initial_pos_y - end_pos_y) < 10)
                    //    {
                    //        if (temporary_drawing.Enabled && (initial_pos_x < temporary_drawing.AbsolutePosX2 && 
                    //                                          initial_pos_x > temporary_drawing.AbsolutePosX1 &&
                    //                                          initial_pos_y < temporary_drawing.AbsolutePosY2 &&
                    //                                          initial_pos_y > temporary_drawing.AbsolutePosY1))
                    //        { }
                    //        else
                    //            temporary_drawing.Enabled = false;

                    //        return;
                    //    }

                    //vmYard yardSelected = null;
                    //foreach (vmYard yard in temporary_drawing.Yards)
                    //{
                    //    if (initial_pos_y > yard.Properties.AbsolutePosY1 && initial_pos_y < yard.Properties.AbsolutePosY2)
                    //    {
                    //        yardSelected = yard;
                    //        break;
                    //    }

                    //}

                    //if (yardSelected != null)
                    //{
                    //    if (initial_pos_y > yardSelected.Properties.AbsolutePosY1 && initial_pos_y < yardSelected.Properties.AbsolutePosY2 &&
                    //        end_pos_y < yardSelected.Properties.AbsolutePosY2 && end_pos_y > yardSelected.Properties.AbsolutePosY1)
                    //    {

                    //    }
                    //    else 
                    //    {
                    //        //temporary_drawing.Enabled = false;
                    //        temporary_drawing.Enabled = true;
                    //        return;
                    //    }


                    //}

                    //        vmYard yardSelected = null;
                    //        foreach (vmYard yard in temporary_drawing.Yards)
                    //        {
                    //            if (initial_pos_y > yard.Properties.AbsolutePosY1 && initial_pos_y < yard.Properties.AbsolutePosY2 &&
                    //                initial_pos_x > yard.Properties.AbsolutePosX1 && initial_pos_x < yard.Properties.AbsolutePosX2)
                    //            {
                    //                yardSelected = yard;
                    //                break;
                    //            }
                    //        }

                    //        if (yardSelected != null)
                    //        {
                    //            if (initial_pos_y > yardSelected.Properties.AbsolutePosY1 && initial_pos_y < yardSelected.Properties.AbsolutePosY2 &&
                    //                end_pos_y < yardSelected.Properties.AbsolutePosY2 && end_pos_y > yardSelected.Properties.AbsolutePosY1 &&
                    //                initial_pos_x > yardSelected.Properties.AbsolutePosX1 && initial_pos_x < yardSelected.Properties.AbsolutePosX2 &&
                    //                end_pos_x < yardSelected.Properties.AbsolutePosX2 && end_pos_x > yardSelected.Properties.AbsolutePosX1)
                    //            { }
                    //            else
                    //            {
                    //                //temporary_drawing.Enabled = false;
                    //                temporary_drawing.Enabled = true;
                    //                return;
                    //            }

                    //            temporary_drawing.YardSelected = yardSelected;
                    //        }

                    //        if (initial_pos_x > end_pos_x)
                    //        {
                    //            temporary_drawing.AbsolutePosX1 = Math.Max(Handlers.DBAccess.Catalogs._dict_layout_cfg[Constants.Configuration.MIN_LAYOUT].PosX, (int)end_pos_x);
                    //            temporary_drawing.AbsolutePosX2 = Math.Min(Handlers.DBAccess.Catalogs._dict_layout_cfg[Constants.Configuration.MAX_LAYOUT].PosX, (int)initial_pos_x);
                    //        }
                    //        else
                    //        {
                    //            temporary_drawing.AbsolutePosX2 = Math.Min(Handlers.DBAccess.Catalogs._dict_layout_cfg[Constants.Configuration.MAX_LAYOUT].PosX, (int)end_pos_x);
                    //            temporary_drawing.AbsolutePosX1 = Math.Max(Handlers.DBAccess.Catalogs._dict_layout_cfg[Constants.Configuration.MIN_LAYOUT].PosX, (int)initial_pos_x);
                    //        }

                    //        if (initial_pos_y > end_pos_y)
                    //        {
                    //            temporary_drawing.AbsolutePosY1 = Math.Max(Handlers.DBAccess.Catalogs._dict_layout_cfg[Constants.Configuration.MIN_LAYOUT].PosY, (int)end_pos_y);
                    //            temporary_drawing.AbsolutePosY2 = Math.Min(Handlers.DBAccess.Catalogs._dict_layout_cfg[Constants.Configuration.MAX_LAYOUT].PosY, (int)initial_pos_y);
                    //        }
                    //        else
                    //        {
                    //            temporary_drawing.AbsolutePosY2 = Math.Min(Handlers.DBAccess.Catalogs._dict_layout_cfg[Constants.Configuration.MAX_LAYOUT].PosY, (int)end_pos_y);
                    //            temporary_drawing.AbsolutePosY1 = Math.Max(Handlers.DBAccess.Catalogs._dict_layout_cfg[Constants.Configuration.MIN_LAYOUT].PosY, (int)initial_pos_y);
                    //        }

                    //        temporary_drawing.Enabled = true;
                    //    }
                    //}
                }
            }
            catch { }
        }
        #endregion
    }

    public class TouchZoom : DependencyObject
    {
        #region private attributes
        static ConcurrentDictionary<object, MouseCapture> _captures = new ConcurrentDictionary<object, MouseCapture>();
        static ConcurrentDictionary<object, Stack<MouseZoom>> _zooms = new ConcurrentDictionary<object, Stack<MouseZoom>>();

        internal class MouseZoom
        {
            public double ScaleX { get; set; }
            public double ScaleY { get; set; }
            public double OffsetX { get; set; }
            public double OffsetY { get; set; }
        }

        internal class MouseCapture
        {
            public double HorizontalOffset { get; set; }
            public double VerticalOffset { get; set; }
            public double ScaleX { get; set; }
            public double ScaleY { get; set; }
            public Point InitialPoint { get; set; }
            public Point EndPoint { get; set; }
        }
        #endregion

        #region enable property
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(TouchZoom), new UIPropertyMetadata(false, IsEnabledChanged));

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
            var target = d as ScrollViewer;
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

        #region zoom property
        internal static readonly DependencyProperty ScaleZoomProperty = DependencyProperty.RegisterAttached("ScaleZoom", typeof(ScaleTransform), typeof(TouchZoom), new PropertyMetadata(null));
        internal static ScaleTransform GetScaleZoom(UIElement element)
        {
            return (ScaleTransform)element.GetValue(ScaleZoomProperty);
        }

        internal static void SetScaleZoom(UIElement element, ScaleTransform value)
        {
            element.SetValue(ScaleZoomProperty, value);
        }

        internal ScaleTransform ScaleZoom
        {
            get { return (ScaleTransform)this.GetValue(ScaleZoomProperty); }
            set { this.SetValue(ScaleZoomProperty, value); }
        }

        internal static readonly DependencyProperty RectangleZoomProperty = DependencyProperty.RegisterAttached("RectangleZoom", typeof(Border), typeof(TouchZoom), new PropertyMetadata(null));
        internal static Border GetRectangleZoom(UIElement element)
        {
            return (Border)element.GetValue(RectangleZoomProperty);
        }

        internal static void SetRectangleZoom(UIElement element, Border value)
        {
            element.SetValue(RectangleZoomProperty, value);
        }

        internal Border RectangleZoom
        {
            get { return (Border)this.GetValue(RectangleZoomProperty); }
            set { this.SetValue(RectangleZoomProperty, value); }
        }
        #endregion

        #region events
        static void target_Loaded(object sender, RoutedEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            //target.Unloaded += target_Unloaded;

            target.PreviewMouseLeftButtonDown += target_PreviewMouseButtonDown;
            target.PreviewMouseMove += target_PreviewMouseMove;
            target.PreviewMouseLeftButtonUp += target_PreviewMouseButtonUp;

            //target.PreviewTouchDown += target_PreviewTouchDown;
            //target.PreviewTouchMove += target_PreviewTouchMove;
            //target.PreviewTouchUp += target_PreviewTouchUp;

            target.PreviewMouseRightButtonDown += target_PreviewMouseRightButtonDown;
            target.PreviewMouseDoubleClick += Target_PreviewMouseDoubleClick;
        }

        static void target_Unloaded(object sender, RoutedEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            //target.Unloaded -= target_Unloaded;

            target.PreviewMouseLeftButtonDown -= target_PreviewMouseButtonDown;
            target.PreviewMouseMove -= target_PreviewMouseMove;
            target.PreviewMouseLeftButtonUp -= target_PreviewMouseButtonUp;

            //target.PreviewTouchDown -= target_PreviewTouchDown;
            //target.PreviewTouchMove -= target_PreviewTouchMove;
            //target.PreviewTouchUp -= target_PreviewTouchUp;

            target.PreviewMouseRightButtonDown -= target_PreviewMouseRightButtonDown;
            target.PreviewMouseDoubleClick -= Target_PreviewMouseDoubleClick;
        }

        static void target_PreviewMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            ScaleTransform scaleZoom = GetScaleZoom(target);
            if (scaleZoom != null)
            {
                if (scaleZoom.ScaleX >= TouchConstants.MAX_SCALE && scaleZoom.ScaleY >= TouchConstants.MAX_SCALE)
                {
                    return;
                }

                string key = string.Format(TouchConstants.MOUSE_EVENT_NAME, target.Name);

                MouseCapture capture = _captures.GetOrAdd(key, new MouseCapture());
                capture.HorizontalOffset = target.HorizontalOffset;
                capture.VerticalOffset = target.VerticalOffset;
                capture.ScaleX = scaleZoom.ScaleX;
                capture.ScaleY = scaleZoom.ScaleY;
                capture.InitialPoint = capture.EndPoint = e.GetPosition(target);
            }
        }

        static void target_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            ScaleTransform scaleZoom = GetScaleZoom(target);
            if (scaleZoom != null)
            {
                if (scaleZoom.ScaleX >= TouchConstants.MAX_SCALE && scaleZoom.ScaleY >= TouchConstants.MAX_SCALE)
                {
                    return;
                }

                string key = string.Format(TouchConstants.TOUCH_EVENT_NAME, target.Name);

                MouseCapture capture = _captures.GetOrAdd(key, new MouseCapture());
                capture.HorizontalOffset = target.HorizontalOffset;
                capture.VerticalOffset = target.VerticalOffset;
                capture.ScaleX = scaleZoom.ScaleX;
                capture.ScaleY = scaleZoom.ScaleY;
                capture.InitialPoint = capture.EndPoint = e.GetTouchPoint(target).Position;
            }
        }

        static void target_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            string key = string.Format(TouchConstants.MOUSE_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryGetValue(key, out capture))
            {
                capture.EndPoint = e.GetPosition(target);

                var dx = capture.EndPoint.X - capture.InitialPoint.X;
                var dy = capture.EndPoint.Y - capture.InitialPoint.Y;
                if (Math.Abs(dx) > 5 || Math.Abs(dy) > 5)
                {
                    target.CaptureMouse();
                }

                target.ScrollToHorizontalOffset(capture.HorizontalOffset);
                target.ScrollToVerticalOffset(capture.VerticalOffset);

                ShowZoom(target, capture);
            }
        }

        static void target_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.TOUCH_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryGetValue(key, out capture))
            {
                capture.EndPoint = e.GetTouchPoint(target).Position;

                var dx = capture.EndPoint.X - capture.InitialPoint.X;
                var dy = capture.EndPoint.Y - capture.InitialPoint.Y;
                if (Math.Abs(dx) > 5 || Math.Abs(dy) > 5)
                {
                    target.CaptureTouch(e.TouchDevice);
                }

                target.ScrollToHorizontalOffset(capture.HorizontalOffset);
                target.ScrollToVerticalOffset(capture.VerticalOffset);

                ShowZoom(target, capture);
            }
        }

        static void target_PreviewMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.MOUSE_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryRemove(key, out capture))
            {
                CalculateZoom(target, capture);
            }

            target.ReleaseMouseCapture();
        }

        static void target_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            string key = string.Format(TouchConstants.TOUCH_EVENT_NAME, target.Name);

            MouseCapture capture;
            if (_captures.TryRemove(key, out capture))
            {
                CalculateZoom(target, capture);
            }

            target.ReleaseTouchCapture(e.TouchDevice);
        }

        static void target_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            ResetZoom(target, e.GetPosition(target), false);
        }

        static void Target_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            if (e.RightButton != MouseButtonState.Pressed)
            {
                return;
            }

            ResetZoom(target, e.GetPosition(target), true);
        }
        #endregion

        #region private method
        static void ShowZoom(ScrollViewer target, MouseCapture capture)
        {
            try
            {
                Border rectZoom = GetRectangleZoom(target);
                if (rectZoom != null)
                {
                    var dx = Math.Abs(capture.EndPoint.X - capture.InitialPoint.X);
                    var dy = Math.Abs(capture.EndPoint.Y - capture.InitialPoint.Y);
                    if (dx > 50 || dy > 50)
                    {
                        rectZoom.Margin = new Thickness(Math.Min(capture.EndPoint.X, capture.InitialPoint.X) + capture.HorizontalOffset,
                                                        Math.Min(capture.EndPoint.Y, capture.InitialPoint.Y) + capture.VerticalOffset,
                                                    0, 0);
                        rectZoom.Width = Math.Abs(capture.EndPoint.X - capture.InitialPoint.X);
                        rectZoom.Height = Math.Abs(capture.EndPoint.Y - capture.InitialPoint.Y);
                        rectZoom.Visibility = Visibility.Visible;
                    }
                }
            }
            catch { }
        }

        static void CalculateZoom(ScrollViewer target, MouseCapture capture)
        {
            try
            {
                Border rectZoom = GetRectangleZoom(target);
                if (rectZoom != null)
                    rectZoom.Visibility = Visibility.Collapsed;

                ScaleTransform scaleZoom = GetScaleZoom(target);
                if (scaleZoom != null)
                {
                    var dx = Math.Abs(capture.EndPoint.X - capture.InitialPoint.X);
                    var dy = Math.Abs(capture.EndPoint.Y - capture.InitialPoint.Y);
                    if (dx > 50 || dy > 50)
                    {
                        Stack<MouseZoom> zooms = _zooms.GetOrAdd(target, new Stack<MouseZoom>());
                        zooms.Push(new MouseZoom() { ScaleX = capture.ScaleX, ScaleY = capture.ScaleY, OffsetX = capture.HorizontalOffset, OffsetY = capture.VerticalOffset });

                        var scale_dx = (dx > 0) ? target.Width / dx : 1;
                        var scale_dy = (dy > 0) ? target.Height / dy : 1;

                        var current_offset_x = Math.Min(capture.EndPoint.X, capture.InitialPoint.X) + capture.HorizontalOffset;
                        var current_offset_y = Math.Min(capture.EndPoint.Y, capture.InitialPoint.Y) + capture.VerticalOffset;

                        var original_offset_x = current_offset_x / capture.ScaleX;
                        var original_offset_y = current_offset_y / capture.ScaleY;

                        scaleZoom.ScaleX = capture.ScaleX * scale_dx;
                        scaleZoom.ScaleY = capture.ScaleY * scale_dy;

                        if (scaleZoom.ScaleX > TouchConstants.MAX_SCALE)
                        {
                            scaleZoom.ScaleX = TouchConstants.MAX_SCALE;
                        }

                        if (scaleZoom.ScaleY > TouchConstants.MAX_SCALE)
                        {
                            scaleZoom.ScaleY = TouchConstants.MAX_SCALE;
                        }

                        target.ScrollToHorizontalOffset(original_offset_x * scaleZoom.ScaleX);
                        target.ScrollToVerticalOffset(original_offset_y * scaleZoom.ScaleY);
                    }
                    else if (dx < 10 && dy < 10)
                    {
                        ResetZoom(target, capture.EndPoint, false);
                    }
                }
            }
            catch { }
        }




        static void ResetZoom(ScrollViewer target, Point point, bool all)
        {
            try
            {
                ScaleTransform scaleZoom = GetScaleZoom(target);
                if (scaleZoom != null)
                {
                    Stack<MouseZoom> zooms;
                    if (_zooms.TryGetValue(target, out zooms))
                    {
                        MouseZoom zoom = null;
                        if (all)
                        {
                            while(zooms.Count > 0)
                            {
                                zoom = zooms.Pop();
                            }
                        }
                        else if (zooms.Count > 0)
                        {
                            zoom = zooms.Pop();
                        }

                        if (zoom != null)
                        {
                            scaleZoom.ScaleX = zoom.ScaleX;
                            scaleZoom.ScaleY = zoom.ScaleY;

                            target.ScrollToHorizontalOffset(zoom.OffsetX);
                            target.ScrollToVerticalOffset(zoom.OffsetY);
                            return;
                        }
                    }


                    vmLayout data = target.DataContext as vmLayout;

                    if (data.GeneralLayout)
                    {
                        if (scaleZoom != null)
                        {


                            var original_point_x = (point.X + target.HorizontalOffset) / scaleZoom.ScaleX;
                            var original_point_y = (point.Y + target.VerticalOffset) / scaleZoom.ScaleY;

                            scaleZoom.ScaleX = 1;
                            scaleZoom.ScaleY = 1;

                            var new_point_x = (original_point_x * scaleZoom.ScaleX);
                            var new_point_y = (original_point_y * scaleZoom.ScaleY);

                            target.ScrollToHorizontalOffset(new_point_x - point.X);
                            target.ScrollToVerticalOffset(new_point_y - point.X);
                            
                        }

                    }
                    else
                    {
                        var original_border_x0 = target.HorizontalOffset / scaleZoom.ScaleX;
                        var original_border_x1 = (target.HorizontalOffset + target.Width) / scaleZoom.ScaleX;
                        var original_border_y1 = (target.VerticalOffset + target.Height) / scaleZoom.ScaleY;

                        scaleZoom.ScaleX = 1;
                        scaleZoom.ScaleY = 1;

                        var new_border_x0 = (original_border_x0 * scaleZoom.ScaleX);

                        var new_border_x1 = (original_border_x1 * scaleZoom.ScaleX);

                        var diff_x = (new_border_x1 - new_border_x0);
                        int yardId = 0;
                        //foreach (vmYard yard in data.Yards)
                        //{
                        //    if (yard.Enabled)
                        //    {
                        //        yardId = yard.Properties.Id;
                        //        break;
                        //    }
                        //}

                        target.ScrollToHorizontalOffset(new_border_x0 + (diff_x - target.Width) / 2);
                        double y_post = (target.ActualHeight * (yardId - 1));
                        target.ScrollToVerticalOffset(y_post);
                    }
                }
            }
            catch { }
        }
        #endregion
    }

    public class ClickZoom : DependencyObject
    {
        #region private attributes

        #endregion

        #region enable property

        #endregion

        #region zoom property

        #endregion

        #region private method
        public static void ZoomIn(DependencyObject obj, ScaleTransform objScale)
        {
            //var target = obj as ScrollViewer;
            ScrollViewer layout = obj as ScrollViewer;
            ScaleTransform zoomScale = objScale;


            var original_border_x0 = layout.HorizontalOffset / zoomScale.ScaleX;
            var original_border_y0 = layout.VerticalOffset / zoomScale.ScaleY;

            var original_border_x1 = (layout.HorizontalOffset + layout.Width) / zoomScale.ScaleX;
            var original_border_y1 = (layout.VerticalOffset + layout.Height) / zoomScale.ScaleY;

            zoomScale.ScaleX = zoomScale.ScaleX + 0.1;
            zoomScale.ScaleY = zoomScale.ScaleY + 0.1;

            if (zoomScale.ScaleX > TouchConstants.MAX_SCALE)
            {
                zoomScale.ScaleX = TouchConstants.MAX_SCALE;
            }

            if (zoomScale.ScaleY > TouchConstants.MAX_SCALE)
            {
                zoomScale.ScaleY = TouchConstants.MAX_SCALE;
            }

            var new_border_x0 = (original_border_x0 * zoomScale.ScaleX);
            var new_border_y0 = (original_border_y0 * zoomScale.ScaleY);

            var new_border_x1 = (original_border_x1 * zoomScale.ScaleX);
            var new_border_y1 = (original_border_y1 * zoomScale.ScaleY);

            var diff_x = (new_border_x1 - new_border_x0);
            var diff_y = (new_border_y1 - new_border_y0);

            layout.ScrollToHorizontalOffset(new_border_x0 + (diff_x - layout.Width) / 2);
            layout.ScrollToVerticalOffset(new_border_y0 + (diff_y - layout.Height) / 2);

        }

        public static void ZoomOut(DependencyObject obj, ScaleTransform objScale)
        {
            //var target = obj as ScrollViewer;
            ScrollViewer layout = obj as ScrollViewer;
            ScaleTransform zoomScale = objScale;

            var original_border_x0 = layout.HorizontalOffset / zoomScale.ScaleX;
            var original_border_y0 = layout.VerticalOffset / zoomScale.ScaleY;

            var original_border_x1 = (layout.HorizontalOffset + layout.Width) / zoomScale.ScaleX;
            var original_border_y1 = (layout.VerticalOffset + layout.Height) / zoomScale.ScaleY;

            zoomScale.ScaleX = zoomScale.ScaleX - 0.1;
            zoomScale.ScaleY = zoomScale.ScaleY - 0.1;

            if (zoomScale.ScaleX < TouchConstants.MIN_SCALE)
            {
                zoomScale.ScaleX = TouchConstants.MIN_SCALE;
            }

            if (zoomScale.ScaleY < TouchConstants.MIN_SCALE)
            {
                zoomScale.ScaleY = TouchConstants.MIN_SCALE;
            }

            var new_border_x0 = (original_border_x0 * zoomScale.ScaleX);
            var new_border_y0 = (original_border_y0 * zoomScale.ScaleY);

            var new_border_x1 = (original_border_x1 * zoomScale.ScaleX);
            var new_border_y1 = (original_border_y1 * zoomScale.ScaleY);

            var diff_x = (new_border_x1 - new_border_x0);
            var diff_y = (new_border_y1 - new_border_y0);

            layout.ScrollToHorizontalOffset(new_border_x0 + (diff_x - layout.Width) / 2);
            layout.ScrollToVerticalOffset(new_border_y0 + (diff_y - layout.Height) / 2);
        }


        public static void ZoomYard(DependencyObject obj, ScaleTransform objScale, int yardValue)
        {
            
            ScrollViewer layout = obj as ScrollViewer;
            ScaleTransform zoomScale = objScale;


            if (yardValue != 99)
            {
                //Auto
                if (yardValue == 1)
                {
                    layout.ScrollToHorizontalOffset(120);
                    double y_post = 0;
                    layout.ScrollToVerticalOffset(y_post);
                }
                //Semi
                else
                {
                    layout.ScrollToHorizontalOffset(1600);
                    double y_post = 0;
                    layout.ScrollToVerticalOffset(y_post);
                }
            }
            else 
            {

                //reset the zoom position    
                //ResetZoom(layout, zoomScale);

                //zoomScale.ScaleY = yardValue;
                var original_border_x0 = layout.HorizontalOffset / zoomScale.ScaleX;
                ////var original_border_y0 = 0 /  zoomScale.ScaleY == 0 ? 0.01 :zoomScale.ScaleY;

                var original_border_x1 = (layout.HorizontalOffset + layout.Width) / zoomScale.ScaleX;
                var original_border_y1 = (layout.VerticalOffset + layout.Height) / zoomScale.ScaleY;

                zoomScale.ScaleX = 1;
                zoomScale.ScaleY = 1;

                double length_layout = 669 * zoomScale.ScaleY;


                //if (zoomScale.ScaleX < TouchConstants.MIN_SCALE)
                //{
                //    zoomScale.ScaleX = TouchConstants.MIN_SCALE;
                //}

                //if (zoomScale.ScaleY < TouchConstants.MIN_SCALE)
                //{
                //    zoomScale.ScaleY = TouchConstants.MIN_SCALE;
                //}

                var new_border_x0 = (original_border_x0 * zoomScale.ScaleX);
                //var new_border_y0 = (original_border_y0 * zoomScale.ScaleY);

                var new_border_x1 = (original_border_x1 * zoomScale.ScaleX);
                //var new_border_y1 = (original_border_y1 * zoomScale.ScaleY);

                var diff_x = (new_border_x1 - new_border_x0);
                //var diff_y = (new_border_y1 - new_border_y0);

                layout.ScrollToHorizontalOffset(0);
                double y_post = 0;
                layout.ScrollToVerticalOffset(y_post);

            }
            
        }

        static void ResetZoom(ScrollViewer layout, ScaleTransform zoomScale)
        {
            try
            {
                var original_border_x0 = layout.HorizontalOffset / zoomScale.ScaleX;
                var original_border_y0 = 0 / zoomScale.ScaleY;

                var original_border_x1 = (layout.HorizontalOffset + layout.Width) / zoomScale.ScaleX;
                var original_border_y1 = (layout.VerticalOffset + layout.Height) / zoomScale.ScaleY;

                zoomScale.ScaleX = 1;
                zoomScale.ScaleY = 1;
                
                var new_border_x0 = (original_border_x0 * zoomScale.ScaleX);
                var new_border_y0 = (original_border_y0 * zoomScale.ScaleY);

                var new_border_x1 = (original_border_x1 * zoomScale.ScaleX);
                var new_border_y1 = (original_border_y1 * zoomScale.ScaleY);

                var diff_x = (new_border_x1 - new_border_x0);
                var diff_y = (new_border_y1 - new_border_y0);

                layout.ScrollToHorizontalOffset(new_border_x0 + (diff_x - layout.Width) / 2);
                layout.ScrollToVerticalOffset(new_border_y0 + (diff_y - layout.Height) / 2);
            
            }
            catch { }
        }
        #endregion
    }
}