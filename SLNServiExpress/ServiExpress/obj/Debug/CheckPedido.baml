   M S B A M L   `   `   `  ����G  CServiExpress, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ServiExpressServiExpress  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	       ServiExpress.CheckPedido   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ServiExpress     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   -   5          � Title$  SERVIEXPRESS��5   	   ���#002456$	��600��63   $	��900��6@   .��5      � $��	0,0,-8,-2q�6   .+�5   
   �� $��Recepcion de Pedido��6   $��0,10,0,0q�6.   $	��Top=�6@   ���	#FFFDFDFD$��48��6o   $	��338��6{   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��36(�6�   $��Center=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgDetalle��5      $��Center=�6&   $	��252��6C   $��227,115,114,0q�6P   $	��Top=�6g   $	��559��6   6�   �� 5   
   -   5         ��Name$ Btnatras��5      $�� ��6#    /  +MahApps.Metro.Styles.MetroCircleButtonStyle#���   6.   $
��Left=�6t   $��808,489,0,0q�6�   $	��Top=�6�   $��56��6�   $��50��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6   J� RenderTransformOrigin$ 0.5,0.5&�6  z�5      V� 5      .~�5      ��  �� ScaleY$ 1Q�6%    �� ScaleX$ 1Q�60   �� 5       �� AngleY$ 0Q�6$    �� AngleX$ 0Q�6/   �� 5       �� Angle$ -1Q�6&   T� 5      5      ��5      �� 5      	 �� ImageSource$	 Imagenes/atras.png��6   
 j� Stretch$
 Uniform=�6>   5      �� 5   
   $��Agregar comentario��6    � ToolTip$ Agrege motivo del rechazo��6-   $
��Left=�6Q   $��
29,270,0,0q�6l   $	��Top=�6�   $	��145��6�   $��Baskerville Old Face)�6�   $��16(�6�   
�������&   System.Windows.Media.TextOptions   TextHintingMode$ Fixed=�6�   $��SemiBold"�6  �� 5   
   -   5         ��Name$ txtComentario��5      $
��Left=�6)   $��56��6D   $��
31,311,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��163��6�   {�.  6�   �� 5   
   $��Pedido��6   $ Agrege motivo del rechazo��6!   $
��Left=�6E   $��
31,115,0,0q�6`   $	��Top=�6t   $	��145��6�   $��Baskerville Old Face)�6�   $��16(�6�   
�������$ Fixed=�6�   $��SemiBold"�6�   �� 5   
   -   5         ��Name$ 	cboPedido��5      $
��Left=�6&   $��
31,148,0,0q�6A   $	��Top=�6U   $	��163��6m   6y   �� 5    
   -   5        $ Guardar Comentario��5       $
��Left=�6.   $��813,130,0,0q�6I   $	��Top=�6^   $��50��6v   $��50��6�   ��6�   Z� ��5!      �� 5"      $	 Imagenes/editar.png��6   5$      �� 5%   
   ���	#FF055BD1$��1q�6)   $
��Left=�6=   $��2��6X   $��
18,386,0,0q�6c   $	��Top=�6w   $	��857��6�   �� 5&   
   -   5        $ btnAceptardetalle��5&      $ Validar Producto��6,   $
��Left=�6G   $��813,221,0,0q�6b   $	��Top=�6w   $��50��6�   $��50��6�   ��6�   Z� ��5'      �� 5(      $	 Imagenes/aceptar.png��6   5*      �� 5+   
   -   5        $ btnRechazar��5+      $ Rechazar Producto. ��6&   $
��Left=�6D   $��813,302,0,0q�6_   $	��Top=�6t   $��50��6�   $��50��6�   ��5,      �� 5-      $	 Imagenes/cancelar.png��6   5/      � 50   
   -	   5         �Name$ 	gridAyuda��50      $
��Left=�6"   $	��159��6=   $��
63,393,0,0q�6J   $	��Top=�6^   $	��723��6v   .+�51      �� -
   5        $ 
btnAceptar��51      $�� ��6)   $
��Left=�64   $��
117,28,0,0q�6O   $	��Top=�6c   $��74��6{   $��75��6�   ��6�   Z� ��52      �� 53      $	 Imagenes/aceptar.png��6!   55      �� 56      -   5        $ btnCancelar��56      $�� ��6*   $
��Left=�65   $��
446,28,0,0q�6P   $	��Top=�6d   $��74��6|   $��75��6�   ��6�   Z� ��57      �� 58      $	 Imagenes/cancelar.png��6!   5:      �� 5;      $��Validar Todo��6   $
��Left=�6+   $��101,115,0,0q�6F   $	��Top=�6[   $	��102��6s   $��Baskerville Old Face)�6   $��16(�6�   
�������$ Fixed=�6�   $��SemiBold"�6�   �� 5<      $��Rechazar Todo��6   $
��Left=�6,   $��425,116,0,0q�6G   $	��Top=�6\   $	��114��6t   $��Baskerville Old Face)�6�   $��16(�6�   $��SemiBold"�6�   $ Fixed=�6�   
�������$ 0.5,0.5&�6�   z�5=      V� 5>      .~�5?      �� �� 5@      �� 5A      $ 0.797Q�6*   T� 5B      5C      5E      5F      5H      5I      