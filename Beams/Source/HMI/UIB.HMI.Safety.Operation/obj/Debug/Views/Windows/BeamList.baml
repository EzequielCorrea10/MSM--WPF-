   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      i eJanus.Rodeo.Windows.Library.UI.Controls, Version=1.0.8984.31656, Culture=neutral, PublicKeyToken=null�fclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls'Janus.Rodeo.Windows.Library.UI.Controls 5      �nclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls/Janus.Rodeo.Windows.Library.UI.Controls.Widgets 5      V RHSM.Utility.Controls, Version=1.0.9112.26731, Culture=neutral, PublicKeyToken=nullY@clr-namespace:HSM.Utility.Controls;assembly=HSM.Utility.ControlsHSM.Utility.Controls 5      Z VHSM.HMI.Safety.Operation, Version=1.0.9201.26669, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HSM.HMI.Safety.Operation.ViewsHSM.HMI.Safety.Operation.Views 5	      5   /HSM.HMI.Safety.Operation.Views.Windows.BeamList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6sys&clr-namespace:System;assembly=mscorlib     5      wjctrfclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5      �jwidgetsnclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5      Qlctr@clr-namespace:HSM.Utility.Controls;assembly=HSM.Utility.Controls     5      =view,clr-namespace:HSM.HMI.Safety.Operation.Views     5	        � WindowStyle$
  None=�5
       � AllowsTransparency .   � 
ResizeMode$ NoResize=�6A   $��10q�6W      showEffectWindow J� Effect# [  6l    � SizeToContent$ WidthAndHeight=�5       � WindowStartupLocation$ CenterOwner=�62   $��	Condensed&�6V   
������  � Title$ 
ZoneDetail��5   	    � 	Resources 5      ��%    5      .��5      ��   	winBorder#��[ 6   ._�5   
   �   grdBackgroundTransparent#��[ 6    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    �� 5      $��60 �6    	 � ColumnDefinitions	 5      �� 5      $��10 �6#   �� 5      $	��400 �6#   �� 5      $��10 �6#   .+�5      � -   5        $��grdTitle��5   4   $��0��6   $��3��6      rowTitle#��[ 6D   .+�5      �� $��0��6   
 �� Orientation$
 
Horizontal=�6*   $��50��6C   $
��Left=�6O   $��Center=�6j   $��	20,0,50,0q�6�   .+�5      �� $��20(�6p   $��SemiBold"�6~   
������� �� TextAlignment$ Center=�6�   $��Center=�6�   $��5q�6�   $
��Auto��6�   ��6    �� *ZoneDisplay+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      �� 5       $��0��6   $
 
Horizontal=�6*   $��40��6C   $��Right=�6O   $��Center=�6k   .+�5!      �� -   5        $��X��5!      $��25(�6)   $��	ExtraBold"�67   $��50��6N   $��40��6Y   $��0,0,10,0q�6e     btnTransparent#��[ 6w   ��5"      ��  �� Path$ CloseCommand�6;   5#      5$      �� 5&      $��1��6   $��1��6&   $
 Vertical=�66   $	��Top=�6M   $
��Left=�6e   $��0,10,0,0q�6�   .+�5'      �� -   5        $��
icTodoList��5'      ��5(      �� 5)      .R�5*      �� -   5        $��35��5-   %   $	��400��5.   %   $��Center=�5/   %   $��0,5,0,5q�50   %   ��5+   %   �� $ DataContext.FooCommand� �� RelativeSource ��  �� AncestorType" >���5,   %   �� .��51   "   �� $ Center=�52      $��Center=�53      $��Center=�54      ��51   ,   �� *Name+54      55      56      58      59      �� 5;      $��2��6   $��1��6&   $
 
Horizontal=�66   $
��Left=�6O   $��Center=�6j   .+�5<      �� -   5        $	��150��5<      
������ #��[ 6>   $��Center=�6f   ��5=      �� $ CloseCommand�.��5>      �� $
 
Horizontal=�6!   $��40��6:   .+�5?      ��   img_Exit#��[ 6    $��20��6C   �� 5@      $
��Exit��6      TransOptionLabel#��[ 6/   $��20(�6Y   $��Center=�6g   $��Center=�6�   $
��10,0q�6�   $��0q�6�   5A      5B      5C      5E      5F      5G      