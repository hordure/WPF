   M S B A M L   `   `   `  ����L  HProjectMaster2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMaster2016ProjectMaster2016  5   	   0    *ProjectMaster2016.EditProjectMessageWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:ProjectMaster2016     5   	   -   5          � Title$  Breyta skilaboðum��5   	   $	��400��6#   $	��650��60    � WindowStartupLocation$ CenterScreen=�6S    � 	Resources 5      ,   &ProjectMaster2016.projectmasterDataSet   projectmasterDataSet  project_messagesViewSource �� Source �� Source��%a   &	        &	      7     5   
   6%   �� 5   
    6B   �� *project_messages+8   5	      .��5
      � $��	0,0,-8,-1q�6    � DataContext# [ 6   .+�5   
   �� $��	Verkefni:��6   $
��Left=�6$   $��	49,39,0,0q�6?   $	��Top=�6R   $��87��6j   �� 5   
   $��Starfsmaður:��6   $
��Left=�6'   $��	49,79,0,0q�6B   $	��Top=�6U   �� 5   
   $��
Skilaboð:��6   $
��Left=�6$   $��
49,119,0,0q�6?   $	��Top=�6S   �� 5   
   $��Skilaboð dags.:��6   $
��Left=�6*   $��
49,290,0,0q�6E   $	��Top=�6Y   �� 5   
   -   5         ��Name$# lblEditProjectMessage_Project��5   2   $	��320��6Y   $
��Left=�6e   $��
222,39,0,0q�6�   $	��Top=�6�   ��6   �� */ projectname+6�   �� 5   
   -   5        $$ lblEditProjectMessage_Employee��5   +   $
��Left=�6S   $��
222,79,0,0q�6n   $	��320��6�   $	��Top=�6�   ��6   �� */ name+6�   �� 5   
   -   5         ��Name$ 
txtMessage��5   5   $	��150��6I    �� TextWrapping$
 Wrap=�6V   $
��Left=�6j   $��222,119,0,0q�6�   $	��Top=�6�   	 J� RenderTransformOrigin$	 0.237,-0.192&�6�   $	��360��6�   $��3��6�   ��6   �� */ projectmessage+6�   �� 5   
   -   5        $ lblCreateDate��5   7   
 �� ContentStringFormat$
 
dd.MM.yyyy��6N   $
��Left=�6o   $��222,290,0,0q�6�   $	��Top=�6�   $	 0.5,0.3&�6�   ��6   �� */ messagetimestamp+6�   �� 5   
   -   5         ��Name$" btnEditProjectMessageProject��5      $��
557,39,0,0q�67   ���	#FFF9F3F3$��2q�6c   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��28��6�   $��1��6  .��5      �� $��../../images/wrench.png��6   $��20��66   $
��Fill=�6B   $��21��6Q   5      �� 5   
   -   5        $# btnEditProjectMessageEmployee��5      $��
557,79,0,0q�68   ���	#FFF9F3F3$��2q�6d   
������ $��30��6�   $	��Top=�6�   $
��Left=�6�   $��30��6�   $��2��6	  .��5      �� $��../../images/wrench.png��6   $��20��66   $
��Fill=�6B   $��21��6Q   5      �� 5   
   -   5        $ btnUptadeProjectMessage��5   !   $��Vista��6   $
��Left=�6B   $��389,326,0,0q�6]   $	��Top=�6r   $��75��6�   $��4��6�   �� 5   
   -	   5        $ lblpid��5   *   $y�Hidden=�6:   $
��Left=�6N   $��
162,80,0,0q�6i   $	��Top=�6}   ��6   �� */ pid+6}   �� 5   
   -
   5        $ lbleid��5   *   $y�Hidden=�6:   $
��Left=�6N   $��169,126,0,0q�6i   $	��Top=�6~   ��6   �� */ eid+6~   �� 5   
   -   5        $ 	btnCancel��5      $��Hætta við��6$   $
��Left=�68   $��507,326,0,0q�6S   $	��Top=�6h   $��75��6�   $��5��6�   6�   5      5      