   M S B A M L   `   `   `  ����  HSM.Utility.Controls-    'HSM.Utility.Controls.usrHorizontalMeter   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $
��this��5        � 	Resources  5         MeterBackgroundBrush �� Color  MeterForegroundBrush  ValueBackgroundBrush  ValueForegroundBrush��%�   &	        &	 #     &	 G     &	 j     �� 5   
   $ 	#99009900��67   �� 5	   
   $ 
WhiteSmoke��67   �� 5
   
   $ 	#FF464646��67   �� 5   
   $ 
WhiteSmoke��67   5      .��5      �� 
������ $��Center=�6&   $��0q�6A    �� Padding$ 0q�6L   $
��Auto��6X   $
��Auto��6f   ��5      ��  �� Path$ MeterBorderThickness� �� ElementName$
 this����5      �� $ MeterBorderBrush�$
 this�� �� CornerRadius 5      �� $ MeterCornerRadius�$
 this��._�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0q�6.   .+�5      ��   TransOptionLabel#��[ 6   #��[  5      #��[ 5      $
��Bold"�5      $��Center=�6&   $
��Left=�6H   $��5,0,0,0q�6j    � Cursor$ Arrow��6|   ��5      �� $ TitleDescription�$
 this����5      �� $ 
TitleWidth�$
 this����5      �� $ TitleFontSize�$
 this��5   |   �� 5      #��[ 5      $��1,0,0,0q�5       $��Normal"�6.   $��Center=�6B   $��Center=�6d   $ Arrow��6�   ��5      �� $ ValueDescription�$
 this�� �� UpdateSourceTrigger$ PropertyChanged=���5      �� $ 
ValueWidth�$
 this����5      �� $ ValueFontSize�$
 this����5      �� $ MeterHeight�$
 this����5      �� $ MeterBorderBrush�$
 this����5!      �� 5"      	 �� 
TargetType"	 ��6   
 �� BasedOn#
 [ 68   .�5#      ��  �� Property � �� �� Value 67   �� $ EffectColor�$
 this�� �� Triggers 5$      �� 5%       �� Binding 6*   �� $ EffectColor�$
 this��$ PropertyChanged=� �� Value 6�   Z� .a�5&   "   ��  � ��# [ 6?   5'      �� 5(       6*   �� $ EffectColor�$
 this��$ PropertyChanged=� Transparent6�   .a�5)   "   ��  � ��# [ 6?   5*      5,      5.      �� 5/      #��[ 53      #��[ 54      $��1,0,0,0q�56      $��Normal"�6.   $��Center=�6B   $��Center=�6d   $ Arrow��6�   ��5/      �� $ SPDescription�$
 this��$ PropertyChanged=���50      �� $ 
ValueWidth�$
 this����51      �� $ ValueFontSize�$
 this����52      �� $ MeterHeight�$
 this����55      �� $ MeterBorderBrush�$
 this����57      �� 58      "	 ��6   #
 [ 68   .�59      ��  � y�$ Visible=�67    5:      �� 5;       6*   �� $ SPDescription�$
 this��$ PropertyChanged=� 6�   Z� .a�5<   "   ��  � y�$ 	Collapsed=�6?   5=      5?      5A      �� 5B      #��[ 5F      #��[ 5G      $��1,0,0,0q�5I      $��Normal"�6.   $��Center=�6B   $��Center=�6d   $ Arrow��6�   ��5B      �� $ ExtraDescription�$
 this��$ PropertyChanged=���5C      �� $ 
ValueWidth�$
 this����5D      �� $ ValueFontSize�$
 this����5E      �� $ MeterHeight�$
 this����5H      �� $ MeterBorderBrush�$
 this����5J      �� 5K      "	 ��6   #
 [ 68   .�5L      ��  � y�$ Visible=�67    5M      �� 5N       6*   �� $ ExtraDescription�$
 this��$ PropertyChanged=� 6�   Z� .a�5O   "   ��  � y�$ 	Collapsed=�6?   5P      5R      5T      �� 5U      #��[  5Y      #��[ 5Z      $��1,0,0,0q�5\      $��SemiBold"�6.   $��Center=�6D   $��Center=�6f   $ Arrow��6�   ��5U      �� $ UnitDescription�$
 this����5V      �� $ 	UnitWidth�$
 this����5W      �� $ UnitFontSize�$
 this����5X      �� $ MeterHeight�$
 this����5[      �� $ MeterBorderBrush�$
 this����5]      �� 5^      "	 ��6   #
 [ 68   .�5_      ��  � y�$ Visible=�67    5`      �� 5a       6*   �� $ UnitDescription�$
 this��$ PropertyChanged=� 6�   Z� .a�5b   "   ��  � y�$ 	Collapsed=�6?   5c      5e      5g      5h      5i      5j      