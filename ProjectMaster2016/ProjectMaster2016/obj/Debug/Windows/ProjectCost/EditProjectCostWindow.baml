   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   -    'ProjectMaster2016.EditProjectCostWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Breyta kostnaði��5   	   $��458.209��6!   $��650.746��62    � WindowStartupLocation$ CenterScreen=�6Y    � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  project_costsViewSource �� Source �� Source��%^   &	        &	      7     5   
   6%   �� 5   
    6?   �� *project_costs+8   5	      .��5
      � $��	0,-1,-8,0q�6    � DataContext# [ 6   .+�5   
   �� $��	Verkefni:��6   $
��Left=�6$   $��	47,70,0,0q�6?   $	��Top=�6R   $��87��6j   �� 5   
   $��Starfsmaður:��6   $
��Left=�6'   $��
47,110,0,0q�6B   $	��Top=�6V   �� 5   
   $��Kostnaðarlýsing:��6   $
��Left=�6+   $��
47,150,0,0q�6F   $	��Top=�6Z   �� 5   
   $#��Dagsetning kostnaðarfærslu:��6   $
��Left=�66   $��
47,225,0,0q�6Q   $	��Top=�6e   �� 5   
   $��Færsla stofnuð:��6   $
��Left=�6*   $��
47,265,0,0q�6E   $	��Top=�6Y   �� 5   
   $��Upphæð��6   $
��Left=�6!   $��
48,305,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$  lblEditProjectCost_Project��5   2   $	��320��6V   $
��Left=�6b   $��
220,70,0,0q�6}   $	��Top=�6�   ��6   �� */ projectname+6�   �� 5   
   -   5        $! lblEditProjectCost_Employee��5   +   $
��Left=�6P   $��220,110,0,0q�6k   $	��320��6�   $	��Top=�6�   ��6   �� */ name+6�   �� 5   
   -   5         ��Name$ txtpcdescription��5   6   $��60��6P    �� TextWrapping$
 Wrap=�6\   $
��Left=�6p   $��220,150,0,0q�6�   $	��Top=�6�   	 J� RenderTransformOrigin$	 0.237,-0.192&�6�   $	��363��6�   ��6   �� */ costdescription+6�   �� 5   
   -   5        $ lblCreateDate��5   4   
 �� ContentStringFormat$
 dd.MM.yyyy    kl. HH:mm��6K   $
��Left=�6y   $��220,265,0,0q�6�   $	��Top=�6�   ��6   �� */ costtimestamp+6�   �� 5   
   -   5        $ txtcost��5   -   $
��Left=�6   $��23��6>   $��220,305,0,0q�6J   $
 Wrap=�6_   $	��Top=�6�   $��80��6�   ��6s   �� */ cost+6�   �� 5   
   -   5         ��Name$ btnEditProjectCostProject��5      $��
555,70,0,0q�64   ���	#FFF9F3F3$��1q�6`   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��28��6�   .��5      �� $��../../images/wrench.png��6   $��20��66   $
��Fill=�6B   $��21��6Q   5      �� 5   
   -   5        $  btnEditProjectCostEmployee��5      $��555,110,0,0q�65   ���	#FFF9F3F3$��1q�6b   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��28��6�   .��5      �� $��../../images/wrench.png��6   $��20��66   $
��Fill=�6B   $��21��6Q   5      �� 5   
   -	   5        $ btnUptadeProjectCost��5   !   $��Vista��6   $
��Left=�6?   $��104,361,0,0q�6Z   $	��Top=�6o   $��75��6�   6�   �� 5   
   -
   5        $ lblpid��5   *   $y�Hidden=�6:   $
��Left=�6N   $��
162,80,0,0q�6i   $	��Top=�6}   ��6   �� */ pid+6}   �� 5   
   -   5        $ lbleid��5   *   $y�Hidden=�6:   $
��Left=�6N   $��169,126,0,0q�6i   $	��Top=�6~   ��6   �� */ eid+6~   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
dpCostDate��5      $
��Left=�6K   $��220,225,0,0q�6f   $	��Top=�6{      SelectedDate 6)   �� *
costdate+6{   5!      5"      