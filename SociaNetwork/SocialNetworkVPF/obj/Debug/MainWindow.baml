   M S B A M L   `   `   `  ����G  CSociaNetwork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SociaNetworkSociaNetwork  5   	       SociaNetwork.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SociaNetwork     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��600��5      $
��1024��6'     � WindowStartupLocation$  CenterScreen=�64    � 
ResizeMode$ NoResize=�6Y    � WindowStyle$
 None=�6o   .��5	      � -   5        ���	#FFEEEEEE.+�5
   
   � $��40��6   $	��Top=�6   ���	#FFEBAEAC J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�62      Color$ 	#FFACACAC��6B   .+�5      �� -   5        $��Right=�5      $��Center=�61   ��6L   Z� ��6b   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Power=�6*    J� RenderTransformOrigin$ 0.5,0.5&�67   $��29��6W   $��46��6c   z�5      V� 5      .~�5      �� �� 5      �� 5      	 �� Angle$	 1.977Q�6.   T� 5      5      5      5      5      � 5   
   $��
250,40,0,0q�6   ���	#FFE5DBDB.+�5      � -   5        
 �Name$
 GridPrincipal��5      $��Center=�6*   $��Center=�6G   5      � 5!   
   $	��260��6   $
��Left=�6   ���	#FF31577E.+�5"      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5"   2   ���	#FFD6C2C2C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6U   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.2X�.��5#      � -   5        $
 
GridCursor��5#      $��0 40 0 0q�6+   ���	#FF0069C0$��10��6T   $
��Left=�6_   $��60��6z   $	��Top=�6�   5$      �� 5&      -   5         ��Name$ ListViewMenu��5&      $��
0,40,0,173q�6-   
�������$��Champagne & Limousines)�6X   $��18(�6�    �� SelectedIndex$ 0��6�   .@�5(      �� $��60��6   ���	#FFDAA9A9.��5)      ��  �� Orientation$ 
Horizontal=�6!   .+�5*      �� $
��News��6$   $��17(�60   $��Center=�6>   $
��20 0q�6Y   5+      5,      �� 5.      $��60��6   ���	#FFCEABAB.��5/      �� $ 
Horizontal=�6!   .+�50      �� $��My page ��6$   $��17(�64   $��Center=�6B   $
��20 0q�6]   51      52      �� 53      $��60��6   ���	#FFC3A1A1.��54      �� $ 
Horizontal=�6!   .+�55      �� $��Edit profile��6$   $��17(�68   $��Center=�6F   $
��20 0q�6a   56      57      �� 59      $��60��6   ���	#FFAE8484.��5:      �� $ 
Horizontal=�6!   .+�5;      �� $��Search��6$   $��17(�62   $��Center=�6@   $
��20 0q�6[   5<      5=      5?      5@      5B      5C      