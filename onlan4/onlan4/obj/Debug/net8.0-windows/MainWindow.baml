   M S B A M L   `   `   `  ����A  =onlan4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:onlan4onlan4  5   	       onlan4.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:onlan4     5   	     � Title$  Quản lí nhân sự ��5   	   $	��450��6"   $	��800��6/    � 	Resources 5	       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '��       �� 5
   
   " ��6    5      P� 5       �@J�	IsFocused$
 True��6/   . �5      ��  � ��
 � � �63   5      5      5      .��5      � $��10q�6   .+�5   
   �� $��Mã dự án��6   $
��Left=�6#   $��	10,10,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5         ��Name$ txtMaDa��5      $
��Left=�6#   $��
166,18,0,0q�6>   	 �� TextWrapping$
	 Wrap=�6R   $	��Top=�6f   $	��120��6~   �� 5   
   $��Tên dự án��6   $
��Left=�6$   $��	10,41,0,0q�6?   $	��Top=�6R   �� 5   
   -   5        $ 
txtTenDuAn��5      $
��Left=�6&   $��
166,45,0,0q�6A   $
	 Wrap=�6U   $	��Top=�6j   $	��120��6�   �� 5   
   $��Ngày bắt đầu��6   $
��Left=�6'   $��	10,72,0,0q�6B   $	��Top=�6U   (  "System.Windows.Controls.DatePicker  5   
   -   5        
  Name$
 dpNgayBatDau��5      $
��Left=�6+   $��
166,78,0,0q�6F   $	��Top=�6Z   $	��120��6r   �� 5   
   $��Nhân viên phụ trách��6   $
��Left=�6.   $��
10,103,0,0q�6I   $	��Top=�6]   �� 5   
   -   5         ��Name$ cbNhanVienPhuTrach��5      $
��Left=�6/   $��166,107,0,0q�6J   $	��Top=�6_   $	��120��6w    �� DisplayMemberPath$ HoTen��6�    �� SelectedValuePath$
 MaNV��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgDuAn��5      $��10,156,0,128q�6$   $
��Bold"�6:      AutoGenerateColumns$ False��6c      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã dự án��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *MaDa+6P     5      $ Tên dự án��6%   $ * 6T    68   �� *	TenDuAn+6T     5       $  Ngày bắt đầu��6%   $ * 6s    6<   �� *
NgayBatDau+ �� StringFormat$ 
dd/MM/yyyy��6s     5!      $ Nhân viên phụ trách��6%   $ * 6k    6B   �� *MaNvNavigation.HoTen+   ElementStyle 5"      �� 5#      " ��6    .�5$      ��  � ��
 �  ��6;   5%      5'      5)      �� 5*   
   -   5        $��Thêm��5*      $
��Left=�6    $��209,306,0,0q�6;   $	��Top=�6P   6h   �� 5+   
   -   5        $��Thống kê��5+      $
��Left=�6$   $��322,306,0,0q�6?   $	��Top=�6T   6l   5,      5-      