   M S B A M L   `   `   `  ����  GeometryApp    GeometryApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  
MainWindow��5      $	��600��6   $	��800��6#    � 
ResizeMode$ NoResize=�6/   .��5      � .+�5      �� .@�5      �� -   5         ��Name$ Tabber��5      $
��CRUD��6   .��5      � .+�5	      &   System.Windows.Controls.DataGrid  -   5        $��DataView��5	         AutoGenerateColumns .     
IsReadOnly .    	RowHeight$ 30Q�5
         SelectionMode$ Single=�6   $��0,0,0,41q�6[   ��5	   <   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5   	   ,  &System.Windows.Controls.DataGridColumn   Header$ 
Shape Type��6   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 110 60   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6<   ��  �� Path$
 Type�  5   	   $
 Info��6   $		 230 6*   
 66   �� $
 Info�  5   	   $ Position��6   $		 250 6.   
 6:   �� $ Coordinates�  5   	   $ Color��6   $		 180 6+   
 67   �� $ Color�5      �� 5      -   5         ��Name$ BtCreate��5      $��Create��6   $��	0,0,614,2q�6.   $��26��6A   $��Bottom=�6M   6h   �� 5      -   5        $ 
ButtonEdit��5      $
��Edit��6   $��179,0,435,2q�6.   $��26��6C   $��Bottom=�6O   6j   �� 5      -   5        $ ButtonDelete��5      $��Delete��6!   $��358,0,256,2q�62   $��26��6G   $��Bottom=�6S   6n   5      5      �� 5      $��WYSIWYG��6   .��5      �� -   5         ��Name$ FieldCanvas��5      $��0,0,0,0q�6"   5      5      5      5      