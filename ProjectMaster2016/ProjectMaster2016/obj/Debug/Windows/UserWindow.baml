   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   "    ProjectMaster2016.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Yfirlit��5   	   $	��700��6   $	��400��6&   $
��1100��66   $	��950��6C    � WindowStartupLocation$ CenterScreen=�6R   
���   �$��3q�6�    � WindowStyle$ SingleBorderWindow=�6�    � 
ResizeMode$ 	CanResize=�6�    � 	Resources 5         Storyboard1 �� TargetProperty �� 
TargetName<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value	   EasingFunction-  'System.Windows.Media.Animation.BackEase7  1System.Windows.Media.Animation.EasingFunctionBase
   
EasingMode/  )System.Windows.Media.Animation.CircleEase,   &ProjectMaster2016.projectmasterDataSet  projectmasterDataSet  projectViewSource �� Source �� Source �� 
TargetType �� Property �� Value��%�  &	        &	 7    &	 J    7  '_� w    �� 5   
   .��5      r� $ (FrameworkElement.Margin)�6/   $ grid1��6e   .	�5	        $ 0��6*   $ 
-900,0,0,0q�66   	 5
        5      $
 EaseOut=�6#   5        5      $ 0:0:0.5��6*   $ 0q�6<   	 5        5      $
 EaseOut=�6%   5      5      5        5   
   6%   �� 5   
    69   �� *	project+8   �� 5   
   " _�6   .�5      ��  � ��$	 300��6)   �� 5       � �� 5      �� 5      .R�5      �� #��z��6+    5      ���� 5   "   '��       " ��6(   .�5   &   ��  � ��$
 Wrap=�6E   5    #   5!      5"      5#      5%      5&      5'       � Triggers 5(      :� 5)   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5*      �� #��[  6   5+      .��5-      ]� ��. .+�5.   
   �� 
���   �$��0q�6%   $	��Top=�69   ._�50      � $��45��6   ���	#FFC5E9F7.+�51      �� -   5         ��Name$ lblName��51      $�� ��6)   $��0,0,11,0q�64   $	��Top=�6F   $��Right=�6_   �� 52      -   5         ��Name$ 	btnLogOut��52      $��Útskráning��6,   
������ 
������  � Cursor$
 Hand��6u   $��Right=�6�   $��	0,22,11,0q�6�   $	��Top=�6�   $��76��6�   $��Rockwell)�6�   $��12��6  �� 54      
���   �$��0,0,0,0q�6-   $��Right=�6G   $��50��6c   ._�55      � 56      �� 57      $��Mín síða��6   $��	468,2,0,0q�6+   $	��Top=�6>   $��24(�6V   $
��Bold"�6d   $
��Left=�6v   $	��143��6�   $��Rockwell Extra Bold)�6�   58      59      �� 5;   
   
���   �$��0,0,1,0q�6%   $	��115��6?   $
��Left=�6K   ._�5=      �� -   5         ��Name$ spLeft��5=      
������ $��1,0,-1,0q�6B   .+�5>      o� -   5         o�Name$
 Menu��5>      $��0,10,0,0q�6(   
������ 
������ $
��Left=�6m   $��25��6�   $��16(�6�   .@�5?      m� 
������ 
������ $��	Mín verk��6S   $��Rockwell)�6e   $��1��6{   .@�5@      m� -   5        
������ 
������ $��Stofna��5@   V   6f   5B      5C      o� 5D      $��0,10,0,0q�6   
������ $
��Left=�6C   $��25��6^   $��16(�6j   $��Rockwell)�6x   .@�5E      m� 
������ $��
Starfsmenn��68   $��2��6L   .@�5F      m� -   5         m�Name$ admin��5F   #   
������ $��Stofna��6K   6[   m� 5G      -   5        $ editEmployee��5G   #   
������ $��Breyta��6R   6b   m� 5H      -	   5        $ menu_Employee_List��5H   #   
������ $��Yfirlit��6X   6i   5I      5J      o� 5K      -
   5        $ admin1��5K      $��0,10,0,0q�6(   
������ $
��Left=�6S   $��25��6n   $��16(�6z   $��Rockwell)�6�   .@�5L      m� -   5        $ admin2��5L      
������ $��Stjórnandi��6H   $��0q�6\   $��3��6p   .@�5N      m� -   5        $ menu_projectsOverview��5N   #   $��Verkefni��6B   6T   �� 5O      6&   m� 5P      -   5        $ menu_projectMessages��5P   #   $��   - Skilaboð��6A   6X   m� 5Q      -   5        $ menu_projectCosts��5Q   #   $��   - Kostnaður��6>   6V   m� 5R      -   5        $ menu_projectHours��5R   #   $��   - Tímar��6>   6R   5T      5U      � 5V      .+�5W      �� $	��Top=�6   $��
ExtraBlack"�64   $��Eigin verkefni��6L   $��29��6e   $��	1,51,-9,0q�6r   $��Rockwell)�6�   �� 5X      $	��Top=�6   $
��Bold"�65   $��
Í vinnslu��6G   $��25��6[   $��5,81,0,0q�6g   $��Rockwell)�6y   �� 5Y      -   5        $ lblMPUnfinished��5Y      $	��Top=�66   $
��Bold"�6N   $��12��6`   $��25��6m   $��
65,81,10,0q�6y   $��Rockwell)�6�   �� 5Z      $	��Top=�6   $
��Bold"�66   $��Lokið��6H   $��25��6X   $��	5,101,0,0q�6d   $��Rockwell)�6w   �� 5[      -   5        $ lblMPFinished��5[      $	��Top=�63   $
��Bold"�6K   $��12��6]   $��25��6j   $��65,101,10,0q�6v   $��Rockwell)�6�   �� 5\      $	��Top=�6   $
��Bold"�65   $
��Alls��6G   $��25��6V   $��	5,121,0,0q�6b   $��Rockwell)�6u   �� 5]      -   5        $ 
lblMPTotal��5]      $	��Top=�60   $
��Bold"�6H   $��24��6Z   $��25��6g   $��65,121,10,0q�6s   $��Rockwell)�6�   �� 5_      $	��Top=�6   $��
ExtraBlack"�64   $��Önnur verkefni��6L   $��29��6e   $��
1,191,-9,0q�6r   �� 5`      $	��Top=�6   $
��Bold"�65   $��
Í vinnslu��6G   $��25��6[   $��	5,221,0,0q�6g   �� 5a      -   5        $ lblRPUnfinished��5a      $	��Top=�66   $
��Bold"�6N   $��12��6`   $��25��6m   $��65,221,10,0q�6y   $��Rockwell)�6�   �� 5b      $	��Top=�6   $
��Bold"�66   $��Lokið��6H   $��25��6X   $��5,241,0,-15q�6d   $��Rockwell)�6y   �� 5c      -   5        $ lblRPFinished��5c      $	��Top=�63   $
��Bold"�6K   $��12��6]   $��25��6j   $��65,241,10,-15q�6v   $��Rockwell)�6�   �� 5d      $	��Top=�6   $
��Bold"�65   $
��Alls��6G   $��25��6V   $��5,261,0,-35q�6b   $��Rockwell)�6w   �� 5e      -   5        $ 
lblRPTotal��5e      $	��Top=�60   $
��Bold"�6H   $��24��6Z   $��25��6g   $��65,261,10,-35q�6s   $��Rockwell)�6�   5f      5g      5h      �� 5i   
   
���   �$��0q�6%   $	��100��69   $��Right=�6E   ._�5j      � -   5         �Name$ grid2��5j      5k      � 5l   
   -   5        $ grid1��5l      $��0q�6    � DataContext# [ 6)    � ColumnDefinitions 5m      �� 5n      $	��22* �6#   �� 5o      $
��421* �6#   .+�5q      &   System.Windows.Controls.DataGrid  -   5          Name$ projectDataGrid��5q      $��Rockwell)�60    �� SelectedValuePath$	 pid��6F      AutoGenerateColumns .  $��7,116,10,31q�6z   $��0q�6�   
������    EnableRowVirtualization .    RowDetailsVisibilityMode$ VisibleWhenSelected=�6�       
IsReadOnly  . !   VerticalGridLinesBrush! �	#FFC5E9F7"   HorizontalGridLinesBrush" �	#FFC5E9F7$��1��6�  ��. ��6�   �� #   Columns# 5s      0  *System.Windows.Controls.DataGridTextColumn  5t      -   5        createdColumn��,  &System.Windows.Controls.DataGridColumn$   Header$$ Stofn. dags.��5t   }   %   
IsReadOnly% . &   Width5	  /System.Windows.Controls.DataGridLengthConverter$& SizeToHeader	 6�   1
  +System.Windows.Controls.DataGridBoundColumn' 
  Binding' 6@   �� *pdate+( �� StringFormat$( {0:dd. MM yyyy}��6�     5u      -   5        	pidColumn��$	$ Nr.��5u   T   % . $& SizeToHeader	 6s   ' 6<   �� *pid+6s     5v      -   5        projectnameColumn��$$ Titill��5v   d   $& *	 6t   ' 6D   �� *projectname+) 
  ElementStyle) 5w      �� 5x      " ��6$   .�5y   "   ��  � ��$ CharacterEllipsis=�6A   �� 5z   "    �@�ToolTip 6<   �� *Text+* �� RelativeSource* �� *Self+6{   5{      5}        5~      -   5        employee_eidColumn��$$ employee eid��5~   f   +   
Visibility$+ 	Collapsed=�6|   $& SizeToHeader	 6�   ' 6E   �� *employee_eid+6�     5      -   5        pdescriptionColumn��$$ Verkefnalýsing��5   F   $& 2*	 6�   ' 6^   �� *pdescription+) 5�      �� 5�      " ��6$   .�5�   "   ��  � ��$ CharacterEllipsis=�6A   �� 5�   "    �@�ToolTip 6<   �� *Text+* �� *Self+6{   5�      5�      4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      -   5        projectisfinishedColumn��$+ Visible=�5�   t   $$ Lokið��6�   $& SizeToHeader	 6�   ' 6N   �� *projectisfinished+6�     5�      -   5        pdeadlineColumn��$& SizeToHeader	 5�   B   $$ Lok fyrir dags.��6W   ' 6p   �� *	pdeadline+$( {0:d. MMMM yyyy}��4  .System.Windows.Controls.DataGridTemplateColumn  5�      -    5        pdateColumn��$$ pdate��5�   B   $+ 	Collapsed=�6Q   $& SizeToHeader	 6h   ,   CellTemplate, 5�      �� 5�      .R�5�   "   (  "System.Windows.Controls.DatePicker  -   SelectedDate- 6-   �� *pdate+. �� Mode$. TwoWay=�/ �� NotifyOnValidationError/ . 0 �� ValidatesOnExceptions0 . 5�      5�      5�      �� 5�      -!   5        $ btnMyProjects��5�      $��Eigin verkefni��6,   $
��Left=�6E   ���	#FFF9F3F3$��1q�6x   
������ $��
155,10,0,0q�6�   $	��Top=�6�   $	��198��6�   $��51��6�   $��Rockwell Condensed)�6�   $��36(�6
  $��1��6�  $��4��6�  �� 5�      -"   5        $ btnMPAll��5�      $
��Allt��6'   $
��Left=�66   ���	#FFF9F3F3$��1q�6i   
������ $��
298,70,0,0q�6�   $	��Top=�6�   $��55��6�   $��25��6�   $��Rockwell Condensed)�6�   $��16(�6�   $��1��6  $��5��6/  �� 5�      -#   5        $ btnMPUnfinished��5�      $��
Í vinnslu��6.   $
��Left=�6B   ���	#FFF9F3F3$��1q�6u   
������ $��
155,70,0,0q�6�   $	��Top=�6�   $��55��6�   $��25��6�   $��Rockwell Condensed)�6�   $��16(�6  $��1��62  $��6��6B  �� 5�      -$   5        $ btnMPFininshed��5�      $��Lokið��6-   $
��Left=�6=   ���	#FFF9F3F3$��1q�6p   
������ $��
227,70,0,0q�6�   $	��Top=�6�   $��55��6�   $��25��6�   $��Rockwell Condensed)�6�   $��16(�6  $��1��6.  $��7��6>  �� 5�      -%   5        $ btnRelateProjects��5�      $��Önnur verkefni��60   $
��Left=�6I   ���	#FFF9F3F3$��1q�6|   
������ $��
432,14,0,0q�6�   $	��Top=�6�   $	��198��6�   $��51��6�   $��Rockwell Condensed)�6�   $��36(�6  $��1��6�  $��8��6�  �� 5�      -&   5        $ btnRPAll��5�      $
��Allt��6'   $
��Left=�66   ���	#FFF9F3F3$��1q�6i   
������ $��
575,70,0,0q�6�   $	��Top=�6�   $��55                     ��6�   $��25��6�   $��Rockwell Condensed)�6�   $��16(�6  $��1��64  $��9��6D  �� 5�      -'   5        $ btnRPUnfinished��5�      $��
Í vinnslu��6.   $
��Left=�6B   ���	#FFF9F3F3$��1q�6u   
������ $��
432,70,0,0q�6�   $	��Top=�6�   $��55��6�   $��25��6�   $��Rockwell Condensed)�6�   $��16(�6  $��1��62  $��10��6B  �� 5�      -(   5        $ btnRPFininshed��5�      $��Lokið��6-   $
��Left=�6=   ���	#FFF9F3F3$��1q�6p   
������ $��
504,70,0,0q�6�   $	��Top=�6�   $��55��6�   $��25��6�   $��Rockwell Condensed)�6�   $��16(�6  $��1��6,  $��11��6<  5�      5�      5�      