   M S B A M L   `   `   `  ����H  DKassarakendus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Kassarakendus.ViewsKassarakendus.Views  5      $    Kassarakendus.Views.AddingView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Kassarakendus.Views     5        N� Title$  Adding��5	       � 	Resources 5
         HeadersStyle �� 
TargetType �� Property �� Value��%�  &	        '�� �     '��     '�� T    �� 5   
   " ��6%   .�5      ��  � ��$ 16(�6)   �� 5       � ��
 �����6+   �� 5       � ��$ 
0,10,10,10q�6'   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ 25��6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 25��6'   5      5      .��5      � $��Center=�6   $��Center=�5      $	��400��5      $	��400��5       � RowDefinitions 5   
   �� 5       $
��auto �6   �� 5!       � ColumnDefinitions 5#   
   �� 5$      �� 5%      .+�5'   
   � $��0��6   $��2��6    5(      �� 5)      �� 5*       5,      �� 5-      $��5* �6#   �� 5.      $��1* �6#   .+�50      �� $��2��6   $��0��6,   #��[  51      $��Lisa uus kategooria��52      �� 53      -   5         ��Name$ tbNewCategory��53      $��0��54      $��1��6&   �� 55      -   5         ��Name$ btnNewCategory��55      $��1��57      $��1��6%   $
��Lisa��58      
���2͚�59      5:      � 5;   
   $��1��6   $��2��6    5<      �� 5=      $
��auto �6    �� 5>       5@      �� 5A      �� 5B      .+�5D      �� $��2��6   #��[  5E      $��Lisa uus toode��5F      �� 5G      $��1��6   .+�5H      �� $��Toote nimetus��6   �� 5I      $��
Toote kood��6   �� 5J      $��Toote kategooria��6   �� 5K      $��
Toote hind��6   �� 5L      $��Toote kogus��6   �� 5M      $��
Kommentaar��6   5N      �� 5O      -   5        	 ��Name$	 spProductForm��5O      $��1��5P      $��1��6&   .+�5Q      �� -   5        $ tbNewProductName��5Q      ��5R      �� *SelectedProduct.ProductName+�� 5S      -   5        $ tbNewProductCode��5S      ��5T      �� *SelectedProduct.ProductCode+�� 5U      -   5        
 ��Name$
 cbNewProductCategory��5U      $��25��5W       �� SelectedIndex$ 0��5X      ��5V      �� *
Categories+��5Y      �� 5Z      .R�5[      �� ��6(   �� *CategoryName+5\      5^      �� 5_      -   5        $ tbNewProductPrice��5_      ��5`      �� *SelectedProduct.ProductPrice+�� 5a      -   5        $ tbNewProductQuanity��5a      ��5b      �� *!SelectedProduct.ProductQuantity+�� 5c      -	   5        $ tbNewProductComment��5c       �� TextWrapping$
 Wrap=�5d      ��5e      �� * SelectedProduct.ProductComment+� 5f       5g      �� 5h      �� 5i      .+�5k      �� -
   5        $ btnNewProduct��5k      $
��Lisa��5m      
���2͚�5n      �� 5o      -   5        $ btnEditProduct��5o      $��Muuda��5q      
���2͚�$y�	Collapsed=�5s      �� 5t      -   5        $ btnCancelAddProduct��5t      $��Tühista��5v      $��1��5w      
���Gc��5x      5y      5z      5{      5~      5      