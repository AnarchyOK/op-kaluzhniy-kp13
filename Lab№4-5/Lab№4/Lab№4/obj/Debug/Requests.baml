   M S B A M L   `   `   `  ����?  ;Lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab4Lab4  5   	       Lab4.Requests   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab4     5   	     � Title$  Requests��5   	   $	��618��6   $	��749��6'   .��5	      � .+�5
   
   �� -   5         ��Name$ ToStartWindow��5
      $��
Вийти��6(   $
��Left=�68   $��
10,531,0,0q�6S   $	��Top=�6g   $	��711��6   $��34��6�   $��24(�6�   $��Arial)�6�   $
��Bold"�6�   6�   �� 5   
   $��Center=�6   $	��516��62   $��0,10,0,0q�6?   $	��Top=�6Q   $	��729��6i   .@�5      �� $��Запит 1��6   $��20(�6'   $��Arial)�65   $��Normal$�6H   $
��28.8��6[   .��5      � $��0,0,9,0q�6   .+�5      �� $
��Left=�6    $��	10,10,0,0q�6;   $
��Wrap=�6N   $5��/Відомості про кінотеатри ��6b   $	��Top=�6�   $��27��6�   $	��669��6�    �� TextAlignment$ Justify=�6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
CinemaData��5      $
��Left=�63   $	��432��6N   $��	10,37,0,0q�6[   $	��Top=�6n   $	��669��6�   $��Normal$�6�   $��16(�6�   $��Courier New)�6�   $
��Bold"�6�   5      5      �� 5      $��Запит 2��6   $��20(�6'   $��Arial)�65   $��Normal$�6H   $
��28.8��6[   .��5      � $��0,0,-1,0q�6    � ColumnDefinitions 5      �� 5      $	��50* �6+   �� 5      $
��121* �6+   .+�5      �� $
��Left=�6    $��	10,10,0,0q�6;   $
��Wrap=�6N   $O��IФільми у жанрі *Бойовик* та в обрану дату��6b   $	��Top=�6�   $��51��6�   $	��491��6�   $ Justify=�6�   $��2��6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dp��5   !   $��Center=�6-   $��0,51,0,0q�6J   $	��Top=�6\   $	��193��6t     5      -   5        $ ComediesData��5      $
��Left=�65   $	��368��6P   $��
10,101,0,0q�6]   $	��Top=�6q   $	��704��6�   $��16(�6�   $��Courier New)�6�   $��Normal$�6�   $
��Bold"�6�   $��2��6�   �� 5      -   5        $	 Go3��5      $��Знайти��6*   $
��Left=�6;   $��	44,53,0,0q�6V   $	��Top=�6i   $	��178��6�   $��29��6�   $��1��6�   5      5      �� 5      $��Запит 3��6   $��20(�6'   $��Arial)�65   $��Normal$�6H   $
��28.8��6[   .��5      � $��0,0,-5,0q�6    5       �� 5!      $	��63* �6+   �� 5"      $��1048* �6+   .+�5$      �� $
��Left=�6    $��	10,10,0,0q�6;   $
��Wrap=�6N   $	��Top=�6b   $��51��6z   $	��491��6�   $ Justify=�6�   $��2��6�   $J��DЦіни на кваитки у обраний період часу��6�     5%      -   5        $ CostData��5%      $
��Left=�61   $	��340��6L   $��
10,129,0,0q�6Y   $	��Top=�6m   $	��692��6�   $��2��6�   $��Courier New)�6�   $��Italic$�6�   $��16(�6�   $
��Bold"�6�   �� 5&      -   5         ��Name$ TheatersCBox��5&      $
��Left=�65   $��	10,48,0,0q�6P   $	��Top=�6c   $	��292��6{   $��2��6�   $��42��6�     5'      -   5        $ PData��5'   !   $
��Left=�60   $��	16,95,0,0q�6K   $	��Top=�6^   $	��178��6v   $��1��6�    J� RenderTransformOrigin$ 0.635,0.621&�6�   �� 5(      $
��Left=�6    $��	14,98,0,0q�6;   $
��Wrap=�6N   $��Від:��6b   $	��Top=�6n   $��24��6�   $��52��6�   $ Justify=�6�   $��2��6�     5)      -	   5        $ LData��5)   !   $
��Left=�60   $��258.2,95,0,0q�6K   $	��Top=�6a   $	��178��6y   $��1��6�   �� 5*      $
��Left=�6    $��
214,98,0,0q�6;   $
��Wrap=�6O   $��До:��6c   $	��Top=�6n   $��24��6�   $��45��6�   $ Justify=�6�   $��1��6�   �� 5+      -
   5        $	 Go5��5+      $��Знайти��6*   $
��Left=�6;   $��
258,48,0,0q�6V   $	��Top=�6j   $	��178��6�   $��42��6�   $��1��6�   5,      5-      �� 5.      $��Запит 4��6   $��20(�6'   $��Arial)�65   $��Normal$�6H   $
��28.8��6[   .��5/      � $��0,0,-1,0q�6   .+�50      �� $
��Left=�6    $��	10,10,0,0q�6;   $
��Wrap=�6N   $	��Top=�6b   $��51��6z   $	��540��6�   $ Justify=�6�   $t��nФільми кивтки яких коштують менше 100 гривень, але більше за 50��6�     51      -   5        $ c100_50��51      $��Center=�60   $	��413��6M   $��0,66,0,0q�6Z   $	��Top=�6l   $	��704��6�   $��Courier New)�6�   $��Italic$�6�   $��16(�6�   $
��Bold"�6�   52      53      �� 54      $��Запит 5��6   $��20(�6'   $��Arial)�65   $��Normal$�6H   $
��28.8��6[   .��55      � $��0,0,33,0q�6    56      �� 57      $	��64* �6+   �� 58      $
��491* �6+   .+�5:      �� $
��Left=�6    $��	29,10,0,0q�6;   $
��Wrap=�6N   $&�� Фільми за актором��6b   $	��Top=�6{   $��27��6�   $	��637��6�   $ Justify=�6�   $��2��6�     5;      -   5        $ Theater_P_Actor��5;      $
��Left=�68   $	��391��6S   $��	29,78,0,0q�6`   $	��Top=�6s   $	��637��6�   $��16(�6�   $��Italic$�6�   $��Courier New)�6�   $
��Bold"�6�   $��2��6�   �� 5<      -   5        $ 
ActorsCBox��5<      $
��Left=�63   $��	29,37,0,0q�6N   $	��Top=�6a   $	��563��6y   $��2��6�   6�   5=      5?      �� 5@      $��Запит 6��6   $��20(�6'   $��Arial)�65   $��Normal$�6H   $
��28.8��6[   .��5A      �  5B      �� 5C      $
��191* �6+   �� 5D      $
��919* �6+   .+�5F      �� $
��Left=�6    $��	38,10,0,0q�6;   $
��Wrap=�6N   $;��5Фільми які отримали нагороду��6b   $	��Top=�6�   $��51��6�   $	��491��6�   $ Justify=�6�   $��2��6�     5G      -   5        $ FilmsReward��5G      $
��Left=�64   $	��403��6O   $��	38,66,0,0q�6\   $	��Top=�6o   $	��646��6�   $��16(�6�   $
��Bold"�6�   $��Courier New)�6�   $��2��6�   5H      5J      �� 5K      $��Запит 7��6   $��20(�6'   $��Arial)�65   $��Normal$�6H   $
��28.8��6[   .��5L      � .+�5M        -   5        $ 	FilmsData��5M      $��Center=�62   $	��408��6O   $��0,61,0,0q�6\   $	��Top=�6n   $	��703��6�   �� 5N      $��Center=�6    $��0,10,0,0q�6=   $
��Wrap=�6O   $	��Top=�6c   $��46��6{   $	��595��6�   $ Justify=�6�   $1��+Фільми по районах Києва��6�   5O      5Q      �� 5R      $��Запит 8��6   $��20(�6'   $��Arial)�65   $��Normal$�6H   $
��28.8��6[   .��5S      �  5T      �� 5U      $	��68* �6+   �� 5V      $
��195* �6+   �� 5W      $	��99* �6+   .+�5Y      �� $
��Left=�6    $��	35,32,0,0q�6;   $
��Wrap=�6N   $	��Top=�6b   $��29��6z   $	��572��6�   $ Justify=�6�   $��3��6�   $@��:Загальний прибуток кінотеатрів��6�     5Z      -   5        $ Money��5Z      $
��Left=�6.   $	��413��6I   $��	10,66,0,0q�6V   $	��Top=�6i   $	��703��6�   $��Courier New)�6�   $��Italic$�6�   $��16(�6�   $
��Bold"�6�   $��3��6�   5[      5]      5_      5a      5b      