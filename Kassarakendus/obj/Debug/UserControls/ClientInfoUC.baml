   M S B A M L   `   `   `  ����H  DKassarakendus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Kassarakendus.UserControlsKassarakendus.UserControls  5      -    'Kassarakendus.UserControls.ClientInfoUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Kassarakendus.UserControls     5      $��Stretch=�5	        � 	Resources  5
       �� 
TargetType �� Property �� Value��%�   '��       '�� m     �� 5   
   " ��6   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 0q�60   5      �� 5   
   " ��6   .�5      ��  � ��$ 20��6'   �� 5       � ��$ 20��6&   5      5      .��5      � .+�5   
   �� -   5         ��Name$ 
spUserInfo��5       
  spInfo#��[  5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        .��5      �� $+��%../Views/Images/Icons/appbar.edit.png��6   5      �� 5      $��Eesnimi:��6   �� 5      -   5         ��Name$ tblFirstName��5      ��5      �� *Client.FirstName+�� 5      -   5         ��Name$ tbFirstName��5      $y�	Collapsed=�5      5       5!      �� 5"      $ 
Horizontal=�6   .+�5#      �� -   5        .��5$      �� $+��%../Views/Images/Icons/appbar.edit.png��6   5%      �� 5&      $��
Perenimi: ��6   �� 5'      -   5        $ tblLastName��5'      ��5(      �� *Client.LastName+�� 5)      -   5        $ 
tbLastName��5)      $y�	Collapsed=�5*      5+      5,      �� 5-      $ 
Horizontal=�6   .+�5.      �� -   5        .��5/      �� $+��%../Views/Images/Icons/appbar.edit.png��6   50      �� 51      $��	Telefon: ��6   �� 52      -	   5        $ tblPhone��52      ��53      �� *Client.Phone+�� 54      -
   5        $ tbPhone��54      $y�	Collapsed=�55      56      57      �� 58      $ 
Horizontal=�6   .+�59      �� -   5        .��5:      �� $+��%../Views/Images/Icons/appbar.edit.png��6   5;      �� 5<      $��E-mail: ��6   �� 5=      -   5        $ tblEmail��5=      ��5>      �� *Client.Email+�� 5?      -   5        $ tbEmail��5?      $y�	Collapsed=�5@      5A      5B      �� 5C      $ 
Horizontal=�6   .+�5D      �� -   5        .��5E      �� $+��%../Views/Images/Icons/appbar.edit.png��6   5F      �� 5G      $��Tase: ��6   �� 5H      -   5        $ tblLevel��5H      ��5I      �� *ClientLevel.LevelName+�� 5J      -   5         ��Name$ cbClientLevel��5J      $y�	Collapsed=�5L      ��5K      �� *Levels+��5M      �� 5N      .R�5O      �� ��6(   �� *	LevelName+5P      5R      5S      �� 5T      $ 
Horizontal=�6   .+�5U      �� $��Klient alates: ��6   �� 5V      -   5        $ tblSince��5V      ��5W      �� *Client.Since+	 �� StringFormat$	 
dd-MM-yyyy��5X      � 5Y      -   5        
 �Name$
 gridEditBtns��5Y      $y�	Collapsed=�5Z       � ColumnDefinitions 5[      �� 5\      �� 5]      .+�5_      �� -   5         ��Name$ btnEditConfirm��5_      $��Uuenda��5a      
���2͚�5b      �� 5c      -   5        $ btnCancelEdit��5c      $��Tühista��5e      $��1��5f      
���Gc��5g      5h      5i      5j      5k      