   M S B A M L   `   `   `  ����H  DKassarakendus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Kassarakendus.ViewsKassarakendus.Views  5      #    Kassarakendus.Views.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Kassarakendus.Views     5      $	��350��5	      $	��350��6     N� Title$  	LoginView��5
       N� ShowsNavigationUI .   � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 45��6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 4,0,4,0q�6'   �� 5       � ��$	 Top=�62   �� 5       � ��$ 20(�6)   5      5      .��5      �� $��7q�6   
�������$	��350��5      $	��350��6   $��Center=�5      $��Center=�5      ._�5   
   �� $��5q�6   
������ ._�5      �� $��3q�6   
������� �� Padding$ 15q�5      ._�5      � .+�5       �� -   5         ��Name$ 
tbUserName��5       $��23��5!      $��140,100,0,0q�5"       �� TextWrapping$
 Wrap=�5#      $	��Top=�5$      $	��150��5%      $��Right=�5&      $��Center=�5'      G� 5(      -   5        	 G�Name$	 
tbPassword��5(   "   $��Right=�5)   "   $��23��5*   "   $��140,150,0,0q�6.   $	��Top=�5+   "   $	��150��5,   "   $��Center=�5-   "   �� 5.      -   5        
 ��Name$
 labelUsername��5.      $��Kasutajanimi: ��5/      $
��Left=�50      $��0,95,0,0q�51      $	��Top=�52      
�������$��18(�54      �� 55      -   5        $
 labelPassword��55      $��Salasõna: ��56      $
��Left=�57      $��	0,145,0,0q�58      $	��Top=�59      
�������$��18(�5;      �� 5<      $��	0,200,0,0q�6!    �� Orientation$ 
Horizontal=�5=      $��Center=�5>      .+�5?      �� -   5         ��Name$ btnConfirmLogin��5?   !   $��
Logi sisse��5@   !   
���2͚�5B   !   �� 5C      -   5        $ btnCancelLogin��5C   !   $��Tühista��5D   !   
���Gc��5F   !   5G      �� 5H      -   5         ��Name$ 
loginTitle��5H       $
��Left=�5I       $
��Wrap=�5J       $��Login��5K       $	��Top=�5L       $��36(�5M       
�������5N       �� 5O      -   5         ��Name$ 
spLoginErr��5O   !   $��	0,177,0,0q�5P   !   $��Right=�5Q   !   5R      5S      5T      5U      5W      