   M S B A M L   `   `   `  ����B  >Lab№1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:FirstWPFAppFirstWPFApp  5   	       FirstWPFApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:FirstWPFApp     5   	   -   5          �Name$  MainWindow1��5   	    � Title$% Перший WPF-додаток��5   	   ���	#FFE6C0C0$y�Visible=�6;    � WindowStartupLocation$ CenterScreen=�6P    � 
ResizeMode$ CanMinimize=�6u   $	��630��6�   $	��430��6�   
������� � Icon$ 	Icon1.ico��6�   .��5	      � ���	#FF258CBB � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   $	��624��6,   �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ ExitBtn��5      $��
Вихід��6"   $��Right=�62   $��
0,0,176,24q�6N   $��Bottom=�6b   $	��267��6}   $��50��6�   ���	#FFFF6C40 � Cursor$
 Hand��6�   6�   �� 5   
   -   5        $
 Win1��5      $,��&База даних студентів��6   $��0,0,176,276q�6>   4  .System.Windows.Automation.AutomationProperties   Name$
 Win1��6f   $��Right=�6�   $	��267��6�   $��54��6�   $��Bottom=�6�   ���	#FF2C9ED3$
 Hand��6�   �� 5   
   -   5        $
 Win2��5      $#��Хрестики-Нулики��6   $��Right=�69   $��54��6U   $��0,0,176,217q�6a   $��Bottom=�6v   $	��267��6�   $
 Win2��6�   ���	#FF2C9ED3$
 Hand��6�   �� 5   
   -   5        $
 Win3��5      $��Калькулятор��6   $��Right=�65   $��54��6Q   $��0,0,176,158q�6]   $��Bottom=�6r   $	��267��6�   $
 Win3��6�   ���	#FF2C9ED3$
 Hand��6�   �� 5   
   -   5        $
 Win4��5      $��
Автор��6   $��Right=�6/   $��54��6K   $��
0,0,176,99q�6W   $��Bottom=�6k   $	��267��6�   $
 Win4��6�   ���	#FF2C9ED3$
 Hand��6�   �� 5   
   $��ГОЛОВНЕ ВІКНО��6   $
��Left=�6(   $��
227,22,0,0q�6C   $	��Top=�6W   $	��180��6o   $��44��6{   $��Forte)�6�   {�.  $ Arrow��6�   $��20(�6�   ���	#00000000���	#FF0C092C$
��Bold"�6�   $��Italic$�6	  5      5      