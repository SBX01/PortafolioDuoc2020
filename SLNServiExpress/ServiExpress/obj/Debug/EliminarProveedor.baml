   M S B A M L   `   `   `  ����G  CServiExpress, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ServiExpressServiExpress  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	   $    ServiExpress.EliminarProveedor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ServiExpress     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   -   5          � Title$  SERVIEXPRESS��5   	   ���#002542$��389.397��63   $��576.778��6D   .��5      � .+�5   
   �� $�� Eliminar Proveedor ��6   $
��Left=�6/   $��
103,10,0,0q�6J   $	��Top=�6^   ���	#FFFDFDFD$��48��6�   $	��456��6�   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��36(�6�   �� 5   
   -   5         ��Name$ lblrutp��5      $��Rut  Proveedor:��6!   $
��Left=�6;   $��	54,75,0,0q�6V   $	��Top=�6i   $
��Bold"�6�   ���	#FFFDFDFD$��34��6�   $	��190��6�   $��20(�6�   �� 5   
   -   5         ��Name$ 
cborutprov��5      $
��Left=�6'   $��
282,84,0,0q�6B   $	��Top=�6V   $	��146��6n    J� RenderTransformOrigin$ 0.584,0.275&�6z   6�   �� 5   
   -   5         ��Name$ Btnatras��5      $�� ��6#    /  +MahApps.Metro.Styles.MetroCircleButtonStyle#���   6.   $
��Left=�6t   $��492,271,0,0q�6�   $	��Top=�6�   $��48��6�   $��49��6�   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6  $ 0.5,0.5&�6  z�5      V� 5      .~�5      ��  �� ScaleY$ 1Q�6%    �� ScaleX$ 1Q�60   �� 5       �� AngleY$ 0Q�6$    �� AngleX$ 0Q�6/   �� 5      	 �� Angle$	 -1Q�6&   T� 5      5      ��5      �� 5      
 �� ImageSource$
 imagenes/atras.png��6    j� Stretch$ UniformToFill=�6>   5      �� 5   
   -   5        $ 	btnReload��5      $�� ��6$   $
��Left=�6/   $��
443,82,0,0q�6J   $	��Top=�6^   $��30��6v   $��27��6�   $��14(�6�   $
��Bold"�6�   $��Calibri)�6�   ��5      �� 5      $
 Imagenes/reload.png��6   $ UniformToFill=�6?    �� RelativeTransform 5       V� 5!      .~�5"      ��  �� CenterY$	 0.5Q�6-    �� CenterX$	 0.5Q�6;   �� 5#       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5$      $	 -180.00000000000003Q�6.    �� CenterY$	 0.5Q�6J    �� CenterX$	 0.5Q�6X   T� 5%      5&      5(      5*      &   System.Windows.Controls.DataGrid  5+   
   -   5          Name$ dgProv��5+      $
��Left=�6#   $	��206��6>   $��
41,127,0,0q�6K   $	��Top=�6_   $	��425��6w   6�   5,      5-      