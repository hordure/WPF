   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   (    "ProjectMaster2016.AddProjectWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Nýtt verkefni��5   	   $	��450��6   $	��590��6,    � WindowStartupLocation$ CenterScreen=�6Q   
������� � WindowState$ Normal=�6�    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5	      �� .��5
      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S    g� Duration$ 0:0:0.5D�6Z   	 g� FillBehavior$	 HoldEnd=�6m   5      5      5      
 � 	Resources
 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  employeeViewSource �� Source �� Source��%Y   &	        &	      7     5   
   6%   �� 5   
    6:   �� *
employee+8   5      .��5      � .+�5   
   �� -   5         ��Name$ txtTitle��5      $��23��6$   $��
128,34,0,0q�60    �� TextWrapping$
 Wrap=�6D   $�� ��6X   $	��Top=�6`   $
��Left=�6x   $	��353��6�   �� 5   
   -   5        $ txtDescription��5      $	��134��6*   $��
128,71,0,0q�67   $
 Wrap=�6K   $�� ��6_   $	��Top=�6g   $
��Left=�6   $	��353��6�   �� 5   
   $��Titill:��6   $
��Left=�6"   $��	79,31,0,0q�6=   $	��Top=�6P   �� 5   
   $��Lýsing:��6   $
��Left=�6"   $��	69,67,0,0q�6=   $	��Top=�6P   �� 5   
   $��Umsjónarmaður:��6   $
��Left=�6)   $��
15,216,0,0q�6D   $	��Top=�6X   �� 5   
   -   5         ��Name$ 
cbEmployee��5       �� DisplayMemberPath$
 name��6'    �� SelectedValuePath$	 eid��6@   $��128,220,0,0q�6X   $	��Top=�6m   $
��Left=�6�   $	��353��6   � DataContext 6�   ��  �� Mode$ OneWay=�# [ ��6�   �� $ OneWay=�6  (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	dpDueDate��5      $��128,257,0,0q�6(   $��26��6=   $	��Top=�6I   $
��Left=�6a   $	��161��6|   
 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%f   '        �� 5      "  6   .�5      ��  � ��$ Veldu dagsetningu��6-   6I   5      5       5!      �� 5"   
   $��Lokið fyrir:��6   $
��Left=�6'   $��
49,257,0,0q�6B   $	��Top=�6V   $��73��6n   �� 5#   
   $��*��6   $��
481,22,0,0q�6   $	��Top=�60   ���	#FFFF0E0E$��24(�6_   $
��Left=�6m   $��20��6�   �� 5$   
   $��*��6   $��
481,59,0,0q�6   $	��Top=�60   ���	#FFFF0E0E$��24(�6_   $
��Left=�6m   $��20��6�   �� 5%   
   $��*��6   $��481,208,0,0q�6   $	��Top=�61   ���	#FFFF0E0E$��24(�6`   $
��Left=�6n   $��20��6�   �� 5&   
   -   5         ��Name$ btnAdd��5&      $��Nýskrá��6!   $
��Left=�62   $��128,354,0,0q�6M   $	��Top=�6b   $	��100��6z   $��27��6�   6�   �� 5'   
   -   5        $ 	btnCancel��5'      $��Hætta við��6$   $
��Left=�68   $��247,354,0,0q�6S   $	��Top=�6h   $	��100��6�   $��28��6�   6�   �� 5(   
   -   5         ��Name$ lblEmployee��5(      $y�Hidden=�6%   $��Label��69   $��128,216,0,0q�6I   $
��Left=�6^   $	��Top=�6z   �� 5)   
   -	   5        $ 	lblUserId��5)      $��Label��6#   $
��Left=�63   $��	518,7,0,0q�6N   $	��Top=�6a   5.      5/      