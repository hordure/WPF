   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   ,    &ProjectMaster2016.AddProjectCostWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Skrá kostnað��5   	   $��444.358��6   $��697.88��6/    � WindowStartupLocation$ CenterScreen=�6U    � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  employeeViewSource �� Source �� Source  projectViewSource��%�   &	        &	      7   &	 A     7     5   
   6%   �� 5	   
    6:   �� *
employee+8   �� 5
   
    69   �� *	project+8   5      .��5      � $��0,0,2,3q�6    � DataContext# [ 6   .+�5   
   �� $��	Verkefni:��6   $
��Left=�6$   $��	47,70,0,0q�6?   $	��Top=�6R   $��87��6j   �� 5   
   -   5         ��Name$ lblAddProjectCostProject��5      $��
Veldu verk��62   $��
220,70,0,0q�6G   $
��Left=�6[   $	��400��6v   $	��Top=�6�   $��1��6�   �� 5   
   $��Starfsmaður:��6   $
��Left=�6'   $��
47,110,0,0q�6B   $	��Top=�6V   �� 5   
   -   5        $ lblAddProjectCostEmployee��5      $��Veldu starfsmann��63   $��220,110,0,0q�6N   $
��Left=�6c   $	��400��6   $	��Top=�6�   $��2��6�   �� 5   
   $��Kostnaðarlýsing:��6   $
��Left=�6+   $��
47,150,0,0q�6F   $	��Top=�6Z   �� 5   
   $#��Dagsetning kostnaðarfærslu:��6   $
��Left=�66   $��
47,224,0,0q�6Q   $	��Top=�6e   �� 5   
   $��Upphæð��6   $
��Left=�6!   $��
48,264,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ txtpcdescription��5      $�� ��6    �� TextWrapping$
 Wrap=�65   $��60��6I   $
��Left=�6U   $��220,150,0,0q�6p   $	��Top=�6�   	 J� RenderTransformOrigin$	 0.237,-0.192&�6�   $	��363��6�   $��3��6�   �� 5   
   -   5        $ txtcost��5   -   $
��Left=�6   $��23��6>   $��220,264,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $��80��6�   $��5��6�   �� 5   
   -   5        
 ��Name$
 btnAddProjectCostProject��5      $��
625,70,0,0q�63   ���	#FFF9F3F3$��0q�6_   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��28��6�   .��5      �� $��/images/plus.png��6   $��20��6/   $
��Fill=�6;   $��21��6J   5      �� 5   
   -   5        $
 btnAddProjectCostEmployee��5      $��625,110,0,0q�64   ���	#FFF9F3F3$��0q�6a   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��28��6�   .��5      �� $��/images/plus.png��6   $��20��6/   $
��Fill=�6;   $��21��6J   5      �� 5    
   -   5        $
 btnAddProjectCost��5    $   $��
Bæta við��6   $
��Left=�6?   $��104,342,0,0q�6Z   $	��Top=�6o   $��75��6�   $��6��6�   �� 5!   
   -	   5        $ lblpid��5!      $�� ��6   $
��Left=�6,   $��
162,80,0,0q�6G   $	��Top=�6[   �� 5"   
   -
   5        $ lbleid��5"      $�� ��6   $
��Left=�6,   $��169,126,0,0q�6G   $	��Top=�6\   (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ 
dpCostDate��5#      $
��Left=�6*   $��220,224,0,0q�6E   $	��Top=�6Z   $��4��6r    5$      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%f   '        �� 5%      "  6   .�5&      ��  � ��$ Veldu dagsetningu��6-   6I   5'      5(      5)      5+      5,      