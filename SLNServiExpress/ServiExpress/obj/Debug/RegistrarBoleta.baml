   M S B A M L   `   `   `  ����G  CServiExpress, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ServiExpressServiExpress  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	   "    ServiExpress.RegistrarBoleta   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ServiExpress     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   -   5          � Title$  SERVIEXPRESS��5   	   ���#002456$	��714��64   $	��819��6A   .��5      � .+�5   
   �� $�� Registro  De Boleta ��6   $
��Left=�60   $��
228,10,0,0q�6K   $	��Top=�6_   ���	#FFFDFDFD$��48��6�   $	��456��6�   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��36(�6�   �� 5   
   -   5         ��Name$ lblfech��5      $#��Fecha Boleta                :��6!   $
��Left=�6I   $��	32,72,0,0q�6d   $	��Top=�6w   ���	#FFFDFDFD$
��Bold"�6�   $��36��6�   $	��188��6�   $��22(�6�   �� 5   
   $��Tipo Pago               :��6   $
��Left=�64   $��
30,119,0,0q�6O   $	��Top=�6c   $��46��6{   $	��190��6�   ���	#FFFDFDFD$
��Bold"�6�   $��22(�6�    J� RenderTransformOrigin$ 0.479,0.263&�6�   �� 5   
   -   5        $ lblto��5      $��Total Boleta      :��6   $
��Left=�6=   $��
24,163,0,0q�6X   $	��Top=�6l   $��41��6�   $	��196��6�   ���	#FFFDFDFD$
��Bold"�6�   $��22(�6�   �� 5   
   -   5         ��Name$ txttotalbol��5      $
��Left=�6'   $��23��6B   $��180,175,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��151��6�   �� 5   
   -   5         ��Name$ Btnatras��5      $�� ��6#    /  +MahApps.Metro.Styles.MetroCircleButtonStyle#���   6.   $
��Left=�6t   $��733,616,0,0q�6�   $	��Top=�6�   $��48��6�   $��38��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6  $ 0.597,1.474&�6  z�5      V� 5      .~�5      ��  �� ScaleY$ 1Q�6%    �� ScaleX$ 1Q�60   �� 5       �� AngleY$ 0Q�6$   	 �� AngleX$	 0Q�6/   �� 5      
 �� Angle$
 -1Q�6&   T� 5       T� X$ 0.898Q�6)    T� Y$
 -0.1Q�63   5      ��5      �� 5       �� ImageSource$ imagenes/atras.png��6    j� Stretch$ Uniform=�6>   5      (  "System.Windows.Controls.DatePicker  5    
   -   5          Name$ fechaboleta��5       $��180,79,478,0q�6+   $	��Top=�6A   $ -0.017,0.943&�6Y   �� 5!   
   -   5         ��Name$ cmbopago��5!      $
��Left=�6%   $��182,128,0,0q�6@   $	��Top=�6U   $	��150��6m   $ 0.581,0.964&�6y   $��25��6�   �� 5#   
   $4��.Detalle de la Boleta                         :��6   $
��Left=�6J   $��
40,236,0,0q�6e   $	��Top=�6y   $
��Bold"�6�   ���	#FFFDFDFD$��34��6�   $	��220��6�   $��22(�6�   �� 5$   
   $�� Agregar Boleta  ��6   $
��Left=�6,   $��
14,622,0,0q�6G   $	��Top=�6[   $
��Bold"�6s   
�������$��41��6�   $	��186��6�   $��22(�6�   �� 5&   
   -   5        $ btneditbole��5&      $�� ��6&   #���   61   $
��Left=�6w   $��244,556,0,0q�6�   $	��Top=�6�   $��74��6�   $��55��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6  $ -0.215,0.37&�6!  z�5'      V� 5(      .~�5)      �� $ 1Q�6%   $ 1Q�60   �� 5*      $ 0Q�6$   $	 0Q�6/   �� 5+      $
 -1Q�6&   T� 5,      $ -0.152Q�6)   $ 0.877Q�64   5-      ��5/      �� 50      $ imagenes/modi.png��6   $ Uniform=�6=   52      �� 53   
   -	   5        $ btnagregarbolet��53      $�� ��6*   #���   65   $
��Left=�6{   $��
74,553,0,0q�6�   $	��Top=�6�   $��62��6�   $��58��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6  $��14(�6  $ 0.5,0.5&�6$  z�54      V� 55      .~�56      �� $ 1Q�6%   $ 1Q�60   �� 57      $ 0Q�6$   $	 0Q�6/   �� 58      $
 -1Q�6&   T� 59      5:      ��5<      �� 5=      $ imagenes/agregar.png��6   $ Uniform=�6@   5?      �� 5@   
   $�� Editar Boleta  ��6   $
��Left=�6+   $��210,624,0,0q�6F   $	��Top=�6[   $
��Bold"�6s   
�������$��39��6�   $	��212��6�   $��22(�6�   $ 1.385,-0.297&�6�   �� 5A   
   $�� Eliminar Boleta  ��6   $
��Left=�6-   $��380,624,0,0q�6H   $	��Top=�6]   $
��Bold"�6u   
�������$��39��6�   $	��212��6�   $��22(�6�   $ 
0.28,2.392&�6�   �� 5B   
   $�� Listar Boleta  ��6   $
��Left=�6+   $��562,624,0,0q�6F   $	��Top=�6[   $
��Bold"�6s   
�������$��39��6�   $	��149��6�   $��22(�6�   �� 5C   
   -
   5        $ btnelimbolet��5C      $�� ��6'   #���   62   $
��Left=�6x   $��446,554,0,0q�6�   $	��Top=�6�   $��54��6�   $��56��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6   $��14(�6  $ 0.529,-0.249&�6"  z�5D      V� 5E      .~�5F      �� $ 1Q�6%   $ 1Q�60   �� 5G      $ 0Q�6$   $	 0Q�6/   �� 5H      $
 -1Q�6&   T� 5I      $ -0.915Q�6)   $ -0.028Q�64   5J      ��5L      �� 5M      $ imagenes/eliminar.png��6   $ Uniform=�6A   5O      �� 5P   
   -   5        $ btnlistarboleta��5P      $�� ��6*   #���   65   $
��Left=�6{   $��600,550,0,0q�6�   $	��Top=�6�   $��54��6�   $��59��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6  $��14(�6  $ 0.5,0.5&�6%  z�5Q      V� 5R      .~�5S      �� $ 1Q�6%   $ 1Q�60   �� 5T      $ 0Q�6$   $	 0Q�6/   �� 5U      $
 -1Q�6&   T� 5V      5W      ��5Y      �� 5Z      $ imagenes/list.png��6   $ Uniform=�6=   5\      &   System.Windows.Controls.DataGrid  5]   
   -   5          Name$ dgBoleta��5]      $
��Left=�6%   $	��245��6@   $��
40,282,0,0q�6M   $	��Top=�6a   $	��678��6y   5^      5_      