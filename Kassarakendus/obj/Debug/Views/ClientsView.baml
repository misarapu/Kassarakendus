   M S B A M L   `   `   `  ����H  DKassarakendus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Kassarakendus.ViewsKassarakendus.Views  5      %    Kassarakendus.Views.ClientsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Kassarakendus.Views     5        N� Title$  ClientsView��5	      .��5      ]� .+�5   
   ]� 
���������.  $	��150��5      $
��Left=�5      .+�5      �� -   5         ��Name$ 	icClients��5      $	��Top=�5      ��5      �� *
AllClients+��5      �� 5      .R�5      ��  ��Name$ 	btnClient��6!   -   5        $��Stretch=�5   !   
������ $��16(�5   !   $��Center=�5   !   ��5   !   �� *
FullName+5   !   5      5      �� 5      $��Bottom=�6   .+�5       �� $��Otsi:��6   �� 5!      -   5         ��Name$ tbSearchClient��5!      $��16(�5#      $��0,1,0,0q�5$      5%      5&      � 5(   
   .+�5)      �  � RowDefinitions 5*      �� 5+      $��* �6$   �� 5,      $
��Auto �6$   .+�5.      �� -   5         ��Name$ spUserControl��5.      
�������5/      �� 50      -   5        $ 
spInfoBtns��51         	spButtons#��[  50      $��1��52      .+�53      �� -   5        $ btnSelectClient��53      .��55      �� $0��*../Views/Images/Icons/appbar.checkmark.png��6    56      �� 57      -   5        .��58      �� $5��/../Views/Images/Icons/appbar.user.add.light.png��6    59      �� 5:      -   5        $ btnDeleteClient��5:      .��5<      �� $2��,../Views/Images/Icons/appbar.user.delete.png��6    5=      5>      5?      � 5A      -	   5         �Name$ gridClientAdd��5A      $y�	Collapsed=�5B       5C      �� 5D      $��* �6$   �� 5E      $
��Auto �6$   .+�5G      ��  
 spInfo#��[ 6   .+�5H      ��  �� Orientation$ 
Horizontal=�6!   .+�5I      �� $��	Eesnimi: ��6    �� 5J      -
   5        $ tbFirstName��5J   "   5K      �� 5L      $ 
Horizontal=�6!   .+�5M      �� $��
Perenimi: ��6    �� 5N      -   5        $ 
tbLastName��5N   "   5O      �� 5P      $ 
Horizontal=�6!   .+�5Q      �� $��	Telefon: ��6    �� 5R      -   5        $ tbPhone��5R   "   5S      �� 5T      $ 
Horizontal=�6!   .+�5U      �� $��E-mail: ��6    �� 5V      -   5        $ tbEmail��5V   "   5W      �� 5X      $ 
Horizontal=�6!   .+�5Y      �� $��Tase: ��6    �� 5Z      -   5         ��Name$ cbClientLevel��5Z   #   	 �� SelectedIndex$	 0��5\   #   ��5[   #   �� *Levels+��5]      �� 5^   "   .R�5_   &   �� ��60   �� *	LevelName+5`   #   5b      5c      5d      � 5f      $��1��6   
 � ColumnDefinitions
 5g      �� 5h      �� 5i      .+�5k      �� -   5        $ btnAddNewClient��5k      $��16(�5m      $
��Lisa��5n      
���2͚�5o      �� 5p      -   5        $ btnCancelAddUser��5p      $��2��5q      $��16(�5r      $��Tühista��5s      
���Gc��5u      5v      5w      5x      5y      5z      