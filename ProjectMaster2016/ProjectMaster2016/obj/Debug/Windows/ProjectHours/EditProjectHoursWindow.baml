   M S B A M L   `   `   `  ����  ProjectMaster2016.    (ProjectMaster2016.EditProjectHoursWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Breyta tímaskráningu��5   	   $	��444��6&   $	��679��63    � WindowStyle$ SingleBorderWindow=�6@    � WindowStartupLocation$ CenterScreen=�6a   
������� � WindowState$ Normal=�6�    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5	      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S   	 g� Duration$	 0:0:0.5D�6Z   
 g� FillBehavior$

 Stop=�6m   5
      5      5      .��5      � $��0,0,-8,0q�6   .+�5   
   �� $��	Verkefni:��6   $
��Left=�6$   $��	47,70,0,0q�6?   $	��Top=�6R   $��87��6j   �� 5   
   -   5         ��Name$ lblEditProject��5      
�������$��Veldu verkefni��6<   $��
220,70,0,0q�6U   $
��Left=�6i   $	��367��6�   $	��Top=�6�   �� 5   
   $��Starfsmaður:��6   $
��Left=�6'   $��
47,110,0,0q�6B   $	��Top=�6V   �� 5   
   -   5         ��Name$! btnEditProjectHours_Project��5      $��
592,70,0,0q�66   ���	#FFF9F3F3$��1q�6b    � Cursor$
 Hand��6v   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��30��6�   .��5      �� $��/images/wrench.png��6   $��20��61   $
��Fill=�6=   $��21��6L   5      �� 5   
   -   5        $" btnEditProjectHours_Employee��5      $��592,110,0,0q�67   ���	#FFF9F3F3$��1q�6d   $
 Hand��6x   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��30��6�   .��5      �� $��/images/wrench.png��6   $��20��61   $
��Fill=�6=   $��21��6L   5      �� 5   
   -   5        $ lblEmployee��5      $�� ��6%   $��220,110,0,0q�60   $
��Left=�6E   $	��367��6a   $	��Top=�6n   �� 5   
   $��Lýsing:��6   $
��Left=�6"   $��
47,150,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5         ��Name$ txtphdescription��5      $�� ��6   $��60��65   $
��Left=�6A    �� TextWrapping$
 Wrap=�6\   $��220,150,0,0q�6p   $	��Top=�6�    J� RenderTransformOrigin$ 0.237,-0.192&�6�   $	��400��6�   �� 5   
   $��Dagsetning tímafærslu:��6   $
��Left=�61   $��
47,221,0,0q�6L   $	��Top=�6`   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpHoursDate��5      $
��Left=�6+   $��220,221,0,0q�6F   $	��Top=�6[    � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%f   '        �� 5       "  6   .�5!      ��  � ��$ Veldu dagsetningu��6-   6I   5"      5#      5$      �� 5%   
   $��Fjöldi tíma: ��6   $
��Left=�6(   $��
48,261,0,0q�6C   $	��Top=�6W   �� 5&   
   -   5        $ txthours��5&   .   $
��Left=�6   $��23��6@   $��220,261,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $��80��6�   �� 5'   
   -	   5        $��Breyta��5'      $
��Left=�6"   $��225,334,0,0q�6=   $	��Top=�6R   $��75��6j   6u   �� 5(   
   -
   5        $��Hætta við��5(      $
��Left=�6%   $��336,334,0,0q�6@   $	��Top=�6U   $��75��6m   6x   �� 5)   
   -   5        $ txtPhid��5)      $�� ��6!   $
��Left=�6,   $y�Hidden=�6G   $��180,119,0,0q�6[   $	��Top=�6p   �� 5*   
   -   5        $ lblpid��5*      $�� ��6    $
��Left=�6+   $��
164,78,0,0q�6F   $	��Top=�6Z   5,      5-      