using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WinFormsApp16.Forms
{
    public partial class FormOrder : Form
    {
        LiveCharts.WinForms.GeoMap geoMap;
        
        
        public FormOrder()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
            InitializeComponent();
            //worker.DoWork += (sender, args) => PerformReading(); // 백그라운드로 실행할 메소드 이벤트 생성
            //worker.RunWorkerCompleted += (sender, args) => ReadingCompleted(); // 종료시 실행할 이벤트
            //worker.RunWorkerAsync(); // 백그라운드로 비동기 실행
            //                         //Show progress form in a main thread
            //waitForm.StartPosition = FormStartPosition.Manual;  //275, 84
            //waitForm.Location = new System.Drawing.Point(275, 84);
            //waitForm.ShowDialog(); // 로딩폼 나타내기
            

            label1.Text = "COUNTRY";
            this.BackColor = Color.FromArgb(34, 33, 74);
            this.TransparencyKey = Color.FromArgb(255, 0, 0);
            this.StartPosition = FormStartPosition.Manual;
            this.DesktopLocation = new Point(100, 100);
            this.ClientSize = new Size(330, 330);
            //panel1.BringToFront();
            //차트부분

            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis { Labels = new string[] { "전달", "이번달" } });
            cartesianChart2.AxisX.Add(new LiveCharts.Wpf.Axis { Labels = new string[] { "IRON", "" } });
            cartesianChart2.AxisX.Add(new LiveCharts.Wpf.Axis { Labels = new string[] { "", "COAL" } });
            //모든 항목 지우기
            //cartesianChart1.DefaultLegend;
            cartesianChart1.Series.Clear();
            cartesianChart1.LegendLocation = LegendLocation.Top;
            cartesianChart2.LegendLocation = LegendLocation.Top;
            //cartesianChart1.DataTooltip.Visibility = System.Windows.Visibility.Hidden;
            //cartesianChart2.DataTooltip.Visibility = System.Windows.Visibility.Hidden;
            //항목 추가
            //cartesianChart1.Series.Add(new LiveCharts.Wpf.LineSeries()
            //{
            //    //Title = "Sample1",
            //    //Stroke = new SolidColorBrush(Colors.Green),
            //    Stroke = System.Windows.Media.Brushes.IndianRed,
            //    Values = new LiveCharts.ChartValues<double>(new List<double> { 10, 20, 30 })
            //}



            //) ;

            //cartesianChart1.Series.Add(new LineSeries
            //{

            //    //Values = new ChartValues<double> { 1, 5, 3, 5, 3 },
            //    Values = new ChartValues<double> { 1, 5, 3, 5, 3 },
            //    //ScalesYAt = 0
            //});
            //cartesianChart1.Series.Add(new LineSeries
            //{
            //    Values = new ChartValues<double> { 20, 30, 70, 20, 10 },
            //    ScalesYAt = 1
            //});
            //cartesianChart1.Series.Add(new LineSeries
            //{
            //    Values = new ChartValues<double> { 600, 300, 200, 600, 800 },
            //    ScalesYAt = 2
            ////});
            //cartesianChart1.AxisY.Add(new Axis
            //{
            //    //Foreground = System.Windows.Media.Brushes.DodgerBlue,
            //    //Title = "Blue Axis"
            //});
            //cartesianChart1.AxisY.Add(new Axis
            //{
            ////    Foreground = System.Windows.Media.Brushes.IndianRed,
            ////    Title = "Red Axis",
            ////    Position = AxisPosition.RightTop
            //});
            //cartesianChart1.AxisY.Add(new Axis
            //{
            //    //Foreground = System.Windows.Media.Brushes.DarkOliveGreen,
            //    //Title = "Green Axis",
            //    //Position = AxisPosition.RightTop
            //});

            //MariaSeries = new ColumnSeries
            //{
            //    Values = new ChartValues<double> { 4, 6, 2, 7, 6 }
            //};
            //CharlesSeries = new ColumnSeries
            //{
            //    Values = new ChartValues<double> { 6, 2, 8, 3, 5 }
            //};

            //cartesianChart2.Series = new SeriesCollection
            //{
            //    MariaSeries,
            //    CharlesSeries

            //};
            this.Size = new Size(400, 400);
            Graphics graphics = CreateGraphics();
            Pen pen = new Pen(Color.Black);
            graphics.DrawLine(pen, 0, 0, 1000, 1000);
            graphics.Dispose();
            geoMap = new LiveCharts.WinForms.GeoMap();
            Dictionary<string, double> keyValues = new Dictionary<string, double>();
            keyValues["AU"] = 1;
            keyValues["CN"] = 1000000;
            keyValues["RU"] = 100000;
            keyValues["BR"] = 1000;
            keyValues["CA"] = 1000000;
            geoMap.HeatMap = keyValues;
            geoMap.Source = $"{Application.StartupPath}\\World.xml";
            //this.Controls.Add(geoMap);
            geoMap.Dock = DockStyle.Fill;

            //worldmap.Dock = DockStyle.Fill;
            //geoMap.Size = new System.Drawing.Size(900, 700);
            geoMap.LandClick += lc;
            //geoMap.AutoSize = true;
            //tableLayoutPanel1.Controls.Add(geoMap, 0, 0);
            splitContainer1.Panel1.Controls.Add(geoMap);
            JObject jObject = new JObject(
                new JProperty("SENDER_TYPE", "USER"),
                new JProperty("MESSAGE_TYPE", "ENTER_FORM_REQUEST"),
                new JProperty("FORM_TYPE", "ORE"),
                new JProperty("TOKEN", ConnectionHandler.token)
                , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
                );
            string result;
            result = jObject.ToString(Newtonsoft.Json.Formatting.None);
            ConnectionHandler.send(result);
            //worldmap.Controls.Add(geoMap);
            //worldmap.Dock = DockStyle.Fill;
            //panel1.Parent = geoMap;
            //panel1.BackColor = Color.FromArgb(125, Color.Black);

        }
        public ColumnSeries MariaSeries { get; set; }
        public ColumnSeries CharlesSeries { get; set; }

       
        Form CreateForm(double opacity, Point location, Size size)
        {
            var f = new Form();
            f.FormBorderStyle = FormBorderStyle.None;
            //f.BackColor = Color.Red;
            f.BackColor = Color.FromArgb(34, 33, 74);
            f.Opacity = opacity;
            f.StartPosition = FormStartPosition.Manual;
            f.DesktopLocation = PointToScreen(location);
            f.ClientSize = size;
            f.Owner = this;
            f.ShowInTaskbar = false;
            return f;
        }
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if (OwnedForms.Length > 0)
            {
                var p = PointToScreen(new Point(10, 10));
                var dx = p.X - OwnedForms[0].Location.X;
                var dy = p.Y - OwnedForms[0].Location.Y;
                foreach (var f in OwnedForms)
                    f.Location = new Point(f.Location.X + dx, f.Location.Y + dy);
            }
        }
        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);
        //    Form f1 = CreateForm(0.50, new Point(10, 500), new Size(200, 300));
        //    f1.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    f1.add
        //    f1.ForeColor = Color.FromArgb(255, 0, 0);
        //    f1.ControlBox = false;
        //    f1.Controls.Add(ordertextbox1);
        //    ordertextbox1.Location = new Point(5, 5);
        //    ordertextbox1.BringToFront();
        //    Form f2 =
        //     f1.TopLevel = false;
        //    this.geoMap.Controls.Add(f1);
        //    f1.SendToBack();
        //    f1.Show();
        //    f1.BringToFront();


        //    CreateForm(0.75, new Point(170, 10), new Size(150, 150)).Show();
        //    CreateForm(0.50, new Point(10, 170), new Size(150, 150)).Show();
        //    CreateForm(0.25, new Point(170, 170), new Size(150, 150)).Show();
        //}

        private void FormOrder_Load(object sender, EventArgs e)
        {
            
            //geoMap = new LiveCharts.WinForms.GeoMap();
            //Dictionary<string, double> keyValues = new Dictionary<string, double>();
            //keyValues["AU"] = 1;
            //keyValues["CN"] = 1000000;
            //keyValues["RU"] = 100000;
            //keyValues["BR"] = 1000;
            //keyValues["CA"] = 1000000;
            //geoMap.HeatMap = keyValues;
            //geoMap.Source = $"{Application.StartupPath}\\World.xml";
            ////this.Controls.Add(geoMap);
            //geoMap.Dock = DockStyle.Fill;

            ////worldmap.Dock = DockStyle.Fill;
            ////geoMap.Size = new System.Drawing.Size(900, 700);
            //geoMap.LandClick += lc;
            ////geoMap.AutoSize = true;
            ////tableLayoutPanel1.Controls.Add(geoMap, 0, 0);
            //splitContainer1.Panel1.Controls.Add(geoMap);

            ////worldmap.Controls.Add(geoMap);
            ////worldmap.Dock = DockStyle.Fill;
            ////panel1.Parent = geoMap;
            ////panel1.BackColor = Color.FromArgb(125, Color.Black);

        }
        void lc(object arg1, LiveCharts.Maps.MapData arg2)
        {
            JObject jObject = new JObject(
            new JProperty("SENDER_TYPE", "USER"),
            new JProperty("MESSAGE_TYPE", "ORE_COUNTRY_REQUEST"),
            new JProperty("FORM_TYPE", "ORE"),
            new JProperty("TOKEN", ConnectionHandler.token)
            , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
            ) ;
            string result;
            switch (arg2.Id)
            {
                case "CN":
                    label1.Text = "CHINA";
                    jObject.Add("COUNTRY", "CHINA");
                    result = jObject.ToString(Newtonsoft.Json.Formatting.None);
                    ConnectionHandler.send(result);
                    break;
                case "AU":
                    label1.Text = "AUSTRALIA";
                    jObject.Add("COUNTRY", "AUSTRALIA");
                    result = jObject.ToString(Newtonsoft.Json.Formatting.None);
                    ConnectionHandler.send(result);
                    break;
                case "RU":
                    label1.Text = "RUSSIA";
                    jObject.Add("COUNTRY", "RUSSIA");
                    result = jObject.ToString(Newtonsoft.Json.Formatting.None);
                    ConnectionHandler.send(result);
                    break;
                case "BR":
                    label1.Text = "BRAZIL";
                    jObject.Add("COUNTRY", "BRAZIL");
                    result = jObject.ToString(Newtonsoft.Json.Formatting.None);
                    ConnectionHandler.send(result);
                    break;
                case "CA":
                    label1.Text = "CANADA";
                    jObject.Add("COUNTRY", "CANADA");
                    result = jObject.ToString(Newtonsoft.Json.Formatting.None);
                    ConnectionHandler.send(result);
                    break;
                default: break;
            }

            Debug.WriteLine(arg2.Id);
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // 255, 128, 0
            Pen bluePen = new Pen(Color.FromArgb(255, 128, 0), 5);



            //Draw line using PointF structures
            PointF ptf1 = new PointF(0, 0);
            PointF ptf2 = new PointF(200.0F, 200.0f);
            e.Graphics.DrawLine(bluePen, ptf1, ptf2);

            bluePen.Dispose();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Pen bluePen = new Pen(Color.FromArgb(255, 128, 0), 5);



            //Draw line using PointF structures
            //PointF ptf1 = new PointF(0, 0);
            //PointF ptf2 = new PointF(200.0F, 200.0f);
            PointF ptf1 = new PointF(0, 60);
            PointF ptf2 = new PointF(60, 0);
            e.Graphics.DrawLine(bluePen, ptf1, ptf2);

            bluePen.Dispose();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            Pen bluePen = new Pen(Color.FromArgb(135, 44, 130), 5);
            PointF ptf1 = new PointF(0, 30);
            PointF ptf2 = new PointF(30, 0);
            e.Graphics.DrawLine(bluePen, ptf1, ptf2);

            bluePen.Dispose();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Pen bluePen = new Pen(Color.FromArgb(135, 44, 130), 5);
            PointF ptf1 = new PointF(0, 30);
            PointF ptf2 = new PointF(30, 0);
            e.Graphics.DrawLine(bluePen, ptf1, ptf2);

            bluePen.Dispose();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Pen bluePen = new Pen(Color.FromArgb(255, 128, 0), 5);



            //Draw line using PointF structures
            PointF ptf1 = new PointF(0, 0);
            PointF ptf2 = new PointF(200.0F, 200.0f);
            e.Graphics.DrawLine(bluePen, ptf1, ptf2);

            bluePen.Dispose();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            Pen bluePen = new Pen(Color.FromArgb(135, 44, 130), 5);



            //Draw line using PointF structures
            PointF ptf1 = new PointF(0, 0);
            PointF ptf2 = new PointF(200.0F, 200.0f);
            e.Graphics.DrawLine(bluePen, ptf1, ptf2);

            bluePen.Dispose();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String coal = textBox1.Text;
            String iron = textBox2.Text;
            textBox1.Text = "";
            textBox2.Text = "";
            JObject jObject = new JObject(
                new JProperty("SENDER_TYPE", "USER"),
                new JProperty("MESSAGE_TYPE", "ORE_ORDER_REQUEST"),
                new JProperty("FORM_TYPE", "ORE"),
                new JProperty("COAL", coal),
                new JProperty("IRON", iron),
                new JProperty("TOKEN", ConnectionHandler.token)
                , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
                );

            string result = jObject.ToString(Newtonsoft.Json.Formatting.None);
            ConnectionHandler.send(result);
        }
    }
}
