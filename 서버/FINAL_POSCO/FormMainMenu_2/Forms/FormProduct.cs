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
    public partial class FormProduct : Form
    {
        string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
            "(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));" +
            "User Id=SYSTEM;Password=dlehdgml;";
        OracleConnection conn;

        OracleCommand cmd;
        public FormProduct()
        {
            //chart1.Series[0].Name = "석탄";
            //chart1.Series[1].Name = "철광석";
            //chart1.Titles.Add("현재 재고");
            InitializeComponent();

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

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btn_renew_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(strConn);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT SUM(COAL),SUM(IRON) from stock";
            OracleDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            int coal = rdr.GetInt32(0);
            int iron = rdr.GetInt32(1);

            coal_stock.Text = coal.ToString();
            iron_stock.Text = iron.ToString();


            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, coal);
            chart1.Series[0].Points.AddXY(1, iron);
            chart1.Series[0].Points[0].LegendText = "철광석";
            chart1.Series[0].Points[1].LegendText = "석탄";
        }
    }
}

