   M S B A M L   `   `   `  ����Z  VCase_Management_Submission_Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Case_Management_Submission_Task.MVVM.Views*Case_Management_Submission_Task.MVVM.Views  5      q=clr-namespace:Case_Management_Submission_Task.MVVM.ViewModels/Case_Management_Submission_Task.MVVM.ViewModels  5      >    8Case_Management_Submission_Task.MVVM.Views.CustomersView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:Case_Management_Submission_Task.MVVM.Views     5      T
viewmodels=clr-namespace:Case_Management_Submission_Task.MVVM.ViewModels     5      .��5      � $��20q�6     � ColumnDefinitions  5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��20q�6    � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��* �6    .+�5      �� $��0��6   $��	Customers��6%   $��18(�66   $��Medium"�6D   �� 5      -   5        $��1��5      
������ 
������ $��0q�5       ��5   $   �� *	Customers+ �� SelectedItem 5      �� *SelectedCustomer+��5!      �� 5"      .R�5#      �� .+�5$      �� $��Medium"�6E   ��6(   �� *DisplayName+6E   �� 5%      $��0 0 0 5q�6?   ��6(   �� *Email+6?   5&      5'      5)      5+      � 5-   
   $��1��6   $��	0 20 0 20q�6    5/      �� 50      $
��Auto �6    �� 51      $��* �6    �� 52      $
��Auto �6    .+�55      �� $��0��6   $��PERSONAL INFOMATION��6%   $��18(�6@   $��Medium"�6N   �� 57      
���   �$��1q�6)   $��Center=�6=   $��1��6X   ._�58      � $��1��6     5:      �� 5;      $
��Auto �6+   �� 5<      $��* �6+   .+�5?      � $��0��6   $��Center=�6+   $��0 0 15 0q�6F     5A      �� 5B      $
��Auto �6/   �� 5C      $��* �6/   .+�5F      �� $��0��6%   .+�5G      �� $��First name:��6(   $��
10 10 0 10q�6;   $��Medium"�6O   �� 5H      $��
Last name:��6(   $��
10 10 0 10q�6:   $��Medium"�6N   �� 5I      $��Email:��6(   $��
10 10 0 10q�66   $��Medium"�6J   �� 5J      $��Phone number:��6(   $��
10 10 0 10q�6=   $��Medium"�6Q   5K      �� 5M      $��1��6%   .+�5N      �� -   5        $��tb_firstName��5N   (   $��
10 10 0 10q�6h   ��6<   �� *SelectedCustomer.FirstName+6h   �� 5O      -   5        $��tb_lastName��5O   (   $��
10 10 0 10q�6f   ��6;   �� *SelectedCustomer.LastName+6f   �� 5P      -   5        $��tb_email��5P   (   $��
10 10 0 10q�6`   ��68   �� *SelectedCustomer.Email+6`   �� 5Q      -   5        $��tb_phoneNumber��5Q   (   $��
10 10 0 10q�6l   ��6>   �� *SelectedCustomer.PhoneNumber+6l   5R      5T      � 5V      $��1��6   $��Center=�6+   $��15 0 0 0q�6G   .+�5X      �   5Z      �� 5[   "   $
��Auto �63   �� 5\   "   $��* �63   .+�5_      �� $��0��6)   .+�5`   "   �� $��Street name:��6,   $��
10 10 0 10q�6@   $��Medium"�6T   �� 5a   "   $��Postal code:��6,   $��
10 10 0 10q�6@   $��Medium"�6T   �� 5b   "   $��City:��6,   $��
10 10 0 10q�69   $��Medium"�6M   5c      �� 5e      $��1��6)   .+�5f   "   �� -   5        $��tb_streetName��5f   ,   $��
10 10 0 10q�6n   ��6A   �� *SelectedCustomer.StreetName+6n   �� 5g   "   -   5        $��tb_postalCode��5g   ,   $��
10 10 0 10q�6n   ��6A   �� *SelectedCustomer.PostalCode+6n   �� 5h   "   -   5        $��tb_city��5h   ,   $��
10 10 0 10q�6b   ��6;   �� *SelectedCustomer.City+6b   �� 5i   "   $��
10 10 0 10q�6,   5j      5k      5l      5n      5o      �� 5q      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   .+�5r      �� $��Add Case��6F   $	��150��6Y   $��40��6e   $��0 0 10 0q�6q   ��6   �� *NavigateToAddCaseCommand+6q   �� 5s      $��
Edit Cases��6H   $	��150��6]   $��40��6i   $��10 0 0 0q�6u   ��6   �� *NavigateToEditCasesCommand+6u   5t      5u      5w      5x      