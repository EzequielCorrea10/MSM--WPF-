   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      i eJanus.Rodeo.Windows.Library.UI.Controls, Version=1.0.8984.31656, Culture=neutral, PublicKeyToken=null�fclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls'Janus.Rodeo.Windows.Library.UI.Controls 5      �nclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls/Janus.Rodeo.Windows.Library.UI.Controls.Widgets 5      V RHSM.Utility.Controls, Version=1.0.9112.26731, Culture=neutral, PublicKeyToken=nullY@clr-namespace:HSM.Utility.Controls;assembly=HSM.Utility.ControlsHSM.Utility.Controls 5      Z VHSM.HMI.Safety.Operation, Version=1.0.9201.26669, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HSM.HMI.Safety.Operation.ViewsHSM.HMI.Safety.Operation.Views 5	      7   1HSM.HMI.Safety.Operation.Views.Windows.ZoneDetail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6sys&clr-namespace:System;assembly=mscorlib     5      wjctrfclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5      �jwidgetsnclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5      Qlctr@clr-namespace:HSM.Utility.Controls;assembly=HSM.Utility.Controls     5      =view,clr-namespace:HSM.HMI.Safety.Operation.Views     5	        � WindowStyle$
  None=�5
       � AllowsTransparency .   � 
ResizeMode$ NoResize=�6A   $��10q�6W      showEffectWindow J� Effect# [  6l    � SizeToContent$ WidthAndHeight=�5       � WindowStartupLocation$ CenterOwner=�62   $��	Condensed&�6V   
������  � Title$ 
ZoneDetail��5   	    � 	Resources 5      ��%    5      .��5      ��   	winBorder#��[ 6   ._�5   
   �   grdBackgroundTransparent#��[ 6    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    �� 5      $��60 �6    	 � ColumnDefinitions	 5      �� 5      $��10 �6#   �� 5      $	��400 �6#   �� 5      $��10 �6#   .+�5      � -   5        $��grdTitle��5   4   $��0��6   $��3��6      rowTitle#��[ 6D   .+�5      �� $��0��6   
 �� Orientation$
 
Horizontal=�6*   $��50��6C   $
��Left=�6O   $��Center=�6j   $��	20,0,50,0q�6�   .+�5      �� $��Beam Detail��6    $��25(�63   $��SemiBold"�6A   
������� �� TextAlignment$ Center=�6o   $��Center=�6�   $��5q�6�   5      �� 5       $��0��6   $
 
Horizontal=�6*   $��40��6C   $��Right=�6O   $��Center=�6k   .+�5!      �� -   5        $��X��5!      $��25(�6)   $��	ExtraBold"�67   $��50��6N   $��40��6Y   $��0,0,10,0q�6e     btnTransparent#��[ 6w   ��5"      ��  �� Path$ CloseCommand�6;   5#      5$      �� 5&      $��1��6   $��1��6&   $
 Vertical=�66   $	��Top=�6M   $
��Left=�6e   $��0,10,0,0q�6�   .+�5'      �� 
�������$��2q�6-    �� CornerRadius$ 10��6A    �� Padding$ 10q�6S   $��0q�6`   $��77��6k   ._�5(      � 	 5)      �� 5*      $	��250 �6/   �� 5+      $
��Auto �6/   �� 5,      $	��150 �6/   �� 5-      $
��Auto �6/    5/      �� 50      $��50 �6,   �� 51      $��50 �6,   .+�53      �� $��0��6    $��0��60   $��Name:��6=     TransOptionLabel#��[ 6M   $��20(�6w   $
��Bold"�6�   $��0,0,5,0q�6�   $��10,0,0,0q�6�   $
��Left=�54   (   $��Right=�6C   $��Center=�6f   $��Center=�6�   �� 56      $��0��6!   $��1q�6.   $ 5��6B   
�������$��140,0,260,10q�6f   $��3��6|   ._�57      �� -   5        $��BeamName��57   &   $��18(�58   .   $��SemiBold"�6<   $	��200��6R   $��30��6^   $��0,0,0,0q�6j    �� TextAlignment$ Center=�59   .   ��5:   .   �� $
 Name� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5;      5=      5>      5?      �� 5A      $��2��6   $��1��6&   $
 
Horizontal=�66   $
��Left=�6O   $��Center=�6j   .+�5B      �� -   5        $	��150��5B      
������ #��[ 6>   $��Center=�6f   ��5C      �� $ CloseCommand�.��5D      �� $
 
Horizontal=�6!   $��40��6:   .+�5E      ��   img_Exit#��[ 6    $��20��6C   �� 5F      $
��Exit��6    #��[ 6/   $��20(�6Y   $��Center=�6g   $��Center=�6�   $
��10,0q�6�   $��0q�6�   5G      5H      5I      �� 5K      $��2��6   $��1��6&   $
 
Horizontal=�66   $
��Left=�6O   $��Center=�6j   $��	221,0,0,0q�6�   .+�5L      �� -   5        $	��150��5L      
������ #��[ 6>   $��Center=�6f   ��5M      �� $ CloseCommand�.��5N      �� $
 
Horizontal=�6!   $��40��6:   .+�5O      �� $��20��6    �� 5P      $��Update��6    #��[ 61   $��20(�6[   $��Center=�6i   $��Center=�6�   $
��10,0q�6�   $��0q�6�   5Q      5R      5S      5T      5U      5V      