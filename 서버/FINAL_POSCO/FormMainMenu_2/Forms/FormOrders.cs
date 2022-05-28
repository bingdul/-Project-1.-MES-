using HtmlAgilityPack;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMainMenu_2.Forms
{
    public partial class FormOrders : Form
    {
        //oracle

        string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
            "(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));" +
            "User Id=SYSTEM;Password=dlehdgml;";
        OracleConnection conn;

        OracleCommand cmd;



        public FormOrders()
        {
            //oracle
            conn = new OracleConnection(strConn);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            //Init
            InitializeComponent();

            // 웹 페이지 파싱(석탄)
            var html_coal = "https://markets.businessinsider.com/commodities/coal-price";
            HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
            var htmlDoc_coal = web.Load(html_coal);
            var text_coal = htmlDoc_coal.DocumentNode.SelectSingleNode("//span[@class='price-section__current-value']").InnerText;

            // 웹 페이지 파싱(철광석)
            var html_iron = "https://markets.businessinsider.com/commodities/iron-ore-price";
            var htmlDoc_iron = web.Load(html_iron);
            var text_iron = htmlDoc_iron.DocumentNode.SelectSingleNode("//span[@class='price-section__current-value']").InnerText;

            // 랜덤값 
            Random rand = new Random();
            double coalprice = double.Parse(text_coal);
            double ironprice = double.Parse(text_iron);

            int iTemp = rand.Next(-11, 11);
            double fValue = 2.0f + ((double)iTemp * 0.1f);
            int jTemp = rand.Next(-11, 11);
            double ffValue = 2.0f + ((double)jTemp * 0.1f);

            //자재 가격 랜덤값 더하기
            double coal_brazli = Math.Truncate((coalprice + fValue) * 10) / 10;
            double iron_brazil = Math.Truncate((ironprice + fValue) * 100) / 100;
            double coal_auz = Math.Truncate((coalprice + ffValue) * 10) / 10;
            double iron_auz = Math.Truncate((ironprice + ffValue) * 100) / 100;

            //자재 가격 textbox 할당
            tb_china_coal_price.Text = text_coal;
            tb_china_iron_price.Text = text_iron;

            tb_brazil_iron_price.Text = Convert.ToString(iron_brazil);
            tb_brazil_coal_price.Text = Convert.ToString(coal_brazli);


            tb_auz_iron_price.Text = Convert.ToString(iron_auz);
            tb_auz_coal_price.Text = Convert.ToString(coal_auz);
        }

        private void FormOrders_Load(object sender, EventArgs e)
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
            label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
        }

        // 중국 석탄 구매버튼
        private void btn_china_coal_buy_Click(object sender, EventArgs e)
        {
            string val = tb_china_coal.Text;
            int stock = int.Parse(val);
            MessageBox.Show($"석탄을 {val}t 구매하였습니다.");
            //cmd.CommandText = $"INSERT INTO STOCK (COAL, PRICE,COUNTRY) VALUES ({stock},'{tb_china_coal_price.Text}','china')";

            cmd.CommandText = "SELECT COAL FROM STOCK WHERE OXY=1";
            OracleDataReader r=cmd.ExecuteReader();
            r.Read();

            cmd.CommandText = "UPDATE STOCK SET COAL = "+(int.Parse(r.GetOracleValue(0).ToString())+ stock)+" WHERE OXY = 1 ";
            cmd.ExecuteNonQuery();
        }
        // 중국 철광석 구매버튼
        private void btn_china_iron_buy_Click(object sender, EventArgs e)
        {
            string val = tb_china_iron.Text;
            int stock = int.Parse(val);
            cmd.CommandText = "SELECT IRON FROM STOCK WHERE OXY=1";
            OracleDataReader r = cmd.ExecuteReader();
            r.Read();

            cmd.CommandText = "UPDATE STOCK SET IRON = " + (int.Parse(r.GetOracleValue(0).ToString()) + stock) + " WHERE OXY = 1 ";
            cmd.ExecuteNonQuery();
            MessageBox.Show($"철광석을 {val}t 구매하였습니다.");
        }
        // 브라질 석탄 구매버튼
        private void btn_brazil_coal_buy_Click(object sender, EventArgs e)
        {
            string val = tb_brazil_coal.Text;
            int stock = int.Parse(val);
            cmd.CommandText = "SELECT COAL FROM STOCK WHERE OXY=2";
            OracleDataReader r = cmd.ExecuteReader();
            r.Read();

            cmd.CommandText = "UPDATE STOCK SET COAL = " + (int.Parse(r.GetOracleValue(0).ToString()) + stock) + " WHERE OXY = 2 ";
            cmd.ExecuteNonQuery();
            MessageBox.Show($"석탄을 {val}t 구매하였습니다.");
        }
        // 브라질 철광석 구매버튼
        private void btn_brazil_iron_buy_Click(object sender, EventArgs e)
        {
            string val = tb_brazil_iron.Text;
            int stock = int.Parse(val);
            cmd.CommandText = "SELECT IRON FROM STOCK WHERE OXY=2";
            OracleDataReader r = cmd.ExecuteReader();
            r.Read();

            cmd.CommandText = "UPDATE STOCK SET IRON = " + (int.Parse(r.GetOracleValue(0).ToString()) + stock) + " WHERE OXY = 2 ";
            cmd.ExecuteNonQuery();
            MessageBox.Show($"철광석을 {val}t 구매하였습니다.");
        }
        // 호주 석탄 구매버튼
        private void btn_auz_coal_buy_Click(object sender, EventArgs e)
        {
            string val = tb_auz_coal.Text;
            int stock = int.Parse(val);
            cmd.CommandText = "SELECT COAL FROM STOCK WHERE OXY=3";
            OracleDataReader r = cmd.ExecuteReader();
            r.Read();

            cmd.CommandText = "UPDATE STOCK SET COAL = " + (int.Parse(r.GetOracleValue(0).ToString()) + stock) + " WHERE OXY = 3";
            cmd.ExecuteNonQuery();
            MessageBox.Show($"석탄을 {val}t 구매하였습니다.");
        }
        // 호주 철광석 구매버튼
        private void btn_auz_iron_buy_Click(object sender, EventArgs e)
        {
            string val = tb_auz_iron.Text;
            int stock = int.Parse(val);
            cmd.CommandText = "SELECT IRON FROM STOCK WHERE OXY=3";
            OracleDataReader r = cmd.ExecuteReader();
            r.Read();

            cmd.CommandText = "UPDATE STOCK SET IRON = " + (int.Parse(r.GetOracleValue(0).ToString()) + stock) + " WHERE OXY = 3 ";
            cmd.ExecuteNonQuery();
            MessageBox.Show($"철광석을 {val}t 구매하였습니다.");
        }
    }
}
