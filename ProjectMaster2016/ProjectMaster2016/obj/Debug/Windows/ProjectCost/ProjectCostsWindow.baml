   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   *    $ProjectMaster2016.ProjectCostsWindow   5   	   wpfhttp://wpfcontrols.com/  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Kostnaðaryfirlit��5   	   $	��700��6"   $
��1100��6/    � WindowStyle$ SingleBorderWindow=�6S    � WindowStartupLocation$ CenterScreen=�6t   
������� � WindowState$ Normal=�6�    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5	      �� .��5
      �� .��5      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S   	 g� Duration$	 0:0:0.5D�6Z   
 g� FillBehavior$
 HoldEnd=�6m   5      5      5       � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  project_costsViewSource �� Source �� Source �� 
TargetType �� Property �� Value��%�  &	        &	      7   '_� F       5   
   6%   �� 5   
    6?   �� *project_costs+8   �� 5   
   " _�6   .�5      ��  � ��$	 300��6)   �� 5       � �� 5      �� 5      .R�5      �� #��z��6+    5      ���� 5   "   '��       " ��6(   .�5   &   ��  � ��$
 Wrap=�6E   5   #   5      5      5       5"      5#      5$      .��5(      �  � DataContext# [ 6   .+�5)   
   &   System.Windows.Controls.DataGrid  -   5          Name$ project_costsDataGrid��5)       �� SelectedValuePath$
 pcid��62      RowDetailsVisibilityMode$ VisibleWhenSelected=�6K   $��22,106,26,59q�6z      EnableRowVirtualization .    AutoGenerateColumns .     
IsReadOnly . ��6�   ��  � ContextMenu 5*      �� 5+      -   5         ��Name$ ctxMenu��5+      .@�5,      m� -   5         m�Name$ menu_EditProject��5,      $��Breyta��69   6I   m� 5-      -   5        $ menu_RemoveProject��5-      $��Eyða��6;   6I   5.         Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      -   5        costtimestampColumn��,  &System.Windows.Controls.DataGridColumn   MinWidth$ 90Q�52   B      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6P      Header$ Færsla stofnuð��6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6}   �� *costtimestamp+  �� StringFormat$  {0:dd.MM.yyyy kl.HH:mm}��  53      -   5        project_pidColumn��$ SizeToCells 53   @   $ 50Q�6T   $ Verknr.��6b    6s   �� *project_pid+  54      -   5        projectnameColumn��$ 2* 54   @   $ 35Q�6K   $
 Verk��6Y    6g   �� *projectname+!   ElementStyle! 55      �� 56      " ��6    .�57      ��  � ��$ CharacterEllipsis=�6=   �� 58       �@�ToolTip 68   �� *Text+" �� RelativeSource" �� *Self+6w   59      5;        5<      -	   5        employee_eidColumn��$ SizeToCells 5<   A   $ 70Q�6U   $ Starfsm.nr.��6c    6x   �� *name+  5=      -
   5        project_employeenameColumn��$ SizeToCells 5=   I   $ project pid��6^   #   
Visibility$# Hidden=�6s    6�   �� *name+  5>      -   5        costdescriptionColumn��$ 4* 5>   D   $ 60Q�6O   $ Skýring��6]    6n   �� *costdescription+! 5?      �� 5@      " ��6    .�5A      ��  � ��$ CharacterEllipsis=�6=   �� 5B       �@�ToolTip 68   �� *Text+" �� *Self+6w   5C      5E        5F      -   5        costdateColumn��$ SizeToCells 5F   >   $ 95Q�6R   $ Dags. kostnaðar��6`    6y   �� *
costdate+$  {0:dd.MM.yyyy}��  5G      -   5        
costColumn��$ SizeToCells 5G   9   $ 70Q�6M   $ Upphæð��6\    6l   �� *cost+$  C��! 5H      �� 5I      " ��6    .�5J      ��  � ��$ Right=�6D   5K      5M        5N      -   5        
pcidColumn��$ SizeToHeader 5N   9   $   
IsReadOnly$ . $# Hidden=�6`   $
 pcid��6u    6�   �� *pcid+5P      �� 5Q   
   -   5        % ��Name$% btnAddProject��5Q      $��	0,59,26,0q�6(   ���	#FFF9F3F3$��1q�6S   
������ $��34��6�   $	��Top=�6�   $��Right=�6�   $��26��6�   .��5R      �� $��../../images/plus.png��6   $��20��63   $��21��6?   5S      �� 5T   
   -   5        & ��Name$& lblName��5T      $�� ��6!   $��0,0,11,0q�6,   $	��Top=�6>   $��Right=�6W   �� 5U   
   -   5        $% 	btnLogOut��5U      $��Útskráning��6$   
������ 
������ ' � Cursor$
' Hand��6m   $��Right=�6{   $��	0,22,11,0q�6�   $	��Top=�6�   $��76��6�   6�   (  "System.Windows.Controls.DatePicker  5V   
   -   5        (  Name$( 
dpFromDate��5V      $��	24,23,0,0q�6)   $��26��6<   $	��Top=�6H   $
��Left=�6`   $��95��6{    5W      :  4System.Windows.Controls.Primitives.DatePickerTextBox��%_   '        �� 5X      "  6   .�5Y      ��  � ��$ 
Frá dags.��6-   6A   5Z      5[      5\        5]   
   -   5        $( dpToDate��5]      $��
133,23,0,0q�6'   $��26��6;   $	��Top=�6G   $
��Left=�6_   $��95��6z    5^      ��%^   '        �� 5_      "  6   .�5`      ��  � ��$ 	Til dags.��6-   6A   5a      5b      5c      �� 5d   
   -   5        $% btnfillByDate��5d      $��Velja tímabil��6(   $
��Left=�6@   $��	24,63,0,0q�6[   $	��Top=�6n   $��95��6�   6�   �� 5e   
   $��	Tímabil:��6   $
��Left=�6#   $��
368,57,0,0q�6>   $	��Top=�6R   �� 5f   
   -   5        $& lbldateRange��5f      $��Label��6&   $
��Left=�66   $��
420,57,0,0q�6Q   $	��Top=�6e   �� 5g   
   -   5        $% btnSelectAll��5g      $��
Velja allt��6'   $
��Left=�6<   $��
133,63,0,0q�6W   $	��Top=�6k   $��95��6�   6�   5j      5k      