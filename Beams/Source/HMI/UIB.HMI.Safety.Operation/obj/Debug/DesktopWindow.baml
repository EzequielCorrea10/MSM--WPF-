   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   i eJanus.Rodeo.Windows.Library.UI.Controls, Version=1.0.8984.31656, Culture=neutral, PublicKeyToken=null�fclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls'Janus.Rodeo.Windows.Library.UI.Controls 5   	   �nclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls/Janus.Rodeo.Windows.Library.UI.Controls.Widgets 5   	   Z VHSM.HMI.Safety.Operation, Version=1.0.9082.16916, Culture=neutral, PublicKeyToken=null]3clr-namespace:HSM.HMI.Safety.Operation.Enumerations%HSM.HMI.Safety.Operation.Enumerations 5   	   O,clr-namespace:HSM.HMI.Safety.Operation.ViewsHSM.HMI.Safety.Operation.Views 5	   	   Y1clr-namespace:HSM.HMI.Safety.Operation.Converters#HSM.HMI.Safety.Operation.Converters 5
   	   ,   &HSM.HMI.Safety.Operation.DesktopWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   wjctrfclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5   	   �jwidgetsnclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5   	   Denum3clr-namespace:HSM.HMI.Safety.Operation.Enumerations     5   	   =view,clr-namespace:HSM.HMI.Safety.Operation.Views     5	   	   G	converter1clr-namespace:HSM.HMI.Safety.Operation.Converters     5
   	     � AllowsTransparency  .     showEffectWindow J� Effect# [  5   $   $��0q�6O   $	��900��5   	   $
��1700��6   
 � Top$ 0��6#    � Left$ 0��6+    � 
ResizeMode$ CanResizeWithGrip=�5   	    � WindowStyle$ SingleBorderWindow=�6(    � 	Resources 5       �� 
TargetType �� Property	 �� Value  boolTrue  	boolFalseE ?HSM.HMI.Safety.Operation.Converters.ScreenPageToStringConverter  screenPageToStringConverter��%�   '��       &	 H     &	 d     &	 �     �� 5   
   " ��6   .�5      ��  � ��$	 50��6&   5      ��5   
   True��6-   ��5   
   	False��6/     5   
   60   5      .��5      �   grdBackground#��[ 6   
 � RowDefinitions
 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $��5 �6    � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5       $��* �6   �� 5!      $��10 �6   .+�5$   
   � $��3��6   $��0��6#     rowTitle#��[ 60   .+�5%      �� $��0,0,0,10q�6   ���	#4C195587$��5��6H   ._�5&      �  5'      �� 5(      $
��Auto �6+   �� 5)      $��* �6+   .+�5,      �� $��0��6!    �� Orientation$ 
Horizontal=�61   $��Center=�6J   $
��Left=�6e   .+�51      �� -   5         ��Name$ txtTitle��51   $    �� Padding$ 60,0,0,0q�66   
�������$��50(�6a   $
��Bold"�6o    �� 
LineHeight$ 48��6�   $��Center=�6�   $��VT HSM Collecting zone��52   $   53      �� 55      $��1��6!   $ 
Horizontal=�61   $��Center=�6J   $��Right=�6e   .+�56      �� -   5        $��txtTitleRepeat��56   $    �� TextAlignment$ Right=�6:   $ 0,0,60,0q�6P   $��1(�6c   ���	#262E5F87  	AlphaText#��[ 6�   ��57   $   ��  �� Path$ 
ActivePage� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� 	Converter# [  �� ConverterParameter# [ 58      59      5:      5;      � 5=   
   $��1��6   $��1��6   $��2��6,   
 5>      �� 5?      $	��750 �6     5A      �� 5B      $��* �6#   �� 5C      $
��Auto �6#   .+�5F      ]� $��0��6   $��0��6%   
������ $��0,5,0,10q�6N   .+�5G      �� -   5         ��Name$ 
tabControl��5G   F     TabControlStyle#��[ 6   $��Stretch=�6Z   $��0q�6x   .@�5H      �� -   5        $��	tabLayout��5I   5   $��Layout��5H      $	��210��6.   $��40��6:   $��0q�5I      $��0q�6)     BtnTabItemStyle#��[ 6F    �� 
IsSelected 5J      �� $ LayoutActive�$ TwoWay=�$ PropertyChanged=�.��5K      .  (HSM.HMI.Safety.Operation.Views.usrLayout   � DataContext 6)   �� $ LayoutController�$ OneWay=�$ PropertyChanged=�5L      5r      5s      5v      5w      5x      