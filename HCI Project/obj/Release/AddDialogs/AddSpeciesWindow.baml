   M S B A M L   `   `   `  ����   HCI Project    HCI_Project.SpeciesDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � WindowStyle$  
ToolWindow=� � Title$ Specie��$	��583��$	��650�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� ���#ECF0F1.+��� $
��*ID:��$
��Left=�$��	23,22,0,0q�$	��Top=�$��14(��� $��*Name:��$
��Left=�$��	23,51,0,0q�$	��Top=�$��14(��� $��Description:��$
��Left=�$��
23,337,0,0q�$	��Top=�$��14(��� $��*Type:��$
��Left=�$��	23,84,0,0q�$	��Top=�$��14(��� $��Endargement Status:��$
��Left=�$��
23,161,0,0q�$	��Top=�$��14(��� $��Anual Revenue:��$
��Left=�$��
23,479,0,0q�$	��Top=�$��14(��� $��Tourist Status:��$��26��$
��Left=�$��
23,448,0,0q�$	��Top=�$��14(��� -    ��Name$ 
imgSpecies��$��..\Images\pandaLogo.jpg��$��423,0,30,334q� J� OpacityMask
 �   ��� -   $ imgIdWarning��$��..\Images\warning.ico��$��24��$��24��$��
338,22,0,0q�$y�Hidden=�$	��Top=�$
��Left=��� -   $ imgNameWarning��$��..\Images\warning.ico��$��24��$��24��$��
338,55,0,0q�$y�Hidden=�$	��Top=�$
��Left=��� -   $ imgTypeWarning��$��..\Images\warning.ico��$��24��$��24��$��
338,86,0,0q�$y�Hidden=�$	��Top=�$
��Left=��� -   $ imgRevenueWarning��$��..\Images\warning.ico��$��24��$��24��$��338,481,0,0q�$y�Hidden=�$	��Top=�$
��Left=��� -    ��Name$ txtId��$
��Left=�$��26��$��
166,22,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��167��$��14(��� -   $ txtName��$
��Left=�$��26��$��
166,53,0,0q�$
 Wrap=�$	��Top=�$	��167��$��14(��� -    ��Name$ cmbType��$
��Left=�$��26��$��
166,84,0,0q�$	��Top=�$	��167��$��14(��� -	   	 ��Name$	 chckIUCN��$��Placed on IUCN Red List��$
��Left=�$��
23,143,0,0q�$	��Top=�$��14(��� -
   $ cmbEndangered��$
��Left=�$��26��$��166,161,0,0q�$	��Top=�$	��167��$��14(�.@��� .��Critically Endangered�� 
 �� 
IsSelected
 . .��
Endangered�� .��
Vulnerable�� .��&$Dependent on Conservation of Habitat�� .��	Near Risk�� .��Lowest Risk�� -   $	 chckArea��$��Lives in Populated Area��$
��Left=�$��
23,215,0,0q�$	��Top=�$��14(��� -   $	 
chckDanger��$��Dangerous to people��$
��Left=�$��
23,238,0,0q�$	��Top=�$��14(�(  "System.Windows.Controls.DatePicker  -     Name$
 date��$��26��$
��Left=�$��166,281,0,0q�$	��Top=�$	��167���� -   $ txtDesc��$
��Left=�$��85��$��166,337,0,0q�$
 Wrap=�$	��Top=�$	��167��$��14(��� -   $ 
cmbTourist��$��26��$��166,448,0,0q�$	��Top=�$
��Left=�$	��167��$��14(�.@��� 
 . .��-�� .��
Isolated�� .��Partially Habited�� .��	Habited�� -   $ 
txtRevenue��$��26��$��166,479,0,0q�$
 Wrap=�$	��Top=�$	��167��$��14(�$
��Left=�.�� � ToolTip$ In dollars!��.���� -   $��Change picture��$��499,190,30,0q�$��23��$	��Top=��� -    ��Name$ listTag��$��82��$��467,281,30,0q�$	��Top=�{�.   �� SelectionMode$ Multiple=��� -    ��Name$ btnAdd��$	��Add��$��499,482,30,21q�$��16(�{�.  �� -   $��Cancel��$
��Left=�$��380,482,0,21q�$	��114��$��16(��� $��Date of Discovery:��$
��Left=�$��
23,281,0,0q�$	��Top=�$��14(��� $
��Tag:��$
��Left=�$��29��$��423,281,0,0q�$��14(�$	��Top=�$��58���� -    ��Name$ 
lblWarning��$9��3All fields that contain * must be filled correctly.��$
��Left=�$��338,448,0,0q�$	��Top=�$��14(����#D91E18