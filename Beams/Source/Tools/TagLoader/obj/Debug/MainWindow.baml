   M S B A M L   `   `   `  ����D  @TagLoader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TagLoader	TagLoader  5      i eJanus.Rodeo.Windows.Library.UI.Controls, Version=1.0.8984.31656, Culture=neutral, PublicKeyToken=null�fclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls'Janus.Rodeo.Windows.Library.UI.Controls 5      ;"clr-namespace:TagLoader.ViewModelsTagLoader.ViewModels  5          TagLoader.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      )localclr-namespace:TagLoader     5      wjctrfclr-namespace:Janus.Rodeo.Windows.Library.UI.Controls;assembly=Janus.Rodeo.Windows.Library.UI.Controls     5      1dc"clr-namespace:TagLoader.ViewModels     5        � WindowStyle$
  None=�5	       � AllowsTransparency .  � 
ResizeMode$ 	CanResize=�6@   $��10q�6W      showEffectWindow J� Effect# [  6l    � SizeToContent$ WidthAndHeight=�5
      $��	Condensed&�62   
������  � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      (   "TagLoader.ViewModels.MainViewModel  5   
    � 	Resources 5        DataGridCellLeft �� 
TargetType*  $System.Windows.Controls.DataGridCell	 �� Property
 �� Value�� 5   
   %�   &	       �� 5      "  6-   .�5      �� 	 � ��

 �����6/   �� 5      	 � ��

 ���� 6/   �� 5      	 � ��$
 Center=�66   5      5      .��5      ��   	winBorder#��[ 6   ._�5   
   �   grdBackgroundTransparent#��[ 6    � RowDefinitions 5      �� 5      $��50 �6    �� 5       $��* �6     � ColumnDefinitions 5"      �� 5#      $��* �6#   .+�5&      � -   5        $��grdTitle��5&       $��0��6   
��� E��.+�5'      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��50��6C   $
��Left=�6O   $��Center=�6j   $��	5,0,130,0q�6�   .+�5(      �� $#��Tag Loader - Janus Automation��6    $��25(�6E   $��SemiBold"�6S   
������� �� TextAlignment$ Center=�6�   $��Center=�6�   $��5q�6�   5)      �� 5*      $��0��6   $ 
Horizontal=�6*   $��40��6C   $��Right=�6O   $��Center=�6k   .+�5+      �� -   5        $��__��5+      $��25(�6*   $��	ExtraBold"�68   $��50��6O   $��40��6Z   $��0,0,10,0q�6f     btnTransparent#��[ 6x   5,      �� 5.      -   5        $��X��5.      $��25(�6)   $��	ExtraBold"�67   $��50��6N   $��40��6Y   $��0,0,10,0q�6e   #��[ 6w   5/      50      51      �� 53      $��1��6   $
��Left=�6&   $	��Top=�6A   $��10q�6Y   $	��900��6e    54       �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName��%K  '��       '�� J     �� 55      " ��6   .�56      �� 	 � ��

 ���� 67   57      �� 58      " ��6   .�59      �� 	 � ��
 5:      �� 5;   "   " ��62   .R�5<   &   � $��Panel��6+   .+�5=   *   �� $ ContentSite��6;   $��Center=�6P   $��Center=�6k   $��Header��6�   $
��10,2q�6�   5>   '    5?   &   P� 5@   *    �@��
IsSelected . . �5A   .   �� $ Panel��65   	 � ��

 ��·�6^   5B   +   P� 5C   *    �@��
IsSelected .  . �5D   .   �� $ Panel��65   	 � ��

 �����6^   5E   +   5G   #   5I      5J      5K      .@�5L      �� $
��Tags��6   .��5M      �  5N      �� 5O      $	��200 �6,   �� 5P      $��* �6,    5R      �� 5S      $��* �6/   �� 5T      $��* �6/   .+�5W      �� $��0��6%   $��0��62   $ Vertical=�6B   $��5q�6Y   .+�5X      �� $��Filters��6'   
�������$��14(�6P   .��5Y   "   �� $ Vertical=�6-   .+�5Z   &   �� $ 
Horizontal=�61   $��Right=�6J   .+�5[   *   �� $��Update as you type��60   
�������$��14(�6e   �� 5\   *   $��Center=�63   
������� d� 	IsChecked 6f   ��  �� Path$ UpdateWhileType� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5]   '   �� 5^   &   $ 
Horizontal=�61   $��Right=�6J   .+�5_   *   �� $	��320��62   $��25��6>   $��Center=�6�   $��Center=�6�   ��6J   �� $ 	TxtFilter�$ TwoWay=�$ PropertyChanged=�6�   �� 5`   *   -   5        $��Get Tags��5`   1   $��25��6D   $��90��6P   $��10,0,0,0q�6[   
�������
��� � �$��14(�5a   \   $
��Bold"�6j   
�������$��2q�6�   5b   1   5c   '   �� 5d   &   $ 
Horizontal=�61   $��Right=�6J   .+�5e   *   �� 
��� E��$��14(�6�   $��Right=�6�   $��25��6�   ��60   �� $ InfoCountTags�$ OneWay=�$ PropertyChanged=�6�   5i   '   5j   #   5k      �� 5l      $��Actions��6'   
�������$��14(�6P   .��5m   "   �� $ 
Horizontal=�6-   .+�5n   &   �� -   5        $��50��5n   -   $��80��69   $	��2,5q�6D   $��Center=�6Q   $��Center=�6s   
�������
��� � �$��14(�5o   X   $
��Bold"�6f   
�������$��2q�6�   ��5q   *   �� 5r   .   $��Crane Simulator��68   $
��Wrap=�6O   $ Center=�6c   5t   '   �� 5u   &   -   5        $��50��5u   -   $��80��69   $	��2,5q�6D   $��Center=�6Q   $��Center=�6s   
�������
���P��$��14(�5v   X   $
��Bold"�6f   
�������$��2q�6�   ��5x   *   �� 5y   .   $��Location Simulator��68   $
��Wrap=�6R   $ Center=�6f   5{   '   �� 5|   &   -   5        $��50��5|   -   $��80��69   $	��2,5q�6D   $��Center=�6Q   $��Center=�6s   
�������
����  �$��14(�5}   W   $
��Bold"�6e   
�������$��2q�6�   ��5   *   �� 5�   .   $��Hook Simulator��68   $
��Wrap=�6N   $ Center=�6b   5�   '   �� 5�   &   -   5        $��50��5�   -   $��80��69   $	��2,5q�6D   $��Center=�6Q   $��Center=�6s   
�������
�������$��14(�5�   W   $
��Bold"�6e   
�������$��2q�6�   ��5�   *   �� 5�   .   $��
Enable All��68   $
��Wrap=�6J   $ Center=�6^   5�   '   �� 5�   &   -	   5        $��50��5�   -   $��80��69   $	��2,5q�6D   $��Center=�6Q   $��Center=�6s   
���   �
���2͚�$��14(�5�   Y   $
��Bold"�6g   
�������$��2q�6�   ��5�   *   �� 5�   .   $��Emergency Load��68   $
��Wrap=�6N   $ Center=�6b   5�   '   5�   #   5�      5�      �� 5�      $��0��6%   $��1��62   $ Vertical=�6B   $��5q�6Y   .+�5�      �� $��Set data to Update��6'   
�������$��14(�6[   $	��190��6i   .��5�   "   �� $ Vertical=�6-   .+�5�   &   �� $��Selected Tag:��6,   
�������$��14(�6\   $��Italic$�6j   �� 5�   &   
�������$��16(�6�   $��45��6�   ��6,   �� $ CurrentTag.TagName�$ TwoWay=�$ PropertyChanged=�6�   �� 5�   &   $��Set this values:��6,   
�������$��14(�6_   $��Italic$�6m   �� 5�   &   $ 
Horizontal=�61   $��5,0,0,0q�6J   .+�5�   *   �� $ Vertical=�65   $��0,0,5,0q�6L   $��Center=�6]   .+�5�   .   �� $	��145��66   $��25��6B   $��Center=�6N   $��Center=�6p   ��5�   6   �� $ NewValue�$ TwoWay=�$ PropertyChanged=��� 5�   .   $��Center=�67   $��Set value as TEXT��6R   
�������$��0,5,0,0q�6�    5�   7   �� $ ValueAsText�$ TwoWay=�$ PropertyChanged=�5�   +   �� 5�   *   -
   5        $��50��5�   1   $��80��6=   $��5q�6H   $��Center=�6S   $��Center=�6u   
�������
�������$��14(�5�   [   $
��Bold"�6i   
�������$��2q�6�   ��5�   .   �� 5�   2   $��Update L2 Values��6<   $
��Wrap=�6T   $ Center=�6h   5�   +   �� 5�   *   -   5        $��50��5�   1   $��80��6=   $��5q�6H   $��Center=�6S   $��Center=�6u   
�������
�������$��14(�5�   [   $
��Bold"�6i   
�������$��2q�6�   ��5�   .   �� 5�   2   $��Update All L2 Values��6<   $
��Wrap=�6X   $ Center=�6l   5�   +   �� 5�   *   -   5        $��50��5�   1   $��80��6=   $��5q�6H   $��Center=�6S   $��Center=�6u   
�������
�������$��14(�5�   [   $
��Bold"�6i   
�������$��2q�6�   ��5�   .   �� 5�   2   $��Send Command��6<   $
��Wrap=�6P   $ Center=�6d   5�   +   5�   '   5�   #   5�      5�      �� 5�      $��1��6%   $��0��62   $��2��6B   $��5q�6V   .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ grdItems��5�   '   
������ $��12(�6R   $	��0,5q�6`   $	��550��6m      AutoGenerateColumns .     CanUserSortColumns .  �� AlternationCount$ 2��6�      CanUserResizeColumns . $   HorizontalScrollBarVisibility$ Disabled=�5�   '   "   VerticalScrollBarVisibility$ Visible=�6P   ��5�   '   �� $ LstFilterTags�$ OneWay=�$ PropertyChanged=�  �� SelectedItem  5�   '   �� $ 
CurrentTag�$ TwoWay=�$ PropertyChanged=�!   Columns! 5�   "   0  *System.Windows.Controls.DataGridTextColumn  5�   &   ,  &System.Windows.Controls.DataGridColumn"   Width5  /System.Windows.Controls.DataGridLengthConverter$" * 6g   #   Header$	# Tag��6q   $   FontSize$$ 14Q�6~   1  +System.Windows.Controls.DataGridBoundColumn%   Binding% 69   �� $ TagName�$ OneWay=�6~     5�   &   $	" 200 6h   $# TagValue��6t   $$ 14Q�6�   % 69   �� $ TagValue�$ OneWay=�6�   5�      5�      5�      5�      �� 5�      $��Alarms��6   .��5�      �  5�      �� 5�      $	��220 �6,   �� 5�      $��* �6,    5�      �� 5�      $��* �6/   �� 5�      $��* �6/   .+�5�      �� $��0��6%   $��0��62   $ Vertical=�6B   $��5q�6Y   .+�5�      �� $��Filters��6'   
�������$��14(�6P   .��5�   "   �� $ Vertical=�6-   .+�5�   &   �� $ 
Horizontal=�61   $��Right=�6J   .+�5�   *   �� $��Update as you type��60   
�������$��14(�6e   �� 5�   *   $��Center=�63   
������� 6f   �� $ UpdateWhileTypeAlarm�$ TwoWay=�$ PropertyChanged=�5�   '   �� 5�   &   $ 
Horizontal=�61   $��Right=�6J   .+�5�   *   �� $	��320��62   $��25��6>   $��Center=�6�   $��Center=�6�   ��6J   �� $ TxtFilterAlarm�$ TwoWay=�$ PropertyChanged=�6�   �� 5�   *   -   5        $��
Get Alarms��5�   1   $��25��6F   $��90��6R   $��10,0,0,0q�6]   
�������
��� � �$��14(�5�   \   $
��Bold"�6j   
�������$��2q�6�   5�   1   5�   '   �� 5�   &   $ 
Horizontal=�61   $��Right=�6J   .+�5�   *   �� 
��� E��$��14(�6�   $��Right=�6�   $��25��6�   ��60   �� $ InfoCountAlarms�$ OneWay=�$ PropertyChanged=�6�   5�   '   5�   #   5�      �� 5�      $��Actions��6'   
�������$��14(�6P   $��0,15,0,0q�6^   .��5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� -   5        $��50��5�   -   $��90��69   $��5q�6D   $��Center=�6O   $��Center=�6q   
�������
��� ���$��14(�5�   Y   $
��Bold"�6g   
�������$��2q�6�   ��5�   *   �� 5�   .   $��Load L2 Alarms��68   $
��Wrap=�6N   $ Center=�6b   5�   '   5�   #   5�      5�      �� 5�      $��0��6%   $��1��62   $ Vertical=�6B   $��5q�6Y   .+�5�      �� $��Set data to Update��6'   
�������$��14(�6[   .��5�   "   �� $ Vertical=�6-   .+�5�   &   �� $��Selected Tag:��6,   
�������$��14(�6\   $��Italic$�6j   �� 5�   &   
�������$��16(�6�   $��45��6�   ��6,   �� $ CurrentAlarm.AlarmName�$ TwoWay=�$ PropertyChanged=�6�   �� 5�   &   $��Set this values:��6,   
�������$��14(�6_   $��Italic$�6m   �� 5�   &   $ Vertical=�61   $��5,0,5,0q�6H   $��Center=�6Y   $
��Left=�6t   .+�5�   *   �� $	��340��63   $��Center=�6?   $��Center=�6a   & �� DisplayMemberPath$
& Name��5   7   $��14(�6P   ��5�   7   �� $ LstStatusAlarms�$ OneWay=�$ PropertyChanged=�  5�   7   �� $ CurrentStatusAlarm�$ TwoWay=�$ PropertyChanged=�5   P   5  '   �� 5  &   $ 
Horizontal=�61   .+�5  *   �� -   5        $��40��5  1   $	��100��6=   $��	5,10,10,5q�6I   $��Center=�6\   $��Center=�6~   
�������
�������$��14(�5  [   $
��Bold"�6i   
�������$��2q�6�   ��5  .   �� 5  2   $��Update��6<   $
��Wrap=�6J   $ Center=�6^   5	  +   �� 5
  *   -   5        $��40��5
  1   $	��100��6=   $��
10,10,10,5q�6I   $��Center=�6]   $��Center=�6   
�������
�������$��14(�5  [   $
��Bold"�6i   
�������$��2q�6�   ��5  .   �� 5  2   $��Deactive Current��6<   $
��Wrap=�6T   $ Center=�6h   5  +   �� 5  *   -   5        $��40��5  1   $	��100��6=   $��
10,10,10,5q�6I   $��Center=�6]   $��Center=�6   
�������
�������$��14(�5  [   $
��Bold"�6i   
�������$��2q�6�   ��5  .   �� 5  2   $��Active Current��6<   $
��Wrap=�6R   $ Center=�6f   5  +   5  '   5  #   5     5     �� 5     $��1��6%   $��0��62   $��2��6B   $��5q�6V   .+�5       -   5        $ grdAlarmItems��5  '   
������ $��12(�6W   $	��0,5q�6e   $	��550��6r    .   . $ 2��6�    . $ Hidden=�5!  '   $ Visible=�6N   ��5  '   �� $ LstFilterAlarms�$ OneWay=�$ PropertyChanged=�  5   '   �� $ CurrentAlarm�$ TwoWay=�$ PropertyChanged=�! 5"  "     5#  &   $" 50 6g   $# Id��6r   $$ 14Q�6~   % 69   �� $ AlarmID�$ OneWay=�6~     5$  &   $" * 6i   $
# Name��6s   $$ 14Q�6�   % 69   �� $ 	AlarmName�$ OneWay=�6�     5%  &   $	" 120 6j   $# State��6v   $$ 14Q�6�   % 69   �� $ 
AlarmState�$ OneWay=�6�     5&  &   $	" 130 6f   $# Update��6r   $$ 14Q�6�   % 69   �� $ Update�$ OneWay=�6�     5'  &   $	" 130 6f   $# TimeOn��6r   $$ 14Q�6�   % 69   �� $ TimeOn�$ OneWay=�6�     5(  &   $	" 130 6g   $# TimeOff��6s   $$ 14Q�6�   % 69   �� $ TimeOff�$ OneWay=�6�   5*     5,     5-     50     �� 52     $��Users��6   .��53     �  54     �� 55     $
��Auto �6,   �� 56     $
��Auto �6,   �� 57     $
��Auto �6,    59     �� 5:     $��* �6/   �� 5;     $��* �6/   .+�5>     �� $��0��6%   $��0��62   $��2��6B   $ Vertical=�6V   $��5q�6m   .+�5?     �� $��Session��6'   
�������$��14(�6P   .��5@  "   �  5A  &   �� 5B  *   $
��Auto �68   �� 5C  *   $
��Auto �68   �� 5D  *   $
��Auto �68   �� 5E  *   $
��Auto �68    5G  &   �� 5H  *   $
��Auto �6;   �� 5I  *   $��10 �6;   �� 5J  *   $
��Auto �6;   �� 5K  *   $��10 �6;   �� 5L  *   $
��Auto �6;   .+�5O  &   �� $��0��61   $��0��6>   $ 
Horizontal=�6N   $��5q�6g   .+�5P  *   �� $��Client Type:��60   $	��100��6G   
�������$��14(�6k   �� 5Q  *   $	��160��63   $��Center=�6?   $��Center=�6a   $
& Name��5T  3   $��14(�6L   ��5R  3   �� $ LstClientTypes�$ OneWay=�$ PropertyChanged=�  5S  3   �� $ CurrentClientType�$ TwoWay=�$ PropertyChanged=�5T  L   5U  '   �� 5V  &   $��1��61   $��0��6>   $ 
Horizontal=�6N   $��5q�6g   .+�5W  *   �� $��Client:��60   $	��100��6B   
�������$��14(�6f   �� 5Z  *   $	��160��63   $��Center=�6?   $��Center=�6a   $
& Name��5]  3   $��14(�6L   ��5[  3   �� $ 
LstClients�$ OneWay=�$ PropertyChanged=�  5\  3   �� $ CurrentClient�$ TwoWay=�$ PropertyChanged=�5]  L   5^  '   �� 5_  &   $��0��61   $��2��6>   $ 
Horizontal=�6N   $��5q�6g   .+�5`  *   �� $��User:��60   $	��100��6@   
�������$��14(�6d   �� 5a  *   $	��160��62   $��Center=�6>   $��Center=�6`   $��14(�5b  �   $��25��6�   ��62   �� $ UserName�$ TwoWay=�$ PropertyChanged=�6�   5c  '   �� 5d  &   $��1��61   $��2��6>   $ 
Horizontal=�6N   $��5q�6g   .+�5e  *   �� $��	Password:��60   $	��100��6D   
�������$��14(�6h   �� 5f  *   $	��160��62   $��Center=�6>   $��Center=�6`   $��14(�5g  �   $��25��6�   ��62   �� $ Password�$ TwoWay=�$ PropertyChanged=�6�   5h  '   �� 5j  &   $��0��61   $��4��6>   $��4��6N   $ 
Horizontal=�6_   $��Right=�6x   $��	109,0,0,0q�6�   .+�5k  *   �� -   5        $��65��5k  1   $��90��6=   $��Center=�6H   $��Center=�6j   
�������
��� ���$��14(�5l  Y   $
��Bold"�6g   
�������$��2q�6�   ��5n  .   �� 5o  2   $��Login��6<   $
��Wrap=�6I   $ Center=�6]   5q  +   �� 5r  *   -   5        $��65��5r  1   $��90��6=   $��20,0,0,0q�6H   $��Center=�6Z   $��Center=�6|   
�������
��� ���$��14(�5s  Y   $
��Bold"�6g   
�������$��2q�6�   ��5u  .   �� 5v  2   $��Logout��6<   $
��Wrap=�6J   $ Center=�6^   5x  +   5y  '   5z  #   5{     5|     �� 5~     $��1��6%   $��0��62   $��2��6B   $��0,10,5,0q�6V   $��Right=�6h   .+�5     �� -   5        $��40��5  %   $	��120��61   $��20,0,0,0q�6=   $��Center=�6O   $��Center=�6q   
�������
��� � �$��14(�5�  X   $
��Bold"�6f   
�������$��2q�6�   ��5�  "   �� 5�  &   $��Get All Sessions��60   $
��Wrap=�6H   $ Center=�6\   5�     5�     �� 5�     $��2��6%   $��0��62   $��2��6B   $��5q�6V   .+�5�       -   5        $ grdUsers��5�  '   
������ $��12(�6R   $	��0,5q�6`   $	��550��6m    .   . $ 2��6�    . $ Hidden=�5�  '   $ Visible=�6N   ��5�  '   �� $ LstUsers�$ OneWay=�$ PropertyChanged=�  5�  '   �� $ CurrentUser�$ TwoWay=�$ PropertyChanged=�! 5�  "     5�  &   $	" 300 6}   $# 
ClientType��6�   $$ 14Q�6�   % 69   �� $# Client.Rodeo_Client_Type.Name�$ OneWay=�6�     5�  &   $	" 300 6k   $# Client��6w   $$ 14Q�6�   % 69   �� $ Client.Name�$ OneWay=�6�     5�  &   $" * 6h   $# UserName��6r   $$ 14Q�6�   % 69   �� $ UserName�$ OneWay=�6�   5�     5�     5�     5�     5�     5�     5�     5�     