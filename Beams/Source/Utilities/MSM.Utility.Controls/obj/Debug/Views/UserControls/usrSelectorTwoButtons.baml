   M S B A M L   `   `   `  ����V  RHSM.Utility.Controls, Version=1.0.9112.26731, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:HSM.Utility.Controls.BehavioursHSM.Utility.Controls.Behaviours  5      0    *HSM.Utility.Controls.usrSelectorTwoButtons   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      C	behaviour-clr-namespace:HSM.Utility.Controls.Behaviours     5      -   5        $
��this��5   +   $��40��6   $��50��6     � 	Resources  5         img_OnSwitch �� 	UriSource �� BitmapScalingMode  img_OffSwitch  btnTwoSelector �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources  Key g� 	BeginTime	 �� 
TargetName
 �� TargetProperty O� KeyTime O� Value �� From	 �� To g� Duration W� From	 W� To �Name J� Opacity �� CornerRadius ��Name �� ScaleX �� ScaleY �� CenterX �� Path �� ElementName  halfSubstractionConverter �� 	Converter �� CenterY'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard  �� Triggers! P� Property" P� Value# �� 
TargetName$ �� AngleX% �� AngleY& �� Angle' N� ExitActions( ��Name  	HideShine) N� EnterActions  	ShowShine��%�  &	        &	 �     &	 A    7  7  7  7  �� 5	   
   $u opack://application:,,,/Janus.Rodeo.Windows.Library.UI.Controls;component/Themes/Resources/Icons/imgOnSwitch.png?�6+   $ HighQuality=�6�   �� 5
   
   $v ppack://application:,,,/Janus.Rodeo.Windows.Library.UI.Controls;component/Themes/Resources/Icons/imgOffSwitch.png?�6,   $ HighQuality=�6�   �� 5   
   " ��6'   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ Metro UI)�6+   �� 5       � ��
 �����6+   �� 5       � ��$ Normal$�6*   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��
 �����6,   �� 5       � ��$ 0q�60   �� 5       � �� 5      �� 5      " ��6&    5      ���� 5      	ShowShine .��5   "   U� $ 00:00:00X�6@   $	 ButtonScale��6U   $
 (ScaleTransform.ScaleX)�6y   .\�5   &   �� $ 00:00:0.300��6;   $	 1.2Q�6Q   5   #   U� 5   "   $ 00:00:00X�6@   $	 ButtonScale��6U   $
 (ScaleTransform.ScaleY)�6y   .\�5   &   �� $ 00:00:0.300��6;   $	 1.2Q�6Q   5    #   �� 5"   "   $	 ButtonBorder��61   $
 Background.Color�6V   $ TransparentX�6�   $ #0a67a3X�6�   $ 0:0:0.1D�6�   W� 5#   "   $	 ButtonBorder��62   $
 Opacity�6W   $	 0.2X�6{   $ 1X�6�   $ 0:0:0.5D�6�   5$      �� 5%      	HideShine .��5&   "   U� $ 00:00:00X�6@   $	 ButtonScale��6U   $
 (ScaleTransform.ScaleX)�6y   .\�5'   &   �� $ 00:00:0.300��6;   $ 1Q�6Q   5(   #   U� 5)   "   $ 00:00:00X�6@   $	 ButtonScale��6U   $
 (ScaleTransform.ScaleY)�6y   .\�5*   &   �� $ 00:00:0.300��6;   $ 1Q�6Q   5+   #   W� 5-   "   $	 ButtonBorder��62   $
 Opacity�6W   $ 1X�6{   $	 0.2X�6�   $ 0:0:0.3D�6�   �� 5.   "   $	 ButtonBorder��61   $
 Background.Color�6V   $ #0a67a3X�6�   $ TransparentX�6�   $ 0:0:0.1D�6�   5/      50      .R�52      � $ 
grdContent��6   $��0,5,0,0q�63   .+�53      �� $��ButtonBorder��6%   $	 0.2Q�69   $��1,0,-1,0q�6G   $ 1��6Y   $��1q�6j   
�������
������ 6�   �� 55      $ contentPresenter��6/   $��Center=�6I   $	��Top=�6f   #��z��56   /   #��z��6O   #��z��6q   #��z��57   /   #��z��6m   z�58   "   �� 59   &   ButtonScale��$ 1Q�6J   $ 1Q�6U    5:   5   �� $ Width�$ contentPresenter��8    5;   5   �� $ Height�$ contentPresenter��8  5=       5?        5@   "   CommonStates��. 5A   &     
Normal��. 5B   *   �� .��5C   .   U� $ 00:00:00X�6L   $	 ButtonScale��6a   $
 (ScaleTransform.ScaleX)�6�   .\�5D   2   �� $ 00:00:0.300��6G   $ 1Q�6]   5E   /   U� 5F   .   $ 00:00:00X�6L   $	 ButtonScale��6a   $
 (ScaleTransform.ScaleY)�6�   .\�5G   2   �� $ 00:00:0.300��6G   $ 1Q�6]   5H   /   5I   +   5J   '   5K   #   5M        5O      P� 5P      ! � {�" . . �5Q   "   �� $# contentPresenter��6<    �@J�Opacity$ 1Q�6Z   5R      P� 5S      ! � {�" .  . �5T   "   �� $# contentPresenter��6<    �@J�Opacity$	 0.9Q�6Z   �� 5U   "   $# ButtonBorder��6?    � y�$ 	Collapsed=�6Y   5V      P� 5W      ! � ��" . . �5X   "   �� $# contentPresenter��6D    � z� 5Y   &   V� 5Z   *   .~�5[   .   �� $	 0.8Q�6=   $	 0.8Q�6J   �� 5\   .   $$ 0Q�6<   $% 0Q�6G   �� 5]   .   $& 0Q�6>   5^   +   5`   #   5a      P� 5b      ! �@J�IsMouseOver" . ' 5c   "   �� 5d   &   $( HideShine_BeginStoryboard��6^   8�� ) 5f   "   �� 5g   &   $( ShowShine_BeginStoryboard��6^   8�� 5i      5k      5m      5n      5o      .��5p      � 
������ * � RowDefinitions* 5q   
   �� 5r      $��30 �6   �� 5s      $��3* �6   �� 5t      $��1* �6   + � ColumnDefinitions+ 5v   
   �� 5w      $��1* �6   �� 5x      $��1* �6   .+�5{   
   �� $��0��6   $��0��6   $��2��6.   $	��Top=�6?   
������ , � Cursor$
, Hand��5}   *   $��0,10,0,0q�68   - �� TextAlignment$- Center=�6K   :   4HSM.Utility.Controls.Behaviours.TouchDeviceMouseOver.   	IsEnabled. . ��5|      �� $ ButtonWidth�$
 this����6F   �� $ ButtonHeight�$
 this����6}   �� $ ButtonFontSize�$
 this����6�   �� $ FirstOptionName�$
 this��/ �� UpdateSourceTrigger$/ PropertyChanged=���5~      �� $ FirstOptionCommand�$
 this��$/ PropertyChanged=���5      �� $! FirstOptionCommandParameter�$
 this��$/ PropertyChanged=���5�      �� 5�      " ��6   0 �� BasedOn#0 [ 65   .�5�      ��  � ��
 �����6=   �� 5�       � {� . 62   1 �� Triggers1 5�      ^� 5�      2 ^� 
Conditions2 5�      �� 5�   "   3 �� Binding3 6,   �� $ OptionSelected�$
 this��$/ PropertyChanged=�4 �� Value4 16�   �� 5�   "   3 6,   �� $ IsFirstOptionRed�$
 this��$/ PropertyChanged=�	4 False6�   .0�5�      ��  � �� �	#FF75C9106E   �� 5�       � {� .  6:   5�      ^� 5�      2 5�      �� 5�   "   3 6,   �� $ OptionSelected�$
 this��$/ PropertyChanged=�4 16�   �� 5�   "   3 6,   �� $ IsFirstOptionRed�$
 this��$/ PropertyChanged=�4 True6�   .0�5�      ��  � ��
 �  ��6E   �� 5�       � {� .  6:   5�      �� 5�      5 �� Binding5 6&   �� $ FirstOptionCommand�$
 this��$/ PropertyChanged=�6 �� Value6 6�   Z� .a�5�      ��  � {� .  6:   5�      �� 5�      5 6&   �� $ 	IsEnabled�$
 this��$/ PropertyChanged=�	6 false6�   .a�5�      ��  � {� .  6:   5�      5�      5�      �� 5�   
   $��0��6   $��1��6   $��2��6.   $	��Top=�6?   
������ $
, Hand��5�   *   $��0,10,0,0q�68   $- Center=�6K   . . ��5�      �� $ ButtonWidth�$
 this����6F   �� $ ButtonHeight�$
 this����6}   �� $ ButtonFontSize�$
 this����6�   �� $ SecondOptionName�$
 this��$/ PropertyChanged=���5�      �� $ SecondOptionCommand�$
 this��$/ PropertyChanged=���5�      �� $" SecondOptionCommandParameter�$
 this��$/ PropertyChanged=���5�      �� 5�      " ��6   #0 [ 65   .�5�      ��  � ��
 �����6=   �� 5�       � {� . 62   1 5�      ^� 5�      2 5�      �� 5�   "   3 6,   �� $ OptionSelected�$
 this��$/ PropertyChanged=�4 26�   �� 5�   "   3 6,   �� $ IsSecondOptionRed�$
 this��$/ PropertyChanged=�	4 False6�   .0�5�      ��  � �� �	#FF75C9106E   �� 5�       � {� .  6:   5�      ^� 5�      2 5�      �� 5�   "   3 6,   �� $ OptionSelected�$
 this��$/ PropertyChanged=�4 26�   �� 5�   "   3 6,   �� $ IsSecondOptionRed�$
 this��$/ PropertyChanged=�4 True6�   .0�5�      ��  � ��
 �  ��6E   �� 5�       � {� .  6:   5�      �� 5�      5 6&   �� $ SecondOptionCommand�$
 this��$/ PropertyChanged=�6 6�   Z� .a�5�      ��  � {� .  6:   5�      �� 5�      5 6&   �� $ 	IsEnabled�$
 this��$/ PropertyChanged=�	6 false6�   .a�5�      ��  � {� .  6:   5�      5�      5�      �� 5�   
   $��1��6   $��0��6   $��2��6-   ��6A   �� $ 
ImageWidth�$
 this����6u   �� $ ImageHeight�$
 this����5�      �� 5�      " ��6   1 5�      �� 5�      5 6&   �� $ OptionSelected�$
 this��$/ PropertyChanged=�6 16�   .a�5�      ��  � ��# [ 67   5�      �� 5�      5 6&   �� $ OptionSelected�$
 this��$/ PropertyChanged=�6 26�   .a�5�      ��  � ��# [  67   5�      5�      5�      �� 5�   
   $��2��6   $��0��6!   $��2��61   7 �� Padding$7 2,5,2,5q�5�      
�������$
��Bold"�6>   $��Center=�6P   $��Center=�6m   ��5�   E   �� $ Description�$
 this��$/ PropertyChanged=���6�   �� $ DescriptionFontSize�$
 this����5�      �� 5�      " ��6   #0 [B��68   .�5�      ��  � y�$ Visible=�63   1 5�      �� 5�      5 6&   �� $ Description�$
 this��$/ PropertyChanged=�6 6�   Z� .a�5�      ��  � y�$ 	Collapsed=�6;   5�      5�      5�      5�      5�      