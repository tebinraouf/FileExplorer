   M S B A M L   `   `   `  ����G  CFileExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FileExplorerFileExplorer  5   	       FileExplorer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FileExplorer     5   	   -   5          � Title$  
MainWindow��5   	   $	��350��5
   	   $	��525��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��5 �6   �� 5      $��* �6   .+�5   
   R� -   5         R�Name$ 
FolderView��5      $��	10,38,4,9q�5       � 	Resources 5       �� 
TargetType �� Property �� Value �� Orientation �� RelativeSource	 �� Mode
 �� AncestorType �� Path)  #FileExplorer.HeaderToImageConverter   Instance �� 	Converter��%G  'Q�       �� 5      " Q�6   .�5      ��  � �� 5      �� 5      .R�5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $��20��6,   $��3q�5   ,   ��5   ,   ��  �� $	 FindAncestor=�"
 Q�$	 Tag�# Z �� 5   &   $��Bottom=�60   ��5    0   �� 5!   #   5"      5$      5%      5&      5(      �� 5)   
   $��Stretch=�6   $��1,39,0,0q�5*      $��Stretch=�5+      $��4��5,      $��1��5-      � 5.   
   $��2��6   .+�5/      �� -   5         ��Name$ myList��5/      $��Stretch=�50       �� AlternationCount$ 2��51      $��Stretch=�52      $��Stretch=�53      $��Disabled=�54      ���	#FFE5E5E5
������    alternatingWithTriggers#��[  57        selectedItemStyle#��[ 58      $��12,51,12,131q�59      ��5<      �� 5=      .R�5>      �� $
��left=�6%   $	��100��5?   %   $ Vertical=�5@   %   .+�5A      �� $��20��5B   $   $��Center=�5C   $   ��5A   $   �� *	FileImage+5C   $   �� 5E      $��1��6$   $��Center=�5G   $   ��5F   $   �� *
FileName+5G   $   5I      5K      ��5M      �� 5N      .R�5O      �  � Orientation$ 
Horizontal=�6$    � 	ItemWidth$	 100��5P   $   66   5Q      5T      5U      5V      5W      