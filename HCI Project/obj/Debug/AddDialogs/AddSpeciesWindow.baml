   M S B A M L   `   `   `  ����  HCI Project    HCI_Project.SpeciesDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStyle$  
ToolWindow=�5   	    � Title$ Specie��5   	   $	��583��6   $	��650��6%    � 
ResizeMode$ NoResize=�61    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���#ECF0F1.+�5   
   �� $
��*ID:��6   $
��Left=�6   $��	23,22,0,0q�6:   $	��Top=�6M   $��14(�6e   �� 5	   
   $��*Name:��6   $
��Left=�6!   $��	23,51,0,0q�6<   $	��Top=�6O   $��14(�6g   �� 5
   
   $��Description:��6   $
��Left=�6'   $��
23,337,0,0q�6B   $	��Top=�6V   $��14(�6n   �� 5   
   $��*Type:��6   $
��Left=�6!   $��	23,84,0,0q�6<   $	��Top=�6O   $��14(�6g   �� 5   
   $��Endargement Status:��6   $
��Left=�6.   $��
23,161,0,0q�6I   $	��Top=�6]   $��14(�6u   �� 5   
   $��Anual Revenue:��6   $
��Left=�6)   $��
23,479,0,0q�6D   $	��Top=�6X   $��14(�6p   �� 5   
   $��Tourist Status:��6   $��26��6*   $
��Left=�66   $��
23,448,0,0q�6Q   $	��Top=�6e   $��14(�6}   �� 5   
   -   5         ��Name$ 
imgSpecies��5      $��..\Images\pandaLogo.jpg��6$   $��423,0,30,334q�6E    J� OpacityMask
 �   �6[   �� 5   
   -   5        $ imgIdWarning��5      $��..\Images\warning.ico��6&   $��24��6E   $��24��6P   $��
338,22,0,0q�6\   $y�Hidden=�6p   $	��Top=�6�   $
��Left=�6�   �� 5   
   -   5        $ imgNameWarning��5      $��..\Images\warning.ico��6(   $��24��6G   $��24��6R   $��
338,55,0,0q�6^   $y�Hidden=�6r   $	��Top=�6�   $
��Left=�6�   �� 5   
   -   5        $ imgTypeWarning��5      $��..\Images\warning.ico��6(   $��24��6G   $��24��6R   $��
338,86,0,0q�6^   $y�Hidden=�6r   $	��Top=�6�   $
��Left=�6�   �� 5   
   -   5        $ imgRevenueWarning��5      $��..\Images\warning.ico��6+   $��24��6J   $��24��6U   $��338,481,0,0q�6a   $y�Hidden=�6v   $	��Top=�6�   $
��Left=�6�   �� 5   
   -   5         ��Name$ txtId��5      $
��Left=�6!   $��26��6<   $��
166,22,0,0q�6H    �� TextWrapping$
 Wrap=�6\   $	��Top=�6q   $	��167��6�   $��14(�6�   6�   �� 5   
   -   5        $ txtName��5      $
��Left=�6#   $��26��6>   $��
166,53,0,0q�6J   $
 Wrap=�6^   $	��Top=�6s   $	��167��6�   $��14(�6�   6�   �� 5   
   -   5         ��Name$ cmbType��5      $
��Left=�6$   $��26��6?   $��
166,84,0,0q�6K   $	��Top=�6_   $	��167��6w   $��14(�6�   6�   �� 5   
   -	   5        	 ��Name$	 chckIUCN��5      $��Placed on IUCN Red List��6%   $
��Left=�6G   $��
23,143,0,0q�6b   $	��Top=�6v   $��14(�6�   �� 5   
   -
   5        $ cmbEndangered��5      $
��Left=�6*   $��26��6E   $��166,161,0,0q�6Q   $	��Top=�6f   $	��167��6~   $��14(�6�   .@�5      �� .��6   Critically Endangered62   �� 5      
 �� 
IsSelected
 . .��6-   
Endangered69   �� 5      .��6   
Vulnerable6'   �� 5      .��6   &$Dependent on Conservation of Habitat6A   �� 5      .��6   	Near Risk6&   �� 5       .��6   Lowest Risk6(   5!      �� 5"   
   -   5        $	 chckArea��5"      $��Lives in Populated Area��6%   $
��Left=�6G   $��
23,215,0,0q�6b   $	��Top=�6v   $��14(�6�   �� 5#   
   -   5        $	 
chckDanger��5#      $��Dangerous to people��6'   $
��Left=�6E   $��
23,238,0,0q�6`   $	��Top=�6t   $��14(�6�   (  "System.Windows.Controls.DatePicker  5$   
   -   5          Name$
 date��5$      $��26��6#   $
��Left=�6/   $��166,281,0,0q�6J   $	��Top=�6_   $	��167��6w   �� 5%   
   -   5        $ txtDesc��5%      $
��Left=�6#   $��85��6>   $��166,337,0,0q�6J   $
 Wrap=�6_   $	��Top=�6t   $	��167��6�   $��14(�6�   �� 5'   
   -   5        $ 
cmbTourist��5'      $��26��6'   $��166,448,0,0q�63   $	��Top=�6H   $
��Left=�6`   $	��167��6{   $��14(�6�   .@�5(      �� 
 . .��6-   -60   �� 5)      .��6   
Isolated6%   �� 5*      .��6   Partially Habited6.   �� 5+      .��6   	Habited6$   5,      �� 5.   
   -   5        $ 
txtRevenue��5.      $��26��6&   $��166,479,0,0q�62   $
 Wrap=�6G   $	��Top=�6\   $	��167��6t   $��14(�6�   $
��Left=�6�   .��6�    � ToolTip$ In dollars!��5/   ;   .��50      �� 52   
   -   5        $��Change picture��52      $��499,190,30,0q�6*   $��23��6@   $	��Top=�6L   6d   �� 54   
   -   5         ��Name$ listTag��54      $��82��6#   $��467,281,30,0q�6/   $	��Top=�6E   {�.   �� SelectionMode$ Multiple=�6o   55      �� 57   
   -   5         ��Name$ btnAdd��57      $	��Add��6!   $��499,482,30,21q�6/   $��16(�6F   {�.  6i   �� 58   
   -   5        $��Cancel��58      $
��Left=�6"   $��380,482,0,21q�6=   $	��114��6S   $��16(�6_   6m   �� 5:   
   $��Date of Discovery:��6   $
��Left=�6-   $��
23,281,0,0q�6H   $	��Top=�6\   $��14(�6t   �� 5;   
   $
��Tag:��6   $
��Left=�6   $��29��6:   $��423,281,0,0q�6F   $��14(�6[   $	��Top=�6j   $��58��6�   �� 5<   
   -   5         ��Name$ 
lblWarning��5<      $9��3All fields that contain * must be filled correctly.��6$   $
��Left=�6b   $��338,448,0,0q�6}   $	��Top=�6�   $��14(�6�   ���#D91E186�   5>      5?      