   M S B A M L   `   `   `  ����D  @Aplikacja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Aplikacja.OknaAplikacja.Okna  5   	       Aplikacja.Okna.Ksiazki   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Aplikacja.Okna     5   	     � Title$  Ksiazki��5   	   $	��450��6   $	��800��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      $��80 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5   
    � $��0��6   $��0��6   $��2��6-   ���	#FF6C83CE6>   �� 5   
   $��	Książki��6   $��Center=�6"   $��Center=�6D   $��40(�6h   
�������6v   �� 5   
   $��1��6   $��0��6"   $��Center=�62   .+�5      �� -   5        $��Dodaj��5      $��5q�6%   $��Bahnschrift SemiLight)�61   $��20(�6T   
�������$
��0 10q�6u   $��0q�6�   ���	#FF4CC35C6�   �� 5      -   5        $��Edytuj��5      $��5q�6&   $��Bahnschrift SemiLight)�62   $��20(�6U   
�������$
��0 10q�6v   $��0q�6�   ���	#FF25C9C96�   �� 5      -   5        $��Usuń��5      $��5q�6$   $��Bahnschrift SemiLight)�60   $��20(�6S   
�������$
��0 10q�6t   $��0q�6�   ���	#FFEE4A4A6�   5      �� 5   
   -   5         ��Name$ 
ksiazkiLst��5      $��0��6'   $��1��64   $��2��6D   $��Stretch=�6U    �� View 5      �� 5       P�5!      �� 5"      $
��ISBN��6)    �� DisplayMemberBinding 67   �� *Isbn+�� 5#      $��Tytuł��6)    68   �� *Tytul+�� 5$      $��Autor��6)    68   �� *Autor+�� 5%      $��Gatunek��6)    6:   �� *	Gatunek+�� 5&      $��Rok wydania��6)    6>   �� *
RokWydania+�� 5'      $��Wydawnictwo��6)    6>   �� *Wydawnictwo.Nazwa+�� 5(      $��Liczba ogółem��6)    6@   �� *LiczbaOgolem+�� 5)      $��Liczba dostępnych��6)    6D   �� *LiczbaDostepnych+5+      5-      5.      5/      