   M S B A M L   `   `   `  ����F  BNapier Bank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Napier_BankNapier_Bank  5   	       Napier_Bank.Output   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Napier_Bank     5   	     � Title$  Output��5   	   $	��500��6   $	��600��6%   .��5	      � $��0,0,2,0q�6    � ColumnDefinitions 5
   
   .+�5   
   �� -   5         ��Name$ txtBody��5      $
��Left=�6#   $	��177��6>   $��
28,123,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��234��6�    �� 
IsReadOnly . 6�   �� 5   
   -   5         ��Name$ 	lblSender��5      $��Sender:��6#   $
��Left=�65   $��	28,25,0,0q�6P   $	��Top=�6c   �� 5   
   -   5        $ 	txtSender��5      $
��Left=�6%   $��23��6@   $��	28,56,0,0q�6L   $
 Wrap=�6_   $	��Top=�6s   $	��234��6�    . 6�   �� 5   
   -   5        $ txtID��5      $
��Left=�6!   $��23��6<   $��
277,56,0,0q�6H   $
 Wrap=�6\   $	��Top=�6p   $	��120��6�    . 6�   �� 5   
   -   5        $ lblID��5      $��
Message ID��6   $
��Left=�64   $��
277,25,0,0q�6O   $	��Top=�6c   �� 5   
   -   5        $ lblBody��5      $��Body:��6!   $
��Left=�61   $��	28,97,0,0q�6L   $	��Top=�6_   �� 5   
   -   5         ��Name$ lstMentions��5      $
��Left=�6'   $	��177��6B   $��367,123,0,0q�6O   $	��Top=�6d   $��85��6|   �� 5   
   -   5        $ lstTrending��5      $
��Left=�6'   $	��177��6B   $��277,123,0,0q�6O   $	��Top=�6d   $��85��6|   �� 5   
   -	   5        $ lstSIR��5      $
��Left=�6"   $	��177��6=   $��457,123,0,0q�6J   $	��Top=�6_   $��85��6w   $��2��6�   5      5      