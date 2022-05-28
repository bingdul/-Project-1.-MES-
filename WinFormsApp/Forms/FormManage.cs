using HZH_Controls.Controls;
using Newtonsoft.Json.Linq;
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
using System.ComponentModel;
using WinFormsApp16.etc;
using System.Diagnostics;

namespace WinFormsApp16.Forms
{
    public partial class FormManage : Form
    {
        public static List<DataGridViewColumnEntity> lstCulumns;
        public  List<object> lstSource;
        public List<object> luserlistSource;
        public FormManage()
        {
            InitializeComponent();


            JObject jObject = new JObject(
                new JProperty("SENDER_TYPE", "USER"),
                new JProperty("MESSAGE_TYPE", "ENTER_FORM_REQUEST"),
                new JProperty("FORM_TYPE", "MANAGE"),
                new JProperty("TOKEN", ConnectionHandler.token)
                , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
                );
            string result;
            result = jObject.ToString(Newtonsoft.Json.Formatting.None);
            ConnectionHandler.send(result);

            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "ID", Width = 15, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "TYPE", HeadText = "TYPE", Width = 15, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "NAME", HeadText = "NAME", Width = 15, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "MAC_ADDRESS", HeadText = "MAC_ADDRESS", Width = 15, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "IP", HeadText = "IP", Width = 15, WidthType = SizeType.Percent});
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "CONNECT_STATUS", HeadText = "CONNECT_STATUS", Width = 15, WidthType = SizeType.Percent });

            List<DataGridViewColumnEntity> lstCulumns2 = new List<DataGridViewColumnEntity>();
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "ID", Width = 15, WidthType = SizeType.Percent });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "NAME", HeadText = "NAME", Width = 15, WidthType = SizeType.Percent });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "ROLE", HeadText = "ROLE", Width = 15, WidthType = SizeType.Percent });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "ACCOUNT_STATUS", HeadText = "ACCOUNT_STATUS", Width = 15, WidthType = SizeType.Percent });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "CONNECT_STATUS", HeadText = "CONNECT_STATUS", Width = 15, WidthType = SizeType.Percent });
            
            this.ucDataGridView1.Columns = lstCulumns;
            this.ucDataGridView2.Columns = lstCulumns2;

            this.ucDataGridView1.IsShowCheckBox = false;
            this.ucDataGridView2.IsShowCheckBox = false;
            //            List<object> lstSource = new List<object>();
            lstSource = new List<object>();
            luserlistSource = new List<object>();
            //            for (int i = 0; i < 20; i++)
            //{
            //                TestModel model = new TestModel()
            //                {
            //                   ID = i.ToString(),

            //                    NAME = "name -" + i

            //                };
            //                lstSource.Add(model);
            //            }

            //            this.ucDataGridView1.DataSource = lstSource;
            //            this.ucDataGridView1.First();

        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,
      int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        private void FormSecurity_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 15, 15));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 15, 15));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 15, 15));
        }

        private void ucDataGridView1_ItemClick(object sender, DataGridViewEventArgs e)
        {
            Debug.WriteLine("안녕하세요");
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        //public void addRow() //table1
        //{
        //    table1.RowCount = table1.RowCount + 1;
        //    table1.Height = table1.Height+ 50;
        //    table1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // 

        //}

    }

   
    
}
