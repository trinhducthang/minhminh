   M S B A M L   `   `   `  ����A  =suaxoa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:suaxoasuaxoa  5   	       suaxoa.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:suaxoa     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��0,0,0,4q�6   .+�5
   
   �� $��Mã NV:��6   $
��Left=�6!   $��	66,50,0,0q�6<   $	��Top=�6O   $��20(�6g   �� 5   
   $��
Họ tên:��6   $
��Left=�6"   $��	66,92,0,0q�6=   $	��Top=�6P   $��20(�6h   �� 5   
   $��Chức vụ:��6   $
��Left=�6#   $��
67,134,0,0q�6>   $	��Top=�6R   $��20(�6j   �� 5   
   $��Phòng ban:��6   $
��Left=�6%   $��
67,178,0,0q�6@   $	��Top=�6T   $��20(�6l   �� 5   
   -   5         ��Name$ txtMaNV��5      $
��Left=�6#   $��
191,60,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��120��6~   �� 5   
   -   5        $ txtHoTen��5      $
��Left=�6$   $��181,101,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5   
   -   5        $ 	txtChucVu��5      $
��Left=�6%   $��181,143,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��120��6�   �� 5   
   -   5        $ txtPhongBan��5      $
��Left=�6'   $��191,187,0,0q�6B   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgNhanVien��5      $��81,231,115,59q�6'   $
��Bold"�6>   $��Center=�6P      AutoGenerateColumns$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã NV ��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *MaMV+6N     5      $ 	Họ Tên��6%   $ * 6P    65   �� *HoTen+6P     5      $ Chức vụ��6%   $ * 6Q    66   �� *ChucV+6Q     5      $ 
Phòng ban��6%   $ * 6V    68   �� *
PhongBan+6V   5      �� 5   
   -   5        	 ��Name$	 btnSua��5      $��Sửa��6!   $
��Left=�6/   $��184,365,0,0q�6J   $	��Top=�6_   6w   �� 5   
   -   5        $	 btnXoa��5      $
��Xóa��6!   $
��Left=�6/   $��297,365,0,0q�6J   $	��Top=�6_   6w   �� 5   
   -   5        $	 
btnThongKe��5      $��Thống kê��6%   $
��Left=�68   $��400,365,0,0q�6S   $	��Top=�6h   6�   5      5      