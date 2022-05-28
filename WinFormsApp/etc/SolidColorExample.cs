using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using LiveCharts;

namespace WinFormsApp16.etc
{
    public partial class SolidColorExample : UserControl
    {
        public SolidColorExample()
        {
           // InitializeComponent();

            Values = new ChartValues<double> { 150, 375, 420, 500, 160, 140 };

            DataContext = this;
        }

        public ChartValues<double> Values { get; set; }

        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            //Chart.Update(true);
        }
    }
}
