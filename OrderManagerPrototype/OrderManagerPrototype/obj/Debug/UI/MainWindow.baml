   M S B A M L   `   `   `  ����  OrderManagerPrototype&     OrderManagerPrototype.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  OrderManager��5   	    � Title$ OrderManager��5   	   $	��629��6   $
��1042��6+   .��5      � -   5         �Name$ MainGrid��5      $��0,0,2,5q�6    � ColumnDefinitions 5   
   �� 5      $
��236* �6   �� 5      $
��279* �6   �� 5	      $��0* �6   �� 5
      �� 5      $��0* �6    � RowDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   R� -   5         R�Name$ 	InboxView��5      $
��Left=�6&   $��0,98,0,0q�6A   $��Stretch=�6S   $	��500��6o   $��2��6�   5      R� 5   
   -   5        $ ServicedView��5      $��Right=�6)   $��0,98,0,0q�6E   $��Stretch=�6W   $	��500��6s   $��1��6   (� 5   
   -   5         (�Name$ InboxViewbox��5      $
��Left=�6(   $��98��6C   $��10,0,0,0q�6O   $	��Top=�6a   $	��206��6y   .��5      �� -   5         ��Name$ 
InboxLabel��5      $��inbox��6(   $
��Left=�68   $	��Top=�6S   $��43.28��6k   $��69.153��6z   $��24(�6�   5      (� 5   
   -   5        $ ServicedViewbox��5      $��Right=�6+   $��98��6G   $��0,0,50,0q�6S   $	��Top=�6e   $	��228��6}   $��1��6�   .��5      �� -   5        $ ServicedLabel��5      $��accepted��6+   $
��Left=�6>   $	��Top=�6Y   $��43��6q   $	��104��6}   $��24(�6�   5      �� 5   
   -	   5        $ InboxCounter��5      $��0��6&   $
��Left=�62   $��
162,53,0,0q�6M   $	��Top=�6a    J� RenderTransformOrigin$ 37.522,0.77&�6y   $��24(�6�   �� 5   
   -
   5        $ ServicedCounter��5      $��0��6)   $��Right=�65   $��	0,53,40,0q�6Q   $	��Top=�6d   $ 37.522,0.77&�6|   $��24(�6�   $��1��6�   5      5      