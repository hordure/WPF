   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   &     ProjectMaster2016.EmployeeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Starfsmannayfirlit��5   	   $	��700��6$   $
��1100��61    � WindowStartupLocation$ CenterScreen=�6U    � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  employeeViewSource �� Source �� Source��%Y   &	        &	      7     5   
   6%   �� 5   
    6:   �� *
employee+8   5	      .��5
      �  � DataContext# [ 6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ employeeDataGrid��5       �� SelectedValuePath$	 eid��6-      RowDetailsVisibilityMode$ VisibleWhenSelected=�6E   $��10,98,10,25q�6t   	   EnableRowVirtualization	 . 
   AutoGenerateColumns
 .     
IsReadOnly . ��6�   ��  � ContextMenu 5      �� 5      -   5         ��Name$ ctxMenu��5      .@�5      m� -   5         m�Name$ menu_AddEmployee��5      $��
Bæta við��69   6K   m� 5      -   5        $ menu_EditEmployee��5      $��Breyta��6:   6J   m� 5      -   5        $ menu_RemoveEmployee��5      $��Eyða��6<   6J   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	eidColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 5   8      
IsReadOnly .    Header$	 eid��6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6l   �� *eid+  5      -   5        
nameColumn��$ SizeToCells 5   9   $
 name��6M    6[   �� *name+  5      -	   5        emailColumn��$ SizeToCells 5   :   $ email��6N    6]   �� *email+  5      -
   5        homeaddressColumn��$	 150 5   @   $ homeaddress��6L    6a   �� *homeaddress+   ElementStyle 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   5      5        5      -   5        	zipColumn��$ SizeToCells 5   8   $	 zip��6L    6Y   �� *zip+  5       -   5        phoneColumn��$ SizeToCells 5    :   $ phone��6N    6]   �� *phone+4  .System.Windows.Controls.DataGridTemplateColumn  5!      -   5        	imgColumn��$ 60 5!   <   $	 img��6G      CellTemplate 5"      �� 5#      .R�5$      �� ��6$   �� *img+5%      5'        5(      -   5        professionColumn��$ SizeToCells 5(   ?   $ 
profession��6S    6g   �� *
profession+  5)      -   5        userroleColumn��$ SizeToCells 5)   =   $
 Role��6Q    6_   �� *
userrole+  5*      -   5        usernameColumn��$ SizeToCells 5*   =   $ username��6Q    6c   �� *
username+5,      �� 5.   
   -   5         ��Name$ btnRemoveEmployee��5.      $��	0,55,51,0q�6,   ���	#FFF9F3F3$��2q�6W    � Cursor$
 Hand��6k   
������ $��30��6�   $	��Top=�6�   $��Right=�6�   $��30��6�   $��6��6�   .��5/      �� $��../../images/minus.png��6   $��15��64   50      �� 51   
   -   5        $ btnAddEmployee��51      $��	0,55,91,0q�6)   ���	#FFF9F3F3$��2q�6T   $
 Hand��6h   
������ $��30��6�   $	��Top=�6�   $��Right=�6�   $��30��6�   $��5��6�   .��52      �� $��../../images/plus.png��6   $��20��63   $��21��6?   53      �� 54   
   -   5        $ btnEditEmployee��54      $��	0,55,11,0q�6*   ���	#FFF9F3F3$��2q�6U   $
 Hand��6i   
������ $��30��6�   $	��Top=�6�   $��Right=�6�   $��30��6�   $��7��6�   .��55      �� $��../../images/wrench.png��6   $
��Fill=�67   $��22��6F   $��22��6Q   56      �� 57   
   -   5         ��Name$ lblName��57      $�� ��6!   $��0,0,11,0q�6,   $	��Top=�6>   $��Right=�6W   �� 58   
   -   5        $ 	btnLogOut��58      $��Útskráning��6$   
������ 
������ $
 Hand��6m   $��Right=�6{   $��	0,22,11,0q�6�   $	��Top=�6�   $��76��6�   $��8��6�   5:      5;      