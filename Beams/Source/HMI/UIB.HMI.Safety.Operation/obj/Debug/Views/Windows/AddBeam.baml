   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      i eJanus.Rodeo.Windows.Library.UI.Controls, Version=1.0.8984.31656, Culture=neutral, PublicKeyToken=null�fclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls'Janus.Rodeo.Windows.Library.UI.Controls 5      �nclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls/Janus.Rodeo.Windows.Library.UI.Controls.Widgets 5      V RHSM.Utility.Controls, Version=1.0.9112.26731, Culture=neutral, PublicKeyToken=nullY@clr-namespace:HSM.Utility.Controls;assembly=HSM.Utility.ControlsHSM.Utility.Controls 5      Z VHSM.HMI.Safety.Operation, Version=1.0.9201.26669, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HSM.HMI.Safety.Operation.ViewsHSM.HMI.Safety.Operation.Views 5	      4   .HSM.HMI.Safety.Operation.Views.Windows.AddBeam   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6sys&clr-namespace:System;assembly=mscorlib     5      wjctrfclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5      �jwidgetsnclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5      Qlctr@clr-namespace:HSM.Utility.Controls;assembly=HSM.Utility.Controls     5      =view,clr-namespace:HSM.HMI.Safety.Operation.Views     5	        � WindowStyle$
  None=�5
       � AllowsTransparency .   � 
ResizeMode$ NoResize=�6A   $��10q�6W      showEffectWindow J� Effect# [  6l    � SizeToContent$ WidthAndHeight=�5       � WindowStartupLocation$ CenterScreen=�62   $��	Condensed&�6X   
������  � Title$ 
ZoneDetail��5   	    � 	Resources 5      ��%    5      .��5      ��   	winBorder#��[ 6   ._�5   
   �   grdBackgroundTransparent#��[ 6    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��50 �6    �� 5      $��50 �6    �� 5      $��* �6    �� 5      $��60 �6    	 � ColumnDefinitions	 5      �� 5      $��10 �6#   �� 5      $	��400 �6#   �� 5      $��10 �6#   .+�5      � -   5        $��grdTitle��5   4   $��0��6   $��3��6      rowTitle#��[ 6D   .+�5      �� $��0��6   
 �� Orientation$
 
Horizontal=�6*   $��50��6C   $
��Left=�6O   $��Center=�6j   $��	20,0,50,0q�6�   .+�5       �� $��Add Beam��6    $��25(�60   $��SemiBold"�6>   
������� �� TextAlignment$ Center=�6l   $��Center=�6�   $��5q�6�   5!      �� 5"      $��0��6   $
 
Horizontal=�6*   $��40��6C   $��Right=�6O   $��Center=�6k   .+�5#      �� -   5        $��X��5#      $��25(�6)   $��	ExtraBold"�67   $��50��6N   $��40��6Y   $��0,0,10,0q�6e     btnTransparent#��[ 6w   ��5$      ��  �� Path$ CloseCommand�6;   5%      5&      �� 5(      $��1��6   $��	-6,10,0,0q�6&   $
 
Horizontal=�69   $��40��6R   $
��Left=�6^   $	��Top=�6y   $��2��6�   .+�5)      �� $��Zone:��6   $	��110��6(   $��20(�64   $��SemiBold"�6B   
�������$��0,0,10,0q�6p   $��Right=�6�   $��Center=�6�   �� 5*      $��18(�6   $��SemiBold"�6)   $��Center=�6?   $��Center=�6\   $	��296��6w   
�������
���   �
�������$��0q�5+   e   ��5,   +   �� *Zones+ �� SelectedItem 5-   )   �� *StorageGroupSelected+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5.      �� 50      $��2��6   $��-6,0,0,0q�6&   $
 
Horizontal=�68   $��40��6Q   $
��Left=�6]   $��Center=�6x   $��2��6�   .+�51      �� $��	Position:��6   $	��110��6,   $��20(�68   $��SemiBold"�6F   
�������$��0,0,10,0q�6t   $��Right=�6�   $��Center=�6�   �� 52      $��18(�6   $��SemiBold"�6)   $��Center=�6?   $��Center=�6\   $	��296��6w   
�������
���   �
�������$��0q�53   e   ��54   +   �� *	Positions+ 55   +   �� *PositionSelected+$ TwoWay=�$ PropertyChanged=�57      �� 59      $��3��6   $
 
Horizontal=�6&   $��40��6?   $
��Left=�6K   $��Center=�6f   $��1��6�   .+�5;      �� $��1��6   $��3��6(   $��Name:��65     TransOptionLabel#��[ 6E   $��20(�6o   $��SemiBold"�6}   $��16,0,0,0q�6�   $��10,0,0,0q�6�   $
��Left=�5<   (   $��Right=�6C   $��Center=�6f   $��Center=�6�   �� 5=      -   5         ��Name$ BeamName��5=      $��10,0,0,0q�6,   $��18(�5>   .   $��SemiBold"�6<   $��30��6R    �� TextAlignment$ Center=�5?   .   $	��295��5@   v   ��6.   �� *Name+$ TwoWay=�$ PropertyChanged=�6v   5A      �� 5D      $��4��6   $��1��6&   $
 
Horizontal=�66   $
��Left=�6O   $��Center=�6j   .+�5E      �� -   5        $	��150��5E      
������ #��[ 6>   $��Center=�6f   ��5F      �� $ CloseCommand�.��5G      �� $
 
Horizontal=�6!   $��40��6:   .+�5H      ��   img_Exit#��[ 6    $��20��6C   �� 5I      $
��Exit��6    #��[ 6/   $��20(�6Y   $��Center=�6g   $��Center=�6�   $
��10,0q�6�   $��0q�6�   5J      5K      5L      �� 5N      $��4��6   $��1��6&   $
 
Horizontal=�66   $
��Left=�6O   $��Center=�6j   $��	240,0,0,0q�6�   .+�5O      �� -   5        $	��150��5O      
������ #��[ 6>   $��Center=�6f   ��5P      �� $ CloseCommand�.��5Q      �� $
 
Horizontal=�6!   $��40��6:   .+�5R      �� $��20��6    �� 5S      $	��Add��6    #��[ 6.   $��20(�6X   $��Center=�6f   $��Center=�6�   $
��10,0q�6�   $��0q�6�   5T      5U      5V      5Y      5[      5]      