   M S B A M L   `   `   `  ����J  FSemanticNetwork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SemanticNetworkSemanticNetwork  5   	        SemanticNetwork.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:SemanticNetwork     5   	   -   5          � Title$  ¯\_(ツ)_/¯��5   	   $��446.042��6   $��565.014��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ btnShowEditWindow��5
      $��Edit knowlege base��6,   $��	10,0,0,52q�6I   $��20��6|   $��Bottom=�6�   $
��Left=�6�   $	��121��6�   �� 5   
   -   5         ��Name$ lvMain��5      $��10,10,10,77q�6#    �� View 5      �� 5      .P�5      ��  �� Width$
 Auto��6%   $��Id��62    �� DisplayMemberBinding 6>   ��  �� Path$ Id��� 5      $
 Auto��6%   $��Childs��62    6B   �� $ Childs��� 5      $
 Auto��6%   $��Parents��62    6C   �� $ Parents��� 5      $
 Auto��6%   $��Variants��62    6D   �� $ Variants�5      5      �� 5   
   -   5         ��Name$ tbData��5      $��136,0,10,52q�6"    �� TextWrapping$
 Wrap=�67   $9��3Невыносимо хочется пить чай��6K   $��20��6n   $��Bottom=�6z   �� 5   
   -   5        $ 
tbQuestion��5      $��136,0,90,27q�6&   $
 Wrap=�6;   $#��Чего не хватает?��6O   $��20��6g   $��Bottom=�6s   �� 5   
   -   5        $ 	btnSearch��5      $��Search��6$   $��	0,0,10,27q�65   $��Right=�6`   $��75��6|   $��20��6�   $��Bottom=�6�   5      5      