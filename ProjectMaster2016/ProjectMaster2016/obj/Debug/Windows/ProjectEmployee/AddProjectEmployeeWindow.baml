   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   0    *ProjectMaster2016.AddProjectEmployeeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Velja starfsmann��5   	   $	��600��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�6R    � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  project_employeesViewSource �� Source �� Source  employeeViewSource��%�   &	        &	      7   &	 J     7     5   
   6%   �� 5   
    6C   �� *project_employees+8   �� 5	   
    6:   �� *
employee+8   5
      .��5      �  � DataContext# [ 6   .+�5   
   �� -   5         ��Name$ btnAddProjectEmployee��5      $��Velja��60   $
��Left=�6@   $��301,525,0,0q�6[   $	��Top=�6p   $��75��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5   
   -   5        $ 	btnCancel��5      $��Hætta við��6$   $
��Left=�68   $��433,525,0,0q�6S   $	��Top=�6h   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ employeeDataGrid��5      	 �� SelectedValuePath$		 eid��6-   
   AutoGenerateColumns
 .     EnableRowVirtualization . $��10,24,10,64q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�      
IsReadOnly . ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	eidColumn��,  &System.Windows.Controls.DataGridColumn   Header$	 eid��5   P      
IsReadOnly .    
Visibility$ Hidden=�6o      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *eid+6�     5      -   5        
nameColumn��$
 Nafn��5   R   $ SizeToCells 6`    69   �� *name+6`     5      -   5        emailColumn��$ email��5   T   $ Visible=�6c   $ SizeToCells 6x    6:   �� *email+6x     5      -   5        homeaddressColumn��$ Hidden=�5   `   $ homeaddress��6t   $ SizeToHeader 6�    6@   �� *homeaddress+6�     5      -	   5        phoneColumn��$ Visible=�5   T   $ phone��6i   $ 60 6x    6:   �� *phone+6x   4  .System.Windows.Controls.DataGridTemplateColumn  5      -
   5        	imgColumn��$
 Mynd��5   <   $ 60 6J      CellTemplate 5      �� 5      .R�5      �� ��6$   �� *img+5      5        5      -   5        professionColumn��$ Starfsheiti��5   ^   $ SizeToCells 6s    6?   �� *
profession+6s   5      5!      5"      