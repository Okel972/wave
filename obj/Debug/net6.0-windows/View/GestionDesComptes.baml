   M S B A M L   `   `   `  ����?  ;Wave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Wave.View	Wave.View  5   	   !    Wave.View.GestionDesComptes   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Wave.View     5   	     � Title$  GestionDesComptes��5   	   $	��450��6#   $	��800��60   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Comptes utilisateurs��6   $��10q�6/   $
��Bold"�6;   $��16(�6M   �� 5   
   -   5         ��Name$ cmbComptesUtilisateurs��5      $��1��63   $��10q�6@    �� SelectedItem 6L   ��  �� Path$ CompteSelectionne� �� Mode$ TwoWay=���5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $
��Bold"�6I   ��6$   �� $ NomUtilisateur�6I   5      5      5      � 5   
   $��2��6   $��10q�6    5      �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    .+�5%      �� $��Nom d'utilisateur :��6   $��0��62   $��Center=�6?   �� 5&      -   5         ��Name$ txtNomUtilisateur��5&      $��0��61   $��10q�6>   $	��200��6J   �� 5(      $��Mot de passe :��6   $��1��6-   $��Center=�6:   G� 5)      -   5         G�Name$ txtMotDePasse��5)      $��1��61   $��10q�6>   $	��200��6J   �� 5+      $ 
Horizontal=�6   $��2��62   $��Right=�6?   $��10q�6[   .+�5,      �� -   5        	 ��Name$	 btnCreerCompte��5,      $��Créer��61   $��5q�6A   6L   �� 5-      -   5        $	 btnModifierCompte��5-      $��Modifier��64   $��5q�6G   6R   �� 5.      -   5        $	 btnSupprimerCompte��5.      $��	Supprimer��65   $��5q�6I   6T   �� 5/      $��Rôle :��6   $��2��6)   $��Center=�66   �� 50      -   5        $ cmbRole��50      $��2��6,   $��10q�69    6E   �� $
 Role�$ TwoWay=�55      56      57      �� 59   
   $
��Aide��6   $��3��6   $��10q�6,   $
��Bold"�68   $��16(�6J   �� 5;   
   $I��CSélectionnez un compte utilisateur pour afficher ses informations.��6   $��4��6^   $��10q�6k   �� 5=   
   -   5        $	 
ClearClick��5=      $��Clear��6%   $
��Left=�65   $��
15,105,0,0q�6P   $��2��6d   $	��Top=�6q   
 J� RenderTransformOrigin$
 -0.311,0.708&�6�   $��30��6�   $��50��6�   5>      5?      