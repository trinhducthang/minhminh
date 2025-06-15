using onlan2.Models;
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

namespace onlan2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QLBVContext db = new QLBVContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dgHoSoBenhAn_Loaded(object sender, RoutedEventArgs e)
        {
            cbTenBenhNhan.ItemsSource = db.BenhNhans.ToList();
            cbTenBenhNhan.DisplayMemberPath = "HoTen";
            cbTenBenhNhan.SelectedValuePath = "MaBn";
            dgHoSoBenhAn.ItemsSource = db.HoSoBenhAns.ToList();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (txtMaHsba.Text == "" || dpNgayKham.SelectedDate == null || txtChuanDoan.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu");
                return;
            }

            // Kiểm tra mã bệnh án đã tồn tại chưa
            int maHSBA = Convert.ToInt32(txtMaHsba.Text.Trim());
            var check = db.HoSoBenhAns.Find(maHSBA);
            if (check != null)
            {
                MessageBox.Show("Mã bệnh án đã tồn tại");
                return;
            }

            // Tạo đối tượng mới
            var hs = new HoSoBenhAn()
            {
                MaHsba = Convert.ToInt32(txtMaHsba.Text),
                NgayKham = dpNgayKham.SelectedDate.Value,
                ChuanDoan = txtChuanDoan.Text.Trim(),
                MaBn = Convert.ToInt32(cbTenBenhNhan.SelectedValue)
            };

            try
            {
                db.HoSoBenhAns.Add(hs);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");

                // Cập nhật lại DataGrid
                dgHoSoBenhAn.ItemsSource = db.HoSoBenhAns.ToList();
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
                var thongKe = db.HoSoBenhAns
                    .GroupBy(h => h.MaBn)
                    .Select(g => new
                    {
                        MaBenhNhan = g.Key,
                        TenBenhNhan = db.BenhNhans
                                           .Where(b => b.MaBn == g.Key)
                                           .Select(b => b.HoTen)
                                           .FirstOrDefault(),
                        SoLuongHoSo = g.Count()
                    })
                    .ToList();

                // Mở cửa sổ thống kê
                ThongKeWindow tkWindow = new ThongKeWindow(thongKe);
                tkWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }

        }
    }
}