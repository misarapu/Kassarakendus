   M S B A M L   `   `   `  ����H  DKassarakendus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Kassarakendus.UserControlsKassarakendus.UserControls  5      +    %Kassarakendus.UserControls.UserInfoUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Kassarakendus.UserControls     5      .��5	      � .+�5
   
   �� -   5          ��Name$  
spUserInfo��5
       
  spInfo#��[  5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��	Eesnimi: ��6   �� 5      -   5         ��Name$ tblFirstName��5      ��5      �� *User.FirstName+5      �� 5      $ 
Horizontal=�6   .+�5      �� $��
Perenimi: ��6   �� 5      -   5        $ tblLastName��5      ��5      �� *User.LastName+5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Sünniaeg: ��6   �� 5      -   5        $ tblBirthDate��5      ��5      �� *User.BirthDateStr+5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Kasutajanimi: ��6   �� 5      -   5        $ tblUserName��5      ��5      �� *User.UserName+5      �� 5       $ 
Horizontal=�6   .+�5!      �� $��	Telefon: ��6   �� 5"      -   5        $ tblPhone��5"      ��5#      �� *
User.Phone+5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� $��E-mail: ��6   �� 5'      -   5        $ tblEmail��5'      ��5(      �� *
User.Email+5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� $��Tööl alates: ��6   �� 5,      -   5        $ tblSince��5,      ��5-      �� *
User.Since+ �� StringFormat$ 
dd-MM-yyyy��5.      5/      50      51      