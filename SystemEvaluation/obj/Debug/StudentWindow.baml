   M S B A M L   `   `   `  ����K  GSystemEvaluation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SystemEvaluationSystemEvaluation  5   	   $    SystemEvaluation.StudentWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SystemEvaluation     5   	     � Title$  Лекарства��5   	    � WindowState$ Normal=�6   
������� � 	Resources 5	       �� 
TargetType �� Property �� Value��%8  '��       �� 5
   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 40��6'   �� 5       � ��$	 150��6&   �� 5       � ��$ 26(�6)   �� 5       � ��$ 	Pescadero)�6+   �� 5       � ��$ Italic$�6*   �� 5       � ��$ 10q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��60 �6   �� 5      $��60 �6   .+�5   
   �� $��3��6   $��Center=�6"   $��Center=�6=   .+�5      �� -   5        
���P��.��5   @   
Меню6F   5      �� 5!   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5"      �� -   5        .��5"   *   Добавить64   �� 5#      -   5        .��5#   +   Изменить65   �� 5$      -   5        
����p��.��5$   H   Удалить6Q   5%      &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ 
dgStudents��5(      $��10q�5'   5   $��1��6A   	   AutoGenerateColumns	 .  $��22(�5(   '   
   CanUserAddRows
 .    CanUserDeleteRows .    CanUserSortColumns .    AlternatingRowBackground
 �������5'      �� *	dataTable+   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Инв/№��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *(&НомерЗачетнойКнижки+  5-      $ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S    67   �� *Фамилия+6S     5.      $ Количество��6%    69   �� *Имя+  5/      $ Цена��6%    63   �� *Отчество+  50      $ Вид��6%    62   �� *КодГруппы+52      53      54      