   M S B A M L   `   `   `  ����I  EPartnerMatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PartnerMatcher.ViewPartnerMatcher.View  5   	       PartnerMatcher.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   3local!clr-namespace:PartnerMatcher.View     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  PartnerMatcher��5   	   $	��400��5   	   $	��230��5	   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� ImageSource$ ../Graphics/Green_BG.jpg��6   .��5      �� 
���   �$��4q�6!   ._�5   
   � $��	2,-6,-2,6q�6   .+�5      �� -   5         ��Name$ 
exitButton��5      $��-152,162,186,-6q�5      $
��Exit��5      $��25(�5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ���� 67   �� 5       � ��$ Normal"�67   �� 5       � ��
 �  ��67   �� 5       � �� 5      �� 5   "    �� 
TargetType" ��62   .R�5   &   �� #��z��6-   ._�5    *   �� $��Center=�6;   $��Center=�6X   5!   '   5"   #   5$      	 �� Triggers	 5%      P� 5&      
 P� Property
 �@J�IsMouseOver P� Value . . �5'   "   ��  � ��$
 Bold"�6?   �� 5(   "    � ��
 �  ��6?   5)      5+      5-      �� 5/      $	��390��6   $��-2,-2,-2,147q�50      $��Center=�51      $��Bottom=�52      $��36(�53      $��	ExtraBold"�54      
��� ���$��PartnerMatcher��56       �� TextAlignment$ Center=�57      $��	Underline{�58      �� 59      $	��394��6   $��
-4,33,-4,0q�5:      $��Center=�5;      $	��Top=�5<      $��14(�5=      $
��Bold"�5>      
�������$3��-Analysis & Design of Information Systems 2016��5@      $ Center=�5A      �� 5C      -   5        $ userLogin_Btn��5C      $	��113��5D      $��42��5E      $��	51,69,0,0q�5F      $
��Left=�5G      $	��Top=�5H      ���	#FF0C00FF$��2q�5J      $��Login��5L      $��25(�5M      $
��Bold"�5N       J� RenderTransformOrigin$ -0.4,0&�5O      �� 5P      -   5        $ 
addUserbtn��5P      $	��113��5Q      $��42��5R      $��
194,68,0,0q�5S      $
��Left=�5T      $	��Top=�5U      ���	#FF0C00FF$��2q�5W      $��Register��5Y      $��25(�5Z      $
��Bold"�5[      $ -0.4,0&�5\      �� 5^      -   5         ��Name$ checkConnection��5^      $��35��5_      $��218,167,0,-9q�5`      $
��Left=�5a      $	��Top=�5b      $�� ��5c      ���	#FFAEFF005d      �� 5e      -   5        $ 
search_Btn��5e      $	��180��5f      $��35��5g      $��
92,122,0,0q�5h      $
��Left=�5i      $	��Top=�5j      ���	#FF0C00FF$��2q�5l      $��Search without login��5n      $��15(�5o      $
��Bold"�5p      $ -0.4,0&�5q      5r      5s      5t      