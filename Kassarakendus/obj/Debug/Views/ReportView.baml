   M S B A M L   `   `   `  ����H  DKassarakendus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Kassarakendus.ViewsKassarakendus.Views  5      $    Kassarakendus.Views.ReportView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Kassarakendus.Views     5        N� Title$  
ReportView��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%V   '��       �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   5      5      .��5      � .+�5   
   ]� .+�5      �� $
��Left=�6   $��0,0,15,0q�5      .+�5      �� $��Otsing:��6   $��24(�5      $��0,0,0,20q�5      
�������5      �� 5      $��Alates:��6   
�������5      (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
dPickSince��5      �� 5      $��Kuni:��6   
�������5        5      -   5        $ dPickTo��5      �� 5      -   5         ��Name$ 
btnResults��5      $��Näita��5      $��	0,10,0,10q�5       
���2͚�5"      �� 5#      $��Müüja:��6   
�������5$      �� 5%      -   5         ��Name$ cbClerk��5%       �� SelectedIndex$ 0��5'      ��5&      �� *
AllUsers+��5(      �� 5)      .R�5*      �� ��6(   �� *
FullName+5+      5-      �� 5.      -   5        $ btnResultsUser��5.      $��Näita��5/      $��	0,10,0,10q�50      
���2͚�52      53      �� 54      
�������.+�55      �� $��	Tulemused��6   $��24(�56      $��0,0,0,20q�57      �� 58      	 �� Orientation$	 
Horizontal=�6   .+�59      �� $��	Müüja: ��6   $��70��5:      �� 5;      -   5        
 ��Name$
 tblClerk��5;       5<      �� 5=      $	 
Horizontal=�6   .+�5>      �� $��Alates: ��6   $��70��5?      �� 5@      -   5        $
 tblSince��5@       5A      �� 5B      $	 
Horizontal=�6   .+�5C      �� $��Kuni: ��6   $��70��5D      �� 5E      -   5        $
 tblTo��5E       5F      �� 5G      $	 
Horizontal=�6   .+�5H      �� $��Käive: ��6   $��70��5I      �� 5J      -	   5        $
 tblSales��5J       5K      �� 5L      $	 
Horizontal=�6   .+�5M      �� $��Tehinguid: ��6   �� 5N      -
   5        $
 tblTotal��5N       $��70��5O       5P      5Q      5R      5S      5T      