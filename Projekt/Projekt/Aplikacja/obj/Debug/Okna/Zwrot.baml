   M S B A M L   `   `   `  ����D  @Aplikacja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Aplikacja.OknaAplikacja.Okna  5   	       Aplikacja.Okna.Zwrot   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Aplikacja.Okna     5   	     � Title$  Zwrot��5   	   $	��450��6   $	��800��6$   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6"   .+�5      �� $
��ISBN��6   $��30��6#   $��Bahnschrift SemiLight)�6/   $��Right=�6R   ���	#FFD9E3E3$��0,15,0,0q�6�   $��15(�6�   �� 5      $��ID czytelnika��6   $��30��6,   $��Bahnschrift SemiLight)�68   $��Right=�6[   ���	#FFD9E3E3$��0,15,0,0q�6�   $��15(�6�   5      �� 5   
   $��0��6   $��1��6"   .+�5      �� -   5         ��Name$ isbnTxt��5      $��30��6'   $��Bahnschrift SemiLight)�63   $
��Left=�6V   $��Center=�6x   
�������$��0,15,0,0q�6�   $��13(�6�   6�   �� 5      -   5        $ czytTxt��5      $��30��6'   $��Bahnschrift SemiLight)�63   $
��Left=�6V   $��Center=�6x   
�������$��0,15,0,0q�6�   $��13(�6�   6�   5      �� 5   
   $��0��6   $��2��6"   �� 5    
   $��0��6   $��3��6"   .+�5!      �� -   5        $��0��5!      $��2��6"   $��30��62   $	��Top=�6>   $��Wybierz z listy��6V   $��0,15,0,0q�6p   ���	#FF25C9C9
�������$��Bahnschrift SemiLight)�6�   $��17(�6�   6�   �� 5"      -   5        $��0��5"      $��2��6"   $��30��62   $	��Top=�6>   $��Wybierz z listy��6V   $��0,15,0,0q�6p   ���	#FF25C9C9
�������$��Bahnschrift SemiLight)�6�   $��17(�6�   6�   5#      �� 5$   
   -   5        $��2��5$      $��4��6   $��30��62   $	��Top=�6>   $��Zwróć��6V   $��0,15,0,0q�6f   ���	#FFEFFF40
���   �$��Bahnschrift SemiLight)�6�   $��17(�6�   6�   �� 5%   
   -   5         ��Name$ wypozyczeniaLst��5%      $��1��6,   $��4��69   $��Stretch=�6M    �� View 5&      �� 5'      P�5(      �� 5)      $
��ISBN��6)    �� DisplayMemberBinding 67   �� *Ksiazka.Isbn+�� 5*      $��Tytuł��6)    68   �� *Ksiazka.Tytul+�� 5+      $��Autor��6)    68   �� *Ksiazka.Autor+�� 5,      $��	Czytelnik��6)    6<   �� *Czytelnik.Id+�� 5-      $��Data wypożyczenia��6)    6D   �� *DataWypozyczenia+ �� StringFormat$ {0:dd-MM-yyyy}��5/      51      52      53      