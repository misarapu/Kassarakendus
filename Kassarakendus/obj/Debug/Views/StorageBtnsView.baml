   M S B A M L   `   `   `  ����H  DKassarakendus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Kassarakendus.ViewsKassarakendus.Views  5      )    #Kassarakendus.Views.StorageBtnsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Kassarakendus.Views     5      -   5          N�Name$  thisPage��5
       N� Title$ StorageBtnsView��5	       � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '	�       �� 5   
   " 	�6   .�5      ��  � ��$ 15,0,0,0q�6'   �� 5       � ��$ Center=�69   �� 5       � ��$ 16(�6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� -   5         ]�Name$ dbActionBtns��5      $��0,5,0,5q�5      .+�5      �� $
��Left=�6   
�������$��20(�5      $
��Left=�5      ��5      �� *SelectedCategory.CategoryName+5      �� 5      $��Right=�6    �� Orientation$ 
Horizontal=�5       $��Right=�5!      .+�5"      	� -   5        	 	�Name$	 
rbtnSelect��5"      $��Lisa ostukorvi��5#      
 d� 	IsChecked$

 TrueY�5%      	� 5&      -   5        $	 
rbtnDelete��5&      $��Kustuta toode��5'      5(      	� 5)      -   5        $	 rbtnEdit��5)      $��Muuda toodet��5*      5+      5,      5-      �� 5.   
   $��1��6   �� 5/   
   $��2��6   .+�50      �� -   5         ��Name$ 	icButtons��50      ��51      �� *
Products+��52      �� 53      .R�54      � 55      ��57      �� 58      .R�59      �� -   5        $��Stretch=�5:   !      MainButtonStyle#��[  5;   !   .��5<      �� $
��Wrap=�5=   (    �� TextAlignment$ Center=�5>   (   ��5<   (   �� *NameAndPrice+5>   (   5?      5@      5B      �� 5C      ��6   �� *
Categories+��5D      �� 5E      .R�5F      � 5G      ��5I      �� 5J      .R�5K      �� -   5        $��Stretch=�5L   !   #��[  5M   !   .��5N      �� $
��Wrap=�5O   (   $ Center=�5P   (   ��5N   (   �� *CategoryName+5P   (   5Q      5R      5T      5U      5V      5W      