   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   "    ProjectMaster2016.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          �Name$  MainWin��5   	    � Title$ VerkStjórinn��6   $	��410��6/   $	��625��6<    � 
ResizeMode$ NoResize=�6H    � WindowStyle$ SingleBorderWindow=�6u    � WindowStartupLocation$ CenterScreen=�6�   
������� � WindowState$ Normal=�6�    � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  userrolesViewSource �� Source �� Source  employeeViewSource��%�   &	        &	      7   &	 B     7     5   
   6%   �� 5   
    6;   �� *	userroles+8   �� 5	   
    6:   �� *
employee+8   5
      	 � Triggers	 5      :� 5   
   
 :� RoutedEvent$
 FrameworkElement.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S    g� Duration$ 0:0:0.5D�6Z    g� FillBehavior$ HoldEnd=�6m   5      5      5      .��5      �  � DataContext# [ 6   .+�5/   
   �� -   5         ��Name$ txtUsername��5/      $��25��6'   $��202,135,0,0q�63    �� TextWrapping$
 Wrap=�6H   $�� ��6\   $	��Top=�6d   $
��Left=�6|   $	��220��6�   G� 50   
   -   5         G�Name$ PasswordBox��50      $��202,199,0,0q�6+    G� 	MaxLength$ 14��6@   $	��Top=�6O   $��25��6g   $
��Left=�6s   $	��220��6�   �� 51   
   -   5         ��Name$ 	btnSignIn��51      $��Innskrá��6$   $��460,201,0,0q�66   $	��Top=�6K   $
��Left=�6{   $��84��6�   �� 52   
   -   5         ��Name$ lblUser��52      $��Notandanafn��6!   $��
56,135,0,0q�67   $	��Top=�6K   $
��Left=�6c   $��89��6~   �� 53   
   -   5        $ lblPass��53      $��	Lykilorð��6!   $��
56,199,0,0q�64   $	��Top=�6H   $
��Left=�6`   $��60��6{   �� 54   
   -   5        $ lblUserName��54      $��Right=�6>   $��	0,-3,20,0q�6Z   $y�	Collapsed=�6m   $	��Top=�6�   ��6%   �� *name+6�   �� 58   
   $
��Left=�6   $��	37,22,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��98��6n   $	��166��6z   �� 6�   $�username 1,2,3 - admin��6�   �� 6�   �� 6�   $ �username 4,5   - poweruser��6�   �� 6�   �� 6�   $�username 6,7   - user��6�   �� 6  �� 6  �� 6   �� 6,  $�passw sama og username��60  6Q  5;      5<      