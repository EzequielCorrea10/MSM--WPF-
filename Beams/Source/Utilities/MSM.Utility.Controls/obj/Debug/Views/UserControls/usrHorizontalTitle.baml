   M S B A M L   `   `   `  ����  HSM.Utility.Controls-    'HSM.Utility.Controls.usrHorizontalTitle   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $
��this��5      .��5      �� ��6   ��   �� Path$  MeterBorderThickness� �� ElementName$
 this����5      �� $  MeterBorderBrush�$
 this�� �� CornerRadius 5	      �� $  MeterCornerRadius�$
 this����5
   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 0,1&�63   .��5      �  � Color$ 	#FF333333��6    � Offset$ 0Q�61   � 5      $ 	#FF111111��6   $	 0.5Q�61   � 5      $ 	#FF111111��6   $	 1.0Q�61   5      ._�5   
   ��  �� Orientation$ 
Horizontal=�6K   $��Center=�6d   $��Center=�6�   ��6   �� $  MeterHeight�$
 this��.+�5      �� 
�������$��Center=�5   0   $��Center=�6M    �� TextAlignment$ Center=�6h      
withShadow#��[  6   ��5      �� $  TitleDescription�$
 this����5      �� $  
TitleWidth�$
 this����5      �� $  MeterFontSize�$
 this��5      �� 5      
�������$��Center=�5   0   $��Center=�6M   $ Center=�6h   #��[  6   ��5      �� $  ValueDescription�$
 this����5      �� $  
ValueWidth�$
 this����5      �� $  MeterFontSize�$
 this��5      �� 5      
�������$��Center=�5   0   $��Center=�6M   $ Center=�6h   ��5      �� $  SPDescription�$
 this����5      �� $  
ValueWidth�$
 this����5      �� $  MeterFontSize�$
 this����5      �� 5      	 �� 
TargetType"	 ��6   
 �� BasedOn#
 [  6<   .�5       ��  �� Property � y� �� Value$ Visible=�67    �� Triggers 5!      �� 5"       �� Binding 6*   �� $  SPDescription�$
 this�� �� UpdateSourceTrigger$ PropertyChanged=� �� Value 6�   Z� .a�5#   "   ��  � y�$ 	Collapsed=�6?   5$      5&      5(      �� 5)      
�������$��Center=�5,   0   $��Center=�6M   $ Center=�6h   ��5)      �� $  ExtraDescription�$
 this����5*      �� $  
ValueWidth�$
 this����5+      �� $  MeterFontSize�$
 this����5-      �� 5.      "	 ��6   #
 [  6<   .�5/      ��  � y�$ Visible=�67    50      �� 51       6*   �� $  ExtraDescription�$
 this��$ PropertyChanged=� 6�   Z� .a�52   "   ��  � y�$ 	Collapsed=�6?   53      55      57      �� 58      
�������$��Center=�5;   0   $��Center=�6M   $ Center=�6h   ��58      �� $  UnitDescription�$
 this����59      �� $  	UnitWidth�$
 this����5:      �� $  MeterFontSize�$
 this����5<      �� 5=      "	 ��6   #
 [  6<   .�5>      ��  � y�$ Visible=�67    5?      �� 5@       6*   �� $  UnitDescription�$
 this��$ PropertyChanged=� 6�   Z� .a�5A   "   ��  � y�$ 	Collapsed=�6?   5B      5D      5F      5G      5H      5I      