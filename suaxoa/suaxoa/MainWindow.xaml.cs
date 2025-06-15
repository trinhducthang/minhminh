using suaxoa.Models;
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

namespace suaxoa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QLNS1Context db = new QLNS1Context();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list = db.NhanViens
                         .OrderBy(nv => nv.HoTen)
                         .Select(nv => new
                         {
                             nv.MaNv,
                             nv.HoTen,
                             nv.ChucVu,
                             nv.PhongBan
                         }).ToList();

            dgNhanVien.ItemsSource = list;
        }

        private void dgNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgNhanVien.SelectedItem == null) return;

            var selected = dgNhanVien.SelectedItem;
            Type type = selected.GetType();
            PropertyInfo[] props = type.GetProperties();

            txtMaNV.Text = props[0].GetValue(selected)?.ToString();
            txtHoTen.Text = props[1].GetValue(selected)?.ToString();
            txtChucVu.Text = props[2].GetValue(selected)?.ToString();
            txtPhongBan.Text = props[3].GetValue(selected)?.ToString();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtChucVu.Text) ||
                string.IsNullOrWhiteSpace(txtPhongBan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput()) return;

            if (db.NhanViens.Find(txtMaNV.Text) != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var nv = new NhanVien
            {
                MaNv = txtMaNV.Text,
                HoTen = txtHoTen.Text,
                ChucVu = txtChucVu.Text,
                PhongBan = txtPhongBan.Text
            };

            db.NhanViens.Add(nv);
            db.SaveChanges();
            LoadData();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput()) return;

            var nv = db.NhanViens.Find(txtMaNV.Text);
            if (nv != null)
            {
                nv.HoTen = txtHoTen.Text;
                nv.ChucVu = txtChucVu.Text;
                nv.PhongBan = txtPhongBan.Text;
                db.SaveChanges();
                LoadData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên để sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var nv = db.NhanViens.Find(txtMaNV.Text);
            if (nv != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    db.NhanViens.Remove(nv);
                    db.SaveChanges();
                    LoadData();
                    ClearInputs();
                }
            }
        }

        private void ClearInputs()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtChucVu.Clear();
            txtPhongBan.Clear();
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            ThongKeWindow tk = new ThongKeWindow();
            tk.ShowDialog(); // hoặc .Show() nếu bạn không cần modal
        }

    }
}
