   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   ,    &ProjectMaster2016.SelectEmployeeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Velja starfsmann��5   	   $	��600��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�6R    � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  employeeViewSource �� Source �� Source��%Y   &	        &	      7     5   
   6%   �� 5   
    6:   �� *
employee+8   5	      .��5
      �  � DataContext# [ 6    � ColumnDefinitions 5   
   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ employeeDataGrid��5       �� SelectedValuePath$	 eid��6.   	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�6F   $��10,59,10,74q�6u   
   EnableRowVirtualization
 .    AutoGenerateColumns .  ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        
nameColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 5   9      Header$
 name��6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6[   �� *name+  5      -   5        emailColumn��$ SizeToCells 5   :   $ email��6N    6]   �� *email+  5      -   5        phoneColumn��$ SizeToCells 5   :   $ phone��6N    6]   �� *phone+4  .System.Windows.Controls.DataGridTemplateColumn  5      -   5        	imgColumn��$ 60 5   <   $	 img��6G      CellTemplate 5      �� 5      .R�5      �� ��6$   �� *img+5      5        5      -   5        professionColumn��$ SizeToCells 5   ?   $ 
profession��6S    6g   �� *
profession+5      �� 5   
   -   5         ��Name$ btnAddEmployee��5      $��Velja��6)    � Cursor$
 Hand��69   $
��Left=�6G   $��323,516,0,0q�6b   $	��Top=�6w   $��75��6�   6�   �� 5   
   -	   5        $ 	btnCancel��5      $��Hætta við��6$   $
 Hand��68   $
��Left=�6F   $��418,516,0,0q�6a   $	��Top=�6v   $��75��6�   6�   5!      5"      