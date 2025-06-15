using onlan4.Models;
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

namespace onlan4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QLNSContext db = new QLNSContext();
        public MainWindow()
        {
            InitializeComponent();

        }
        private void dgDuAn_Loaded(object sender, RoutedEventArgs e)
        {
            cbNhanVienPhuTrach.ItemsSource = db.NhanViens.ToList();
            cbNhanVienPhuTrach.DisplayMemberPath = "HoTen";
            cbNhanVienPhuTrach.SelectedValuePath = "MaNv";
            dgDuAn.ItemsSource = db.DuAns.ToList();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (txtMaDa.Text == "" || dpNgayBatDau.SelectedDate == null || txtTenDuAn.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu");
                return;
            }
            int maHSDA = Convert.ToInt32(txtMaDa.Text);
            var check = db.DuAns.Find(maHSDA);
            if (check != null)
            {
                MessageBox.Show("Mã dự án đã tồn tại");
                return;
            }
            var hs = new DuAn()
            {
                MaDa = Convert.ToInt32(txtMaDa.Text),
                TenDuAn = txtTenDuAn.Text.Trim(),
                NgayBatDau = dpNgayBatDau.SelectedDate.Value,
                MaNv = Convert.ToInt32(cbNhanVienPhuTrach.SelectedValue)
            };
            try
            {
                db.DuAns.Add(hs);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                dgDuAn.ItemsSource = db.DuAns.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
            }
        }
        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var thongKe = db.DuAns
                    .GroupBy(h => h.MaNv)
                    .Select(g => new
                    {
                        MaNhanVien = g.Key,
                        TenNhanVien = db.NhanViens.Where(b => b.MaNv == g.Key).Select(b => b.HoTen).FirstOrDefault(), SoLuongDuAn = g.Count()
                    }).ToList();

                ThongKeWindow tkWindow = new ThongKeWindow(thongKe);
                tkWindow.ShowDialog();

            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }
        }
    }
}





   