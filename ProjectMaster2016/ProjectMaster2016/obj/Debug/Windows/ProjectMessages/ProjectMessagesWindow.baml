   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   -    'ProjectMaster2016.ProjectMessagesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Yfirlit skilaboða��5   	   $	��700��6#   $
��1100��60    � WindowStartupLocation$ CenterScreen=�6T    � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  project_messagesViewSource �� Source �� Source �� 
TargetType �� Property �� Value��%�  &	        &	      7   '_� I       5   
   6%   �� 5   
    6B   �� *project_messages+8   �� 5	   
   " _�6   .�5
      ��  � ��$	 300��6)   �� 5       � �� 5      �� 5      .R�5      �� #��z��6+    5      ���� 5   "   '��       " ��6(   .�5   &   ��  � ��$
 Wrap=�6E   5   #   5      5      5      5      5      5      .��5      �  � DataContext# [ 6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 project_messagesDataGrid��5      
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�65    �� SelectedValuePath$
 pmid��6d   $��34,98,21,27q�6}      EnableRowVirtualization .    AutoGenerateColumns .     
IsReadOnly . ��6�   ��  � ContextMenu 5      �� 5      -   5         ��Name$ ctxMenu��5      .@�5      m� -   5         m�Name$ menu_EditProject��5      $��Breyta��69   6I   m� 5      -   5        $ menu_RemoveProject��5      $��Eyða��6;   6I   5          Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      -   5        messagetimestampColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 5#   E      MinWidth$ 60Q�6Y      Header$ Stofnað��6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6x   �� *messagetimestamp+ �� StringFormat$ {0:dd.MM.yyyy kl.HH:mm}��  5$      -   5        projectColumn��$ * 5$   <   $ 60Q�6F   $ Verkefni��6T    6f   �� *projectname+   ElementStyle 5%      �� 5&      " ��6    .�5'      ��  � ��$ CharacterEllipsis=�6=   �� 5(       �@�ToolTip 68   �� *Text+ �� RelativeSource �� *Self+6w   5)      5+        5,      -   5        employeeColumn��$ SizeToCells 5,   =   $ 65Q�6Q   $ 
Skráð af��6_    6q   �� *name+  5-      -	   5        projectmessageColumn��$ 3* 5-   C   $ 80Q�6N   $ 	Skilaboð��6\    6n   �� *projectmessage+ 5.      �� 5/      " ��6    .�50      ��  � ��$ CharacterEllipsis=�6=   �� 51       �@�ToolTip 68   �� *Text+ �� *Self+6w   52      54      57      �� 58   
   -
   5         ��Name$ btnAddMessage��58      $��	0,53,26,0q�6(   ���	#FFF9F3F3$��2q�6S    � Cursor$
 Hand��6g   
������ $��30��6�   $	��Top=�6�   $��Right=�6�   $��30��6�   .��59      �� $��../../images/plus.png��6   $��20��63   $��21��6?   5:      �� 5;   
   -   5         ��Name$ lblName��5;      $�� ��6!   $��0,0,11,0q�6,   $	��Top=�6>   $��Right=�6W   �� 5<   
   -   5        $ 	btnLogOut��5<      $��Útskráning��6$   
������ 
������ $
 Hand��6m   $��Right=�6{   $��	0,22,11,0q�6�   $	��Top=�6�   $��76��6�   6�   (  "System.Windows.Controls.DatePicker  5=   
   -   5          Name$ 
dpFromDate��5=      $��	33,19,0,0q�6)   $��26��6<   $	��Top=�6H   $
��Left=�6`   $��95��6{    5>      :  4System.Windows.Controls.Primitives.DatePickerTextBox��%_   '        �� 5?      "  6   .�5@      ��  � ��$ 
Frá dags.��6-   6A   5A      5B      5C        5D   
   -   5        $ dpToDate��5D      $��
142,19,0,0q�6'   $��26��6;   $	��Top=�6G   $
��Left=�6_   $��95��6z    5E      ��%^   '        �� 5F      "  6   .�5G      ��  � ��$ 	Til dags.��6-   6A   5H      5I      5J      �� 5K   
   -   5        $ btnfillByDate��5K      $��Velja tímabil��6(   $
��Left=�6@   $
 Hand��6[   $��	33,62,0,0q�6i   $	��Top=�6|   $��95��6�   6�   �� 5L   
   $��	Tímabil:��6   $
��Left=�6#   $��
368,57,0,0q�6>   $	��Top=�6R   �� 5M   
   -   5        $ lbldateRange��5M      $
��Allt��6&   $
��Left=�65   $��
420,57,0,0q�6P   $	��Top=�6d   �� 5N   
   -   5        $ btnSelectAll��5N      $��
Velja allt��6'   $
��Left=�6<   $
 Hand��6W   $��
142,62,0,0q�6e   $	��Top=�6y   $��95��6�   6�   5P      5Q      