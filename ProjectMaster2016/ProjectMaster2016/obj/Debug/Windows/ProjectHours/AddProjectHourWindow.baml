   M S B A M L   `   `   `  ����  ProjectMaster2016,    &ProjectMaster2016.AddProjectHourWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Skrá tíma��5   	   $	��423��6   $	��726��6(    � WindowStyle$ SingleBorderWindow=�6K    � WindowStartupLocation$ CenterScreen=�6l   
������� � WindowState$ Normal=�6�    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5	      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S   	 g� Duration$	 0:0:0.5D�6Z   
 g� FillBehavior$

 Stop=�6m   5
      5      5      .��5      � $��0,0,-8,0q�6   .+�5   
   �� $��	Verkefni:��6   $
��Left=�6$   $��	47,70,0,0q�6?   $	��Top=�6R   $��87��6j   �� 5   
   -   5         ��Name$ lblAddProjectHoursProject��5      $��Veldu verkefni��63   $��
220,70,0,0q�6L   $
��Left=�6`   $	��400��6{   $	��Top=�6�   ���	#FFE895956�   �� 5   
   $��Starfsmaður:��6   $
��Left=�6'   $��
47,110,0,0q�6B   $	��Top=�6V   �� 5   
   -   5         ��Name$  btnAddProjectHours_Project��5      $��
625,70,0,0q�65   ���	#FFF9F3F3$��1q�6a    � Cursor$
 Hand��6u   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��30��6�   .��5      �� $��/images/plus.png��6   $��20��6/   $
��Fill=�6;   $��21��6J   5      �� 5   
   -   5        $ lblProjectHourEmployee��5      $��Veldu starfsmann��60   $��220,110,0,0q�6K   $
��Left=�6`   $	��400��6|   $	��Top=�6�   ���	#FFE895956�   �� 5   
   -   5        $! btnAddProjectHours_Employee��5      $��625,110,0,0q�66   ���	#FFF9F3F3$��1q�6c   $
 Hand��6w   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��30��6�   .��5      �� $��/images/plus.png��6   $��20��6/   $
��Fill=�6;   $��21��6J   5      �� 5   
   $��Lýsing:��6   $
��Left=�6"   $��
47,150,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5         ��Name$ txtphdescription��5      $�� ��6    �� TextWrapping$
 Wrap=�65   $��60��6I   $
��Left=�6U   $��220,150,0,0q�6p   $	��Top=�6�    J� RenderTransformOrigin$ 0.237,-0.192&�6�   $	��400��6�   �� 5   
   $��Dagsetning tímafærslu:��6   $
��Left=�61   $��
47,218,0,0q�6L   $	��Top=�6`   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpHoursDate��5      $
��Left=�6+   $��220,218,0,0q�6F   $	��Top=�6[    � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%f   '        �� 5       "  6   .�5!      ��  � ��$ Veldu dagsetningu��6-   6I   5"      5#      5$      �� 5%   
   $��Fjöldi tíma: ��6   $
��Left=�6(   $��
48,258,0,0q�6C   $	��Top=�6W   �� 5&   
   -   5        $ txthours��5&   .   $
��Left=�6   $��23��6@   $��220,258,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $��80��6�   �� 5'   
   -	   5        $��Nýskrá��5'      $
��Left=�6"   $��220,334,0,0q�6=   $	��Top=�6R   $
 Hand��6j   $��75��6x   6�   �� 5(   
   -
   5        $��Hætta við��5(      $
��Left=�6%   $��336,334,0,0q�6@   $	��Top=�6U   $
 Hand��6m   $��75��6{   6�   5*      5+      