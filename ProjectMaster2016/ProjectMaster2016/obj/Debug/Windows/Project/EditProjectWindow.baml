   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   )    #ProjectMaster2016.EditProjectWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Breyta verkefni��5   	   $	��444��6!   $	��710��6.    � WindowStartupLocation$ CenterScreen=�6Q    � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  projectViewSource �� Source �� Source  employeeViewSource  project_employeesViewSource��%�   &	        &	      7   &	 @     7   &	 n     7     5   
   6%   �� 5   
    69   �� *	project+8   �� 5	   
    6:   �� *
employee+8   �� 5
   
    6C   �� *project_employees+8   5      .��5      �  � DataContext# [ 6   $��0,0,2,0q�6<   .+�5   
   �� -   5         ��Name$ txtprojectName��5      $
��Left=�6*   $��23��6E   $��
117,73,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $	��Top=�6{   $	��228��6�   ��6�   �� */ projectname+�� 5   
   -   5        $ txtPDescription��5      $
��Left=�6+   $	��150��6F   $��117,101,0,0q�6S   $
 Wrap=�6h   $	��Top=�6�   $	��228��6�   ��6|   �� */ pdescription+6�   �� 5   
   -   5         ��Name$ lblPDate��5      	 �� ContentStringFormat$	 dd.MM.yyyy    kl. HH:mm��6i   $
��Left=�6�   $��117,293,0,0q�6�   $	��Top=�6�   
 J� RenderTransformOrigin$
 0.6,0.5&�6�   ��6"   �� *pdate+# [ 6�   �� 5   
   $��Titill��6   $
��Left=�6!   $��	71,73,0,0q�6<   $	��Top=�6O   �� 5   
   $��Lýsing��6   $
��Left=�6!   $��
60,104,0,0q�6<   $	��Top=�6P   �� 5   
   $��Umsjónarmaður��6   $
��Left=�6)   $��	8,262,0,0q�6D   $	��Top=�6W   �� 5   
   $��Stofnað��6   $
��Left=�6"   $��
52,293,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5         ��Name$ 
cbEmployee��5       �� DisplayMemberPath$
 name��6'    �� SelectedValuePath$	 eid��6@   $
��Left=�6X   $��118,266,0,0q�6s   $	��Top=�6�   $	��183��6�   ��6�   ��  �� Mode$ OneWay=� 6�   �� $ OneWay=�# [ �� 5   
   $��Lokið��6   $
��Left=�6    $��
65,327,0,0q�6;   $	��Top=�6O   $
 0.184,0.423&�6g   �� 5   
   -   5        $ lblIsFinished��5      $��Label��6J   $
��Left=�6Z   $��118,327,0,0q�6u   $	��Top=�6�   $
 0.526,0&�6�   ���	#FF759EE8$��18(�6%  $
��Bold"�63  �� 5   
   -   5         ��Name$ 	btnUpdate��5      $��Vista��6$   $
��Left=�64   $��131,371,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ 	btnCancel��5      $��Hætta við��6$   $
��Left=�68   $��226,371,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   $��Verkefni��6   $
��Left=�6#   $��	291,8,0,0q�6>   $	��Top=�6Q   $	��116��6i   $��24(�6u   �� 5   
   $��Starfsmenn verkefnis��6   $
��Left=�6/   $��
379,69,0,0q�6J   $	��Top=�6^   � 5   
   .+�5      �� -	   5         ��Name$ lbProjectEmployees��5      $
 name��62   $
 peid��6K   $
��Left=�6d   $	��250��6   $��376,105,0,0q�6�   $	��Top=�6�   $	��222��6�    6�   �� $ OneWay=�# [ ��6  �� $ OneWay=� � ContextMenu 5      �� 5       .@�5!      m� $��
Bæta við��6#   67   m� 5"      $��Eyða��6#   63   5#      5%      5'      �� 5(   
   -
   5        $ btnAddProjectEmployee��5(      $��
534,61,0,0q�60   ���	#FFF9F3F3$��0q�6\   
������ $��34��6�   $	��Top=�6�   $
��Left=�6�   $��26��6�   .��5)      �� $��../../images/plus.png��6   $��20��63   $��21��6?   5*      �� 5+   
   -   5        $ btnRemoveProjectEmployee��5+      $��
567,64,0,0q�63   ���	#FFF9F3F3$��0q�6_   
������ $��29��6�   $	��Top=�6�   $
��Left=�6�   $��28��6�   .��5,      �� $��../../images/minus.png��6   $��15��64   5-      52      53      