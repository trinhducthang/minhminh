using onlan5.Models;
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

namespace onlan5
{
    /// <summary>
    /// Interaction logic for ThongKeWindow.xaml
    /// </summary>
    public partial class ThongKeWindow : Window
    {
        private QLTVContext db = new QLTVContext();

        public ThongKeWindow()
        {
            InitializeComponent();
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            var thongKe = db.Saches
                .GroupBy(s => s.TacGia)
                .Select(g => new { TacGia = g.Key, SoLuong = g.Count() })
                .OrderByDescending(g => g.SoLuong)
                .ToList();

            dgThongKe.ItemsSource = thongKe;
        }
    }
}

