   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   /    )ProjectMaster2016.AddProjectMessageWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Skrá skilaboð��5   	   $��362.358��6   $��697.88��60    � WindowStartupLocation$ CenterScreen=�6V    � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet��%   &	          5   
   6%   5      .��5	      � $��0,0,2,3q�6   .+�5
   
   �� $��	Verkefni:��6   $
��Left=�6$   $��	47,70,0,0q�6?   $	��Top=�6R   $��87��6j   �� 5   
   -   5         ��Name$! lblAddProjectMessageProject��5      $��
Veldu verk��65   $��
220,70,0,0q�6J   $
��Left=�6^   $	��400��6y   $	��Top=�6�   �� 5   
   $��Starfsmaður:��6   $
��Left=�6'   $��
47,110,0,0q�6B   $	��Top=�6V   �� 5   
   -   5        $" lblAddProjectMessageEmployee��5      $��Veldu starfsmann��66   $��220,110,0,0q�6Q   $
��Left=�6f   $	��400��6�   $	��Top=�6�   �� 5   
   $��
Skilaboð:��6   $
��Left=�6$   $��
47,150,0,0q�6?   $	��Top=�6S   �� 5   
   -   5         ��Name$ txtpcdescription��5      $�� ��6   $	��114��65    �� TextWrapping$
 Wrap=�6C   $
��Left=�6W   $��220,150,0,0q�6r   $	��Top=�6�    J� RenderTransformOrigin$ 0.237,-0.192&�6�   $	��363��6�   $��3��6�   �� 5   
   -   5         ��Name$! btnAddProjectMessageProject��5      $��
625,70,0,0q�66   ���	#FFF9F3F3$��1q�6b   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��28��6�   $��1��6  .��5      �� $��../../images/plus.png��6   $��20��64   $
��Fill=�6@   $��21��6O   5      �� 5   
   -   5        $" btnAddProjectMessageEmployee��5      $��625,110,0,0q�67   ���	#FFF9F3F3$��1q�6d   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��28��6�   $��2��6  .��5      �� $��../../images/plus.png��6   $��20��64   $
��Fill=�6@   $��21��6O   5      �� 5   
   -   5        $ btnAddProjectMessage��5   !   $��Vista��6   $
��Left=�6?   $��406,286,0,0q�6Z   $	��Top=�6o   $��75��6�   $��4��6�   �� 5   
   -   5        $ lblpid��5      $�� ��6   $
��Left=�6,   $��
162,80,0,0q�6G   $	��Top=�6[   �� 5   
   -	   5        $ lbleid��5      $�� ��6   $
��Left=�6,   $��169,126,0,0q�6G   $	��Top=�6\   �� 5   
   -
   5        $ 	btnCancel��5      $��Hætta við��6$   $
��Left=�68   $��508,286,0,0q�6S   $	��Top=�6h   $��75��6�   $��5��6�   5      5      