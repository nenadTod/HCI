   M S B A M L   `   `   `  ����V  RMapControl.WPF, Version=2.4.11.0, Culture=neutral, PublicKeyToken=f26fcf0059638459?0clr-namespace:MapControl;assembly=MapControl.WPF
MapControl  5       HCI Project&    HCI_Project.Controls.ResourceMap   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @map0clr-namespace:MapControl;assembly=MapControl.WPF     5        � 	Resources  5
         MapControl.TileLayer   	Landscape   
SourceName   Description   
TileSource$   MapControl.TileSourceConverter �� 
TargetType  VisibleAnimation �� Property �� Value �� Triggers P� Property	 P� Value
 N� EnterActions �� TargetProperty W� From	 W� To g� Duration��%v  &	        &	       5   
   $ Thunderforest Landscape��6*   $� �Maps © [Thunderforest](http://www.thunderforest.com/), Data © [OpenStreetMap Contributors](http://www.openstreetmap.org/copyright)��5      $A ;http://{c}.tile.thunderforest.com/landscape/{z}/{x}/{y}.png 5      �� 5   
   " �6   .�5      ��  � y�$ 	Collapsed=�6+   �� 5       �@J�Opacity$ 0Q�6(    5      P� 5       � y�$	 Visible=�60   
 5      �� 5      .��5      �� .��5   "   W� $ Opacity�62   $	 0.0X�5      $	 1.0X�6)   $ 0:0:0.5D�62   5      5      5!      5#      5$      .��5&      � .+�5'   
   � -   5        $��Filter��5'      #��[ 6    K� ZIndex$ 1��6G   ���#ECF0F1$��36��6m   $	��295��6y   $��5,2,133,264q�6�   $
��Left=�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   .+�5(      �� -   5        $��
FilterText��5(      $	��110��6(   $
��Left=�65   $��32��6P   $	��Top=�6\   $��2,2,0,0q�6t   �� 5)      -   5        $��StatusFilterChoice��5)      $	��110��61   $
��Left=�6>   $��32��6Y   $	��Top=�6e   $��2,2,0,0q�6}   $y�	Collapsed=�6�   .@�5*      �� .��6   Critically Endangered66   �� 5+       �� 
IsSelected . .��61   
Endangered6=   �� 5,      .��6   
Vulnerable6+   �� 5-      .��6   &$Dependent on Conservation of Habitat6E   �� 5.      .��6   	Near Risk6*   �� 5/      .��6   Lowest Risk6,   50      �� 51      -   5        $��UCNFilterChoice��51      $	��110��6.   $
��Left=�6;   $��32��6V   $	��Top=�6b   $��2,2,0,0q�6z   $y�	Collapsed=�6�   .@�52      ��  . $��On the list��61   �� 53      $��Not on the list��6   54      �� 55      -   5        $��
FilterType��55      $	��105��6)   $��32��65   $
��11.5(�6A   $ 0.219,-2.25&�6Q   $
��Left=�6v   $	��Top=�6�   $��	115,2,0,0q�6�   .@�56      �� $��Center=�6    . $��-��6N   �� 57      $��Id��6   �� 58      $
��Name��6   �� 59      $��Status��6   �� 5:      $
��11.5(�6   $��On IUCN Red List��6/   �� 5;      $	��Tag��6   5<      �� 5>      -   5        $��32��5>   .   $��32��69   $
��Left=�6E   $	��Top=�6`   $��	261,2,0,0q�6x   .��6�   Ap6�   �� 5@      -   5        $��32��5@   4   $��32��6?   $
��Left=�6K   $	��Top=�6f   $��	226,2,0,0q�6~   .��6�   Rm6�   5A      � 5B   
   $ 0��6   .+�5C         MapControl.Map  -   5          Name$	 map��5C         MapControl.MapBase   	ZoomLevel$ 4Q�6#      MinZoomLevel$ 4Q�61      MaxZoomLevel$ 15Q�6B      	TileLayer# [  5D       J� 	AllowDrop .    Center 5C   T   �� *	MapCenter+5D   Y   5E      5F      5J      