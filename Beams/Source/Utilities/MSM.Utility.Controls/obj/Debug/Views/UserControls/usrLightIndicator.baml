   M S B A M L   `   `   `  ����  HSM.Utility.Controls,    &HSM.Utility.Controls.usrLightIndicator   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5        $
��this��5      .��5      �� $��Uniform=�6�   ��6   ��   �� Path$  Width� �� ElementName$
 this�� �� UpdateSourceTrigger$ PropertyChanged=���6`   �� $  Height�$
 this��$ PropertyChanged=���5   
   �� 5       �� 
TargetType" ��6   .�5	      ��  �� Property � ��   img_OffIndicator �� Value# [  6+    �� Triggers 5
      ^� 5       ^� 
Conditions 5      �� 5       �� Binding 6(   �� $  LightOn�$
 this��$ PropertyChanged=�	 �� Value		 False6�   �� 5       6(   �� $  IsLightOffRed�$
 this��$ PropertyChanged=�		 False6�   .0�5      ��  � ��# [  63   5      ^� 5       5      �� 5       6(   �� $  LightOn�$
 this��$ PropertyChanged=�		 False6�   �� 5       6(   �� $  IsLightOffRed�$
 this��$ PropertyChanged=�	 True6�   .0�5      ��  � ��  img_OnIndicator# [ 63   5      ^� 5       5      �� 5       6(   �� $  LightOn�$
 this��$ PropertyChanged=�	 true6�   �� 5       6(   �� $  IsLightOnGreen�$
 this��$ PropertyChanged=�		 False6�   .0�5      ��  � ��# [ 63   5      ^� 5        5!      �� 5"       6(   �� $  LightOn�$
 this��$ PropertyChanged=�	 true6�   �� 5#       6(   �� $  IsLightOnGreen�$
 this��$ PropertyChanged=�	 True6�   .0�5%      ��  � ��  img_OnGreenIndicator# [ 63   5&      5(      5*      5+      