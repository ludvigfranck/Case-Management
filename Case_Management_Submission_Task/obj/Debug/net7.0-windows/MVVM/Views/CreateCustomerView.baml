   M S B A M L   `   `   `  ����Z  VCase_Management_Submission_Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Case_Management_Submission_Task.MVVM.Views*Case_Management_Submission_Task.MVVM.Views  5      q=clr-namespace:Case_Management_Submission_Task.MVVM.ViewModels/Case_Management_Submission_Task.MVVM.ViewModels  5      C    =Case_Management_Submission_Task.MVVM.Views.CreateCustomerView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:Case_Management_Submission_Task.MVVM.Views     5      T
viewmodels=clr-namespace:Case_Management_Submission_Task.MVVM.ViewModels     5      .��5      � $��20q�6     � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��CREATE CUSTOMER��6!   $��Center=�68   $��18(�6U   $��Medium"�6c   � 5   
   $��1��6   $	��Top=�6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      � $��0��6   $��0 0 15 0q�6#   .+�5      �� $��Center=�6   .+�5      �� $��Enter First name:��6    $
��Auto��69   $��Medium"�6G   �� 5       �� CornerRadius$ 0��6   $��1q�5       
���   �
������� �� Padding$ 2q�5#      $��0 0 0 20q�5$      ._�5%      �� 
������ $��0q�6`   ��6"   �� *Customer.FirstName+6`   5&      �� 5(      $��Enter Last name:��6    $
��Auto��68   $��Medium"�6F   �� 5)      $ 0��6   $��1q�5*      
���   �
�������$ 2q�5-      $��0 0 0 20q�5.      ._�5/      �� 
������ $��0q�6_   ��6"   �� *Customer.LastName+6_   50      �� 52      $��Enter Email address:��6    $
��Auto��6<   $��Medium"�6J   �� 53      $ 0��6   $��1q�54      
���   �
�������$ 2q�57      $��0 0 0 20q�58      ._�59      �� 
������ $��0q�6\   ��6"   �� *Customer.Email+6\   5:      �� 5<      $��Enter Phone number:��6    $
��Auto��6;   $��Medium"�6I   �� 5=      $ 0��6   $��1q�5>      
���   �
�������$ 2q�5A      $��0 0 0 20q�5B      ._�5C      �� 
������ $��0q�6b   ��6"   �� *Customer.PhoneNumber+6b   5D      �� 5F      $��Enter Street name:��6    $
��Auto��6:   $��Medium"�6H   �� 5G      $ 0��6   $��1q�5H      
���   �
�������$ 2q�5K      $��0 0 0 20q�5L      ._�5M      �� 
������ $��0q�6a   ��6"   �� *Customer.StreetName+6a   5N      5O      5P      � 5R      $��1��6   $��15 0 0 0q�6#     5T      �� 5U      $
��auto �6$   �� 5V      $��* �6$   .+�5Y      �� $��0��6   $��Center=�6*   .+�5[      �� $��Enter Postal code:��6    $
��Auto��6:   $��Medium"�6H   �� 5\      $ 0��6   $��1q�5]      
���   �
�������$ 2q�5`      $��0 0 0 20q�5a      ._�5b      �� 
������ $��0q�6a   ��6"   �� *Customer.PostalCode+6a   5c      �� 5e      $��Enter City:��6    $
��Auto��63   $��Medium"�6A   �� 5f      $ 0��6   $��1q�5g      
���   �
�������$ 2q�5j      $��0 0 0 20q�5k      ._�5l      �� 
������ $��0q�6[   ��6"   �� *Customer.City+6[   5m      5n      � 5p      $��1��6     5r      �� 5s      $
��Auto �6(   �� 5t      $��* �6(   .+�5w      �� $��0��6    $��Select Device/Devices:��6-   $
��Auto��6K   $��Medium"�6Y   � 5y      $��1��6    5z      �� 5{      $
��Auto �6/   �� 5|      $
��Auto �6/   .+�5      ��  �� SelectionMode$ Multiple=�5�   %   $
��Auto��5�   %   
������ ��5   "   �� *	Devices+ �� SelectedItem 5�   %   �� *SelectedDevices+��5�      �� 5�   "   .R�5�   &   ��  �� Orientation$ 
Horizontal=�61   .+�5�   *   �� ��64   �� *
DeviceName+�� 5�   *    d� 	IsChecked 63   �� *
IsSelected+5�   '   5�   #   5�      �� 5�      $��0 0 0 20q�6%   $
��Auto��67   5�      5�      5�      5�      5�      �� 5�   
   $��2��6;   $��ADD CUSTOMER��6H   $��44��6_   $	��188��6k   ��6   �� *CreateCustomerCommand+6k   5�      5�      