   M S B A M L   `   `   `  ����  HSM.Utility.Controls-    'HSM.Utility.Controls.usrButtonIndicator   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$
  this��5       � 	Resources 5
         img_BrakesGray �� 	UriSource �� BitmapScalingMode  img_BrakesGreen  img_BrakesRed  img_DrivesGray  img_DrivesGreen  img_DrivesRed  img_MotorGray  img_MotorGreen  img_MotorRed 	 img_SymeoGray 
 img_SymeoGreen  img_SymeoRed��%Y  &	        &	 �     &	 '    &	 �    &	 L    &	 �    &	 r    &	     &	 �    &		 +    &	
 �    &	 P    �� 5   
   $h bpack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/BrakesGray55x55.png?�6-   $ Unspecified=�6�   �� 5   
   $i cpack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/BrakesGreen55x55.png?�6/   $ Unspecified=�6�   �� 5   
   $g apack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/BrakesRed55x55.png?�6/   $ Unspecified=�6�   �� 5   
   $h bpack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/DrivesGray55x55.png?�6/   $ Unspecified=�6�   �� 5   
   $i cpack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/DrivesGreen55x55.png?�6/   $ Unspecified=�6�   �� 5   
   $g apack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/DrivesRed55x55.png?�6/   $ Unspecified=�6�   �� 5   
   $h bpack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/MotorsGray55x55.png?�6/   $ Unspecified=�6�   �� 5   
   $i cpack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/MotorsGreen55x55.png?�6/   $ Unspecified=�6�   �� 5   
   $g apack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/MotorsRed55x55.png?�6/   $ Unspecified=�6�   �� 5   
   $g apack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/SymeoGray55x55.png?�6/   $ Unspecified=�6�   �� 5   
   $h bpack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/SymeoGreen55x55.png?�6/   $ Unspecified=�6�   �� 5   
   $f `pack://application:,,,/HSM.Utility.Controls;component/Themes/Resources/Desktop/SymeoRed55x55.png?�6/   $ Unspecified=�6�   5      .��5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�6*   $��Center=�6E   .+�5   
   �� $��Center=�6k   $��Center=�6�   ��6   �� *Button1Width+ �� ElementName$
 this�� �� UpdateSourceTrigger$ PropertyChanged=�.+�5      �� $��0,0,0,0q�6   $��55��6&   $��55��62   $��0,0,0,0q�6=   ��6O   ��  �� Path$ DrivesCommand���5      �� $ vmCommandParameter�$
 this��$ PropertyChanged=�.��5      �� $��Uniform=�5   b   ��5      �� *Width+$
 this��$ PropertyChanged=���5      �� *Height+$
 this��$ PropertyChanged=���5      �� 5        �� 
TargetType" ��6    .�5!      �� 	 �� Property	 � ��
 �� Value#
 [ 67    �� Triggers 5"      ^� 5#   "    ^� 
Conditions 5$   &   �� 5%   *    �� Binding 64   �� *	Button1On+$
 this��$ PropertyChanged=� �� Value	 False6�   �� 5&   *    64   �� *IsButton1OffRed+$
 this��$ PropertyChanged=�	 False6�   .0�5(   &   �� 	 � ��#
 [ 6?   5)   #   ^� 5*   "    5+   &   �� 5,   *    64   �� *	Button1On+$
 this��$ PropertyChanged=�	 False6�   �� 5-   *    64   �� *IsButton1OffRed+$
 this��$ PropertyChanged=� True6�   .0�5/   &   �� 	 � ��#
 [ 6?   50   #   ^� 51   "    52   &   �� 53   *    64   �� *	Button1On+$
 this��$ PropertyChanged=� True6�   �� 54   *    64   �� *IsButton1OnGreen+$
 this��$ PropertyChanged=�	 False6�   .0�56   &   �� 	 � ��#
 [ 6?   57   #   ^� 58   "    59   &   �� 5:   *    64   �� *	Button1On+$
 this��$ PropertyChanged=� True6�   �� 5;   *    64   �� *IsButton1OnGreen+$
 this��$ PropertyChanged=� True6�   .0�5=   &   �� 	 � ��#
 [ 6?   5>   #   5@      5B      5C      5D      �� 5F   
   $��Center=�6k   $��Center=�6�   ��6   �� *Button2Width+$
 this��$ PropertyChanged=�.+�5G      �� $��0,0,0,0q�6   $��55��6&   $��55��62   $��0,0,0,0q�6=   ��6O   �� $ BrakesCommand���5H      �� $ vmCommandParameter�$
 this��$ PropertyChanged=�.��5I      �� $��Uniform=�5J   b   ��5I      �� *Width+$
 this��$ PropertyChanged=���5J      �� *Height+$
 this��$ PropertyChanged=���5K      �� 5L      " ��6    .�5M      �� 	 � ��#
 [  67    5N      ^� 5O   "    5P   &   �� 5Q   *    64   �� *	Button2On+$
 this��$ PropertyChanged=�	 False6�   �� 5R   *    64   �� *IsButton2OffRed+$
 this��$ PropertyChanged=�	 False6�   .0�5T   &   �� 	 � ��#
 [  6?   5U   #   ^� 5V   "    5W   &   �� 5X   *    64   �� *	Button2On+$
 this��$ PropertyChanged=�	 False6�   �� 5Y   *    64   �� *IsButton2OffRed+$
 this��$ PropertyChanged=� True6�   .0�5[   &   �� 	 � ��#
 [ 6?   5\   #   ^� 5]   "    5^   &   �� 5_   *    64   �� *	Button2On+$
 this��$ PropertyChanged=� True6�   �� 5`   *    64   �� *IsButton2OnGreen+$
 this��$ PropertyChanged=�	 False6�   .0�5b   &   �� 	 � ��#
 [ 6?   5c   #   ^� 5d   "    5e   &   �� 5f   *    64   �� *	Button2On+$
 this��$ PropertyChanged=� True6�   �� 5g   *    64   �� *IsButton2OnGreen+$
 this��$ PropertyChanged=� True6�   .0�5i   &   �� 	 � ��#
 [ 6?   5j   #   5l      5n      5o      5p      �� 5r   
   $��Center=�6k   $��Center=�6�   ��6   �� *Button3Width+$
 this��$ PropertyChanged=�.+�5s      �� $��0,0,0,0q�6   $��55��6&   $��55��62   $��0,0,0,0q�6=   ��6O   �� $ RegularBrakesCommand���5t      �� $ vmCommandParameter�$
 this��$ PropertyChanged=�.��5u      �� $��Uniform=�5v   b   ��5u      �� *Width+$
 this��$ PropertyChanged=���5v      �� *Height+$
 this��$ PropertyChanged=���5w      �� 5x      " ��6    .�5y      �� 	 � ��#
 [  67    5z      ^� 5{   "    5|   &   �� 5}   *    64   �� *	Button3On+$
 this��$ PropertyChanged=�	 False6�   �� 5~   *    64   �� *IsButton3OffRed+$
 this��$ PropertyChanged=�	 False6�   .0�5�   &   �� 	 � ��#
 [  6?   5�   #   ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button3On+$
 this��$ PropertyChanged=�	 False6�   �� 5�   *    64   �� *IsButton3OffRed+$
 this��$ PropertyChanged=� True6�   .0�5�   &   �� 	 � ��#
 [ 6?   5�   #   ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button3On+$
 this��$ PropertyChanged=� True6�   �� 5�   *    64   �� *IsButton3OnGreen+$
 this��$ PropertyChanged=�	 False6�   .0�5�   &   �� 	 � ��#
 [ 6?   5�   #   ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button3On+$
 this��$ PropertyChanged=� True6�   �� 5�   *    64   �� *IsButton3OnGreen+$
 this��$ PropertyChanged=� True6�   .0�5�   &   �� 	 � ��#
 [ 6?   5�   #   5�      5�      5�      5�      �� 5�   
   $��Center=�6k   $��Center=�6�   ��6   �� *Button4Width+$
 this��$ PropertyChanged=�.+�5�      �� $��0,0,0,0q�6   $��55��6&   $��55��62   $��0,0,0,0q�6=   ��6O   �� $ MotorsCommand���5�      �� $ vmCommandParameter�$
 this��$ PropertyChanged=�.��5�      �� $��Uniform=�5�   j   ��5�      �� *Width+$
 this��$ PropertyChanged=���5�      �� *Height+$
 this��$ PropertyChanged=���5�      �� 5�      " ��6    .�5�      �� 	 � ��#
 [ 67    5�      ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button4On+$
 this��$ PropertyChanged=�	 False6�   �� 5�   *    64   �� *IsButton4OffRed+$
 this��$ PropertyChanged=�	 False6�   .0�5�   &   �� 	 � ��#
 [ 6?   5�   #   ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button4On+$
 this��$ PropertyChanged=�	 False6�   �� 5�   *    64   �� *IsButton4OffRed+$
 this��$ PropertyChanged=� True6�   .0�5�   &   �� 	 � ��#
 [ 6?   5�   #   ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button4On+$
 this��$ PropertyChanged=� True6�   �� 5�   *    64   �� *IsButton4OnGreen+$
 this��$ PropertyChanged=�	 False6�   .0�5�   &   �� 	 � ��#
 [ 6?   5�   #   ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button4On+$
 this��$ PropertyChanged=� True6�   �� 5�   *    64   �� *IsButton4OnGreen+$
 this��$ PropertyChanged=� True6�   .0�5�   &   �� 	 � ��#
 [ 6?   5�   #   5�      5�      5�      5�      �� 5�   
   $��Center=�6k   $��Center=�6�   ��6   �� *Button5Width+$
 this��$ PropertyChanged=�.+�5�      �� $��0,0,0,0q�6   $��55��6&   $��55��62   $��0,0,0,0q�6=   ��6O   �� $ SymeoCommand���5�      �� $ vmCommandParameter�$
 this��$ PropertyChanged=�.��5�      �� $��Uniform=�5�   ]   ��5�      �� *Width+$
 this��$ PropertyChanged=���5�      �� *Height+$
 this��$ PropertyChanged=���5�      �� 5�      " ��6    .�5�      �� 	 � ��#
 [	 67    5�      ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button5On+$
 this��$ PropertyChanged=�	 False6�   �� 5�   *    64   �� *IsButton5OffRed+$
 this��$ PropertyChanged=�	 False6�   .0�5�   &   �� 	 � ��#
 [	 6?   5�   #   ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button5On+$
 this��$ PropertyChanged=�	 False6�   �� 5�   *    64   �� *IsButton5OffRed+$
 this��$ PropertyChanged=� True6�   .0�5�   &   �� 	 � ��#
 [ 6?   5�   #   ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button5On+$
 this��$ PropertyChanged=� True6�   �� 5�   *    64   �� *IsButton5OnGreen+$
 this��$ PropertyChanged=�	 False6�   .0�5�   &   �� 	 � ��#
 [ 6?   5�   #   ^� 5�   "    5�   &   �� 5�   *    64   �� *	Button5On+$
 this��$ PropertyChanged=� True6�   �� 5�   *    64   �� *IsButton5OnGreen+$
 this��$ PropertyChanged=� True6�   .0�5�   &   �� 	 � ��#
 [
 6?   5�   #   5�      5�      5�      5�      5�      5�      