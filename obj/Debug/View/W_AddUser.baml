   M S B A M L   `   `   `  ����I  EPartnerMatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PartnerMatcher.ViewPartnerMatcher.View  5   	   #    PartnerMatcher.View.W_AddUser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   3local!clr-namespace:PartnerMatcher.View     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Add a new user��5   	   $	��600��5   	   $	��550��5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� ImageSource$ ../Graphics/Green_BG.jpg��6   .��5      �� 
���   �$��4q�6!   ._�5   
   � $��0,0,0,0q�6   .+�5      �� -   5         ��Name$ actions_groupbox��5      $	��334��5      $��57��5      $��126,369,0,0q�5      $
��Left=�5      $	��Top=�5      $
��Bold"�5      ���	#FFF5DC64$��Actions��5      �� 5      $	��590��6   $��	-4,2,-2,0q�5      $��Center=�5      $	��Top=�5      $��24(�5      $
��Bold"�5      
�������$��Insert New User Details��5!       �� TextAlignment$ Center=�5"      ��5#      Z� �� 5$      -   5         ��Name$ 
exitButton��5$      $	��584��5%      $��	0,426,0,0q�5&      $
��Left=�5'      $	��Top=�5(      $
��Back��5*      $��30(�5+      ��5,      �� 5-       �� 
TargetType" ��6   .�5.      ��  �� Property � ��	 �� Value
	 ���� 67   �� 5/       � ��$	 Normal"�67   �� 50       � ��
	 �  ��67   �� 51       � ��	 52      �� 53   "   
 �� 
TargetType"
 ��62   .R�54   &   �� #��z��6-   ._�55   *   �� $��Center=�6;   $��Center=�6X   56   '   57   #   59       �� Triggers 5:      P� 5;       P� Property �@J�IsMouseOver P� Value . . �5<   "   ��  � ��$
	 Bold"�6?   �� 5=   "    � ��
	 �  ��6?   5>      5@      5B      �� 5D      -   5         ��Name$ checkConnection��5D      $��366,441,0,0q�5E      $
��Left=�5F      $	��Top=�5G      $�� ��5H      ���	#FFAEFF005I      �� 5J      -   5        $ userDetailsGroupBox��5J      $	��334��5K      $	��323��5L      $��
126,41,0,0q�5M      $
��Left=�5N      $	��Top=�5O      ���	#FF8AB3CB$
��Bold"�5Q      ���	#FFF5DC64$��User Details��5S      .��5T      �� -   5         ��Name$ firstName_txt��5T      $	��165��5U      $��23��5V      $��
139,10,0,0q�5W      $
��Left=�5X      $	��Top=�5Y      $��Center=�5Z       �� TextWrapping$
 Wrap=�5\      5]      �� 5^      -   5        $ firstName_lbl��5^      $��
141,63,0,0q�5_      $
��Left=�5`      $	��Top=�5a      $��
First Name��5b      $��16(�5c      ���	#FFF0DC5A5d      �� 5e      -   5        $ 
gender_lbl��5e      $��141,190,0,0q�5f      $
��Left=�5g      $	��Top=�5h      $��Gender��5i      $��16(�5j      ���	#FFF0DC5A5k      �� 5l      -   5        $ birthDate_lbl��5l      $��141,219,0,0q�5m      $
��Left=�5n      $	��Top=�5o      $��
Birth Date��5p      $��16(�5q      ���	#FFF0DC5A5r      �� 5s      -	   5        $ phoneNumber_lbl��5s      $��141,250,0,0q�5t      $
��Left=�5u      $	��Top=�5v      $��Phone Number��5w      $��16(�5x      ���	#FFF0DC5A5y      �� 5z      -
   5        $ address_lbl��5z      $��141,280,0,0q�5{      $
��Left=�5|      $	��Top=�5}      $��Address��5~      $��16(�5      ���	#FFF0DC5A5�      �� 5�      -   5        $ password_lbl��5�      $��141,157,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Password��5�      $��16(�5�      ���	#FFF0DC5A5�      �� 5�      -   5        $ phoneNumber_txt��5�      $	��165��5�      $��23��5�      $��271,254,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Center=�5�      $
 Wrap=�5�      �� 5�      -   5        $ address_txt��5�      $	��165��5�      $��23��5�      $��271,284,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Center=�5�      $
 Wrap=�5�      (  "System.Windows.Controls.DatePicker  5�      -   5          Name$ date_btn��5�      $	��165��5�      $��271,222,0,0q�5�      $
��Left=�5�      $	��Top=�5�         DisplayDate$ 
1990-01-07��5�         SelectedDateFormat$ Short=�5�      �� 5�      -   5         ��Name$ 
gender_box��5�      $	��165��5�      $��271,194,0,0q�5�      $
��Left=�5�      $	��Top=�5�      .@�5�      �� $��Select Gender��6    �� 
IsSelected . 67   �� 5�      $
��Male��6   �� 5�      $��Female��6   5�      �� 5�      -   5        $ 
submit_btn��5�      $	��145��5�      $��28��5�      $��291,388,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Submit��5�      $��16(�5�      $
��Bold"�5�      �� 5�      -   5        $ 	clear_btn��5�      $	��133��5�      $��28��5�      $��145,388,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Clear��5�      $��16(�5�      $
��Bold"�5�      �� 5�      -   5        $ password_txt��5�      $	��164��5�      $��23��5�      $��272,161,0,0q�5�      $
��Left=�5�      $	��Top=�5�      �� 5�      -   5        $ 	email_lbl��5�      $��141,126,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��E-Mail��5�      $��16(�5�      ���	#FFF0DC5A5�      �� 5�      -   5        $ 	email_txt��5�      $	��165��5�      $��23��5�      $��271,130,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Center=�5�      $
 Wrap=�5�      �� 5�      -   5        $ lastName_lbl��5�      $��
141,94,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��	Last Name��5�      $��16(�5�      ���	#FFF0DC5A5�      �� 5�      -   5        $ lastName_txt��5�      $	��165��5�      $��23��5�      $��
271,98,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Center=�5�      $
 Wrap=�5�      �� 5�      -   5        $ uploadCV_btn��5�      $	��291��5�      $��31��5�      $��145,320,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Upload CV (Optional)��5�      $
��Bold"�5�      6'   5�      5�      5�      