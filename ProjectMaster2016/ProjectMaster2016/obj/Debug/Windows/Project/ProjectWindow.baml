   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   %    ProjectMaster2016.ProjectWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Verkefnayfirlit��5   	   $	��700��6!   $
��1100��6.    � WindowStyle$ SingleBorderWindow=�6S    � WindowStartupLocation$ CenterScreen=�6t    � WindowState$ Normal=�6�    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5	      �� .��5
      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S   	 g� Duration$	 0:0:0.5D�6Z   
 g� FillBehavior$

 Stop=�6m   5      5      5       � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  projectViewSource �� Source �� Source �� 
TargetType �� Property �� Value��%�  &	        &	      7   '_� @       5   
   6%   �� 5   
    69   �� *	project+8   �� 5   
   " _�6   .�5      ��  � ��$	 300��6)   �� 5       � �� 5      �� 5      .R�5      �� #��z��6+    5      ���� 5   "   '��       " ��6(   .�5   &   ��  � ��$
 Wrap=�6E   5   #   5      5      5      5!      5"      5#      .��5%      �  � DataContext# [ 6   .+�5&   
   � .+�5'      (  "System.Windows.Controls.DatePicker  -   5          Name$ 
dpFromDate��5'      $��	11,22,0,0q�6-   $��26��6@   $	��Top=�6L   $
��Left=�6d   $��95��6   $��1��6�    5(      :  4System.Windows.Controls.Primitives.DatePickerTextBox��%_   '        �� 5)      "  6   .�5*      ��  � ��$ 
Frá dags.��61   6E   5+      5,      5-        5.      -   5        $ dpToDate��5.      $��
120,22,0,0q�6+   $��26��6?   $	��Top=�6K   $
��Left=�6c   $��95��6~   $��2��6�    5/      ��%^   '        �� 50      "  6   .�51      ��  � ��$ 	Til dags.��61   6E   52      53      54      �� 55      -   5         ��Name$ btnfillByDate��55      $��Velja tímabil��6,   $
��Left=�6D   $��	11,62,0,0q�6_   $	��Top=�6r   $��95��6�   $��3��6�   �� 56      $��	Tímabil:��6   $
��Left=�6'   $��
368,57,0,0q�6B   $	��Top=�6V   �� 57      -   5         ��Name$ lbldateRange��57      $��Label��6*   $
��Left=�6:   $��
420,57,0,0q�6U   $	��Top=�6i   �� 58      -   5        $ btnSelectAll��58      $��
Velja allt��6+   $
��Left=�6@   $��
120,62,0,0q�6[   $	��Top=�6o   $��95��6�   $��4��6�   5;      &   System.Windows.Controls.DataGrid  5=   
   -   5          Name$ projectDataGrid��5=       �� SelectedValuePath$	 pid��6,      RowDetailsVisibilityMode$ VisibleWhenSelected=�6D   $��10,98,10,25q�6s      EnableRowVirtualization .    AutoGenerateColumns .     
IsReadOnly . ��. ��6�   ��  � ContextMenu 5>      �� 5?      .@�5@      m� -   5         m�Name$ menu_EditProject��5@      $��Breyta��69   6I   m� 5A      -	   5        $ menu_RemoveProject��5A      $��Eyða��6;   6I   �� 5B      -
   5         ��Name$	 sep��5B       6/   m� 5C      -   5        $ menu_relateEntries��5C      $!�� Yfirlit - Tengdar færslur��6;   6�   �� 5D      6"   m� 5E      -   5        $ menu_ProjectCost��5E      $��    - Kostnaður��69   6s   m� 5F      -   5        $ menu_ProjectMessages��5F      $��    - Skilaboð��6=   6z   m� 5G      -   5        $ menu_ProjectHours��5G      $��    - Tímaskráning��6:   6x   5H         Columns 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      -   5        	pdate��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 5K   5       Header$  Stofn dags.��6K   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 6`   �� *pdate+" �� StringFormat$" {0:dd.MM.yyyy}��  5L      -   5        	pidColumn��#   
IsReadOnly# . $   
Visibility$$ Hidden=�5L   K   $	  pid��6_   ! 6l   �� *pid+  5M      -   5        projectnameColumn��$ 2* 5M   @   $  Verkefni��6K   ! 6]   �� *projectname+%   ElementStyle% 5N      �� 5O      " ��6    .�5P      ��  � ��$ CharacterEllipsis=�6=   �� 5Q       �@�ToolTip 68   �� *Text+& �� RelativeSource& �� *Self+6w   5R      5T        5U      -   5        employee_eidColumn��$ * 5U   A   $$ Hidden=�6K   $  employee eid��6_   ! 6u   �� *employee_eid+  5V      -   5        employee_nameColumn��$ * 5V   B   $$ Visible=�6L   $  Umsjón��6a   ! 6q   �� *name+  5W      -   5        pdescriptionColumn��$ 4* 5W   A   $  Lýsing��6L   ! 6\   �� *pdescription+% 5X      �� 5Y      " ��6    .�5Z      ��  � ��$ CharacterEllipsis=�6=   �� 5[       �@�ToolTip 68   �� *Text+& �� *Self+6w   5\      5^      4	  .System.Windows.Controls.DataGridCheckBoxColumn	  5c      -   5        projectisfinishedColumn��$ SizeToHeader 5c   J   $  Lokið��6`   ! 6o   �� *projectisfinished+5f      �� 5g   
   -   5        $ btnRemoveProject��5g      $��	0,55,51,0q�6+   ���	#FFF9F3F3$��2q�6V   ' � Cursor$
' Hand��6j   
������ $��30��6�   $	��Top=�6�   $��Right=�6�   $��30��6�   $��6��6�   .��5h      �� $��../../images/minus.png��6   $��15��64   5i      �� 5j   
   -   5        $ btnAddProject��5j      $��	0,55,91,0q�6(   ���	#FFF9F3F3$��2q�6S   $
' Hand��6g   
������ $��30��6�   $	��Top=�6�   $��Right=�6�   $��30��6�   $��5��6�   .��5k      �� $��../../images/plus.png��6   $��20��63   $��21��6?   5l      �� 5m   
   -   5        $ btnEditProject��5m      $��	0,55,11,0q�6)   ���	#FFF9F3F3$��2q�6T   $
' Hand��6h   
������ $��30��6�   $	��Top=�6�   $��Right=�6�   $��30��6�   $��7��6�   .��5n      �� $��../../images/wrench.png��6   $
��Fill=�67   $��22��6F   $��22��6Q   5o      �� 5p   
   -   5        $ lblName��5p      $�� ��6!   $��0,0,11,0q�6,   $	��Top=�6>   $��Right=�6W   �� 5q   
   -   5        $ 	btnLogOut��5q      $��Útskráning��6$   
������ 
������ $
' Hand��6m   $��Right=�6{   $��	0,22,11,0q�6�   $	��Top=�6�   $��76��6�   $��8��6�   5s      5v      