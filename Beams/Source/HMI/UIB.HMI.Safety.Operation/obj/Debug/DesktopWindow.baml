   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   i eJanus.Rodeo.Windows.Library.UI.Controls, Version=1.0.8984.31656, Culture=neutral, PublicKeyToken=null�fclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls'Janus.Rodeo.Windows.Library.UI.Controls 5   	   �nclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls/Janus.Rodeo.Windows.Library.UI.Controls.Widgets 5   	   Z VHSM.HMI.Safety.Operation, Version=1.0.9201.26669, Culture=neutral, PublicKeyToken=null]3clr-namespace:HSM.HMI.Safety.Operation.Enumerations%HSM.HMI.Safety.Operation.Enumerations 5   	   O,clr-namespace:HSM.HMI.Safety.Operation.ViewsHSM.HMI.Safety.Operation.Views 5	   	   Y1clr-namespace:HSM.HMI.Safety.Operation.Converters#HSM.HMI.Safety.Operation.Converters 5
   	   ,   &HSM.HMI.Safety.Operation.DesktopWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   wjctrfclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5   	   �jwidgetsnclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5   	   Denum3clr-namespace:HSM.HMI.Safety.Operation.Enumerations     5   	   =view,clr-namespace:HSM.HMI.Safety.Operation.Views     5	   	   G	converter1clr-namespace:HSM.HMI.Safety.Operation.Converters     5
   	     � AllowsTransparency  .     showEffectWindow J� Effect# [  5   $   $��0q�6O   $	��960��5   	   $
��1700��6   
 � Top$ 0��6#    � Left$ 0��6+    � 
ResizeMode$ CanResizeWithGrip=�5   	    � WindowStyle$ SingleBorderWindow=�6(    � WindowStartupLocation$ CenterOwner=�6I    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value  boolTrue  	boolFalse 	 janus �� 	UriSource �� BitmapScalingMode  sdiE ?HSM.HMI.Safety.Operation.Converters.ScreenPageToStringConverter  screenPageToStringConverter��%�  '��       &	 H     &	 d     &	 �     &	 	    &	 �    �� 5   
   " ��6   .�5      �� 	 � ��$
 50��6&   5      ��5   
   True��6-   ��5   
   	False��6/   �� 5   
   $] Wpack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Images/Janus.png?�6$   $ HighQuality=�6�   �� 5   
   $[ Upack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Images/SDI.png?�6"   $ HighQuality=�6�     5   
   60   5      .��5      �   grdBackground#��[ 6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $��5 �6    � ColumnDefinitions 5!   
   �� 5"      $��10 �6   �� 5#      $��* �6   �� 5$      $��10 �6   .+�5'   
   � $��3��6   $��0��6#   .+�5(      �� $��0,0,0,10q�6   $��5��61   ._�5)      �  5*      �� 5+      $
��Auto �6+   �� 5,      $��* �6+   .+�5/      �� $��0��6!    �� Orientation$ 
Horizontal=�61   $��Center=�6J   $
��Left=�6e   .+�54      �� -   5         ��Name$ txtTitle��54   $    �� Padding$ 60,0,0,0q�66   
�������$��50(�6a   $
��Bold"�6o    �� 
LineHeight$ 48��6�   $��Center=�6�   $��VT HSM ��55   $   56      �� 57       J� Opacity$ 2Q�6   $
��Left=�6(   #��[ 6C   $	��290��6c   $��1��6o   $��1117,10,0,10q�6   �� 58      $ 2Q�6   $
��Left=�6(   #��[ 6C   $	��116��6a   $��1��6m   $��
980,10,0,0q�6}   �� 5:      $��1��6!   $ 
Horizontal=�61   $��Center=�6J   $��Right=�6e   .+�5;      �� -   5        $��txtTitleRepeat��5;   $    �� TextAlignment$ Right=�6:   $ 0,0,60,0q�6P   $��1(�6c   ���	#262E5F87  	AlphaText#��[ 6�   ��5<   $   ��  �� Path$ 
ActivePage� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� 	Converter# [  �� ConverterParameter# [ 5=      5>      5?      5@      � 5B   
   $��1��6   $��1��6   $��2��6,    5C      �� 5D      $	��800 �6     5F      �� 5G      $��* �6#   �� 5H      $
��Auto �6#   .+�5K      ]� $��0��6   $��0��6%   
������ $��0,0,0,10q�6N   .+�5L      �� -   5         ��Name$ 
tabControl��5L   F     TabControlStyle#��[ 6   $��Stretch=�6Z   $��0q�6x   $	��Top=�6�   .@�5M      �� -   5        $��	tabLayout��5N   5   $��Collecting Zone
��5M      $	��210��6A   $��40��6M   $��0q�5N      $��0q�6)    	 BtnTabItemStyle#��[	 6F    �� 
IsSelected 5O      �� $ LayoutActive�$ TwoWay=�$ PropertyChanged=�.��5P      .  (HSM.HMI.Safety.Operation.Views.usrLayout   � DataContext 6)   �� $ LayoutController�$ OneWay=�$ PropertyChanged=�5Q      �� 5R      -   5        $��tabLayoutSemiAuto��5R   y   $��Piling Zone
��6   $	��210��6=   $��40��6I   $	��Top=�6U   $��0q�6m   #��[	 6�    5S      �� $ LayoutSemiAutoActive�$ TwoWay=�$ PropertyChanged=�.��5T      5  /HSM.HMI.Safety.Operation.Views.usrPillingLayout   60   �� $ LayoutSemiAutoController�$ OneWay=�$ PropertyChanged=�5U      5v      5x      5z      �� 5{   
   $��1��5|   !   $��	0,763,0,0q�5}   !   $
��Left=�5~   !   $	��Top=�5   !   $ 
Horizontal=�5�   !   $��44��6:   $��1��6F   .+�5�      �� -   5        $	��150��5�   %   $��Center=�5�   %   
������  
 btnTransparent#��[
 5�   %    � ToolTip$ 
Create New��5�   %   ��5�   %   �� *CreateTransportOrderCommand+.��5�      �� $��30��6   $ 
Horizontal=�6)   .+�5�      �� $��20��5�   -   $	��0,5q�5�   -     img_Add#��[ 5�   -   �� 5�      $
��10,0q�5�   -   $��0q�5�   -   $��Center=�5�   -   $��Add Beam��5�   -   $��20(�5�   -     TransOptionLabel#��[ 5�   -   5�      5�      5�      5�      5�      