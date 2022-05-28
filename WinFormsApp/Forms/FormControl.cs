using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp16.Forms
{
    public partial class FormControl : Form
    {
        JObject jObject;
        int belt1_value;
        int belt2_value;
        int heater_value;
        public FormControl()
        {
            InitializeComponent();
            JObject jObject = new JObject(
                new JProperty("SENDER_TYPE", "USER"),
                new JProperty("MESSAGE_TYPE", "ENTER_FORM_REQUEST"),
                new JProperty("FORM_TYPE", "CONTROL"),
                new JProperty("TOKEN", ConnectionHandler.token)
                , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
                );
            string result;
            result = jObject.ToString(Newtonsoft.Json.Formatting.None);
            ConnectionHandler.send(result);
            //Thread t1 = new Thread(new ThreadStart(transe));
            //t1.Start();
            //reset();

            //---------------- 폼접속시 db에서 데이터 불러오기--------------


        }
        private void reset()
        {
            //pictureBox2.Visible = false;
        }
        private void FormControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toggleButton1_CheckedChanged(object sender, EventArgs e)
        {
        
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        // 모서리둥글게 --------------------------------------
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,
         int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        private void FormControl_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 15, 15));
        }



        private void toggleButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleButton2_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            jObject = new JObject(
            new JProperty("SENDER_TYPE", "USER"),
            new JProperty("MESSAGE_TYPE", "CONTROL_REQUEST"),
            new JProperty("FORM_TYPE","CONTROL"),
            new JProperty("TARGET", "BELT_ONE"),
            new JProperty("POWER", toggleButton1.Checked ? "ON" : "OFF"),
            new JProperty("VALUE",belt1_value),
            new JProperty("TOKEN", ConnectionHandler.token)
            , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
            );
            string result = jObject.ToString(Newtonsoft.Json.Formatting.None);
            //Debug.WriteLine(result);
            ConnectionHandler.send(result);
        }


        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            jObject = new JObject(
           new JProperty("SENDER_TYPE", "USER"),
           new JProperty("MESSAGE_TYPE", "CONTROL_REQUEST"),
           new JProperty("FORM_TYPE", "CONTROL"),
           new JProperty("TARGET", "HEATER"),
           new JProperty("POWER", toggleButton3.Checked ? "ON" : "OFF"),
           new JProperty("VALUE",heater_value),
           new JProperty("TOKEN", ConnectionHandler.token)
           , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
           );
            string result = jObject.ToString(Newtonsoft.Json.Formatting.None);
            //Debug.WriteLine(result);
            ConnectionHandler.send(result);
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            jObject = new JObject(
         new JProperty("SENDER_TYPE", "USER"),
         new JProperty("MESSAGE_TYPE", "CONTROL_REQUEST"),
         new JProperty("FORM_TYPE", "CONTROL"),
         new JProperty("TARGET", "BELT_TWO"),
         new JProperty("POWER", toggleButton2.Checked ? "ON" : "OFF"),
         new JProperty("VALUE", belt2_value),
         new JProperty("TOKEN",ConnectionHandler.token)
         , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
         );
            string result = jObject.ToString(Newtonsoft.Json.Formatting.None);
            //Debug.WriteLine(result);
            ConnectionHandler.send(result);
            //if (toggleButton2.Checked)
            //{
            //    pictureBox2.Visible = true;
            //}
            //else
            //{
            //    reset();
            //}
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if( trackBar1.Value == 0)
            {
                belt1_value =0;
            }
            if (trackBar1.Value == 1)
            {
                belt1_value =1;
            }
            if (trackBar1.Value == 2)
            {
                belt1_value = 2;
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (trackBar3.Value == 0)
            {
                belt2_value = 0;
            }
            if (trackBar3.Value == 1)
            {
                belt2_value =1;
            }
            if (trackBar3.Value == 2)
            {
                belt2_value =2;
            }
        }
    }
}
