using suaxoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace suaxoa
{
    /// <summary>
    /// Interaction logic for ThongKeWindow.xaml
    /// </summary>
    public partial class ThongKeWindow : Window
    {
        QLNS1Context db = new QLNS1Context();

        public ThongKeWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var thongKe = db.NhanViens
                            .GroupBy(nv => nv.PhongBan)
                            .Select(g => new
                            {
                                PhongBan = g.Key,
                                SoLuong = g.Count()
                            }).ToList();

            dgThongKe.ItemsSource = thongKe;
        }
    }
}
