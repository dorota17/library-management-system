   M S B A M L   `   `   `  ����D  @Aplikacja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Aplikacja.OknaAplikacja.Okna  5   	       Aplikacja.Okna.Wypozycz   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Aplikacja.Okna     5   	     � Title$  Wypozyczenie��5   	   $	��310��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6"   .+�5      �� $
��ISBN��6   $��30��6#   $��Bahnschrift SemiLight)�6/   $��Right=�6R   ���	#FFD9E3E3$��0,15,0,0q�6�   $��15(�6�   �� 5      $��Liczba dostępnych��6   $��30��60   $��Bahnschrift SemiLight)�6<   $��Right=�6_   ���	#FFD9E3E3$��0,15,0,0q�6�   $��15(�6�   �� 5      $��ID czytelnika��6   $��30��6,   $��Bahnschrift SemiLight)�68   $��Right=�6[   ���	#FFD9E3E3$��0,15,0,0q�6�   $��15(�6�   5      �� 5   
   $��0��6   $��1��6"   .+�5      �� -   5         ��Name$ isbnTxt��5      $��30��6'   $��Bahnschrift SemiLight)�63   $
��Left=�6V   $��Center=�6x   
�������$��0,15,0,0q�6�   $��13(�6�   6�   �� 5      -   5        $ 	liczbaTxt��5      $��30��6)   $��Bahnschrift SemiLight)�65   $
��Left=�6X   $��Center=�6z   
�������$��0,15,0,0q�6�   $��13(�6�    �� 
IsReadOnly . 6�   �� 5      -   5        $ czytTxt��5      $��30��6'   $��Bahnschrift SemiLight)�63   $
��Left=�6V   $��Center=�6x   
�������$��0,15,0,0q�6�   $��13(�6�   5      �� 5    
   $��0��6   $��2��6"   .+�5!      �� $��0��6   $��2��6"   $��30��62   $	��Top=�6>   $��
Zatwierdź��6V   $��0,15,0,0q�6j   ���	#FF4CC35C
�������$��Bahnschrift SemiLight)�6�   $��17(�6�   �� 5"      $��0��6   $��2��6%   $��30��65   $	��Top=�6A   $��0,15,0,0q�6Y   �� 5#      $��0��6   $��2��6"   $��30��62   $	��Top=�6>   $��
Zatwierdź��6V   $��0,15,0,0q�6j   ���	#FF4CC35C
�������$��Bahnschrift SemiLight)�6�   $��17(�6�   5$      �� 5%   
   $��0��6   $��3��6"   .+�5&      �� -   5        $��0��5&      $��2��6"   $��30��62   $	��Top=�6>   $��Wybierz z listy��6V   $��0,15,0,0q�6p   ���	#FF25C9C9
�������$��Bahnschrift SemiLight)�6�   $��17(�6�   6�   �� 5'      $��0��6   $��2��6%   $��30��65   $	��Top=�6A   $��0,15,0,0q�6Y   �� 5(      -   5        $��0��5(      $��2��6"   $��30��62   $	��Top=�6>   $��Wybierz z listy��6V   $��0,15,0,0q�6p   ���	#FF25C9C9
�������$��Bahnschrift SemiLight)�6�   $��17(�6�   6�   5*      �� 5+   
   -   5        $��1��5+      $��4��6   $��30��62   $	��Top=�6>   $��	Wypożycz��6V   $��0,15,0,0q�6i   ���	#FFEFFF40
���   �$��Bahnschrift SemiLight)�6�   $��17(�6�   6�   5/      50      