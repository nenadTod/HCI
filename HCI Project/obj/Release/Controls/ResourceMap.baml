   M S B A M L   `   `   `  ���� V  RMapControl.WPF, Version=2.4.11.0, Culture=neutral, PublicKeyToken=f26fcf0059638459?0clr-namespace:MapControl;assembly=MapControl.WPF
MapControl   HCI Project&    HCI_Project.Controls.ResourceMap   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @map0clr-namespace:MapControl;assembly=MapControl.WPF       � 	Resources     MapControl.TileLayer   	Landscape   
SourceName   Description   
TileSource$   MapControl.TileSourceConverter �� 
TargetType  VisibleAnimation �� Property �� Value �� Triggers P� Property	 P� Value
 N� EnterActions �� TargetProperty W� From	 W� To g� Duration��%�  &	        &	 �       $ Thunderforest Landscape��$� �Maps © [Thunderforest](http://www.thunderforest.com/), Data © [OpenStreetMap Contributors](http://www.openstreetmap.org/copyright)��$A ;http://{c}.tile.thunderforest.com/landscape/{z}/{x}/{y}.png �� " �.���  � y�$ 	Collapsed=���  �@J�Opacity$ 0Q� P�  � y�$	 Visible=�
 �� .���� .��W� $ Opacity�$	 0.0X�$	 1.0X�$ 0:0:0.5D�.��� .+�� -   $��Filter��#��[  K� ZIndex$ 1�����#ECF0F1$��36��$	��295��$��5,2,133,264q�$
��Left=�$	��Top=� J� RenderTransformOrigin$ 0.5,0.5&�.+��� -   $��
FilterText��$	��110��$
��Left=�$��32��$	��Top=�$��2,2,0,0q��� -   $��StatusFilterChoice��$	��110��$
��Left=�$��32��$	��Top=�$��2,2,0,0q�$y�	Collapsed=�.@��� .��Critically Endangered��  �� 
IsSelected . .��
Endangered�� .��
Vulnerable�� .��&$Dependent on Conservation of Habitat�� .��	Near Risk�� .��Lowest Risk�� -   $��UCNFilterChoice��$	��110��$
��Left=�$��32��$	��Top=�$��2,2,0,0q�$y�	Collapsed=�.@���  . $��On the list���� $��Not on the list���� -   $��
FilterType��$	��105��$��32��$
��11.5(�$ 0.219,-2.25&�$
��Left=�$	��Top=�$��	115,2,0,0q�.@��� $��Center=� . $��-���� $��Id���� $
��Name���� $��Status���� $
��11.5(�$��On IUCN Red List���� $	��Tag���� -   $��32��$��32��$
��Left=�$	��Top=�$��	261,2,0,0q�.��Ap�� -   $��32��$��32��$
��Left=�$	��Top=�$��	226,2,0,0q�.��Rm� $ 0��.+�   MapControl.Map  -     Name$	 map��   MapControl.MapBase   	ZoomLevel$ 4Q�   MinZoomLevel$ 4Q�   MaxZoomLevel$ 15Q�   	TileLayer# [   J� 	AllowDrop .    Center �� *	MapCenter+