   M S B A M L   `   `   `  ����  HSM.Utility.Controls+    %HSM.Utility.Controls.usrVerticalMeter   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $
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
   ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      ��   TransOptionLabel#��[ 6   #��[  5      #��[ 5      $��0,0,0,1q�5      $
��Bold"�62   $��Center=�6D   $��Center=�6f   $��5,0,0,0q�6�    � Cursor$ Arrow��6�   ��5      �� $ TitleDescription�$
 this����5      �� $ 
TitleWidth�$
 this����5      �� $ TitleHeight�$
 this����5      �� $ TitleFontSize�$
 this����5      �� $ MeterBorderBrush�$
 this��5   �   5      �� 5      $ 
Horizontal=�6   .+�5      �� #��[ 5#      $��Normal"�5%      $��Center=�6,   $��Center=�6N   $ Arrow��6r   ��5      �� $ ValueDescription�$
 this�� �� UpdateSourceTrigger$ PropertyChanged=���5       �� $ 
ValueWidth�$
 this����5!      �� $ ValueHeight�$
 this����5"      �� $ ValueFontSize�$
 this����5$      �� $ MeterBorderBrush�$
 this����5&      �� 5'      	 �� 
TargetType"	 ��6    
 �� BasedOn#
 [ 6<   .�5(      ��  �� Property � �� �� Value 6;   �� $ EffectColor�$
 this�� �� Triggers 5)      �� 5*   "    �� Binding 6.   �� $ EffectColor�$
 this��$ PropertyChanged=� �� Value 6�   Z� .a�5+   &   ��  � ��# [ 6C   5,   #   �� 5-   "    6.   �� $ EffectColor�$
 this��$ PropertyChanged=� Transparent6�   .a�5.   &   ��  � ��# [ 6C   5/   #   51      53      �� 54      #��[  58      #��[ 59      $��1,0,0,0q�5;      $��SemiBold"�62   $��Center=�6H   $��Center=�6j   $ Arrow��6�   ��54      �� $ UnitDescription�$
 this����55      �� $ 	UnitWidth�$
 this����56      �� $ ValueHeight�$
 this����57      �� $ UnitFontSize�$
 this����5:      �� $ MeterBorderBrush�$
 this����5<      �� 5=      "	 ��6    #
 [ 6<   .�5>      ��  � y�$ Visible=�6;    5?      �� 5@   "    6.   �� $ UnitDescription�$
 this��$ PropertyChanged=� 6�   Z� .a�5A   &   ��  � y�$ 	Collapsed=�6C   5B   #   5D      5F      5G      5H      5I      5J      