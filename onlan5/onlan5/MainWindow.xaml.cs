using onlan5.Models;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace onlan5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QLTVContext db = new QLTVContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgSach.ItemsSource = db.Saches.OrderBy(s => s.MaSach).ToList();
        }

        private void dgSach_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgSach.SelectedItem != null)
            {
                try
                {
                    Type t = dgSach.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtMaSach.Text = p[0].GetValue(dgSach.SelectedItem)?.ToString();
                    txtTenSach.Text = p[1].GetValue(dgSach.SelectedItem)?.ToString();
                    txtTacGia.Text = p[2].GetValue(dgSach.SelectedItem)?.ToString();
                    txtNamXuatBan.Text = p[3].GetValue(dgSach.SelectedItem)?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn hàng: " + ex.Message, "Thông báo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int maSach = int.Parse(txtMaSach.Text);
                if (db.Saches.Any(s => s.MaSach == maSach))
                {
                    MessageBox.Show("Mã sách đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var sach = new Sach
                {
                    MaSach = maSach,
                    TenSach = txtTenSach.Text,
                    TacGia = txtTacGia.Text,
                    NamXuatBan = int.TryParse(txtNamXuatBan.Text, out int nam) ? nam : null
                };

                db.Saches.Add(sach);
                db.SaveChanges();

                dgSach.ItemsSource = db.Saches.OrderBy(s => s.MaSach).ToList();
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                Clear_Field();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sách: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dgSach.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var sach = db.Saches.Find(int.Parse(txtMaSach.Text));
            if (sach == null)
            {
                MessageBox.Show("Không tìm thấy sách để sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                sach.TenSach = txtTenSach.Text;
                sach.TacGia = txtTacGia.Text;
                sach.NamXuatBan = int.TryParse(txtNamXuatBan.Text, out int nam) ? nam : null;

                db.Saches.Update(sach);
                db.SaveChanges();

                dgSach.ItemsSource = db.Saches.OrderBy(s => s.MaSach).ToList();
                MessageBox.Show("Sửa sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa sách: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn mã sách để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sách này?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                var sach = db.Saches.Find(int.Parse(txtMaSach.Text));
                if (sach != null)
                {
                    var muonLienQuan = db.MuonSaches.Any(m => m.MaSach == sach.MaSach);
                    if (muonLienQuan)
                    {
                        MessageBox.Show("Không thể xóa sách vì đang được mượn hoặc liên kết với dữ liệu khác!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    db.Saches.Remove(sach);
                    try
                    {
                        db.SaveChanges();
                        Clear_Field();
                        dgSach.ItemsSource = db.Saches.OrderBy(s => s.MaSach).ToList();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa sách: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách cần xóa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Clear_Field()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTacGia.Clear();
            txtNamXuatBan.Clear();
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            var thongKe = db.Saches
                .GroupBy(s => s.TacGia)
                .Select(g => new { TacGia = g.Key, SoLuong = g.Count() })
                .OrderByDescending(g => g.SoLuong)
                .ToList();

            string message = "Thống kê số sách theo tác giả:\n";
            foreach (var item in thongKe)
            {
                message += $"Tác giả: {item.TacGia} - Số sách: {item.SoLuong}\n";
            }

            ThongKeWindow tkWindow = new ThongKeWindow();
            tkWindow.ShowDialog();
        }
    }
}