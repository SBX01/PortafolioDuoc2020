   M S B A M L   `   `   `  ����G  CServiExpress, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ServiExpressServiExpress  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5	   	   $    ServiExpress.ListarAutomoviles   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ServiExpress     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5	   	     � Title$  SERVIEXPRESS��5
   	   ���#002456$��656.828��63   $��1128.007��6D   .��5      � $��0,0,-8,0q�6   .+�5   
   �� $�� Listar Automovil ��6   $
��Left=�6-   $��
365,10,0,0q�6H   $	��Top=�6\   ���	#FFFDFDFD$��48��6�   $	��456��6�   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��36(�6�   �� 5   
   -   5         ��Name$ lblmar��5      $.��( Seleccionar Marca                     :��6    $
��Left=�6S   $��	0,142,0,0q�6n   $	��Top=�6�   $��41��6�   $	��269��6�   
�������$
��Bold"�6�   $��22(�6�   �� 5   
   -   5         ��Name$ cmbmarca��5      $
��Left=�6%   $��225,150,0,0q�6@   $	��Top=�6U   $	��163��6m    J� RenderTransformOrigin$ 0.581,0.964&�6y   $��25��6�   �� 5   
   -   5         ��Name$ btnbuscarmarc��5      $��Buscar��6(   ���#51d1f6$
��Left=�6N   $��411,142,0,0q�6i   $	��Top=�6~   $	��106��6�   $ -0.046,1.189&�6�   $
��Bold"�6�   $��20(�6�   �� 5   
   -   5        $ lblanno��5      $-��' Seleccionar Año                     :��6!   $
��Left=�6R   $��552,142,0,0q�6m   $	��Top=�6�   $��41��6�   $	��269��6�   
�������$
��Bold"�6�   $��22(�6�   �� 5   
   -   5        $ cmbanno��5      $
��Left=�6$   $��782,150,0,0q�6?   $	��Top=�6T   $	��163��6l   $ 0.581,0.964&�6x   $��25��6�   �� 5   
   -   5        $ btnbuscaanno��5      $��Buscar��6'   ���#51d1f6$
��Left=�6M   $��991,142,0,0q�6h   $	��Top=�6}   $	��106��6�   $ -0.046,1.189&�6�   $
��Bold"�6�   $��20(�6�   �� 5   
   -   5        $ lblmod��5      $/��) Seleccionar Modelo                     :��6    $
��Left=�6T   $��	0,236,0,0q�6o   $	��Top=�6�   $��41��6�   $	��269��6�   
�������$
��Bold"�6�   $��22(�6�   �� 5   
   -   5        $ cbomode��5      $
��Left=�6$   $��225,244,0,0q�6?   $	��Top=�6T   $	��163��6l   $ 0.581,0.964&�6x   $��25��6�   �� 5   
   -	   5        $ btnbuscarmod��5      $��Buscar��6'   ���#51d1f6$
��Left=�6M   $��411,229,0,0q�6h   $	��Top=�6}   $	��106��6�   $ -0.046,1.189&�6�   $
��Bold"�6�   $��20(�6�   �� 5   
   -
   5        $ lblcl��5      $0��* Seleccionar Cliente                     :��6   $
��Left=�6T   $��538,229,0,0q�6o   $	��Top=�6�   $��41��6�   $	��269��6�   
�������$
��Bold"�6�   $��22(�6�   �� 5   
   -   5        $ 	cboclient��5      $
��Left=�6&   $��762,237,0,0q�6A   $	��Top=�6V   $	��163��6n   $ 0.581,0.964&�6z   $��25��6�   �� 5   
   -   5        $ btnbuscarcli��5      $��Buscar��6'   ���#51d1f6$
��Left=�6M   $��991,237,0,0q�6h   $	��Top=�6}   $	��106��6�   $ -0.046,1.189&�6�   $
��Bold"�6�   $��20(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtgautomovil��5      $
��Left=�6)   $	��294��6D   $��152,303,0,0q�6Q   $	��Top=�6f   $	��749��6~   �� 5   
   -   5        $ Btnatras��5      $�� ��6#    /  +MahApps.Metro.Styles.MetroCircleButtonStyle#���   6.   $
��Left=�6t   $��998,559,0,0q�6�   $	��Top=�6�   $��48��6�   $��49��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6  $ 0.5,0.5&�6  z�5      V� 5      .~�5       ��  �� ScaleY$ 1Q�6%    �� ScaleX$ 1Q�60   �� 5!       �� AngleY$ 0Q�6$   	 �� AngleX$	 0Q�6/   �� 5"      
 �� Angle$
 -1Q�6&   T� 5#      5$      ��5&      �� 5'       �� ImageSource$ imagenes/atras.png��6    j� Stretch$ Uniform=�6>   5)      5+      5,      