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

namespace WinFormsApp16.Forms
{
    public partial class FormSearch : Form
    {
        public static List<DataGridViewColumnEntity> lstCulumns;
        public List<object> lstSource2;
        public string ipValue = "";
        string date1 = "";
        string date2 ="";
        string com1 = "";
        string com2 = "";
        Button ipbox;
        Button date1_button,date2_button;
        Button comboBox1_button;
        Button comboBox2_button;
        public FormSearch()
        {
            InitializeComponent();
            JObject jObject = new JObject(
                new JProperty("SENDER_TYPE", "USER"),
                new JProperty("MESSAGE_TYPE", "ENTER_FORM_REQUEST"),
                new JProperty("FORM_TYPE", "SEARCH"),
                new JProperty("TOKEN", ConnectionHandler.token)
               , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
                );
            string result;
            result = jObject.ToString(Newtonsoft.Json.Formatting.None);
            ConnectionHandler.send(result);

            //-------------------<데이터 그리드 부분>-----------------------
            List<DataGridViewColumnEntity> lstCulumns2= new List<DataGridViewColumnEntity>();
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "ACCESS_IP", HeadText = "ACCESS_IP", Width = 15, WidthType = SizeType.Percent });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "CLIENT_TYPE", HeadText = "CLIENT_TYPE", Width = 15, WidthType = SizeType.Percent });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "LOG_LEVEL", HeadText = "LOG_LEVEL", Width = 15, WidthType = SizeType.Percent });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "INFORMATION", HeadText = "INFORMATION", Width = 15, WidthType = SizeType.Percent });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "ACTIVITY", HeadText = "ACTIVITY", Width = 15, WidthType = SizeType.Percent });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "TIMESTAMP", HeadText = "TIMESTAMP", Width = 15, WidthType = SizeType.Percent });

            this.ucDataGridView1.Columns = lstCulumns2;
            this.ucDataGridView1.IsShowCheckBox = false;
            lstSource2 = new List<object>();

            //--------------------< 콤보박스 부분>----------------------------
            string[] data = { "WARNING", "ERROR", "COMMON" };
            comboBox1.Items.AddRange(data);
            //comboBox1.SelectedIndex = 0;
            string[] data2 = { "USER","SENSOR","ACTUATOR" };
            comboBox2.Items.AddRange(data2);
            //
            




        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,
         int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        
            private void FormSearch_Load(object sender, EventArgs e)
        {
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 15, 15));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 15, 15));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JObject packeging = new JObject(
                new JProperty("ACCESS_IP",ipValue ),
                new JProperty("TIMESTAMP1",date1),
                new JProperty("TIMESTAMP2", date2),
                new JProperty("LOG_LEVEL", com1),
                new JProperty("CLIENT_TYPE", com2)

                );
            JObject jObject2 = new JObject(
                new JProperty("SENDER_TYPE", "USER"),
                new JProperty("MESSAGE_TYPE", "SEARCH_LOG_REQUEST"),
                new JProperty("FORM_TYPE", "SEARCH"),
                new JProperty("TOKEN", ConnectionHandler.token) , 
                new JProperty("IP", ConnectionHandler.GetExternalIPAddress()),
                new JProperty("QUERY", packeging )
                );
            string result;
            result = jObject2.ToString(Newtonsoft.Json.Formatting.None);
            ConnectionHandler.send(result);

            //ConnectionHandler.searchUpdateButton();
            
        }

        private void ipAdd_button_Click(object sender, EventArgs e)
        {
            ipValue = textBox1.Text;
            if (ipbox == null) ipbox = new Button();
            // ipAdd_button.Text = ipValue+" X";
            //button.Click += 
            ipbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(93)))));
            ipbox.Dock = System.Windows.Forms.DockStyle.Left;
            ipbox.FlatAppearance.BorderSize = 0;
            ipbox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ipbox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            ipbox.Location = new System.Drawing.Point(0, 0);
            //ipAdd_button.Name = "button3";
            ipbox.Size = new System.Drawing.Size(155, 46);
            ipbox.TabIndex = 51;
            ipbox.Text = ipValue + " X";
            ipbox.UseVisualStyleBackColor = false;

            ipbox.Click += (object s, EventArgs e2) =>
            {
                ipValue = "";
                ((Button)s).Dispose();
                MessageBox.Show("삭제됨");
            };

            panel5.Controls.Add(ipbox);

        }
        private void click(object sender, System.EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            //string str = string.Format("{0}월 {1}일을 선택", dt.Month, dt.Day);
            date1 = dt.ToString("yyyy-MM-dd");

            if(date1_button==null) date1_button = new Button();
            // ipAdd_button.Text = ipValue+" X";
            //button.Click += 
            date1_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(93)))));
            date1_button.Dock = System.Windows.Forms.DockStyle.Left;
            date1_button.FlatAppearance.BorderSize = 0;
            date1_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            date1_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            date1_button.Location = new System.Drawing.Point(0, 0);
            //ipAdd_button.Name = "button3";
            date1_button.Size = new System.Drawing.Size(155, 46);
            date1_button.TabIndex = 51;
            date1_button.Text = date1 + "~   X";
            date1_button.UseVisualStyleBackColor = false;

            date1_button.Click += (object s, EventArgs e2) =>
            {
                date1 = "";
                ((Button)s).Dispose();
                MessageBox.Show("삭제됨");
            };

            panel5.Controls.Add(date1_button);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt2 = dateTimePicker2.Value;
            //string str = string.Format("{0}월 {1}일을 선택", dt.Month, dt.Day);
            date2 = dt2.ToString("yyyy-MM-dd");


            if(date2_button==null) date2_button = new Button();
            // ipAdd_button.Text = ipValue+" X";
            //button.Click += 
            date2_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(93)))));
            date2_button.Dock = System.Windows.Forms.DockStyle.Left;
            date2_button.FlatAppearance.BorderSize = 0;
            date2_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            date2_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            date2_button.Location = new System.Drawing.Point(0, 0);
            //ipAdd_button.Name = "button3";
            date2_button.Size = new System.Drawing.Size(155, 46);
            date2_button.TabIndex = 51;
            date2_button.Text ="~"+ date2 + "  X";
            date2_button.UseVisualStyleBackColor = false;

            date2_button.Click += (object s, EventArgs e2) =>
            {
                date2 = "";
                ((Button)s).Dispose();
                MessageBox.Show("삭제됨");
            };

            panel5.Controls.Add(date2_button);
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Button dateAdd_button = new Button();
        //    // ipAdd_button.Text = ipValue+" X";
        //    //button.Click += 
        //    dateAdd_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(93)))));
        //    dateAdd_button.Dock = System.Windows.Forms.DockStyle.Left;
        //    dateAdd_button.FlatAppearance.BorderSize = 0;
        //    dateAdd_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        //    dateAdd_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
        //    dateAdd_button.Location = new System.Drawing.Point(0, 0);
        //    //ipAdd_button.Name = "button3";
        //    dateAdd_button.Size = new System.Drawing.Size(155, 46);
        //    dateAdd_button.TabIndex = 51;
        //    dateAdd_button.Text = date1+"~"+date2 + " X";
        //    dateAdd_button.UseVisualStyleBackColor = false;

        //    dateAdd_button.Click += (object s, EventArgs e2) =>
        //    {
        //        ((Button)s).Dispose();
        //        MessageBox.Show("삭제됨");
        //    };

        //    panel5.Controls.Add(dateAdd_button);
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            com1 = comboBox1.SelectedItem.ToString();

            if(comboBox1_button==null)comboBox1_button = new Button();
            // ipAdd_button.Text = ipValue+" X";
            //button.Click += 
            comboBox1_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(93)))));
            comboBox1_button.Dock = System.Windows.Forms.DockStyle.Left;
            comboBox1_button.FlatAppearance.BorderSize = 0;
            comboBox1_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            comboBox1_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            comboBox1_button.Location = new System.Drawing.Point(0, 0);
            //ipAdd_button.Name = "button3";
            comboBox1_button.Size = new System.Drawing.Size(155, 46);
            comboBox1_button.TabIndex = 51;
            comboBox1_button.Text = com1 + "    X";
            comboBox1_button.UseVisualStyleBackColor = false;

            comboBox1_button.Click += (object s, EventArgs e2) =>
            {
                com1 = "";
                ((Button)s).Dispose();
                MessageBox.Show("삭제됨");
            };

            panel5.Controls.Add(comboBox1_button);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            com2 = comboBox2.SelectedItem.ToString();

            if(comboBox2_button==null)comboBox2_button = new Button();
            // ipAdd_button.Text = ipValue+" X";
            //button.Click += 
            comboBox2_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(93)))));
            comboBox2_button.Dock = System.Windows.Forms.DockStyle.Left;
            comboBox2_button.FlatAppearance.BorderSize = 0;
            comboBox2_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            comboBox2_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            comboBox2_button.Location = new System.Drawing.Point(0, 0);
            //ipAdd_button.Name = "button3";
            comboBox2_button.Size = new System.Drawing.Size(155, 46);
            comboBox2_button.TabIndex = 51;
            comboBox2_button.Text = com2 + "    X";
            comboBox2_button.UseVisualStyleBackColor = false;

            comboBox2_button.Click += (object s, EventArgs e2) =>
            {
                com2 = "";
                ((Button)s).Dispose();
                MessageBox.Show("삭제됨");
            };

            panel5.Controls.Add(comboBox2_button);
        }
    }
}
