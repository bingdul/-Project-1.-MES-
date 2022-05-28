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

namespace FormMainMenu_2
{


    public partial class FormMainMenu : Form
    {
        OracleConnection conn;
        OracleConnection conn1;
        NetworkStream stream;

            // 명령 객체 생성
        OracleCommand cmd;
        OracleCommand cmd1;
        TcpClient client;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        //int coilNum = 0; // 코일의 갯수

        //서버선언부---------------------
        string str = "";
        Thread serverThread;
        //--------------------------------------

        string NUM ;
        string NAME ;
        string STOCK; 
           
        string NUM1;
        string NAME1;
        string STOCK1;
        
        string NUM2;
        string NAME2 ;
        string STOCK2 ;

        string IRON;
        string COAL;
        string IRON2;
        string COAL2;
        string IRON3;
        string COAL3;
        
        
        int coilN=0;
        int churN=0;
        int hungN=0;

        bool isbutton = false;

    
        //생성자 초기설정
        public FormMainMenu()

        {
            Database db = new Database();
            conn = db.dbConnect();

            Database db1 = new Database();
            conn1 = db1.dbConnect();

            InitializeComponent();
            random = new Random();
            btnChildForm.Visible = false;
            Color c = Color.White;
            this.BackColor = c;

            //이미지 잠시 안보이기
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox14.Visible = false; // 소로 톱니바퀴
            pictureBox15.Visible = false;
            pictureBox16.Visible = false; //쇳물
            pictureBox18.Visible = false; // 쇳물2
            label13.Visible = false;//용광로 가동중 라벨
            label1.Visible = false;
            label14.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            label15.Visible = false;
            label4.Visible = false;
            pictureBox5.Visible = false;
           //Thread th = new Thread(Movebal);
           //th.Start();
           serverThread = new Thread(Init);
            serverThread.Start();

            // textBox1.Text = "<참고>\n" + "1. 석탄 10t + 철광석 10t = 공장 1번 가동\n" + "2. 공장 1번 가동 = 50개 생산";

            //더블 버퍼링 -- 안쓸듯하다
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            verticalProgressBar2.Style = ProgressBarStyle.Continuous;
            verticalProgressBar2.Minimum = 0;
            verticalProgressBar2.Maximum = 200;
            verticalProgressBar2.Step = 1;
            verticalProgressBar2.Value = 1;
            
            verticalProgressBar2.ForeColor = Color.Green;


            verticalProgressBar1.Style = ProgressBarStyle.Continuous;
            verticalProgressBar1.Minimum = 0;
            verticalProgressBar1.Maximum = 200;
            verticalProgressBar1.Step = 4;
            verticalProgressBar1.Value = 1;
            verticalProgressBar1.ForeColor = Color.Red;


            //1 4 8
            button1.Enabled = false;
            button4.Enabled = false;
            button8.Enabled = false;
            // 이미지 겹치기
            //pictureBox12.Controls.Add(pictureBox1);
            //pictureBox1.BackColor = Color.Transparent;

        }
        
        

        // 여기부터는 디자인 부분입니다 -- 폼끼리 넘어갈때 참고할수있을듯하다

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("맑은 고딕", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    
                    lbltitles.BackColor = color;
                    label13.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbltitles.Text = childForm.Text;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Forms.FormProduct(),sender);
            //OpenChildForm(new Forms.FormNotifications(), sender);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormOrders(), sender);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormCustomers(), sender);
        }

        private void btnReporting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormReporting(), sender);
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Forms.FormNotifications(), sender);
            ja(str);
        }

        private void bntSetting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSetting(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lbltitles.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            lbltitles.BackColor = Color.FromArgb(0, 150, 136);
            label13.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnChildForm.Visible = false;
        }
        // --------------디자인 끝-----------------------------------------

        //----------------동희코드 시작 ------------------------------------
        
        //용광로 프로그래스바 코드
        void yong_pro()
        {

            


            int ii = 0;
            while (ii++ < 200)
            {
                verticalProgressBar1.PerformStep();
                verticalProgressBar2.PerformStep();
                
                Thread.Sleep(10);
                //verticalProgressBar2.
            }
            //t2.Join();
            //verticalProgressBar2.Visible = true;

        }
        //
        void yong_pro2()
        {

            
            verticalProgressBar2.Step = -1;
            


            
            verticalProgressBar1.Step = -4;
            


            int ii = 200;
            while (ii-- > 0)
            {
                verticalProgressBar1.PerformStep();
                verticalProgressBar2.PerformStep();

                Thread.Sleep(10);
                //verticalProgressBar2.
            }
            //t2.Join();
            //verticalProgressBar2.Visible = true;

        }


        //-------------< 깜빡깜빡 >---------------------------
        // 자원투입
        public void cambak()
        {
            for (int i = 0; i < 10; i++)
            {
                pictureBox25.Load(@"Resources\켜진등.png");
                Delay(150);
                pictureBox25.Load(@"Resources\꺼진등.png");
                Delay(150);

            }
            pictureBox25.Load(@"Resources\켜진등.png");
        }
        //용광로가동
        public void cambak1()
        {
            for (int i = 0; i < 10; i++)
            {
                pictureBox26.Load(@"Resources\켜진등.png");
                Delay(150);
                pictureBox26.Load(@"Resources\꺼진등.png");
                Delay(150);

            }
            pictureBox26.Load(@"Resources\켜진등.png");
        }
        //제 1통로
        public void cambak2()
        {
            for (int i = 0; i < 10; i++)
            {
                pictureBox27.Load(@"Resources\켜진등.png");
                Delay(150);
                pictureBox27.Load(@"Resources\꺼진등.png");
                Delay(150);

            }
            pictureBox27.Load(@"Resources\켜진등.png");
        }
        //전로가동
        public void cambak3()
        {
            for (int i = 0; i < 10; i++)
            {
                pictureBox28.Load(@"Resources\켜진등.png");
                Delay(150);
                pictureBox28.Load(@"Resources\꺼진등.png");
                Delay(150);

            }
            pictureBox28.Load(@"Resources\켜진등.png");
        }
        //제 2통로
        public void cambak4()
        {
            for (int i = 0; i < 10; i++)
            {
                pictureBox29.Load(@"Resources\켜진등.png");
                Delay(150);
                pictureBox29.Load(@"Resources\꺼진등.png");
                Delay(150);

            }
            pictureBox29.Load(@"Resources\켜진등.png");
        }
        //연주 가동
        public void cambak5()
        {
            for (int i = 0; i < 10; i++)
            {
                pictureBox30.Load(@"Resources\켜진등.png");
                Delay(150);
                pictureBox30.Load(@"Resources\꺼진등.png");
                Delay(150);

            }
            pictureBox30.Load(@"Resources\켜진등.png");
        }
        //압연가동
        public void cambak6()
        {
            for (int i = 0; i < 10; i++)
            {
                pictureBox31.Load(@"Resources\켜진등.png");
                Delay(150);
                pictureBox31.Load(@"Resources\꺼진등.png");
                Delay(150);

            }
            pictureBox31.Load(@"Resources\켜진등.png");
        }
        //제품생산
        public void cambak7()
        {
            for (int i = 0; i < 10; i++)
            {
                pictureBox32.Load(@"Resources\켜진등.png");
                Delay(150);
                pictureBox32.Load(@"Resources\꺼진등.png");
                Delay(150);

            }
            pictureBox32.Load(@"Resources\켜진등.png");
        }
        //-----------------------------------------------------



        //코일생산
        public void Movebal()   
        {

            pictureBox1.Load(@"Resources\용광로1.png");

            //자원투입깜빡
            Thread cam = new Thread(cambak);
            cam.Start();
            label4.Visible =true;

            //철광석 움직임
            Thread tt = new Thread(move);
            tt.Start();
           

            Delay(5000);

            //용광로 불꽃과 톱니바퀴보이게하기
            Thread cam1 = new Thread(cambak1);
            cam1.Start();
            

            pictureBox1.Load(@"Resources\용광로움짤.gif");
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            label13.Visible = true;


            //tt.Join();

            Delay(5000);
            
            // 용광로 용해율 온도 프로그래스바
            //yong_pro();
            Thread dd = new Thread(yong_pro);
            dd.Start();
     
            Delay(5000);


            // 통로1 애니메이션 활성화와 쇳불이미지의 이동

            Thread cam2 = new Thread(cambak2);
            cam2.Start();
    
            pictureBox2.Load(@"Resources\통로1애니수정.gif");
            pictureBox16.Visible = true;
            Thread aa = new Thread(moveIronWater);
            aa.Start();
         
            Delay(5000);


            //전로 가동중으로 변경
            Thread cam3 = new Thread(cambak3);
            cam3.Start();
          
            pictureBox3.Load(@"Resources\소로가동중.gif");
            label1.Visible = true;
            pictureBox20.Visible = true;
            pictureBox14.Visible = true;
            Delay(10000);


            //통로2 애니메이션으로 변경
            Thread cam4 = new Thread(cambak4);
            cam4.Start();
           
            pictureBox9.Load(@"Resources\통로2애니최종.gif");
            pictureBox18.Visible = true;
            Thread bb = new Thread(moveIronWater2);
            bb.Start();
          
            Delay(8000);


            //연주 가동중으로 변경
            Thread cam5 = new Thread(cambak5);
            cam5.Start();
            
            pictureBox8.Load(@"Resources\연주애니.gif");
            pictureBox21.Visible = true;
            label14.Visible = true;
            pictureBox5.Visible = true;
            Delay(5000);

            //압연 가동중으로 변경
            Thread cam6 = new Thread(cambak6);
            cam6.Start();
           
            pictureBox22.Load(@"Resources\압연애니.gif");
            label15.Visible = true;
            Delay(3000);

            //코일 생산후 딜레이 마무리
            Thread cam7 = new Thread(cambak7);
            cam7.Start();
       
            pictureBox23.Visible = true;
            pictureBox23.Load(@"Resources\코일.png");
            pictureBox32.Load(@"Resources\꺼진등.png");
            Delay(3000);
            first();
            coilN = 50;

            // 완제품에 추가 50개
            connect();
            cmd.CommandText = "UPDATE PRODUCT SET DROGBA = DROGBA +" + coilN + "WHERE ID = 1";

           cmd.ExecuteNonQuery();
            // 재료 각각 10씩 소모
            connect2();
            cmd1.CommandText = "UPDATE STOCK SET IRON =IRON- " + 10+"  WHERE OXY = 1";
            cmd1.ExecuteNonQuery();

            cmd1.CommandText = "UPDATE STOCK SET COAL =COAL- " + 10 + " WHERE OXY = 1";
            cmd1.ExecuteNonQuery();
            coilN = 0;
            Delay(3000);
            dd.Abort();
            
        }


        //철근생산
        public void Movebal2()
        {

            pictureBox1.Load(@"Resources\용광로1.png");

            //자원투입깜빡
            Thread cam = new Thread(cambak);
            cam.Start();
            label4.Visible = true;
            //철광석 움직임
            Thread tt = new Thread(move);
            tt.Start();


            Delay(5000);

            //용광로 불꽃과 톱니바퀴보이게하기
            Thread cam1 = new Thread(cambak1);
            cam1.Start();

            pictureBox1.Load(@"Resources\용광로움짤.gif");
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            label13.Visible = true;


            //tt.Join();

            Delay(5000);

            // 용광로 용해율 온도 프로그래스바
            //yong_pro();
            Thread dd = new Thread(yong_pro);
            dd.Start();

            Delay(5000);


            // 통로1 애니메이션 활성화와 쇳불이미지의 이동

            Thread cam2 = new Thread(cambak2);
            cam2.Start();
            pictureBox2.Load(@"Resources\통로1애니수정.gif");
            pictureBox16.Visible = true;
            Thread aa = new Thread(moveIronWater);
            aa.Start();
            Delay(5000);


            //전로 가동중으로 변경
            Thread cam3 = new Thread(cambak3);
            cam3.Start();
            pictureBox3.Load(@"Resources\소로가동중.gif");
            label1.Visible = true;
            pictureBox20.Visible = true;
            pictureBox14.Visible = true;
            Delay(10000);


            //통로2 애니메이션으로 변경
            Thread cam4 = new Thread(cambak4);
            cam4.Start();
            pictureBox9.Load(@"Resources\통로2애니최종.gif");
            pictureBox18.Visible = true;
            Thread bb = new Thread(moveIronWater2);
            bb.Start();
            Delay(8000);


            //연주 가동중으로 변경
            Thread cam5 = new Thread(cambak5);
            cam5.Start();
            pictureBox8.Load(@"Resources\연주애니.gif");
            pictureBox21.Visible = true;
            label14.Visible = true;
            pictureBox5.Visible = true;
            Delay(5000);

            //압연 가동중으로 변경
            Thread cam6 = new Thread(cambak6);
            cam6.Start();
            pictureBox22.Load(@"Resources\압연애니.gif");
            label15.Visible = true;
            Delay(3000);

            //철근 생산후 딜레이 마무리
            Thread cam7 = new Thread(cambak7);
            cam7.Start();
            pictureBox23.Visible = true;
            pictureBox23.Load(@"Resources\철근.png");
            pictureBox32.Load(@"Resources\꺼진등.png");
            Delay(3000);
            first();
            churN = 50;

            // 완제품에 추가 50개
            connect();
            cmd.CommandText = "UPDATE PRODUCT SET DROGBA = DROGBA +" + churN + "WHERE ID = 2";

            cmd.ExecuteNonQuery();
            // 재료 각각 10씩 소모
            connect2();
            cmd1.CommandText = "UPDATE STOCK SET IRON =IRON- " + 10 + "  WHERE OXY = 2";
            cmd1.ExecuteNonQuery();

            cmd1.CommandText = "UPDATE STOCK SET COAL =COAL- " + 10 + " WHERE OXY = 2";
            cmd1.ExecuteNonQuery();

            churN = 0;
            Delay(3000);
            dd.Abort();

        }

        //형강생산
        public void Movebal3()
        {

            pictureBox1.Load(@"Resources\용광로1.png");

            //자원투입깜빡
            Thread cam = new Thread(cambak);
            cam.Start();
            label4.Visible = true;
            //철광석 움직임
            Thread tt = new Thread(move);
            tt.Start();


            Delay(5000);

            //용광로 불꽃과 톱니바퀴보이게하기
            Thread cam1 = new Thread(cambak1);
            cam1.Start();

            pictureBox1.Load(@"Resources\용광로움짤.gif");
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            label13.Visible = true;


            //tt.Join();

            Delay(5000);

            // 용광로 용해율 온도 프로그래스바
            //yong_pro();
            Thread dd = new Thread(yong_pro);
            dd.Start();

            Delay(5000);


            // 통로1 애니메이션 활성화와 쇳불이미지의 이동

            Thread cam2 = new Thread(cambak2);
            cam2.Start();
            pictureBox2.Load(@"Resources\통로1애니수정.gif");
            pictureBox16.Visible = true;
            Thread aa = new Thread(moveIronWater);
            aa.Start();
            Delay(5000);


            //전로 가동중으로 변경
            Thread cam3 = new Thread(cambak3);
            cam3.Start();
            pictureBox3.Load(@"Resources\소로가동중.gif");
            label1.Visible = true;
            pictureBox20.Visible = true;
            pictureBox14.Visible = true;
            Delay(10000);


            //통로2 애니메이션으로 변경
            Thread cam4 = new Thread(cambak4);
            cam4.Start();
            pictureBox9.Load(@"Resources\통로2애니최종.gif");
            pictureBox18.Visible = true;
            Thread bb = new Thread(moveIronWater2);
            bb.Start();
            Delay(8000);


            //연주 가동중으로 변경
            Thread cam5 = new Thread(cambak5);
            cam5.Start();
            pictureBox8.Load(@"Resources\연주애니.gif");
            pictureBox21.Visible = true;
            label14.Visible = true;
            pictureBox5.Visible = true;
            Delay(5000);

            //압연 가동중으로 변경
            Thread cam6 = new Thread(cambak6);
            cam6.Start();
            pictureBox22.Load(@"Resources\압연애니.gif");
            label15.Visible = true;
            Delay(3000);

            //철근 생산후 딜레이 마무리
            Thread cam7 = new Thread(cambak7);
            cam7.Start();
            pictureBox23.Visible = true;
            pictureBox23.Load(@"Resources\형강.png");
            pictureBox32.Load(@"Resources\꺼진등.png");
            Delay(3000);
            first();
            hungN = 50;

            connect();
            cmd.CommandText = "UPDATE PRODUCT SET DROGBA = DROGBA +" + churN + "WHERE ID = 3";

            cmd.ExecuteNonQuery();
            // 재료 각각 10씩 소모
            connect2();
            cmd1.CommandText = "UPDATE STOCK SET IRON =IRON- " + 10 + "  WHERE OXY = 3";
            cmd1.ExecuteNonQuery();

            cmd1.CommandText = "UPDATE STOCK SET COAL =COAL- " + 10 + " WHERE OXY = 3";
            cmd1.ExecuteNonQuery();
            hungN = 0;
            Delay(3000);
            dd.Abort();
        }


            //통로 1쇳물 움직이는 메소드
            public void moveIronWater()
        {
            int i = 416;
            int j = 503;
            
            pictureBox16.Location = new Point(i, j);
            for (int iii = 0; iii < 10; iii++)
            {

                while (j <545 )
                {
                    j += 1;
                    Thread.Sleep(2);
                    pictureBox16.Location = new Point(i, j);
                }
                while (i < 592)
                {
                    i += 1;
                    Thread.Sleep(2);
                    pictureBox16.Location = new Point(i, j);
                }
                while (j < 590)
                {
                    j += 1;
                    Thread.Sleep(2);
                    pictureBox16.Location = new Point(i, j);
                }
                i = 416;
                j = 503;
            }
            pictureBox16.Visible = false;
        }
       
        
        //통로 2쇳물 움직이는 메소드
        public void moveIronWater2()
        {
            int i = 693;  //693, 657
            int j = 657;

            pictureBox18.Location = new Point(i, j);

            for (int iii = 0; iii < 10; iii++)
            {
                while (i < 733)
                {
                    i += 1;
                    Thread.Sleep(2);
                    pictureBox18.Location = new Point(i, j);
                }
                while (j > 150)
                {
                    j -= 1;
                    Thread.Sleep(2);
                    pictureBox18.Location = new Point(i, j);
                }
                while (i < 795)
                {
                    i += 1;
                    Thread.Sleep(2);
                    pictureBox18.Location = new Point(i, j);
                }
                i = 693;
                j = 657;
            }

            pictureBox18.Visible = false;
        }
        
        
        //딜레이 메소드
        private static DateTime Delay(int MS)

        {

            DateTime ThisMoment = DateTime.Now;

            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);

            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)

            {

                System.Windows.Forms.Application.DoEvents();

                ThisMoment = DateTime.Now;

            }

            return DateTime.Now;

        }

       
        //철광석 움직이는 메소드
        public void move() 
        {
            int i, j;



            i = 163;
            j = 458;
            pictureBox12.Visible = true;

            pictureBox12.Location = new Point(i, j);

            while (i < 237 && j > 80)//230
            {
                i += 1;
                j -= 2;
                Thread.Sleep(1);
                pictureBox12.Location = new Point(i, j);
            }
            while (i < 387 && j > 80)//230
            {
                i += 1;
                j -= 1;
                Thread.Sleep(1);
                pictureBox12.Location = new Point(i, j);
            }

            //마지막에 철광석이미지 사라지게하기
            pictureBox12.Visible = false;
        }

        // 모든 이미지 초기상태로 메소드
        public void first()
        {
            
            verticalProgressBar2.Style = ProgressBarStyle.Continuous;
            verticalProgressBar2.Minimum = 0;
            verticalProgressBar2.Maximum = 200;
            verticalProgressBar2.Step = 1;
            verticalProgressBar2.Value = 1;

            verticalProgressBar2.ForeColor = Color.Green;


            verticalProgressBar1.Style = ProgressBarStyle.Continuous;
            verticalProgressBar1.Minimum = 0;
            verticalProgressBar1.Maximum = 200;
            verticalProgressBar1.Step = 4;
            verticalProgressBar1.Value = 1;
            verticalProgressBar1.ForeColor = Color.Red;

            //스텝 원래대로 하기

            pictureBox5.Visible = false; ;
            isbutton = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox14.Visible = false; // 소로 톱니바퀴
            pictureBox15.Visible = false;
            pictureBox16.Visible = false; //쇳물
            pictureBox18.Visible = false; // 쇳물2
            label13.Visible = false;//용광로 가동중 라벨
            label1.Visible = false;
            label14.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            label15.Visible = false;
            pictureBox23.Visible = false;
            label4.Visible = false;
            pictureBox2.Load(@"Resources\통로1.png");
            pictureBox9.Load(@"Resources\new통로2.png");
            pictureBox1.Load(@"Resources\용광로가동대기.png");
            pictureBox3.Load(@"Resources\소로가동대기.png");
            pictureBox8.Load(@"Resources\연주가동대기.png");
            pictureBox22.Load(@"Resources\압연1.png");

            pictureBox24.Load(@"Resources\꺼진등.png");
            pictureBox25.Load(@"Resources\꺼진등.png");
            pictureBox26.Load(@"Resources\꺼진등.png");
            pictureBox27.Load(@"Resources\꺼진등.png");
            pictureBox28.Load(@"Resources\꺼진등.png");
            pictureBox29.Load(@"Resources\꺼진등.png");
            pictureBox30.Load(@"Resources\꺼진등.png");
            pictureBox31.Load(@"Resources\꺼진등.png");
            pictureBox32.Load(@"Resources\꺼진등.png");

        }


        //-----------버튼 이벤트-------------------


        // 공장 가동 버튼
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Load(@"Resources\용광로가동대기.png");
            //pictureBox6.Visible = true;
            //pictureBox7.Visible = true;
            button1.Enabled = true;
            button4.Enabled = true;
            button8.Enabled = true;
            isbutton = true;
            //
            pictureBox3.Load(@"Resources\소로가동대기.png");
            //pictureBox14.Visible = true;

            pictureBox8.Load(@"Resources\연주가동대기.png");
            //pictureBox15.Visible = true;

            pictureBox24.Load(@"Resources\켜진등.png");
        }
        
        //용광로 빙글빙글
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        
        // 용광로 불꽃
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

       // 코일생산 버튼 ----- 전체생산
        private void button1_Click_1(object sender, EventArgs e)
        {
        Movebal();
           /* ttt1 = new Thread(Movebal);
           
            ttt1.Start();
           // ttt1.Join();*/
            
            
        }
        //철근생산 버튼 
        private void button4_Click(object sender, EventArgs e)
        {
            //ttt1 = new Thread(Movebal2);
            Movebal2();
            //ttt1.Start();
        }
        //용광로 
        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void verticalProgressBar2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void verticalProgressBar1_Click(object sender, EventArgs e)
        {

        }
        // 쇳물 이미지
        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }
        //통로2
        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //mainForm.ShowDialog();
            if (serverThread.IsAlive) serverThread.Interrupt();
            this.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }


        //--------------------서버---------------------------
       

        private void tb_recv_msg_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            ja(str);
        }
        private void Init()
        { 

            string bintIp = "127.0.0.1";
            const int bindPort = 5458;
            TcpListener server = null;

            IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bintIp), bindPort);
            //서버 만들기, 주소바인딩~!!!
            server = new TcpListener(localAddress);
            //서버실행
            server.Start();
            //Console.WriteLine("자동차 서버");
            //클라이언트의 연결 기다림
            while (true)
            {
                client = server.AcceptTcpClient(); // Block IO

                ((IPEndPoint)client.Client.RemoteEndPoint).ToString();

                stream = client.GetStream();//NetworkStream stream

                int length;
                string data = null;
                byte[] bytes = new byte[256];

                while ((length = stream.Read(bytes, 0, bytes.Length)) != 0) // read를 읽고 더이상 읽을 내용이 없다
                {
                    data = Encoding.Default.GetString(bytes, 0, length);// a[0],a[1],a[2]를 받음

                    
                    str = data; // " 서버 -> 클라이언트로 보내고 싶은 데이터 " 

                    byte[] msg = Encoding.Default.GetBytes(str);
                    stream.Write(msg, 0, msg.Length); // 데이터 송신
                    
                }
                stream.Close();
                client.Close();

            }
        }
        // 클라인트로부터 주문 받은 체품 숫자
        public void ja(string str)
        {
            string[] arr = str.Split();
            int n = int.Parse(arr[0]);
            int s = int.Parse(arr[1]);
            ////


            connect();


            //////
            if (s == 100)// 철근
            {
                MessageBox.Show("철근 주문이 들어왔습니다!");
                //Movebal();
                int gunNum = int.Parse(STOCK1) - n; // 현재 철근 양 알고있다  
                if (gunNum < 0)
                {
                    //cmd.CommandText = "UPDATE PRODUCT SET DROGBA = 0 WHERE ID = 2 ";
                    //cmd.ExecuteNonQuery();
                 // 2. 제철소 가동 끝나고
                    Movebal2();

                    cmd.CommandText = "UPDATE PRODUCT SET DROGBA =DROGBA- " + n + " WHERE ID = 2";
                    cmd.ExecuteNonQuery();

                   

                    /* cmd.CommandText = "SELECT DROGBA FROM PRODUCT WHERE ID=2";
                     OracleDataReader r = cmd.ExecuteReader();
                     r.Read();
                     //cmd.CommandText = "UPDATE PRODUCT SET DROGBA = " + (int.Parse(r.GetOracleValue(0).ToString()) + stock) + " ID = 2 ";
                     cmd.ExecuteNonQuery();

                     cmd.CommandText = "UPDATE PRODUCT SET DROGBA =DROGBA+ " + hungN + " WHERE ID = 3";
                     cmd.ExecuteNonQuery();*/
                }
                else
                {
                    /*cmd.CommandText = "UPDATE PRODUCT SET DROGBA =DROGBA- " + n + " WHERE ID = 2";
                    cmd.ExecuteNonQuery();*/
                }

                //Movebal2();
            }
            else if(s == 1) // 코일 ---- 1. 음수이면 0을 넣어준다 --- >2. 제철소 가동끝나고 --->3. 추가분포함해서 제공
                           // --->4. 제철소 추가로 한번도 가동해서  여유분 10개 생산
            {
                MessageBox.Show("코일 주문이 들어왔습니다!");
                int coilNum = int.Parse(STOCK) - n;
                if(coilNum < 0)
                {
                    Movebal();

                    cmd.CommandText = "UPDATE PRODUCT SET DROGBA =DROGBA- " + n + " WHERE ID = 1";
                    cmd.ExecuteNonQuery();

                   /* cmd.CommandText = "UPDATE STOCK SET IRON =IRON- " + 10 + " WHERE ID = 1";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE STOCK SET COAL =COAL- " + 10 + " WHERE ID = 1";
                    cmd.ExecuteNonQuery();*/

                    //cmd.CommandText = "UPDATE PRODUCT SET DROGBA = 50 WHERE ID = 1 ";
                    //cmd.ExecuteNonQuery();

                }


            }
            else if (s == 1000) // 형강 ---- 1. 음수이면 0을 넣어준다 --- >2. 제철소 가동끝나고 --->3. 추가분포함해서 제공
                             // --->4. 제철소 추가로 한번도 가동해서  여유분 10개 생산
            {
                MessageBox.Show("형강 주문이 들어왔습니다!");
                int hungNum = int.Parse(STOCK2) - n;
                if (hungNum < 0)
                {
                    Movebal3();

                    cmd.CommandText = "UPDATE PRODUCT SET DROGBA =DROGBA- " + n + " WHERE ID = 3";
                    cmd.ExecuteNonQuery();

                    /*cmd.CommandText = "UPDATE STOCK SET IRON =IRON- " + 10 + " WHERE ID = 1";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE STOCK SET COAL =COAL- " + 10 + " WHERE ID = 1";
                    cmd.ExecuteNonQuery();*/
                    //cmd.CommandText = "UPDATE PRODUCT SET DROGBA = 50 WHERE ID = 1 ";
                    //cmd.ExecuteNonQuery();

                }


            }



        }
        public void connect()
        {


            cmd = new OracleCommand();

            cmd.Connection = conn;
            // SQL문 지정 및 select 실행
            cmd.CommandText = "select * from PRODUCT";
            // 결과 리더 객체를 리턴
            OracleDataReader rdr = cmd.ExecuteReader();
            //dataGridView2.Rows.Clear();

            rdr.Read();
            NUM = rdr["ID"].ToString();
            NAME = rdr["NAME"].ToString();
            STOCK = rdr["DROGBA"].ToString(); 
            //string[] row1 = new string[] { NUM, NAME, STOCK };
            //dataGridView2.Rows.Add(NUM, NAME, STOCK);

            rdr.Read();
            NUM1 = rdr["ID"].ToString();
            NAME1 = rdr["NAME"].ToString();
            STOCK1 = rdr["DROGBA"].ToString(); 
            //string[] row1 = new string[] { NUM, NAME, STOCK };

            //dataGridView2.Rows.Add(NUM1, NAME1, STOCK1);
            rdr.Read();
            NUM2 = rdr["ID"].ToString();
            NAME2 = rdr["NAME"].ToString();
            STOCK2 = rdr["DROGBA"].ToString(); 
            //string[] row1 = new string[] { NUM, NAME, STOCK };
            //dataGridView2.Rows.Add(NUM2, NAME2, STOCK2);
        }


        public void connect2()
        {


            cmd1 = new OracleCommand();

            cmd1.Connection = conn1;
            // SQL문 지정 및 select 실행
            cmd1.CommandText = "select * from STOCK";
            // 결과 리더 객체를 리턴
            OracleDataReader rdr1 = cmd1.ExecuteReader();
            //dataGridView2.Rows.Clear();

            rdr1.Read();
            IRON = rdr1["IRON"].ToString();
            COAL= rdr1["COAL"].ToString();
            //STOCK = rdr["DROGBA"].ToString();
            //string[] row1 = new string[] { NUM, NAME, STOCK };
            //dataGridView2.Rows.Add(NUM, NAME, STOCK);

            rdr1.Read();
            IRON2 = rdr1["IRON"].ToString();
            COAL2 = rdr1["COAL"].ToString();
           // STOCK1 = rdr["DROGBA"].ToString();
            //string[] row1 = new string[] { NUM, NAME, STOCK };

            //dataGridView2.Rows.Add(NUM1, NAME1, STOCK1);
            rdr1.Read();
            IRON3 = rdr1["IRON"].ToString();
            COAL3 = rdr1["COAL"].ToString();
            //STOCK2 = rdr["DROGBA"].ToString();
            //string[] row1 = new string[] { NUM, NAME, STOCK };
            //dataGridView2.Rows.Add(NUM2, NAME2, STOCK2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            //ttt1 = new Thread(Movebal3);
            Movebal3();
            //ttt1.Start();
        }

        private void FormMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            if (serverThread.IsAlive) serverThread.Interrupt();
            this.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormNotifications(), sender);
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormOrders(), sender);
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            ja(str);
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            conn.Close();
            if (serverThread.IsAlive) serverThread.Interrupt();
            this.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormNotifications(), sender);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormOrders(), sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try {
                if (isbutton == true)
                {
                    ja(str);
                } 
            }
            catch { MessageBox.Show("주문이 없습니다. 클라이언트를 킨후 시도해주세요!\n 또는 공장가동버튼을 눌러주세요!"); }
           // ja(str);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            conn.Close();
            if (serverThread.IsAlive) serverThread.Interrupt();
            this.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            first();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }
    }
    
      
}

