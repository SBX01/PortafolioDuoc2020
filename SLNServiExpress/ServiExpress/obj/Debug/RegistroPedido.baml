   M S B A M L   `   `   `  ����G  CServiExpress, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ServiExpressServiExpress  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5
   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   !    ServiExpress.RegistroPedido   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ServiExpress     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5
   	   Emah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   -   5          � Title$  SERVIEXPRESS��5   	   ���#002456$ ��730                       ��63   $	��980��5      .��5      � .+�5   
   �� $�� Registro  De Pedido ��6   $
��Left=�60   $��
194,10,0,0q�6K   $	��Top=�6_   ���	#FFFDFDFD$��48��6�   $	��456��6�   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��36(�6�   �� 5   
   -   5         ��Name$ 	btncerrar��5      $��Cerrar Sesiòn��6(   ���#51d1f6$
��Left=�6U   $��
760,21,0,0q�6p   $	��Top=�6�   $	��169��6�   $��Normal"�6�   $��18(�6�    J� RenderTransformOrigin$ 0.485,0.286&�6�   $��Sitka Display)�6�   6	  �� 5   
   $��
Empleado  ��6   $
��Left=�6%   $��	22,63,0,0q�6@   $	��Top=�6S   $��46��6k   $	��258��6w   ���	#FFFDFDFD$
��Bold"�6�   $��20(�6�   $ 0.479,0.263&�6�   �� 5   
   $��Seleccionar  Proveedor ��6   $
��Left=�62   $��
280,63,0,0q�6M   $	��Top=�6a   $��46��6y   $	��257��6�   ���	#FFFDFDFD$
��Bold"�6�   $��20(�6�   $ 0.479,0.263&�6�   �� 5   
   -   5         ��Name$ cboEmpleado��5      $
��Left=�6(   $��
57,114,0,0q�6C   $	��Top=�6W   $	��163��6o   $ 0.581,0.964&�6{   $��25��6�   �� 5   
   -   5        $ cboProveedor��5      $
��Left=�6)   $��307,114,0,0q�6D   $	��Top=�6Y   $	��163��6q   $ 0.581,0.964&�6}   $��25��6�   6�   �� 5   
   $��Total Pedido��6   $
��Left=�6'   $��
24,195,0,0q�6B   $	��Top=�6V   $��46��6n   $	��256��6z   ���	#FFFDFDFD$
��Bold"�6�   $��20(�6�   $ 0.479,0.263&�6�   �� 5   
   -   5         ��Name$ f��5      $
��Left=�6   $��
32,241,0,0q�6:   $
��Wrap=�6N   $	��Top=�6b   $	��182��6z   $	��210��6�   
��������� 6�   .F�5      �� -   5         ��Name$ txtTotalPedido��5      $	��182��62    �� TextWrapping$
 Wrap=�6?   $	��211��6S   {�.  6_   5      6#   �� 5    
   -   5         ��Name$ lbListaDetalle��5       $��Lista Detalle��6(   $
��Left=�6@   $��308,195,0,0q�6[   $	��Top=�6p   $��36��6�   $	��416��6�   ���	#FFFDFDFD$
��Bold"�6�   $��20(�6�   $ 0.479,0.263&�6�   �� 5"   
   -   5        $ btnagregarped��5"      $�� ��6(    /  +MahApps.Metro.Styles.MetroCircleButtonStyle#���   63   $
��Left=�6y   $��
88,562,0,0q�6�   $	��Top=�6�   $��50��6�   $��50��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6   $��14(�6  $ 0.531,0.836&�6"  z�5#      V� 5$      .~�5%      ��  �� ScaleY$ 1Q�6%   	 �� ScaleX$	 1Q�60   �� 5&      
 �� AngleY$
 0Q�6$    �� AngleX$ 0Q�6/   �� 5'       �� Angle$ -1Q�6&   T� 5(       T� X$ 0.305Q�6)    T� Y$ -0.026Q�63   5)      ��5+      �� 5,       �� ImageSource$ imagenes/agregar.png��6   5.      �� 5/   
   $�� Agregar Pedido  ��6   $
��Left=�6,   $��
22,624,0,0q�6G   $	��Top=�6[   $
��Bold"�6s   
�������$��39��6�   $	��214��6�   $��20(�6�   �� 50   
   $�� Editar Pedido  ��6   $
��Left=�6+   $��196,624,0,0q�6F   $	��Top=�6[   $
��Bold"�6s   
�������$��39��6�   $	��214��6�   $��20(�6�   $ 1.385,-0.297&�6�   �� 51   
   $�� Eliminar Pedido  ��6   $
��Left=�6-   $��356,624,0,0q�6H   $	��Top=�6]   $
��Bold"�6u   
�������$��39��6�   $	��212��6�   $��20(�6�   $ 
0.28,2.392&�6�   �� 52   
   $�� Listar Pedido  ��6   $
��Left=�6+   $��534,624,0,0q�6F   $	��Top=�6[   $
��Bold"�6s   
�������$��39��6�   $	��214��6�   $��20(�6�   �� 53   
   $�� Chequear Recepcion  ��6   $
��Left=�60   $��688,623,0,0q�6K   $	��Top=�6`   $
��Bold"�6x   
�������$��40��6�   $	��214��6�   $��20(�6�   �� 54   
   -	   5        $ btneditpedi��54      $�� ��6&   #���   61   $
��Left=�6w   $��234,562,0,0q�6�   $	��Top=�6�   $��50��6�   $��50��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6  $ -0.215,0.37&�6!  z�55      V� 56      .~�57      �� $ 1Q�6%   $	 1Q�60   �� 58      $
 0Q�6$   $ 0Q�6/   �� 59      $ -1Q�6&   T� 5:      $ -0.152Q�6)   $ 0.877Q�64   5;      ��5=      �� 5>      $ imagenes/modi.png��6   5@      �� 5B   
   -
   5        $ 
btnelimped��5B      $�� ��6%   #���   60   $
��Left=�6v   $��404,562,0,0q�6�   $	��Top=�6�   $��50��6�   $��50��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6  $ 0.529,-0.249&�6   z�5C      V� 5D      .~�5E      �� $ 1Q�6%   $	 1Q�60   �� 5F      $
 0Q�6$   $ 0Q�6/   �� 5G      $ -1Q�6&   T� 5H      $ -0.915Q�6)   $ -0.028Q�64   5I      ��5K      �� 5L      $ imagenes/eliminar.png��6    j� Stretch$ Uniform=�6A   5N      �� 5O   
   -   5        $ Btnatras��5O      $�� ��6#   #���   6.   $
��Left=�6t   $��896,611,0,0q�6�   $	��Top=�6�   $��50��6�   $��43��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6  $ 0.597,1.474&�6  z�5P      V� 5Q      .~�5R      �� $ 1Q�6%   $	 1Q�60   �� 5S      $
 0Q�6$   $ 0Q�6/   �� 5T      $ -1Q�6&   T� 5U      $ 0.898Q�6)   $
 -0.1Q�63   5V      ��5X      �� 5Y      $ imagenes/atras.png��6   $ Uniform=�6>   5[      �� 5\   
   -   5        $ btnlistarped��5\      $�� ��6'   #���   62   $
��Left=�6x   $��574,562,0,0q�6�   $	��Top=�6�   $��50��6�   $��50��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6   $��14(�6  $ 0.5,0.5&�6"  z�5]      V� 5^      .~�5_      �� $ 1Q�6%   $	 1Q�60   �� 5`      $
 0Q�6$   $ 0Q�6/   �� 5a      $ -1Q�6&   T� 5b      5c      ��5e      �� 5f      $ imagenes/list.png��6   5h      �� 5j   
   -   5        $ btnchequear��5j      $�� ��6&   #���   61   $
��Left=�6w   $��760,562,0,0q�6�   $	��Top=�6�   $��50��6�   $��50��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6  $ 0.5,0.5&�6!  z�5k      V� 5l      .~�5m      �� $ 1Q�6%   $	 1Q�60   �� 5n      $
 0Q�6$   $ 0Q�6/   �� 5o      $ -1Q�6&   T� 5p      5q      ��5s      �� 5t      $ imagenes/list.png��6   5v      � 5w   
   -   5         �Name$ 
GridPedido��5w      $
��Left=�6#   $	��229��6>   $��305,241,0,0q�6K   $	��Top=�6`   $	��657��6x   
������� J� OpacityMask �	#FFC5E1F1.+�5x      �� $��Producto��6   $
��Left=�6'   $��	24,19,0,0q�6B   $	��Top=�6U   �� 5y      $��Cantidad��6   $
��Left=�6'   $��	24,75,0,0q�6B   $	��Top=�6U   �� 5z      $��Estado��6   $
��Left=�6%   $��
24,133,0,0q�6@   $	��Top=�6T   $ 
0.541,0.59&�6l   �� 5{      -   5        $ cboProductos��5{      $
��Left=�6-   $��	99,23,0,0q�6H   $	��Top=�6[   $	��159��6s   6   �� 5|      -   5        $ txtCantidadDetalle��5|      $
��Left=�62   $��23��6M   $��	99,75,0,0q�6Y   $
 Wrap=�6l   $	��Top=�6�   $	��159��6�   6�   �� 5}      -   5        $ 	cboEstado��5}      $
��Left=�6*   $��
99,137,0,0q�6E   $	��Top=�6Y   $	��159��6q   &   System.Windows.Controls.DataGrid  5~      -   5          Name$ 	dgDetalle��5~      $
��Left=�6*   $	��209��6E   $��
269,10,0,0q�6R   $	��Top=�6f   $	��313��6~   ���	#FFF1EDED6�   �� 5      -   5        $ 	btnAddRow��5       � ToolTip$ Agregar Detalle��6(   $
��Left=�6C   $��
596,19,0,0q�6^   $	��Top=�6r   $��50��6�   ���	#FF6FE81C$��50��6�    �	#FF21FB21��6�   Z� ��5�      �� 5�      $ Imagenes/mas.png��6!   5�      �� 5�      -   5        $ btnDeleteRow��5�      $a [Asegurese de hacer doble click antes de modificar para asegurar que el detalle es el mismo.��6,   $
��Left=�6�   $��
597,86,0,0q�6�   $	��Top=�6�   $��50��6�   ���	#FFEA2323$��50��6  
 �  ����6�   Z� ��5�      �� 5�      $ Imagenes/delete.png��6!   5�      �� 5�      -   5        $ btnEditarDetalle��5�      $a [Asegurese de hacer doble click antes de modificar para asegurar que el detalle es el mismo.��6/   $
��Left=�6�   $��596,156,0,0q�6�   $	��Top=�6�   $��50��6�   $ 
0.293,0.45&�6�   ���	#FFE05608$��50��69   �	#FFFF881F��6  Z� ��5�      �� 5�      $ Imagenes/editar.png��6!   5�      �� 5�      $��Precio��6   $
��Left=�6%   $��
24,184,0,0q�6@   $	��Top=�6T   �� 5�      -   5        $ 	txtPrecio��5�      $
��Left=�6)   $��23��6D   $��
99,187,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��159��6�   5�        5�   
   -   5        $ dgDetalleProducto��5�      $
��Left=�6.   $	��239��6I   $��305,231,0,0q�6V   $	��Top=�6k   $	��657��6�   $y�Hidden=�6�   6�   �� 5�   
   -   5         ��Name$ checkAgregar��5�      $��Activar detalle��6)   $��Right=�6C   $��	0,184,0,0q�6_   $	��Top=�6r   $��20(�6�   $	��212��6�   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6�   $
��Bold"�6�   
�������$��5q�6�   $��32��6  ���	#FFF1902E6*  5�      5�      