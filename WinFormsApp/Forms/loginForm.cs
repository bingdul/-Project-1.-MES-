using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WinFormsApp16.Forms;
namespace WinFormsApp16
{
    public partial class loginForm : Form
    {
        JObject jObject;
        JObject jObject1;
        private Form currentChildForm;
        public static string id = "";
        public loginForm()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            //Thread t1 = new Thread(new ThreadStart(trans));
            //t1.Start();
            trans();

            //OpenChildForm(new FormMainMenu());


            //this.Close();
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.Show();
        }

        public void trans()
        {
            string answer;

            string ip = "192.168.100.2";
            string port = "8000";
            ConnectionHandler.Client = new TcpClient(ip, Int32.Parse(port));
            ConnectionHandler.Ns = ConnectionHandler.Client.GetStream();
            ConnectionHandler.rd = new StreamReader(ConnectionHandler.Ns, Encoding.UTF8);

            //string message = "서버 연결을 확인합니다.";
            id = ID_textbox.Text;
            string password = password_textbox.Text;
            //string information ="{  \"SENDER_TYPE\" : \"USER\", \"MESSAGE_TYPE\" : \"LOGIN_REQUEST\"," +
            //    "                           \"ID\" :  \"" + id + "\",     \"PASSWORD\" :  \"" + password + "\"}";
            //jObject = JObject.Parse(information);

            jObject = new JObject(
                new JProperty("SENDER_TYPE", "USER"),
                new JProperty("MESSAGE_TYPE", "LOGIN_REQUEST"),
                new JProperty("ID", id),
                new JProperty("PASSWORD", password)
                , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
                );
            string result = jObject.ToString(Newtonsoft.Json.Formatting.None);
            //Debug.WriteLine(result);
            ConnectionHandler.send(result);
            string s;
            s = ConnectionHandler.rd.ReadLine();
            s = ConnectionHandler.decrypt(s); //데이터 복호화
            JObject jObject1 = JObject.Parse(s);
            if ((string)jObject1["MESSAGE_TYPE"] == "LOGIN_RESPONSE")
            {
                ConnectionHandler.rd.Close();
                ConnectionHandler.Ns.Close();
                ConnectionHandler.Client.Close();
                ConnectionHandler.login(jObject1);
            }
        }

        //-------------------------------------<모서리 둥글게>------------------------------------------
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,
       int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        private void loginForm_Load(object sender, EventArgs e)
        {
            //panel8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel8.Width, panel8.Height, 15, 15));
        }

        private void signup_login_Click(object sender, EventArgs e)
        {
            FormSignUp formSignUp = new FormSignUp();
            formSignUp.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.receiveThread != null) { ConnectionHandler.rd.Close(); Program.receiveThread.Abort(); }
            if (Program.sendThread != null) Program.sendThread.Abort();
            Application.Exit();
        }









        //---------------------------------------------------------------------------------------------
    }
        
}
