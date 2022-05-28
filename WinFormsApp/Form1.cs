using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using WinFormsApp16.Forms;
using HZH_Controls.Controls;
using Newtonsoft.Json.Linq;

namespace WinFormsApp16
{
    public partial class FormMainMenu : Form
    {
        //필드
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public Form currentChildForm;
        
     
        

        //생성자
        public FormMainMenu()
        {
            InitializeComponent();
            //worker.DoWork += (sender, args) => PerformReading(); // 백그라운드로 실행할 메소드 이벤트 생성
            //worker.RunWorkerCompleted += (sender, args) => ReadingCompleted(); // 종료시 실행할 이벤트

            //                         //Show progress form in a main thread
            //waitForm.StartPosition = FormStartPosition.Manual;  //275, 84
            //waitForm.Location = new System.Drawing.Point(275, 84);
            switch (User.Role)
            {
                case "OPERATOR":
                    iconButton1.Visible = false;
                    break;
                case "GUEST":
                    btnOrder.Visible = false;
                    iconButton4.Visible = false;
                    iconButton5.Visible = false;
                    iconButton1.Visible = false;
                    break;
                    
            }
            
            


            OpenChildForm(new FormDashboard());
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMeau.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;

            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;

            // this는 Form1을 가리킴
            this.BackColor = Color.LightSteelBlue;
            this.Text = "myDigitalClock";

            label1.Text = DateTime.Now.ToString();
            label1.TextAlign = ContentAlignment.MiddleCenter;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //pictureBox3.Background = new SolidBrush(Color.FromArgb(50, 255, 0, 0));
            //button1.BackColor= Color.FromArgb(50, 255, 0, 0);
            //circularProgressBar1
            //BringToFront();
        }
        //void PerformReading()
        //{
        //    // 아래에 데이터 로딩 등 오래 걸리는 작업 
        //    Program.ac.MainForm.Invoke((MethodInvoker)delegate () {
        //        //Program.ac.MainForm.Visible = false;
        //        waitForm.ShowDialog();

        //    });
            
        //    Thread.Sleep(2000);
        //}

        //void ReadingCompleted()
        //{
        //    waitForm.Close(); //로딩폼 닫기
        //}
        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            label1.Text = DateTime.Now.ToString();
        }
        //옵션이라고 하긴함
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(130, 80, 100);
        }

        //메소드
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //버튼
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //icon current child form
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                // currentBtn.IconColor =  Color.FromArgb(172, 126, 241);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            
            
            childForm.BringToFront();
            childForm.Show();
            //waitForm.BringToFront();
            //worker.RunWorkerAsync(); // 백그라운드로 비동기 실행

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormDashboard());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            
            
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormOrder());
        }
        //메인 로고 버튼
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();

            Reset();
            OpenChildForm(new FormDashboard());
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false; // 홈로고 누르면 다 초기화되게 
        }

        //드래그 폼하기
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panerTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // t1.Abort();
            if (Program.receiveThread != null)
            {
                Program.receiveThread.Abort();
            }
            if (Program.sendThread != null) ConnectionHandler.isAlive = false;
            Application.Exit();

        }

        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

      

        

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormControl());
        }

        private void iconButton3_Click(object sender, EventArgs e) // 차트
        {
        }

        private void iconButton5_Click(object sender, EventArgs e) // 스케줄
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FormSearch());
        }

        private void iconButton1_Click(object sender, EventArgs e) // 시쿠리티
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormManage());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            //OpenChildForm(new FormExport());
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {

        }

       
    
    }

}
