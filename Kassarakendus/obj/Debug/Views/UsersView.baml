   M S B A M L   `   `   `  ����H  DKassarakendus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Kassarakendus.ViewsKassarakendus.Views  5      #    Kassarakendus.Views.UsersView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Kassarakendus.Views     5      -   5          N� Title$  	UsersView��5	      .��5      ]� .+�5   
   ]� 
���������.  $	��150��5      $
��Left=�5      .+�5      �� -   5         ��Name$ icUsers��5      $	��Top=�5      ��5      �� *
AllUsers+��5      �� 5      .R�5      ��  ��Name$ btnUser��6!   -   5        $��Stretch=�5   !   
������ $��16(�5   !   $��Center=�5   !   ��5   !   �� *
FullName+5   !   5      5      �� 5      $��Bottom=�6   .+�5       �� $��Otsi:��6   �� 5!      -   5         ��Name$ tbSearchUser��5!      $��16(�5#      $��0,1,0,0q�5$      5%      5&      � 5(   
   .+�5)      �  � RowDefinitions 5*      �� 5+      $��* �6$   �� 5,      $
��Auto �6$   .+�5.      �� $
��Auto=�6   .��5/      �� -   5         ��Name$ spUserControl��5/   !   
�������50   !   51      �� 52      -   5        $ 
spInfoBtns��53         	spButtons#��[  52      $��1��54      .+�55      �� -   5        .��56      �� $5��/../Views/Images/Icons/appbar.user.add.light.png��6    57      �� 58      -   5        $ btnDeleteUser��58      .��5:      �� $2��,../Views/Images/Icons/appbar.user.delete.png��6    5;      5<      5=      � 5?      -	   5         �Name$ gridUserAdd��5?      $y�	Collapsed=�5@       5A      �� 5B      $��* �6$   �� 5C      $
��Auto �6$   .+�5E      ��  
 spInfo#��[ 6   .+�5F      ��  �� Orientation$ 
Horizontal=�6!   .+�5G      �� $��	Eesnimi: ��6    �� 5H      -
   5        $ tbFirstName��5H   "   5I      �� 5J      $ 
Horizontal=�6!   .+�5K      �� $��
Perenimi: ��6    �� 5L      -   5        $ 
tbLastName��5L   "   5M      �� 5N      $ 
Horizontal=�6!   .+�5O      �� $��Kasutajanimi: ��6    �� 5P      -   5        $ 
tbUserName��5P   "   5Q      �� 5R      $ 
Horizontal=�6!   .+�5S      �� $��
Salasõna:��6    G� 5T      -   5         G�Name$ 
pbPassword��5T   &   5U      �� 5V      $ 
Horizontal=�6!   .+�5W      �� $��Sünniaeg: ��6    �� 5X      $ 
Horizontal=�6%   .+�5Y      �� -   5        $ tbDay��5Y   &   $��30��5Z   "   �� 5[      -   5        $ tbMonth��5[   &   $��30��5\   "   �� 5]      -   5        $ tbYear��5]   &   $��50��5^   "   5_      5`      �� 5a      $ 
Horizontal=�6!   .+�5b      �� $��Roll: ��6    �� 5c      -   5        	 ��Name$	 
cbUserRole��5c   #   
 �� SelectedIndex$
 0��5d   #   .@�5e      �� $��Admin��6+   �� 5f      $��Müüja��6+   5g      5h      �� 5i      $ 
Horizontal=�6!   .+�5j      �� $��	Telefon: ��6    �� 5k      -   5        $ tbPhone��5k   "   5l      �� 5m      $ 
Horizontal=�6!   .+�5n      �� $��E-mail: ��6    �� 5o      -   5        $ tbEmail��5o   "   5p      5q      � 5s      $��1��6    � ColumnDefinitions 5t      �� 5u      �� 5v      .+�5x      �� -   5        $ btnAddNewUser��5x      $��16(�5z      $
��Lisa��5{      
���2͚�5|      �� 5}      -   5        $ btnCancelAddUser��5}      $��2��5~      $��16(�5      $��Tühista��5�      
���Gc��5�   (   5�      5�      5�      5�      5�      