   M S B A M L   `   `   `  ����G  CServiExpress, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ServiExpressServiExpress  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	   !    ServiExpress.ListarServicio   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ServiExpress     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	     � Title$  SERVIEXPRESS��5   	   ���#002456$��719.571��63   $��891.255��6D   .��5      � $��	0,0,21,-3q�6   .+�5   
   �� $�� Listar   Servicios ��6   $
��Left=�6/   $��
205,22,0,0q�6J   $	��Top=�6^   
�������$��48��6�   $	��456��6�   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��36(�6�   �� 5   
   -   5         ��Name$ lblencargad��5      $<��6 Seleccionar Empleado Encargado :                    :��6%   $
��Left=�6f   $��
51,139,0,0q�6�   $	��Top=�6�   $��41��6�   $	��373��6�   
�������$
��Bold"�6�   $��22(�6�   �� 5   
   -   5         ��Name$ cmbempl��5      $
��Left=�6$   $��443,146,0,0q�6?   $	��Top=�6T   $	��163��6l    J� RenderTransformOrigin$ 0.581,0.964&�6x   $��25��6�   �� 5   
   -   5         ��Name$ btnbuscarenc��5      $��Buscar��6'   ���#51d1f6$
��Left=�6M   $��625,131,0,0q�6h   $	��Top=�6}   $	��137��6�   $ -0.046,1.189&�6�   $
��Bold"�6�   $��20(�6�   �� 5   
   -   5        $ btnlistarserv��5      $��Listar Proveedores��6)   ���#51d1f6$
��Left=�6[   $��282,211,0,0q�6v   $	��Top=�6�   $	��263��6�   $ 0.153,-0.056&�6�   $��20(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtgservicios��5      $
��Left=�6)   $	��300��6D   $��
51,257,0,0q�6Q   $	��Top=�6e   $	��793��6}   �� 5   
   -   5        $ Btnatras��5      $�� ��6#    /  +MahApps.Metro.Styles.MetroCircleButtonStyle#���   6.   $��793,592,21,0q�6t   $	��Top=�6�   $��49��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6�   $ 0.5,0.5&�6�   z�5      V� 5      .~�5      ��  �� ScaleY$ 1Q�6%    �� ScaleX$ 1Q�60   �� 5       �� AngleY$ 0Q�6$   	 �� AngleX$	 0Q�6/   �� 5      
 �� Angle$
 -1Q�6&   T� 5      5      ��5      �� 5       �� ImageSource$ imagenes/atras.png��6    j� Stretch$ Uniform=�6>   5      5!      5"      