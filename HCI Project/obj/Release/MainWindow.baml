   M S B A M L   `   `   `  ����   HCI Project    HCI_Project.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     h dXceed.Wpf.AvalonDock.Themes.Metro, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4g cXceed.Wpf.AvalonDock.Themes.Aero, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4i eXceed.Wpf.AvalonDock.Themes.VS2010, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4[ WXceed.Wpf.AvalonDock, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4=xcad,http://schemas.xceed.com/wpf/xaml/avalondock     -     � Title$  Endangered Species�� � WindowState$ 	Maximized=� � 	Resources    DefaultImage �� 	UriSource��%*   &	        �� $ Images/pandaLogo.jpg?� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$
 Save��  -   $
 Undo��  -   $
 Redo��  -   $
 Find��  -   $ SaveAs�� J� InputBindings �� 
 �� Key$ F�� �� 	Modifiers$ Shiftf�	 �� Command$
	 Find���� $ F5��$	 SaveAs���� $ 
Ctrl+Shiftf�$ Z��$
	 Redo��.��� .+�]� ��. .+�o� 
 o� 
IsMainMenu
 . $	��Top=�
���   �$
��Bold"�$��13.333(�$��0,0,0,2q����	#FF41B1E1����  �� Color$ #ECF0F1��.@�m� $
��File��$��Normal"�$��75��$��14.667(����	#FF41B1E1$��0,0,2,0q�.@�m� $
��Save�� m� Command$
 Save��
�������$��0,0,0,1q�m� -   $
��Exit�� �� *OpenCommand+m� $
��Edit��$��Normal"�$��75��$��14.667(����	#FF41B1E1$��0,0,2,0q�.@�m� $
��Undo��$
 Undo��$��0,0,0,1q�
�������m� $
��Redo��$
 Redo��$��0,0,0,1q����	#FF41B1E1m� -   $��Edit Species��$��0,0,0,1q�
������� �� *OpenCommand+m� -	   $��
Edit Types��$��0,0,0,1q�
������� �� *OpenCommand+m� -
    m�Name$ editTags��$��	Edit Tags��$��0,0,0,1q� �� *OpenCommand+m� $��Filter��$
 Find��$��0,1,0,0q����	#FF41B1E1 m� InputGestureText$ Shift+F��m� $
��View��$��Normal"�$��75��$��14.667(����	#FF41B1E1$��0,0,2,0q�.@�m� $��
Fullscreen��$ SaveAs��$��0,0,0,1q�
�������$ F5��m� -   $��History��$��0,0,0,1q�
�������m� $	��Add��$��Normal"�$��75��$��14.667(����	#FF41B1E1$��0,0,2,0q�.@�m� -   $��Species��
�������$��0,0,0,1q� �� *OpenCommand+m� -   $��Types��
�������$��0,0,0,1q� �� *OpenCommand+m� -   $
��Tags�� �� *OpenCommand+m� $
��Help��$��Normal"�$��75��$��14.667(����	#FF41B1E1$��0q�.@�m� $��About�� �� *OpenCommand+� $��Bottom=�.+�)  #Xceed.Wpf.AvalonDock.DockingManager  -     Name$ dockingManager��$��3�����#ECF0F1$��13.333(�$
��Bold"�   Theme ,  &Xceed.Wpf.AvalonDock.Themes.MetroTheme     Layout. ,  &Xceed.Wpf.AvalonDock.Layout.LayoutRoot     	RootPanel. -  'Xceed.Wpf.AvalonDock.Layout.LayoutPanel     Orientation$ 
Horizontal=��  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutPanelElement, Xceed.Wpf.AvalonDock, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 9  3Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPaneGroup  �  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutDocumentPane, Xceed.Wpf.AvalonDock, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 4	  .Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPane	  -   	Documents��   LeftSide 2
  ,Xceed.Wpf.AvalonDock.Layout.LayoutAnchorSide
  �  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorGroup, Xceed.Wpf.AvalonDock, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 3  -Xceed.Wpf.AvalonDock.Layout.LayoutAnchorGroup  �  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable, Xceed.Wpf.AvalonDock, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 2  ,Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable  /  )Xceed.Wpf.AvalonDock.Layout.LayoutContent   Title$ Species��   CanClose .     CanFloat .     CanHide .     CanAutoHide .    AutoHideWidth$	 115Q�   Content. ]� .+�� $	��Top=�.+���   �� Padding$  0,3,0,7q�._��� -   $��	searchBox��! � ToolTip$! Search Species by Name.��$	��115��$��27��$��16(�$��Normal"�$
��1.75q��� $��Bottom=�$��0,1,0,0q�
�������._��� -   $��Images\trash.png��$��96��$��96��" J� 	AllowDrop" . $"! Drop species to delete them.���� .���� # �� Orientation$# Vertical=�$ �� CanVerticallyScroll$ . .+��� -   $��speciesList��
������ ���� ���� .R��� ���	#FF41B1E1$��0,0,0,1q�._��� -   $-! 'Drag the item and drop it onto the map.��$# Vertical=�
% J� Uid% �� *id+.+��� $��80��$
��Bold"����� *name+�� $��84������ *icon+& �� FallbackValue#& [  ' �� TargetNullValue#' [  (   	RightSide( 
  .   .   $
 Maps�� .   .   .   . . �� $# Vertical=�.+��� -   $��mapList��
������ ) � IsSharedSizeScope) . $��Stretch=����� ���� .R��� -   
�������
�������$! Click to open this map.��% �� *name+.���� $# Vertical=�$��0,0,0,50q�.+��� $��90��$
��Bold"����� *name+�� $	��100��$��Images\mini_world_map.png��