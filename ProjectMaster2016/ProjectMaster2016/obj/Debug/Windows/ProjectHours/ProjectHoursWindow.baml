   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   *    $ProjectMaster2016.ProjectHoursWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Tímayfirlit��5   	   $	��700��6   $
��1100��6*    � WindowStyle$ SingleBorderWindow=�6N    � WindowStartupLocation$ CenterScreen=�6o   
������� � WindowState$ Normal=�6�    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5	      �� .��5
      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S   	 g� Duration$	 0:0:0.5D�6Z   
 g� FillBehavior$

 Stop=�6m   5      5      5       � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  project_hoursViewSource �� Source �� Source �� 
TargetType �� Property �� Value��%�  &	        &	      7   '_� F       5   
   6%   �� 5   
    6?   �� *project_hours+8   �� 5   
   " _�6   .�5      ��  � ��$	 300��6)   �� 5       � �� 5      �� 5      .R�5      �� #��z��6+    5      ���� 5   "   '��       " ��6(   .�5   &   ��  � ��$
 Wrap=�6E   5   #   5      5      5      5!      5"      5#      .��5%      �  � DataContext# [ 6   .+�5&   
   &   System.Windows.Controls.DataGrid  -   5          Name$ project_hoursDataGrid��5&       �� SelectedValuePath$
 phid��62      AutoGenerateColumns .     EnableRowVirtualization . $��40,88,30,46q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�      
IsReadOnly . ��. ��6�   ��  � ContextMenu 5'      �� 5(      -   5         ��Name$	 ctx��5(      .@�5)      m� -   5         m�Name$ menu_EditProject��5)      $��Breyta��69   6I   m� 5*      -   5        $ menu_RemoveProject��5*      $��Eyða��6;   6I   5+         Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      -   5        hourtimestampColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 5.   B      Header$ Hvenær skráð��6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6l   �� *hourtimestamp+ �� StringFormat$ {0:dd.MM.yyyy kl.HH:mm}��  5/      -   5        project_nameColumn��$ Verkefni��5/   a   $ 2* 6s       
IsReadOnly  .  6A   �� *projectname+!   ElementStyle! 50      �� 51      " ��6    .�52      ��  � ��$ CharacterEllipsis=�6=   �� 53       �@�ToolTip 68   �� *Text+" �� RelativeSource" �� *Self+6w   54      56        57      -   5        employee_nameColumn��$ Skráningaraðili��57   [   #   MinWidth$# 50Q�6t   $ SizeToCells 6�    6B   �� *name+6�     58      -	   5        hourdescriptionColumn��$ Skýring��58   h   $ 4* 6y    6D   �� *hourdescription+! 59      �� 5:      " ��6    .�5;      ��  � ��$ CharacterEllipsis=�6=   �� 5<       �@�ToolTip 68   �� *Text+" �� *Self+6w   5=      5?        5@      -
   5        hourdateColumn��$ SizeToCells 5@   =   $# 70Q�6Q   $ Dags. tíma��6`    6t   �� *
hourdate+$ {0:dd.MM.yyyy}��  5A      -   5        workhourColumn��$ Tímar��5A   Z   $ SizeToHeader 6i    6=   �� *
workhour+6i   5C      �� 5D   
   -   5        $ ��Name$$ btnAddProjectHours��5D      $��	0,46,44,0q�6-   ���	#FFF9F3F3$��2q�6X   
������ $��30��6�   $	��Top=�6�   % � Cursor$
% Hand��6�   $��Right=�6�   $��30��6�   $��5��6�   .��5E      �� $��../../images/plus.png��6   $��20��63   $��20��6?   5F      �� 5G   
   -   5        & ��Name$& lblName��5G      $�� ��6!   $��0,0,11,0q�6,   $	��Top=�6>   $��Right=�6W   �� 5H   
   -   5        $$ 	btnLogOut��5H      $��Útskráning��6$   
������ 
������ $
% Hand��6m   $��Right=�6{   $��	0,22,11,0q�6�   $	��Top=�6�   $��76��6�   $��6��6�   (  "System.Windows.Controls.DatePicker  5I   
   -   5        '  Name$' 
dpFromDate��5I      $��	41,16,0,0q�6)   $��26��6<   $	��Top=�6H   $
��Left=�6`   $��95��6{   $��1��6�    5J      :  4System.Windows.Controls.Primitives.DatePickerTextBox��%_   '        �� 5K      "  6   .�5L      ��  � ��$ 
Frá dags.��6-   6A   5M      5N      5O        5P   
   -   5        $' dpToDate��5P      $��
150,16,0,0q�6'   $��26��6;   $	��Top=�6G   $
��Left=�6_   $��95��6z   $��2��6�    5Q      ��%^   '        �� 5R      "  6   .�5S      ��  � ��$ 	Til dags.��6-   6A   5T      5U      5V      �� 5W   
   -   5        $$ btnfillByDate��5W      $��Velja tímabil��6(   $
��Left=�6@   $��	41,56,0,0q�6[   $	��Top=�6n   $��95��6�   $��3��6�   �� 5X   
   $��	Tímabil:��6   $
��Left=�6#   $��
368,57,0,0q�6>   $	��Top=�6R   �� 5Y   
   -   5        $& lbldateRange��5Y      $
��Allt��6&   $
��Left=�65   $��
420,57,0,0q�6P   $	��Top=�6d   �� 5Z   
   -   5        $$ btnSelectAll��5Z      $��
Velja allt��6'   $
��Left=�6<   $��
150,56,0,0q�6W   $	��Top=�6k   $��95��6�   $��4��6�   5]      5^      