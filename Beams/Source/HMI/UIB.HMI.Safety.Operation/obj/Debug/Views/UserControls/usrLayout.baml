   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      i eJanus.Rodeo.Windows.Library.UI.Controls, Version=1.0.8984.31656, Culture=neutral, PublicKeyToken=null�fclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls'Janus.Rodeo.Windows.Library.UI.Controls 5      �nclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls/Janus.Rodeo.Windows.Library.UI.Controls.Widgets 5      V RMSM.Utility.Controls, Version=1.0.9063.23491, Culture=neutral, PublicKeyToken=nullY@clr-namespace:MSM.Utility.Controls;assembly=MSM.Utility.ControlsMSM.Utility.Controls 5      T PMSM.Utility.Common, Version=1.0.9063.23491, Culture=neutral, PublicKeyToken=nullmIclr-namespace:MSM.Utility.Common.Enumerations;assembly=MSM.Utility.CommonMSM.Utility.Common.Enumerations 5	      Z VMSM.HMI.Safety.Operation, Version=1.0.9063.23870, Culture=neutral, PublicKeyToken=null]3clr-namespace:MSM.HMI.Safety.Operation.Enumerations%MSM.HMI.Safety.Operation.Enumerations 5
      Y1clr-namespace:MSM.HMI.Safety.Operation.Converters#MSM.HMI.Safety.Operation.Converters 5      W0clr-namespace:MSM.HMI.Safety.Operation.Selectors"MSM.HMI.Safety.Operation.Selectors 5      Y1clr-namespace:MSM.HMI.Safety.Operation.Behaviours#MSM.HMI.Safety.Operation.Behaviours 5      O,clr-namespace:MSM.HMI.Safety.Operation.ViewsMSM.HMI.Safety.Operation.Views 5      .   (MSM.HMI.Safety.Operation.Views.usrLayout   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6sys&clr-namespace:System;assembly=mscorlib     5      wjctrfclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5      �jwidgetsnclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls.Widgets;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5      Qlctr@clr-namespace:MSM.Utility.Controls;assembly=MSM.Utility.Controls     5      [lenumIclr-namespace:MSM.Utility.Common.Enumerations;assembly=MSM.Utility.Common     5	      Evenum3clr-namespace:MSM.HMI.Safety.Operation.Enumerations     5
      G	converter1clr-namespace:MSM.HMI.Safety.Operation.Converters     5      Eselector0clr-namespace:MSM.HMI.Safety.Operation.Selectors     5      G	behaviour1clr-namespace:MSM.HMI.Safety.Operation.Behaviours     5      Hi:http://schemas.microsoft.com/expression/2010/interactivity     5      =view,clr-namespace:MSM.HMI.Safety.Operation.Views     5      $��0q�5        � 	Resources  5      C  =MSM.HMI.Safety.Operation.Converters.LayoutLeftMarginConverter   layoutLeftMarginConverterB  <MSM.HMI.Safety.Operation.Converters.LayoutTopMarginConverter  layoutTopMarginConverter>  8MSM.HMI.Safety.Operation.Converters.LayoutWidthConverter  layoutWidthConverter?  9MSM.HMI.Safety.Operation.Converters.LayoutHeightConverter  layoutHeightConverter<  6MSM.HMI.Safety.Operation.Converters.LayoutTopConverter  layoutTopConverter=  7MSM.HMI.Safety.Operation.Converters.LayoutLeftConverter  layoutLeftConverter>  8MSM.HMI.Safety.Operation.Selectors.LayoutElementSelector  layoutElementSelectorD  >MSM.HMI.Safety.Operation.Converters.LayoutMachineYardConverter  layoutMachineYardConverter  img_GridLEFT �� 	UriSource �� BitmapScalingMode 	 img_GridRIGHT 
 img_Binocular  img_ZoomOut  
img_ZoomIn  img_Show  Img_Cardinals_1  Img_Cardinals_2  
RightArrow  	DownArrow 
 LWidth  LHeight  BridgeWidth  BridgeHeightYard  BridgeHeightGeneral  TrolleyHeight  TrolleyWidth  TrolleyGeneralHeight  TrolleyGeneralWidth  	ZeroValue  boolTrue  	boolFalse  Lststyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding J� SnapsToDevicePixels  btnArrow	 ��Name
 � Cursor �� 
StartPoint �� EndPoint � Offset � Color � Points �� Stretch J� Effect3	  -System.Windows.Media.Effects.DropShadowEffect 	  ShadowDepth 	  	Direction 	  Color 	  Opacity 	  
BlurRadius �� Triggers P� Property P� Value �� 
TargetName   btnHand ! btnBinocular " 
btnZoomOut # 	btnZoomIn $ 	btnTOLink �� Path % TransOptionLabel �� BasedOn �� Triggers �� Binding �� Mode  �� UpdateSourceTrigger! �� RelativeSource" �� AncestorType# �� Value$ �� Angle% �� CenterY& �� CenterX' �� StringFormat & btnTOLinkHorizontal ' btnCheck( �Name) �� Color* J� Opacity+ �� CornerRadius, ��Name ( btnSelected ) maintDataTemplate��%�3  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 (    &	
 �    &	 D    &	 �    &	 U    &	 �    &	 i    &	 �    &	 �    &	     &	 )    &	 D    &	 `    &	 {    &	 �    &	 �    &	 �    &	 �    &	     &	     &	 ;    &	 X    &	 %    &	  5    &	! �    7 
 &	" f    7  &	# C    7  &	$  !    7 % &	& �%    7 % &	' -'    &	( �+    &	) �1      5   
   6.     5   
   6-     5   
   6)     5   
   6*     5   
   6'     5   
   6(     5   
   6)     5   
   6/   �� 5   
   $e _pack://application:,,,/MSM.Utility.Controls;component/Themes/Resources/Images/LeftArrowGrid.png?�6+   $ HighQuality=�6�   �� 5   
   $f `pack://application:,,,/MSM.Utility.Controls;component/Themes/Resources/Images/RightArrowGrid.png?�6,   $ HighQuality=�6�   �� 5   
   $` Zpack://application:,,,/MSM.Utility.Controls;component/Themes/Resources/Icons/binocular.png?�6,   $ HighQuality=�6�   �� 5   
   $^ Xpack://application:,,,/MSM.Utility.Controls;component/Themes/Resources/Icons/ZoomOut.png?�6*   $ HighQuality=�6�   �� 5   
   $] Wpack://application:,,,/MSM.Utility.Controls;component/Themes/Resources/Icons/ZoomIn.png?�6)   $ HighQuality=�6�   �� 5   
   $[ Upack://application:,,,/MSM.Utility.Controls;component/Themes/Resources/Icons/Show.png?�6'   $ HighQuality=�6�   �� 5    
   $c ]pack://application:,,,/MSM.Utility.Controls;component/Themes/Resources/Images/cardinals_1.png?�6.   $ HighQuality=�6�   �� 5!   
   $c ]pack://application:,,,/MSM.Utility.Controls;component/Themes/Resources/Images/cardinals_2.png?�6.   $ HighQuality=�6�   �� 5"   
   $a [pack://application:,,,/MSM.Utility.Controls;component/Themes/Resources/Icons/rightArrow.png?�6)   $ HighQuality=�6�   �� 5#   
   $_ Ypack://application:,,,/MSM.Utility.Controls;component/Themes/Resources/Icons/coilDrop.png?�6(   $ HighQuality=�6�   X�5%   
   1500Q�6*   X�5&   
   665Q�6*   ��5)   
   6500��6.   X�5+   
   664Q�63   X�5,   
   221Q�66   ��5.   
   2500��60   ��5/   
   4500��6/   ��51   
   2000��67   ��52   
   1800��66   ��56   
   0��6)   ��57   
   True��6-   ��58   
   	False��6/   �� 5;   
   " ��6!   .�5<      ��  � �� 5=      �� 5>      " ��6&   .R�5?      �� $��Border��6!   
������ $ 7q�6H    . ._�5@      �� 5A      5C      5E      5F      �� 5H   
   " d�6+   .R�5I      �� $	 btnArrow��6   $��50��6'   $��30��62   $��	1,1,0.3,1q�6>   
�������$

 Hand��6m   ��5J      �� 5K      $	 1,0&�6*   $	 1,1&�6;   .��5L      � $ 0Q�6'   $ 	#FF252525��62   � 5M      $	 0.5Q�6'   $ 	#FF686868��64   � 5N      $	 0.5Q�6'   $ 	#FF686868��64   � 5O      $ 1Q�6'   $ 	#FF252525��62   5P      ._�5R      � 
�������$��20��6'   Y �   ��� ��� ��� ���@]� `ET@f H���! H� -1�� $� @o@��O��O$��Center=�6u   $ Uniform=�6�   
���   �$	��0.5��6�    5S      	  5T      $ 3Q�6+   $	 320Q�6=   $ 	#BF373737��6O   $	 0.7Q�6c   $ 2Q�6s   5V      5W       5X      P� 5Y       �@J�IsMouseOver . . �5Z      �� $ btnArrow��63    � �� 5[      �� 5\      $	 1,0&�62   $	 1,1&�6C   .��5]   "   � $ 0Q�6/   $ 	#FF686868��6:   � 5^   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5_   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5`   "   $ 1Q�6/   $ 	#FF686868��6:   5a      5c      5d      P� 5e       �@d�	IsChecked$
 trueY�6/   . �5f      �� $ btnArrow��63    � �� 5g      �� 5h      $	 1,0&�62   $	 1,1&�6C   .��5i   "   � $ 0Q�6/   $ 	#FF686868��6:   � 5j   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5k   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5l   "   $ 1Q�6/   $ 	#FF686868��6:   5m      5o      �� 5p      $ btnArrow��6/    �@�Cursor$ Arrow��6E   5q      5s      �� 5u   
   " d�6*   .R�5v      �� $	 brdHand��6   $��50��6&   $��30��61   $��1,1,1,1q�6=   
�������$

 Hand��6j   ��5w      �� 5x      $	 1,0&�6*   $	 1,1&�6;   .��5y      � $ 0Q�6'   $ 	#FF252525��62   � 5z      $	 0.5Q�6'   $ 	#FF686868��64   � 5{      $	 0.5Q�6'   $ 	#FF686868��64   � 5|      $ 1Q�6'   $ 	#FF252525��62   5}      ._�5      �� 
�������$��19(�6+   $��Center=�69   $	��✋��6V    5�      	  5�      $ 3Q�6+   $	 320Q�6=   $ 	#BF373737��6O   $	 0.7Q�6c   $ 2Q�6s   5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ brdHand��63    � �� 5�      �� 5�      $	 1,0&�62   $	 1,1&�6C   .��5�   "   � $ 0Q�6/   $ 	#FF686868��6:   � 5�   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5�   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5�   "   $ 1Q�6/   $ 	#FF686868��6:   5�      5�      5�      P� 5�       �@d�	IsChecked$
 trueY�6/   . �5�      �� $ brdHand��63    � �� 5�      �� 5�      $	 1,0&�62   $	 1,1&�6C   .��5�   "   � $ 0Q�6/   $ 	#FF686868��6:   � 5�   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5�   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5�   "   $ 1Q�6/   $ 	#FF686868��6:   5�      5�      �� 5�      $ brdHand��6/    �@�Cursor$ Arrow��6D   5�      5�      �� 5�   
   " d�6/   .R�5�      �� $��brdBinocular��6   $��50��6)   $��30��64   $��	0.3,1,1,1q�6@   
�������$

 Hand��6o   ��5�      �� 5�      $	 1,0&�6*   $	 1,1&�6;   .��5�      � $ 0Q�6'   $ 	#FF252525��62   � 5�      $	 0.5Q�6'   $ 	#FF686868��64   � 5�      $	 0.5Q�6'   $ 	#FF686868��64   � 5�      $ 1Q�6'   $ 	#FF252525��62   5�      ._�5�      �� 8��  $��40��6@   $��30��6K   $
 Fant=�6W    5�      	  5�      $ 3Q�6+   $	 320Q�6=   $ 	#BF373737��6O   $	 0.7Q�6c   $ 2Q�6s   5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ brdBinocular��63    � �� 5�      �� 5�      $	 1,0&�62   $	 1,1&�6C   .��5�   "   � $ 0Q�6/   $ 	#FF686868��6:   � 5�   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5�   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5�   "   $ 1Q�6/   $ 	#FF686868��6:   5�      5�      5�      P� 5�       �@d�	IsChecked$
 trueY�6/   . �5�      �� $ brdBinocular��63    � �� 5�      �� 5�      $	 1,0&�62   $	 1,1&�6C   .��5�   "   � $ 0Q�6/   $ 	#FF686868��6:   � 5�   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5�   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5�   "   $ 1Q�6/   $ 	#FF686868��6:   5�      5�      �� 5�      $ brdBinocular��6/    �@�Cursor$ Arrow��6I   5�      5�      �� 5�   
   " d�6-   .R�5�      �� $��brdBinocular��6   $��50��6)   $��30��64   $��	0.3,1,1,1q�6@   
�������$

 Hand��6o   ��5�      �� 5�      $	 1,0&�6*   $	 1,1&�6;   .��5�      � $ 0Q�6'   $ 	#FF252525��62   � 5�      $	 0.5Q�6'   $ 	#FF686868��64   � 5�      $	 0.5Q�6'   $ 	#FF686868��64   � 5�      $ 1Q�6'   $ 	#FF252525��62   5�      ._�5�      �� 8��  $��40��6>   $��30��6I   $
 Fant=�6U    5�      	  5�      $ 3Q�6+   $	 320Q�6=   $ 	#BF373737��6O   $	 0.7Q�6c   $ 2Q�6s   5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ brdBinocular��63    � �� 5�      �� 5�      $	 1,0&�62   $	 1,1&�6C   .��5�   "   � $ 0Q�6/   $ 	#FF686868��6:   � 5�   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5�   "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5�   "   $ 1Q�6/   $ 	#FF686868��6:   5�      5�      5�      5�      �� 5�   
   " d�6,   .R�5�      �� $��brdBinocular��6   $��50��6)   $��30��64   $��	0.3,1,1,1q�6@   
�������$

 Hand��6o   ��5�      �� 5�      $	 1,0&�6*   $	 1,1&�6;   .��5      � $ 0Q�6'   $ 	#FF252525��62   � 5     $	 0.5Q�6'   $ 	#FF686868��64   � 5     $	 0.5Q�6'   $ 	#FF686868��64   � 5     $ 1Q�6'   $ 	#FF252525��62   5     ._�5     �� 8��  $��40��6=   $��30��6H   $
 Fant=�6T    5     	  5     $ 3Q�6+   $	 320Q�6=   $ 	#BF373737��6O   $	 0.7Q�6c   $ 2Q�6s   5
     5      5     P� 5      �@J�IsMouseOver . . �5     �� $ brdBinocular��63    � �� 5     �� 5     $	 1,0&�62   $	 1,1&�6C   .��5  "   � $ 0Q�6/   $ 	#FF686868��6:   � 5  "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5  "   $	 0.5Q�6/   $ 	#FF9B9B9B��6<   � 5  "   $ 1Q�6/   $ 	#FF686868��6:   5     5     5     5'     �� 5*  
   " ��6"   .�5+     ��  � �� 6(   �� $ TODetailsCommand��� 5,      � �� 5-     �� 5.     " ��6&   .R�5/     �� $
��Bold"�6T   $��Center=�50      $��Right=�6B   ��5/      �� $ Machine.BackgroundColor���51     �� 52  "   " ��6(   8   .�53  &   ��  � ��$ 70��6?   �� 54  &    � ��$ 70��6>   �� 55  &    � ��$ -410,-115,-150, 300q�6?   �� 56  &    � ��$ 20(�6A    57  &   �� 58  *    66   �� $ DataContext.GeneralLayout�$ OneWay=�$  PropertyChanged=�! �� "" >�# True6�   .a�59  .   ��  � ��$ 50��6G   �� 5:  .    � ��$ 50��6F   �� 5;  .    � ��$ -231,-405,30,-150q�6G   �� 5<  .    � ��$ 16(�6I   5=  +   5?  #   z�5A     V� 5B  "   .~�5C  &   �� $	$ -90Q�66   $% 20Q�6B   $	& 150Q�6O   5D  #   ��5F     �� 5G  "   " ��62   .R�5H  &   �� $��	Underline{�60   $

 Hand��6L   $��Center=�6Z   $��Right=�6u   ��5I  0   �� $  TransportOrder.TOReference�$'  TO: {0}��5J  #   5L     5M     5O     5P     �� 5R  
   " ��6,   .�5S     ��  � �� 6(   �� $ TODetailsCommand��� 5T      � �� 5U     �� 5V     " ��6&   .R�5W     �� 8��  
���   �$
��Bold"�5X  3   $��Center=�5Y      $��Center=�6B   ��5Z     �� 5[  "   " ��62   .R�5\  &   �� $��	Underline{�60   $

 Hand��6L   $��Center=�6Z   $��Center=�6u   $��TO��5]  0   5_  #   5a     5b     5d     5e     �� 5g  
   " d�6!   .�5h     ��  � ��$ Metro UI)�6+   �� 5i      �@�Cursor$
 Hand��6'   �� 5j      � �� �#3428146+   �� 5k      � �� 5l     �� 5m     " d�6&   .R�5n     � $( 
grdContent��6   ��5o     �� 5p  "   $) Transparent��62   .+�5r     �� $	 Border��63   $	* 0.5Q�6%   #��z��6C   #��z��6c   $��1,0,-1,0q�6�   $+ 5��6�   $��0q�6�   #��z��6�   �� 5s     $	 BorderTickness��61   $* 1Q�6%   #��z��6I   #��z��6i   $��1,0,-1,0q�6�   
�������$+ 5��6�   $��2q�6�   
������ 6�   �� 5t     $, contentPresenter��6�   $��Center=�6/   
�������#��z��6l   $
��Bold"�6�   $��Center=�6�   6�   5u      5v     P� 5w      �@d�	IsChecked$ FalseY�6;   . �5x  "   �� $ Border��6<    �@J�Opacity$	 0.2Q�6P   �� 5y  "   $ BorderTickness��6<    �@J�Opacity$	 0.2Q�6X   �� 5z  "    �@J�Opacity$	 0.7Q�6<   5{     P� 5|      �@d�	IsChecked$
 TrueY�6;   . �5}  "   �� $ Border��6<    �@J�Opacity$ 1Q�6P   �� 5~  "   $ BorderTickness��6<    �@J�Opacity$ 1Q�6X   �� 5  "    �@J�Opacity$ 1Q�6<   5�     5�     5�     5�     �� 5�  
   " ��6$   .�5�     ��  � ��$ Metro UI)�6+   �� 5�      �@�Cursor$
 Hand��6'   �� 5�      � �� �	#FF12311F6+   �� 5�      � ��$ 1q�60   �� 5�      �@J�Opacity$ 1Q�6(    5�     �� 5�      6   �� $ Enabled�$ OneWay=�	# False6L   .a�5�     ��  � �� 5�     �� 5�     " ��6.   .R�5�  "   � $( 
grdContent��6'   ��5�  &   �� 5�  *   $) Transparent��6:   .+�5�  &   �� $	* 0.5Q�6-   #��z��6<   #��z��6\   $��1,0,-1,0q�6~   $+ 5��6�   $��0q�6�   #��z��6�   �� 5�  &   $	* 0.2Q�6-   #��z��6<   #��z��6\   $��1,0,-1,0q�6~   
�������$+ 5��6�   $��2q�6�   
������ 6�   �� 5�  &   $, contentPresenter��6�   $��Center=�67   
�������#��z��6t   $
��Bold"�6�   $��Center=�6�   6�   5�  #   5�     5�     5�     �� 5�      6   �� $ Enabled�$ OneWay=�# True6L   .a�5�     ��  � �� 5�     �� 5�     " ��6.   .R�5�  "   � $( 
grdContent��6'   ��5�  &   �� 5�  *   $) Transparent��6:   .+�5�  &   �� $	 Border��69   $* 1Q�6-   #��z��6I   #��z��6i   $��1,0,-1,0q�6�   $+ 5��6�   $��0q�6�   #��z��6�   �� 5�  &   $	 BorderTickness��69   $* 1Q�6-   #��z��6Q   #��z��6q   $��1,0,-1,0q�6�   
�������$+ 5��6�   $��2q�6�   
������ 6�   �� 5�  &   $, contentPresenter��6�   $��Center=�67   
�������#��z��6t   $
��Bold"�6�   $��Center=�6�   6�   5�  #   5�     5�     5�     5�     �� 5�  
   5�     5�     .��5�     ]� ��.  $��Center=�6&   .+�5�  
   � $	��Top=�6   .+�5�     �� - �� Orientation$- 
Horizontal=�6   $
��Left=�62   $��Center=�6M   5     �� 5     $- 
Horizontal=�6   $��Right=�62   $��Center=�6N   $��	0,0,120,0q�6i   .+�5	     d� -   5        . d�Name$. btnArrow��5	     $��0q�61   #��[ 6<   / d� 	IsChecked$/ FalseY�6x   0 � ToolTip$D0 >Allow the user to create temporary zone directly on the layout��6�   d� 5
     -   5        $. btnHand��5
     $��0q�60   #��[  6;   $/ FalseY�6u   $?0 9Allow the user to move the layout using the mouse / touch��6�   d� 5     -   5        $. btnBinocular��5     $��0q�65   #��[! 6@   $/ FalseY�6   $/0 )Allow the user to make zoom on the layout��6�   5     �� 5     $- 
Horizontal=�6   $��Right=�62   $��Bottom=�6N   $��	0,-60,0,0q�6i   .+�5     �� $	��100��6   $	��100��6%   #��[ 61   $ HighQuality=�6[   ��5     �� 5     " ��6    .�5     ��  � y�$ Visible=�6;    5     �� 5  "    6.   �� $ 
IsInverted�$ OneTime=�# True6`   .a�5  &   ��  � y�$ 	Collapsed=�6C   5  #   5     5     �� 5     $	��100��6   $	��100��6%   #��[ 61   $ HighQuality=�6[   ��5     �� 5     " ��6    .�5      ��  � y�$ 	Collapsed=�6;    5!     �� 5"  "    6.   �� $ 
IsInverted�$ OneTime=�# True6`   .a�5#  &   ��  � y�$ Visible=�6C   5$  #   5&     5(     5)     5+     ]� 5-  
   $��Bottom=�6   ��. $��	0,0,0,-15q�6A   .+�5.     �� -   5        $
��Left=�5.     $��0q�6+   $��50��66    * btnTransparent#��[* 6A   $��1,1,2,2q�6�   ���#e7ffe1
���   �.��5/     �� ._�50     �� #��[ 6   $��Uniform=�6C   $��40��6U   51     52     �� 54     -   5        $��scrollXY��54     $
��1520��6+   $	��669��68   $��5,2,5,2q�6E   $��0q�6V   $��Hidden=�6b   $��Hidden=�6�   8
  2MSM.HMI.Safety.Operation.Behaviours.TouchScrolling1 
  	IsEnabled1 .  3  -MSM.HMI.Safety.Operation.Behaviours.TouchZoom2   	IsEnabled2 .  6  0MSM.HMI.Safety.Operation.Behaviours.TouchDrawing3   	IsEnabled3 .  4   LayoutWidth#4 [ 58     5   LayoutHeight#5 [ 59     6   LayoutGeneralWidth#6 [ 5:     7   LayoutGeneralHeight#7 [ 5;     8   LayoutGeneral8 5<     �� $ GeneralLayout���5=     �� 5>     " ��6    5?     �� 5@      6*   �� $ 
IsInverted�$ OneTime=�# True6\   .a�5A  "   ��  �@�LayoutTransform 5B  &   �� 5C  *   $	$ 180Q�6:   5E  #   5F     5H     .��5K     �  + grdBackground#��[+ 6   $��0q�6>   .+�5M     � .+�5N     �� $��0,39,52,439q�6$   
�������$��2��5P     ��5Q     �� 5R  "   9 � SpreadMethod$9 Reflect=�66   $	 0 0&�6M   $ 
0.001 0.01&�6^   .��5S  &   � $	 0.5Q�63   $ Black��6@   � 5T  &   $	 0.5Q�63   $ White��6@   � 5U  &   $	 0.5Q�63   $
 Gray��6@   5V  #   : J� InputBindings: 5X     d� 5Y  "   ; d� Gesture$; 	LeftClicka�6/   < �� CommandParameter$< 	EntryWest��5Z  /   = �� Command= 5Y  C   �� $ DataContext.FooCommand�! �� "" >�5Z  /   5\     �� 5s     $��50��6    $��50��6,   #��[ 67   $��202,114,1268,505q�6\   �� 5t     $��50��6    $��50��6,   #��[ 67   $��709,114,761,505q�6\   �� 5u     $��50��6    $��50��6,   #��[ 67   $��1310,114,160,505q�6[   5v     � 5x     .+�5y     �� $��50,235,52,243q�6$   
�������$��2��5{     ��5|     �� 5}  "   $9 Reflect=�66   $	 0 0&�6M   $ 
0.001 0.01&�6^   .��5~  &   � $	 0.5Q�63   $ Black��6@   � 5  &   $	 0.5Q�63   $ White��6@   � 5�  &   $	 0.5Q�63   $ Orange��6@   5�  #   : 5�     d� 5�  "   $; 	LeftClicka�6/   $< Queue��5�  -   = 5�  C   �� $ DataContext.FooCommand�! �� "" >�5�  -   5�     �� 5�     $��50��6    $��50��6,   #��[ 67   $��202,324,1268,295q�6[   �� 5�     $��50��6    $��50��6,   #��[ 67   $��709,324,761,295q�6[   > J� RenderTransformOrigin$> 
-0.84,0.66&�6t   �� 5�     $��50��6    $��50��6,   #��[ 67   $��1310,324,160,295q�6[   5�     � 5�     .+�5�     �� $��50,431,0,47q�6$   
�������$��2��5�     ��5�     �� 5�  "   $9 Reflect=�66   $	 0 0&�6M   $ 
0.001 0.01&�6^   .��5�  &   � $	 0.5Q�63   $ Black��6@   � 5�  &   $	 0.5Q�63   $ White��6@   � 5�  &   $	 0.5Q�63   $
 Gray��6@   5�  #   : 5�     d� 5�  "   $; 	LeftClicka�6/   $< ExitWest��5�  -   = 5�  C   �� $ DataContext.FooCommand�! �� "" >�5�  -   5�     �� 5�     $��50��6    $��50��6,   #��[ 67   $��202,518,1268,101q�6\   �� 5�     $��50��6    $��50��6,   #��[ 67   $��709,518,761,101q�6\   $> 
-0.26,0.52&�6u   �� 5�     $��50��6    $��50��6,   #��[ 67   $��1310,518,160,101q�6\   $> 
-0.26,0.52&�6v   5�     �� 5�     -   5        $��zoomRectangle��5�     $��1q�62   
�������$��0,0,0,0q�6_   $��0��6p   $��0��6z   $
��Left=�6�   $	��Top=�6�   5�     5�     �� 5�     -   5        $��Right=�5�     $��0q�6,   $��50��67   #��[* 6B   $��1,1,2,2q�6�   ���#e7ffe1
���   �.��5�     �� ._�5�     �� #��[	 6   $��Uniform=�6D   $��40��6V   5�     5�     5�     5�     5�     