   M S B A M L   `   `   `  ����  HCI Project    HCI_Project.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   h dXceed.Wpf.AvalonDock.Themes.Metro, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4g cXceed.Wpf.AvalonDock.Themes.Aero, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4i eXceed.Wpf.AvalonDock.Themes.VS2010, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4[ WXceed.Wpf.AvalonDock, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4=xcad,http://schemas.xceed.com/wpf/xaml/avalondock     5   	     � Title$  Endangered Species��5   	    � WindowState$ 	Maximized=�6$    � 	Resources 5         DefaultImage �� 	UriSource��%8   &	        �� 5   
   $ Images/pandaLogo.jpg?�6+   5	       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$
 Save��5      6Q     5   
   -   5        $
 Undo��5      6Q     5   
   -   5        $
 Redo��5      6Q     5   
   -   5        $
 Find��5      6S     5   
   -   5        $ SaveAs��5      6Y    J� InputBindings 5      �� 5   
   
 �� Key$ F��6    �� 	Modifiers$ Shiftf�6   	 �� Command$
	 Find��6/   6@   �� 5   
   $ F5��6   $	 SaveAs��6   61   �� 5   
   $ 
Ctrl+Shiftf�6   $ Z��6,   $
	 Redo��64   6E   .��5      � .+�5   
   ]� ��. .+�5      o� 
 o� 
IsMainMenu
 . $	��Top=�6%   
���   �$
��Bold"�6M   $��13.333(�6_   $��0,0,0,2q�6q   ���	#FF41B1E1��5      �� 5        �� Color$ #ECF0F1��6&   5!      .@�5#      m� $
��File��6   $��Normal"�6)   $��75��6=   $��14.667(�6H   ���	#FF41B1E1$��0,0,2,0q�6r   .@�5$      m� $
��Save��6    m� Command$
 Save��5%   )   
�������$��0,0,0,1q�6L   m� 5&      -   5        $
��Exit��5&       5'   )   �� *OpenCommand+6I   5(      m� 5)      $
��Edit��6   $��Normal"�6)   $��75��6=   $��14.667(�6H   ���	#FF41B1E1$��0,0,2,0q�6r   .@�5*      m� $
��Undo��6   $
 Undo��5+   )   $��0,0,0,1q�68   
�������6R   m� 5,      $
��Redo��6   $
 Redo��5-   )   $��0,0,0,1q�68   ���	#FF41B1E16R   m� 5.      -   5        $��Edit Species��5.      $��0,0,0,1q�5/   b   
������� 6)   �� *OpenCommand+6|   m� 50      -   5        $��
Edit Types��50      $��0,0,0,1q�51   `   
������� 6)   �� *OpenCommand+6z   m� 52      -	   5         m�Name$ editTags��52   2   $��	Edit Tags��6   $��0,0,0,1q�53   I    6)   �� *OpenCommand+6I   m� 54      $��Filter��6   $
 Find��55   )   $��0,1,0,0q�68   ���	#FF41B1E1 m� InputGestureText$ Shift+F��6j   56      m� 57      $
��View��6   $��Normal"�6)   $��75��6=   $��14.667(�6H   ���	#FF41B1E1$��0,0,2,0q�6r   .@�58      m� $��
Fullscreen��6   $ SaveAs��59   )   $��0,0,0,1q�6:   
�������$ F5��6h   m� 5:      -
   5        $��History��5:      $��0,0,0,1q�60   
�������6^   5;      m� 5<      $	��Add��6   $��Normal"�6(   $��75��6<   $��14.667(�6G   ���	#FF41B1E1$��0,0,2,0q�6q   .@�5=      m� -   5        $��Species��5=      
�������$��0,0,0,1q�5>   x    6)   �� *OpenCommand+6x   m� 5?      -   5        $��Types��5?      
�������$��0,0,0,1q�5@   u    6)   �� *OpenCommand+6u   m� 5A      -   5        $
��Tags��5A       5B   )   �� *OpenCommand+6J   5C      m� 5D      $
��Help��6   $��Normal"�6)   $��75��6=   $��14.667(�6H   ���	#FF41B1E1$��0q�6r   .@�5E      m� $��About��6    5F   )   �� *OpenCommand+5G      5H      � 5I      $��Bottom=�6   .+�5J      )  #Xceed.Wpf.AvalonDock.DockingManager  -   5          Name$ dockingManager��5J   &   $��3��6>   ���#ECF0F1$��13.333(�6g   $
��Bold"�6y      Theme 5K      ,  &Xceed.Wpf.AvalonDock.Themes.MetroTheme  5L         Layout. 5O      ,  &Xceed.Wpf.AvalonDock.Layout.LayoutRoot     	RootPanel. 5P      -  'Xceed.Wpf.AvalonDock.Layout.LayoutPanel     Orientation$ 
Horizontal=�6+   �  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutPanelElement, Xceed.Wpf.AvalonDock, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5Q      9  3Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPaneGroup  �  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutDocumentPane, Xceed.Wpf.AvalonDock, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5R   "   4	  .Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPane	  -   5        	Documents��5S   #   5T      5U         LeftSide 5W      2
  ,Xceed.Wpf.AvalonDock.Layout.LayoutAnchorSide
  5X      �  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorGroup, Xceed.Wpf.AvalonDock, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5Y   "   3  -Xceed.Wpf.AvalonDock.Layout.LayoutAnchorGroup  �  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable, Xceed.Wpf.AvalonDock, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5Z   &   2  ,Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable  /  )Xceed.Wpf.AvalonDock.Layout.LayoutContent   Title$ Species��6<      CanClose .     CanFloat .     CanHide .     CanAutoHide .    AutoHideWidth$	 115Q�6�      Content. 5[   *   ]� .+�5\   .   � $	��Top=�68   .+�5]   2   ��   �� Padding$  0,3,0,7q�69   ._�5^   6   �� -   5        $��	searchBox��5^   `   ! � ToolTip$! Search Species by Name.��6>   $	��115��6q   $��27��6}   $��16(�6�   $��Normal"�6�   $
��1.75q�6�   6�   5_   3   5`   3   �� 5a   .   $��Bottom=�65   $��0,1,0,0q�6M   
�������._�5b   2   �� -   5        $��Images\trash.png��5b   8   $��96��6R   $��96��6]   " J� 	AllowDrop" . $"! Drop species to delete them.��6�   5c   /   �� 5d   2   .��5e   2   �� # �� Orientation$# Vertical=�6=   $ �� CanVerticallyScroll$ . .+�5f   6   �� -   5        $��speciesList��5f   >   
������ ��6Q   �� ��5g   :   �� 5h   >   .R�5i   B   �� ���	#FF41B1E1$��0,0,0,1q�6a   ._�5j   F   �� -   5        $-! 'Drag the item and drop it onto the map.��5j   Q   $# Vertical=�6�   
% J� Uid% 6�   �� *id+.+�5k   J   �� $��80��6T   $
��Bold"�6u   ��6_   �� *name+6u   �� 5l   J   $��84��6P   ��6[   �� *icon+& �� FallbackValue#& [  ' �� TargetNullValue#' [  5m   G   5n   C   5o   ?   5q   7   5r   3   5s   /   5t   +   5u   '   5v   #   5w      (   	RightSide( 5y      
  5z      . 5{   "     . 5|   &     $
 Maps��6<    .   .   .   . . 5}   *   �� $# Vertical=�65   .+�5~   .   �� -   5        $��mapList��5~   6   
������ ) � IsSharedSizeScope) . $��Stretch=�6�   ��6E   �� ��5   2   �� 5�   6   .R�5�   :   �� -   5        
�������
�������$! Click to open this map.��5�   �   % 6�   �� *name+.��5�   >   �� $# Vertical=�6I   $��0,0,0,50q�6`   .+�5�   B   �� $��90��6L   $
��Bold"�6m   ��6W   �� *name+6m   �� 5�   B   $	��100��6H   $��Images\mini_world_map.png��6T   5�   ?   5�   ;   5�   7   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      