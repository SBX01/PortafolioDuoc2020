   M S B A M L   `   `   `  ����G  CServiExpress, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ServiExpressServiExpress  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	   !    ServiExpress.ListarEmpleado   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ServiExpress     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   -   5          � Title$  SERVIEXPRESS��5   	   ���#002456$��614.217��63   $��837.371��6D   .��5      � $��	0,0,-8,-1q�6   .+�5   
   �� $�� Listar Empleado ��6   $
��Left=�6,   $��
237,10,0,0q�6G   $	��Top=�6[   ���	#FFFDFDFD$��48��6�   $	��456��6�   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��36(�6�   �� 5   
   -   5         ��Name$ lblcargo��5      $.��( Seleccionar Cargo                     :��6"   $
��Left=�6U   $��
133,82,0,0q�6p   $	��Top=�6�   $��41��6�   $	��242��6�   
�������$
��Bold"�6�   $��22(�6�   �� 5   
   -   5         ��Name$ 
cmbcargoem��5      $
��Left=�6'   $��
355,90,0,0q�6B   $	��Top=�6V   $	��163��6n    J� RenderTransformOrigin$ 0.581,0.964&�6z   $��25��6�   �� 5   
   -   5         ��Name$ btnbuscarcargem��5      $��Buscar��6*   ���#51d1f6$
��Left=�6P   $��
553,82,0,0q�6k   $	��Top=�6   $	��137��6�   $ -0.046,1.189&�6�   $
��Bold"�6�   $��20(�6�   6�   �� 5   
   -   5        $ btnlistarem��5      $��Listar Empleado��6'   ���#51d1f6$
��Left=�6V   $��285,151,0,0q�6q   $	��Top=�6�   $	��263��6�   $ 0.153,-0.056&�6�   $��20(�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtgempleado��5      $
��Left=�6(   $	��278��6C   $��
54,215,0,0q�6P   $	��Top=�6d   $	��728��6|   �� 5   
   -   5        $ Btnatras��5      $�� ��6#    /  +MahApps.Metro.Styles.MetroCircleButtonStyle#���   6.   $
��Left=�6t   $��724,513,0,0q�6�   $	��Top=�6�   $��48��6�   $��49��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6  $ 0.5,0.5&�6  z�5      V� 5      .~�5      ��  �� ScaleY$ 1Q�6%    �� ScaleX$ 1Q�60   �� 5       �� AngleY$ 0Q�6$   	 �� AngleX$	 0Q�6/   �� 5      
 �� Angle$
 -1Q�6&   T� 5      5      ��5      �� 5       �� ImageSource$ imagenes/atras.png��6    j� Stretch$ Uniform=�6>   5       5!      5"      