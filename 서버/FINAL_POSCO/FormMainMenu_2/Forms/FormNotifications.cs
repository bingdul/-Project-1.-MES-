using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Collections;
using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client;
using System.Data.OleDb;

namespace FormMainMenu_2.Forms
{
    public partial class FormNotifications : Form
    {
        

        OracleConnection conn;
        public FormNotifications()
        {
           
            
            InitializeComponent();
           
        }
        
       

        private void FormNotifications_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

                }
            }
            //label4.ForeColor = ThemeColor.SecondaryColor;
            //label5.ForeColor = ThemeColor.PrimaryColor;
        }
        private void SetupDataGridView()
        {
            this.Controls.Add(dataGridView1);
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "번호";
            dataGridView1.Columns[1].Name = "제품이름";
            dataGridView1.Columns[2].Name = "재고량";

            this.Controls.Add(dataGridView2);
            dataGridView2.ColumnCount = 5;
            dataGridView2.Columns[0].Name = "나라";
            dataGridView2.Columns[1].Name = "철광석양";
            dataGridView2.Columns[2].Name = "번호";
            dataGridView2.Columns[3].Name = "석탄양";
            dataGridView2.Columns[4].Name = "가격";
            /*
                        this.Controls.Add(dataGridView3);
                        dataGridView3.ColumnCount = 3;
                        dataGridView3.Columns[0].Name = "번호";
                        dataGridView3.Columns[1].Name = "자재이름";
                        dataGridView3.Columns[2].Name = "재고량";*/

        }
        private void PopulateDataGridView1()
        {
            // 오라클 연결
            Database db = new Database();
            conn = db.dbConnect();
            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            // SQL문 지정 및 select 실행
            cmd.CommandText = "select * from PRODUCT";
            // 결과 리더 객체를 리턴
            OracleDataReader rdr = cmd.ExecuteReader();
            
            dataGridView1.Rows.Clear();

            /* while (rdr.Read())
             {
                 string NUM = rdr["ID"].ToString();
                 string NAME = rdr["PRICE"].ToString();
                 string STOCK = rdr["COUNTRY"].ToString();

                 *//*if (NAME == "COIL")
                 {
                     NAME = "코일";
                 }*//*
                 // 데이타를 리스트박스에 추가
                 string [] row1 = new string[] { NUM, NAME, STOCK };
                 dataGridView1.Rows.Add(row1);

             }*/
            rdr.Read();
            string NUM = rdr["ID"].ToString();
            string NAME = rdr["NAME"].ToString();
            string STOCK = rdr["DROGBA"].ToString(); ; ;
            //string[] row1 = new string[] { NUM, NAME, STOCK };
            dataGridView1.Rows.Add(NUM,NAME,STOCK);

            rdr.Read();
            string NUM1 = rdr["ID"].ToString();
            string NAME1 = rdr["NAME"].ToString();
            string STOCK1 = rdr["DROGBA"].ToString(); ; ;
            //string[] row1 = new string[] { NUM, NAME, STOCK };
            
            dataGridView1.Rows.Add(NUM1, NAME1, STOCK1);
            rdr.Read();
            string NUM2 = rdr["ID"].ToString();
            string NAME2 = rdr["NAME"].ToString();
            string STOCK2 = rdr["DROGBA"].ToString(); ; ;
            //string[] row1 = new string[] { NUM, NAME, STOCK };
            dataGridView1.Rows.Add(NUM2, NAME2, STOCK2);




            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
        }
        private void PopulateDataGridView2()
        {
            // 오라클 연결
            Database db = new Database();
            conn = db.dbConnect();
            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            // SQL문 지정 및 select 실행
            cmd.CommandText = "select * from STOCK";
            // 결과 리더 객체를 리턴
            OracleDataReader rdr = cmd.ExecuteReader();
            dataGridView2.Rows.Clear();

            /* while (rdr.Read())
             {
                 string NUM = rdr["ID"].ToString();
                 string NAME = rdr["PRICE"].ToString();
                 string STOCK = rdr["COUNTRY"].ToString();

                 *//*if (NAME == "COIL")
                 {
                     NAME = "코일";
                 }*//*
                 // 데이타를 리스트박스에 추가
                 string [] row1 = new string[] { NUM, NAME, STOCK };
                 dataGridView1.Rows.Add(row1);

             }*/
            rdr.Read();
            string COUNTRY = rdr["COUNTRY"].ToString();
            string IRON = rdr["IRON"].ToString();
            string OXY = rdr["OXY"].ToString();
            string COAL = rdr["COAL"].ToString();
            string PRICE = rdr["PRICE"].ToString();
            //string[] row1 = new string[] { NUM, NAME, STOCK };
            dataGridView2.Rows.Add(COUNTRY, IRON, OXY, COAL, PRICE);

            rdr.Read();
            string COUNTRY1 = rdr["COUNTRY"].ToString();
            string IRON1 = rdr["IRON"].ToString();
            string OXY1 = rdr["OXY"].ToString();
            string COAL1 = rdr["COAL"].ToString();
            string PRICE1 = rdr["PRICE"].ToString();
            //string[] row1 = new string[] { NUM, NAME, STOCK };
            dataGridView2.Rows.Add(COUNTRY1, IRON1, OXY1, COAL1, PRICE1);

            rdr.Read();
            string COUNTRY2 = rdr["COUNTRY"].ToString();
            string IRON2 = rdr["IRON"].ToString();
            string OXY2 = rdr["OXY"].ToString();
            string COAL2 = rdr["COAL"].ToString();
            string PRICE2 = rdr["PRICE"].ToString();
            //string[] row1 = new string[] { NUM, NAME, STOCK };
            dataGridView2.Rows.Add(COUNTRY2, IRON2, OXY2, COAL2, PRICE2);

            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void charchar1()
        {

        }
        private void 조회_Click(object sender, EventArgs e)
        {
            SetupDataGridView();
            PopulateDataGridView1();
            PopulateDataGridView2();
            string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
            "(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));" +
            "User Id=SYSTEM;Password=dlehdgml;";
            OracleConnection conn;

            OracleCommand cmd;
            conn = new OracleConnection(strConn);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT SUM(COAL),SUM(IRON) from stock";
            OracleDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            int coal = rdr.GetInt32(0);
            int iron = rdr.GetInt32(1);


            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, coal);
            chart1.Series[0].Points.AddXY(1, iron);
            chart1.Series[0].Points[0].LegendText = "철광석";
            chart1.Series[0].Points[1].LegendText = "석탄";


            /*cmd.CommandText = "SELECT drogba from product";
            OracleDataReader rdr1 = cmd.ExecuteReader();
            rdr1.Read();
            int coil = rdr.GetInt32(0);
            int chur = rdr.GetInt32(1);
            int hung = rdr.GetInt32(2);

            chart2.Series[0].Points.Clear();
            chart2.Series[0].Points.AddXY(0, coil);
            chart2.Series[0].Points.AddXY(1, chur);
            chart2.Series[0].Points.AddXY(2, hung);
            chart2.Series[0].Points[0].LegendText = "코일";
            chart2.Series[0].Points[1].LegendText = "철근";
            chart2.Series[0].Points[2].LegendText = "형강";*/
            /*//주용 변수 선언

            OracleCommand cmd = new OracleCommand();

            OracleConnection oracleConnection = new OracleConnection();

            OracleDataAdapter oraAdapter = new OracleDataAdapter();

            DataSet ds = new DataSet();



            //오라클 DB연결문 작성

            string con_str = "User ID= SYSTEM;Password=dlehdgml;" +
                "pooling=false;Data Source=(DESCRIPTION=";
            con_str = con_str + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME= xe)));";



            //Connection Open

            oracleConnection.ConnectionString = con_str;

            oracleConnection.Open();



            //Dataset에 데이터 바인딩

            oraAdapter = new OracleDataAdapter("select * from STOCK", oracleConnection);

            oraAdapter.Fill(ds);



            //DB연결종료

            oracleConnection.Dispose();

            oracleConnection.Close();


            dataGridView2.DataSource = ds.Tables[0];
            //바인딩 된 데이터 건수 출력

            MessageBox.Show(ds.Tables[0].Rows.Count.ToString());*/
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}

