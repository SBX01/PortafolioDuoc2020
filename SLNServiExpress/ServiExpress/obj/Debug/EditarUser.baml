   M S B A M L   `   `   `  ����G  CServiExpress, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ServiExpressServiExpress  5   	       ServiExpress.EditarUser   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ServiExpress     5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$  SERVIEXPRESS��5	   	   ���#002456$ ��400                       ��64   $	��500��5
      .��5      � .+�5   
   �� $��Edicion de perfil��6   $��118,10,108,0q�6,   $	��Top=�6B   ���	#FFFDFDFD$��48��6q   $
��Bold"�6}   $��Baskerville Old Face)�6�   $��36(�6�   �� 5   
   -   5        $��Guardar��5      $��
38,0,33,24q�6#   $��27��6L   $��Bottom=�6X   ���	#FF29F9F0���	#FFF7D22B���	#FF001BC3$
��Bold"�6�   � 5   
   $��43,80,37,67q�6   $��Center=�6$   .+�5      �� $��Usuario nuevo��6   $��	14,38,0,0q�6,   $	��Top=�6?   ���	#FFFDFDFD$��34��6n   $	��186��6z   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��20(�6�   $
��Left=�6�   �� 5      -   5         ��Name$ 	txtnombre��5      $
��Left=�6)   $��24��6D   $��
229,44,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��150��6�   �� 5      $��Contraseña nueva��6   $��
12,127,0,0q�6/   $	��Top=�6C   ���	#FFFDFDFD$��34��6r   $	��186��6~   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��20(�6�   $
��Left=�6�   G� 5      -   5         G�Name$ passUser��5      $
��Left=�6,   $��228,131,0,0q�6G   $	��Top=�6\   $	��150��6t   $��22��6�   6�   �� 5      $��Confirme contraseña��6   $��
14,173,0,0q�62   $	��Top=�6F   ���	#FFFDFDFD$��34��6u   $	��184��6�   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��20(�6�   $
��Left=�6�   G� 5      -   5        $ passUserConfirmar��5      $
��Left=�65   $��228,180,0,0q�6P   $	��Top=�6e   $	��150��6}   $��22��6�   6�   �� 5      -   5         ��Name$ 
lblDetalle��5      $�� ��6(   $��226,154,0,0q�63   $	��Top=�6H   ���	#FFFDFDFD$��24��6w   $	��186��6�   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��14(�6�   $
��Left=�6�   �� 5      $��Contraseña anterior��6   $��	12,81,0,0q�62   $	��Top=�6E   ���	#FFFDFDFD$��34��6t   $	��186��6�   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��20(�6�   $
��Left=�6�   G� 5      -   5        $ passUserOld��5      $
��Left=�6/   $��
229,85,0,0q�6J   $	��Top=�6^   $	��150��6v   $��22��6�   6�   �� 5      $��Usuario Antiguo��6   $��	15,-3,0,0q�6.   $	��Top=�6A   ���	#FFFDFDFD$��34��6p   $	��186��6|   $
��Bold"�6�   $��Baskerville Old Face)�6�   $��20(�6�   $
��Left=�6�   �� 5      -   5        $ txtnombreOld��5      $
��Left=�6,   $��24��6G   $��	229,6,0,0q�6S   $
 Wrap=�6f   $	��Top=�6z   $	��150��6�   5      �� 5   
   -   5         ��Name$ Btnatras��5      $�� ��6#    /  +MahApps.Metro.Styles.MetroCircleButtonStyle#���   6.   $��0,10,0,0q�6t   ���	#FFDBE2F7$
��Bold"�6�   $��Italic$�6�   $��14(�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $
��Left=�6  $��56��6#  $��50��6.  $	��Top=�6:  z�5      V� 5      .~�5      ��  �� ScaleY$ 1Q�6%    �� ScaleX$ 1Q�60   �� 5      	 �� AngleY$	 0Q�6$   
 �� AngleX$
 0Q�6/   �� 5        �� Angle$ -1Q�6&   T� 5!      5"      ��5$      �� 5%       �� ImageSource$ Imagenes/atras.png��6    j� Stretch$ Uniform=�6>   5'      5(      5)      