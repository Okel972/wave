   M S B A M L   `   `   `  ����?  ;Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Wave.View	Wave.View  5   	   !    Wave.View.GestionDesOeuvres   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Wave.View     5   	     � Title$  GestionDesOeuvres��5   	   $	��500��6#   $	��800��60   .��5	      �  � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��140 �6   �� 5      .+�5   
   �� $��0��6   $��0��6!   $��Liste de Chansons :��61   $	��Top=�6L   $��9,8,0,0q�6d   $��Italic$�6u   $��14(�6�   $��Comic Sans MS)�6�   �� 5   
   -   5         ��Name$ ChansonList��5      $��0��6(   $��1��65   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��5q�6;   ��6$   �� *Titre+6;   �� 5      $��5q�6=   ��6$   �� *	Artiste+6=   �� 5       $��5q�6;   ��6$   �� *Album+6;   �� 5!      $��5q�6C   ��6$   �� *AnneeDeSortie+6C   �� 5"      $��5q�6E   ��6$   �� *DureeEnSecondes+6E   �� 5#      $��5q�6G   ��6$   �� *IdentifiantUnique+6G   5$      5%      5'      �� 5,   
   $��2��6   $��0��6"   $ Vertical=�62   .+�5-      �� -   5         ��Name$ AddSong��5-      $��10q�6&   $��Ajouter une chanson��62   $	��120��6P   $��30��6\   $	��Top=�6~   $
��Left=�6�   �� 5.      -   5        $ 
ModifySong��5.      $��10q�6)   $��Modifier une chanson��65   $	��120��6T   $��30��6`   $	��Top=�6�   $
��Left=�6�   �� 5/      -   5        $ 
DeleteSong��5/      $��10q�6)   $��Suppr une chanson��65   $	��120��6Q   $��30��6]   $	��Top=�6�   $
��Left=�6�   �� 50      -   5        $ SongsToGroups��50      $��10q�6,   $��Songs to Groups��68   $	��120��6R   $��30��6^   $	��Top=�6j   $
��Left=�6�   6�   51      �� 53   
   -   5        $ 
ClearClick��53      $��1��6%   $��1��65   $��Clear��6B   $
��Left=�6R   $��601,127,0,0q�6m   $	��Top=�6�   6�   � 56   
   -   5         �Name$ ListAdd��56      $��1��6    $��1��6-   $��10q�6=    57      �� 58      $��0.25* �6#   �� 59      $��1* �6#    5<      �� 5=      $
��Auto �6    �� 5>      $
��Auto �6    �� 5?      $
��Auto �6    �� 5@      $
��Auto �6    �� 5A      $
��Auto �6    �� 5B      $
��Auto �6    .+�5E      �� $��0��6   $��0��6%   $��Titre :��65   $��Center=�6D   �� 5F      -   5         ��Name$ 
InputTitle��5F      $��0��6*   $��1��67   $
��10,0q�6G   �� 5H      $��1��6   $��0��6%   $��	Artiste :��65   $��Center=�6F   �� 5I      -	   5        $ InputArtist��5I      $��1��6+   $��1��68   $
��10,0q�6H   �� 5K      $��2��6   $��0��6%   $��Album :��65   $��Center=�6D   �� 5L      -
   5        $ 
InputAlbum��5L      $��2��6*   $��1��67   $
��10,0q�6G   �� 5N      $��3��6   $��0��6%   $��Année de sortie :��65   $��Center=�6N   �� 5O      -   5        $ InputOut��5O      $��3��6(   $��1��65   $
��10,0q�6E   �� 5Q      $��4��6   $��0��6%   $��Durée en sec :��65   $��Center=�6K   �� 5R      -   5        $ 	InputTime��5R      $��4��6)   $��1��66   $
��10,0q�6F   �� 5T      $��5��6   $��0��6%   $��Identifiant unique :��65   $��Center=�6Q   �� 5U      -   5        $ InputId��5U      $��5��6'   $��1��64   $
��10,0q�6D   5V      5Y      5[      