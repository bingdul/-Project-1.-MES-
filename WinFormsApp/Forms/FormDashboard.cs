using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using LiveCharts.Defaults;
using Newtonsoft.Json.Linq;
//using Wpf.Annotations;
using Brushes = System.Windows.Media.Brushes;


namespace WinFormsApp16.Forms
{
    public partial class FormDashboard : Form
    {
        
        public FormDashboard()
        {
            
            InitializeComponent();

            angularGauge1.Value = 0;
            angularGauge1.FromValue = 0; //50
            angularGauge1.ToValue = 200; //250
            angularGauge1.TicksForeground = Brushes.Black; // 게이지 색깔
            angularGauge1.Base.Foreground = Brushes.White; // 게이지 수치 색깔
            angularGauge1.Base.FontWeight = FontWeights.Bold;
            angularGauge1.Base.FontSize = 10;
            angularGauge1.SectionsInnerRadius = 0.5;

            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 150,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 181, 64))
            });
            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 150,
                ToValue = 200,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });

            angularGauge2.Value = 0;
            angularGauge2.FromValue = 0;
            angularGauge2.ToValue = 200;
            angularGauge2.TicksForeground = Brushes.Black; // 게이지 색깔
            angularGauge2.Base.Foreground = Brushes.White; // 게이지 수치 색깔
            angularGauge2.Base.FontWeight = FontWeights.Bold;
            angularGauge2.Base.FontSize = 10;
            angularGauge2.SectionsInnerRadius = 0.5;

            angularGauge2.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 150,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 181, 64))
            });
            angularGauge2.Sections.Add(new AngularSection
            {
                FromValue = 150,
                ToValue = 200,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });

            JObject jObject = new JObject(
                new JProperty("SENDER_TYPE", "USER"),
                new JProperty("MESSAGE_TYPE", "ENTER_FORM_REQUEST"),
                new JProperty("FORM_TYPE", "DASHBOARD"),
                new JProperty("TOKEN", ConnectionHandler.token)
                , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
                );
            string result;
            result = jObject.ToString(Newtonsoft.Json.Formatting.None);
            ConnectionHandler.send(result);
           

        }
       


        public ColumnSeries MariaSeries { get; set; }
        public ColumnSeries CharlesSeries { get; set; }
  


        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void glassyPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,
         int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            
            panel8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel8.Width, panel8.Height, 15, 15));
            panel10.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel10.Width, panel10.Height, 15, 15));

            //panel7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel7.Width, panel7.Height, 15, 15));
            panel8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel8.Width, panel8.Height, 15, 15));
            //Run reading in an additional thread


            //panel13.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel13.Width, panel13.Height, 15, 0));
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
