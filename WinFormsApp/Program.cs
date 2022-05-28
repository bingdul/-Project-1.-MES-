using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp16.Forms;
using WinFormsApp16.etc;
using System.Net;
using System.Runtime.InteropServices;

namespace WinFormsApp16
{
    class Program
    {
        public static ApplicationContext ac = new ApplicationContext();
        public static loginForm lf;
        public static Thread receiveThread,sendThread;
        //public static FormMainMenu formMainMenu;
        [STAThread]
        static void Main()
        {
            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            lf = new loginForm();
            ac.MainForm = lf;
            Application.Run(ac);

            ////----------< 디자인만 할때 풀것 >------------------
            //Application.EnableVisualStyles();
            //Application.Run(new FormMainMenu());

        }
    }
    public class User
    {
        public static string Username;
        public static string Role;


    }
    public class ConnectionHandler
    {
        public static TcpClient Client;
        public static NetworkStream Ns;
        public static StreamReader rd;
        public static String token;
        public static bool isAlive = true;
        //-------------------------------------<얼라이브 보내기!!>-----------------------------------------
        public static void sendAlive()
        {
            while (isAlive)
            {
                JObject jObject1 = new JObject(
                new JProperty("SENDER_TYPE", "USER"),
                new JProperty("MESSAGE_TYPE", "ALIVE"),
                new JProperty("TOKEN", token) 
               );
                string result = jObject1.ToString(Newtonsoft.Json.Formatting.None);
                //Debug.WriteLine(result);
                ConnectionHandler.send(result);
                Thread.Sleep(10000);
            }
            
        }

        public static string decrypt(string src) {
            byte[] orgBytes = Convert.FromBase64String(src);
            string orgStr = Encoding.UTF8.GetString(orgBytes);
            return orgStr;
        }
        [DllImport("kernel32.dll")]
        public static extern bool TerminateThread(IntPtr hThread, uint dwExitCode);

        public static void receive()
        {
            while (true)
            {
                string s;
                try
                {
                    
                    if ((s = rd.ReadLine()) != null)
                    {
                        Debug.WriteLine(s);
                        s = decrypt(s); // 데이터 복호화
                        Debug.WriteLine(s);
                        JObject jObject1;
                        jObject1 = JObject.Parse(s);
                        switch ((string)jObject1["MESSAGE_TYPE"])
                        {
                            case "INIT_OK":
                                init_ok(jObject1);
                                break;
                            case "ORE_COUNTRY_DATA":
                                chooseCountry(jObject1);
                                break;
                            case "ORE_AMOUNT_DATA":
                                updateAmount(jObject1);
                                break;
                            case "FORM_DATA":
                                updateForm(jObject1);
                                //initForm(jObject1);
                                break;
                            default: break;
                        }
                    }
                }
                catch (Exception e)
                {
                    rd.Close();
                    Ns.Close();
                    Client.Close();
                    //Client = new TcpClient("192.168.100.2", Int32.Parse("8000"));
                    //Ns = Client.GetStream();
                    //rd = new StreamReader(Ns, Encoding.UTF8);
                    
                }
                //string answer = rd.ReadLine();
                //Debug.WriteLine(answer);

            }
        }
        public static void addRich(string msg)
        {
            Program.ac.MainForm.Invoke((MethodInvoker)delegate () {
            FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
            FormManage formManage = (FormManage)mainForm.currentChildForm;

                string text = msg;
            formManage.richTextBox1.AppendText(text);

            });
            
        }
        
        public static void init_ok(JObject jObject)
        {
            User.Role = (string)jObject["ROLE"];
            Program.ac.MainForm.Invoke((MethodInvoker)delegate () {
                //Program.ac.MainForm.Visible = false;
                Program.ac.MainForm.Hide();
                Program.ac.MainForm = new FormMainMenu();
                Program.ac.MainForm.Show();

            });
            Program.sendThread = new Thread(new ThreadStart(ConnectionHandler.sendAlive));
            Program.sendThread.Start();
        }
        public static void updateAmount(JObject jObject)
        {
            Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
            {
                //Program.ac.MainForm.Visible = false;
                FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                FormOrder formOrder = (FormOrder)mainForm.currentChildForm;
               
                formOrder.cartesianChart2.Series.Clear();
                formOrder.cartesianChart2.Series.Add(new LiveCharts.Wpf.ColumnSeries()
                {
                    Title = "IRON",
                    Stroke = System.Windows.Media.Brushes.Silver,
                    Values = new LiveCharts.ChartValues<double>(new List<double> { (double)jObject["IRON"], 0 })

                });
                formOrder.cartesianChart2.Series.Add(new LiveCharts.Wpf.ColumnSeries()
                {
                    Title = "COAL",
                    Stroke = System.Windows.Media.Brushes.Black,
                    Values = new LiveCharts.ChartValues<double>(new List<double> { 0, (double)jObject["COAL"] })

                });
            });
        }
        public static void updateForm(JObject jObject)
        {
            switch ((string)jObject["FORM_TYPE"])
            {
                case "DASHBOARD":
                    updateDASHBOARD(jObject);
                    break;
                case "ORE":
                    updateORE(jObject);
                    break;
                case "CONTROL":
                    updateCONTROL(jObject);
                    break;
                case "MANAGE":
                    updateMANAGE(jObject);
                    break;
                case "SEARCH":
                    updateSEARCH(jObject);
                    break;
                default:
                    break;
            }
        }
        public static void updateDASHBOARD(JObject jObject)
        {
            switch ((string)jObject["DATA_TYPE"])
            {
                case "INITIALIZATION":
                    initForm(jObject);
                    //initForm(jObject1);
                    break;
                case "MACHINE_CONDITION":
                    //updatePower(jObject);
                    updateBeltspeed(jObject);
                    //updateTemp(jObject);




                    break;
                default: break;
            }
        }
        public static void updateBeltspeed(JObject jObject)
        {
            Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
            {

            FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
            FormDashboard formDashboard = (FormDashboard)mainForm.currentChildForm;
            //Debug.WriteLine("벨트원이 작동되엇어용");
            //Debug.WriteLine( ((string)jObject["BELT_ONE"]));
                try
            {
                if (((string)jObject["BELT_ONE"]).Split('_')[1] == "0")
                {
                    formDashboard.angularGauge1.Value = 0;

                }
                else if (((string)jObject["BELT_ONE"]).Split('_')[1] == "1")
                {
                    formDashboard.angularGauge1.Value = 100;
                }
                else if (((string)jObject["BELT_ONE"]).Split('_')[1] == "2")
                {
                    formDashboard.angularGauge1.Value = 190;
                }


            }
            catch (Exception e)
            {

            }
            try
            {
                if (((string)jObject["BELT_TWO"]).Split('_')[1] == "0")
                {
                    formDashboard.angularGauge2.Value = 0;
                }
                else if (((string)jObject["BELT_TWO"]).Split('_')[1] == "1")
                {
                    formDashboard.angularGauge2.Value = 100;
                }
                else if (((string)jObject["BELT_TWO"]).Split('_')[1] == "2")
                {
                    formDashboard.angularGauge2.Value = 190;
                }
            }
            catch (Exception e)
            {

            }
            



                //formManage.ucDataGridView2.DataSource = formManage.luserlistSource;
                //formManage.ucDataGridView2.First();
            });
        }
        public static void updateTemp(JObject jObject)
        {
            Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
            {

                FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                FormManage formManage = (FormManage)mainForm.currentChildForm;

               
            });
        }

        public static void updatePower(JObject jObject)
        {
            Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
            {

                FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                FormManage formManage = (FormManage)mainForm.currentChildForm;

               
            });
        }
        public static void updateORE(JObject jObject)
        {
            switch ((string)jObject["DATA_TYPE"])
            {
                case "COUNTRY":
                    chooseCountry(jObject);
                    break;
                case "AMOUNT":
                    updateAmount(jObject);
                    break;
                case "INITIALIZATION":
                    initForm(jObject);
                    //initForm(jObject1);
                    break;
                default: break;
            }
        }
        public static void updateCONTROL(JObject jObject)
        {
            switch ((string)jObject["DATA_TYPE"])
            {
                case "CONDITION":
                    updateCondition(jObject);
                    break;
               
                case "INITIALIZATION":
                    initForm(jObject);
                  
                    break;
                default: break;
            }

        }
        public static void updateCondition(JObject jObject) // 받았을때 바로즉각적으로 갱신
        {
               Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
                    {
                        //Program.ac.MainForm.Visible = false;
                        FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                        FormControl formControl = (FormControl)mainForm.currentChildForm;

                        // Debug.WriteLine("dddd"+((string)jObject["BELT_ONE"]).Split('_')[0]);

                        //---------------BELT1--------------
                        try{
                            string OnOFF1 = ((string)jObject["BELT_ONE"]).Split('_')[0];
                            int speed1 = int.Parse(((string)jObject["BELT_ONE"]).Split('_')[1]);

                            formControl.toggleButton1.Checked = (OnOFF1 == "ON" ? true : false);

                            formControl.trackBar1.Value = speed1;
                            formControl.ucConveyor1.ConveyorDirection = OnOFF1 == "OFF" || speed1 == 0 ? HZH_Controls.Controls.ConveyorDirection.None : HZH_Controls.Controls.ConveyorDirection.Forward;
                            formControl.ucConveyor1.ConveyorSpeed = 30 - (10 * speed1);
                        }
                        catch (Exception e) {
                        
                        }//---------------------------------------------------
                    try
                    {
                        string OnOFF2 = ((string)jObject["BELT_TWO"]).Split('_')[0];
                       int speed2 =int.Parse( ((string)jObject["BELT_TWO"]).Split('_')[1]);
                        formControl.toggleButton2.Checked = (OnOFF2 == "ON" ? true : false);

                        formControl.trackBar3.Value = speed2;
                        formControl.ucConveyor2.ConveyorDirection = OnOFF2 == "OFF" || speed2 == 0 ? HZH_Controls.Controls.ConveyorDirection.None : HZH_Controls.Controls.ConveyorDirection.Forward;
                        formControl.ucConveyor2.ConveyorSpeed = 30 - (10 * speed2);
                        }
                        catch (Exception e)
                        {

                        }
                        try
                        {
                            //--------------------------------------------------------
                            if ((string)jObject["HEATER"] == "OFF")
                            {
                                formControl.toggleButton3.Checked = true;
                            }
                            else if ((string)jObject["HEATER"] == "ON")
                            {
                                formControl.toggleButton3.Checked = true;
                            }
                        }
                        catch (Exception e)
                        {

                        }

                    });

        }
        public static void updateMANAGE(JObject jObject)
        {
            //----
            switch ((string)jObject["DATA_TYPE"])
            {
                case "MACHINE":
                    updateMachine(jObject);
                    break;
                case "USER":
                    updateUser(jObject);
                    break;
                case "LOG":
                    updateLog(jObject);
                    break;

                case "INITIALIZATION":
                    initForm(jObject);

                    break;
                default: break;
            }
        }
        public static void updateMachine(JObject jObject)
        {
            Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
            {

                FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                FormManage formManage = (FormManage)mainForm.currentChildForm;

                foreach (TestModel tm in formManage.lstSource) { 
                    if (tm.NAME == (string)jObject["NAME"]){
                        tm.CONNECT_STATUS = (string)jObject["CONNECT_STATUS"];
                    }
                }

                
                formManage.ucDataGridView1.DataSource = formManage.lstSource;
                formManage.ucDataGridView1.First();
            });
        }
        public static void updateUser(JObject jObject)
        {
            Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
            {

                FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                FormManage formManage = (FormManage)mainForm.currentChildForm;

                foreach (TestModel2 tm in formManage.luserlistSource)
                {
                    if (tm.NAME == (string)jObject["NAME"])
                    {
                        tm.CONNECT_STATUS = (string)jObject["CONNECT_STATUS"];
                    }
                }


                formManage.ucDataGridView2.DataSource = formManage.luserlistSource;
                formManage.ucDataGridView2.First();
            });

        }
        public static void updateLog(JObject jObject)
        {

                addRich((string)jObject["DATA"] + "\n");
        }
        public static void updateSEARCH(JObject jObject)
        {
            Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
            {

                FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                FormSearch formSearch = (FormSearch)mainForm.currentChildForm;

                JArray dataArray = (JArray)jObject["DATA"];

                formSearch.lstSource2 = new List<object>();

                foreach (var item in dataArray)
                {
                    TestModel3 model = new TestModel3()
                    {
                        ACCESS_IP = (string)item.Value<JObject>()["ACCESS_IP"],
                        CLIENT_TYPE = (string)item.Value<JObject>()["CLIENT_TYPE"],
                        LOG_LEVEL = (string)item.Value<JObject>()["LOG_LEVEL"],
                        INFORMATION = (string)item.Value<JObject>()["INFORMATION"],
                        ACTIVITY = (string)item.Value<JObject>()["ACTIVITY"],
                        TIMESTAMP = (string)item.Value<JObject>()["TIMESTAMP"],
                    };
                    formSearch.lstSource2.Add(model);
                }

                formSearch.ucDataGridView1.DataSource = formSearch.lstSource2;
                formSearch.ucDataGridView1.First();




            });

        }

        //public static void searchUpdateButton(JObject jObject)
        //{
        //    Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
        //    {

        //        FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
        //        FormSearch formSearch = (FormSearch)mainForm.currentChildForm;

        //        JArray dataArray = (JArray)jObject["DATA"];

        //        formSearch.lstSource2 = new List<object>();

        //        foreach (var item in dataArray)
        //        {
        //            TestModel3 model = new TestModel3()
        //            {
        //                ACCESS_IP = (string)item.Value<JObject>()["ACCESS_IP"],
        //                CLIENT_TYPE = (string)item.Value<JObject>()["CLIENT_TYPE"],
        //                LOG_LEVEL = (string)item.Value<JObject>()["LOG_LEVEL"],
        //                INFORMATION = (string)item.Value<JObject>()["INFORMATION"],
        //                ACTIVITY = (string)item.Value<JObject>()["ACTIVITY"],
        //                TIMESTAMP = (string)item.Value<JObject>()["TIMESTAMP"],
        //            };
        //            formSearch.lstSource2.Add(model);
        //        }

        //        formSearch.ucDataGridView1.DataSource = formSearch.lstSource2;
        //        formSearch.ucDataGridView1.First();




        //    });
        //}
        public static void initForm(JObject jObject)
        {
            switch ((string)jObject["FORM_TYPE"])
            {
                case "DASHBOARD":

                    string NAME="";
                    string POWER="";
                    string CONNECT_STATUS="";
                    string VALUE="";
                    string PROCESS_RATE = "";


                    Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
                    {
                        FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                        FormDashboard formDashboard = (FormDashboard)mainForm.currentChildForm;

                        JArray machineArray = (JArray)jObject["MACHINE"];


                        int coalNum = (int)jObject["COAL"];
                        int ironNum = (int)jObject["IRON"];

                        formDashboard.label2.Text = Convert.ToString(coalNum);
                        formDashboard.label3.Text = Convert.ToString(ironNum);

                        int coalUsed = (int)jObject["COAL_USED"];
                        int ironUsed = (int)jObject["IRON_USED"];

                        formDashboard.label14.Text = Convert.ToString(coalUsed);
                        formDashboard.label12.Text = Convert.ToString(ironUsed);

                        int success = (int)jObject["SUCCESS"];
                        int failure = (int)jObject["FAILURE"];

                        formDashboard.label8.Text = Convert.ToString(coalUsed);
                        formDashboard.label10.Text = Convert.ToString(ironUsed);

                        int processRate = (int)jObject["PROCESS_RATE"];
                        formDashboard.label23.Text = Convert.ToString(processRate) + "%";


                        formDashboard.circularProgressBar2.Value = processRate;



                        //-----기계부분 ------

                        foreach (var item in machineArray)
                        {


                           NAME = (string)item.Value<JObject>()["NAME"];
                           POWER = (string)item.Value<JObject>()["POWER"];
                           CONNECT_STATUS = (string)item.Value<JObject>()["CONNECT_STATUS"];
                           VALUE = (string)item.Value<JObject>()["VALUE"];
                           
                            //----------벨트1 ,2 속도-------------
                            try
                            {
                                //Debug.WriteLine("벨트원");
                                //Debug.WriteLine(NAME);
                                //Debug.WriteLine(VALUE);
                                if (NAME == "BELT_ONE" && VALUE == "0")
                                {
                                    formDashboard.angularGauge1.Value = 0;

                                    formDashboard.ucConveyor1.ConveyorSpeed = 30 - (10 * (int.Parse(VALUE)));
                                    // formControl.ucConveyor1.ConveyorDirection = OnOFF1 == "OFF" || speed1 == 0 ? HZH_Controls.Controls.ConveyorDirection.None : HZH_Controls.Controls.ConveyorDirection.Forward;
                                    //formControl.ucConveyor1.ConveyorSpeed = 30 - (10 * speed1);

                                }
                                else if (NAME == "BELT_ONE" && VALUE == "1")
                                {
                                    formDashboard.angularGauge1.Value = 100;
                                    formDashboard.ucConveyor1.ConveyorSpeed = 30 - (10 * (int.Parse(VALUE)));
                                }
                                else if (NAME == "BELT_ONE" && VALUE == "2")
                                {
                                    formDashboard.angularGauge1.Value = 190;
                                    formDashboard.ucConveyor1.ConveyorSpeed = 30 - (10 * (int.Parse(VALUE)));
                                }


                            }
                            catch (Exception e)
                            {

                            }
                            try
                            {
                                if (NAME == "BELT_TWO" && VALUE == "0")
                                {
                                    formDashboard.angularGauge2.Value = 0;
                                    formDashboard.ucConveyor2.ConveyorSpeed = 30 - (10 * (int.Parse(VALUE)));
                                }
                                else if (NAME == "BELT_TWO" && VALUE == "1")
                                {
                                    formDashboard.angularGauge2.Value = 100;
                                    formDashboard.ucConveyor2.ConveyorSpeed = 30 - (10 * (int.Parse(VALUE)));
                                }
                                else if (NAME == "BELT_TWO" && VALUE == "2")
                                {
                                    formDashboard.angularGauge2.Value = 190;
                                    formDashboard.ucConveyor2.ConveyorSpeed = 30 - (10 * (int.Parse(VALUE)));
                                }
                            }
                            catch (Exception e)
                            {

                            }
                            //------------

                            //---------------벨트1,2 onoff  ----------
                            try
                            {
                                if (NAME == "BELT_ONE" && POWER == "ON")
                                {
                                    formDashboard.label92.Text = "ON";
                                    formDashboard.label92.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "BELT_ONE" && POWER == "OFF")
                                {
                                    formDashboard.label92.Text = "OFF";
                                    formDashboard.label92.ForeColor = System.Drawing.Color.Red;
                                }
                                
                            }
                            catch (Exception e)
                            {

                            }
                            try
                            {
                                if (NAME == "BELT_TWO" && POWER == "ON")
                                {
                                    formDashboard.label95.Text = "ON";
                                    formDashboard.label95.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "BELT_TWO" && POWER == "OFF")
                                {
                                    formDashboard.label95.Text = "OFF";
                                    formDashboard.label95.ForeColor = System.Drawing.Color.Red; //label104
                                }

                            }
                            catch (Exception e)
                            {


                            }
                            //temp sensor /onoff
                            try
                            {
                                if (NAME == "HEATER" && POWER == "ON")
                                {
                                    formDashboard.label90.Text = "ON";
                                    formDashboard.label90.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "HEATER" && POWER == "OFF")
                                {
                                    formDashboard.label90.Text = "OFF";
                                    formDashboard.label90.ForeColor = System.Drawing.Color.Red; //label104
                                }

                            }
                            catch (Exception e)
                            {

                            }
                            //temp_contorl // on off
                          
                            //belt1 alive
                            try
                            {
                                if (NAME == "BELT_ONE" && CONNECT_STATUS == "CONNECT")
                                {
                                    formDashboard.label57.Text = "LIVE";
                                    formDashboard.label57.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "BELT_ONE" && CONNECT_STATUS == "DISCONNECT")
                                {
                                    formDashboard.label57.Text = "DEAD";
                                    formDashboard.label57.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            catch (Exception e) {}
                            //belt2 alive
                            try
                            {
                                if (NAME == "BELT_TWO" && CONNECT_STATUS == "CONNECT")
                                {
                                    formDashboard.label39.Text = "LIVE";
                                    formDashboard.label39.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "BELT_TWO" && CONNECT_STATUS == "DISCONNECT")
                                {
                                    formDashboard.label39.Text = "DEAD";
                                    formDashboard.label39.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            catch (Exception e) { }
                            //TEMP_SENSOR alive
                            try
                            {
                                if (NAME == "TMP_SENSOR" && CONNECT_STATUS == "CONNECT")
                                {
                                    formDashboard.label54.Text = "LIVE";
                                    formDashboard.label54.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "TMP_SENSOR" && CONNECT_STATUS == "DISCONNECT")
                                {
                                    formDashboard.label54.Text = "DEAD";
                                    formDashboard.label54.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            catch (Exception e) { }
                            //HEATER alive
                            try
                            {
                                if (NAME == "HEATER" && CONNECT_STATUS == "CONNECT")
                                {
                                    formDashboard.label87.Text = "LIVE";
                                    formDashboard.label87.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "HEATER" && CONNECT_STATUS == "DISCONNECT")
                                {
                                    formDashboard.label87.Text = "DEAD";
                                    formDashboard.label87.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            catch (Exception e) { }
                            //CHECK alive
                            try
                            {
                                if (NAME == "CHECK" && CONNECT_STATUS == "CONNECT")
                                {
                                    formDashboard.label59.Text = "LIVE";
                                    formDashboard.label59.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "CHECK" && CONNECT_STATUS == "DISCONNECT")
                                {
                                    formDashboard.label59.Text = "DEAD";
                                    formDashboard.label59.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            catch (Exception e) { }
                            //SPLIT alive
                            try
                            {
                                if (NAME == "SPLIT" && CONNECT_STATUS == "CONNECT")
                                {
                                    formDashboard.label62.Text = "LIVE";
                                    formDashboard.label62.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "SPLIT" && CONNECT_STATUS == "DISCONNECT")
                                {
                                    formDashboard.label62.Text = "DEAD";
                                    formDashboard.label62.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            catch (Exception e) { }
                            //DUST alive
                            try
                            {
                                if (NAME == "DUST_SENSOR" && CONNECT_STATUS == "CONNECT")
                                {
                                    formDashboard.label72.Text = "LIVE";
                                    formDashboard.label72.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "DUST_SENSOR" && CONNECT_STATUS == "DISCONNECT")
                                {
                                    formDashboard.label72.Text = "DEAD";
                                    formDashboard.label72.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            catch (Exception e) { }
                            //GAS SENSOR alive
                            try
                            {
                                if (NAME == "GAS_SENSOR" && CONNECT_STATUS == "CONNECT")
                                {
                                    formDashboard.label75.Text = "LIVE";
                                    formDashboard.label75.ForeColor = System.Drawing.Color.Lime;
                                }
                                else if (NAME == "GAS_SENSOR" && CONNECT_STATUS == "DISCONNECT")
                                {
                                    formDashboard.label75.Text = "DEAD";
                                    formDashboard.label75.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            catch (Exception e) { }
                            //HEATER VALUE
                            try
                            {
                                if (NAME == "HEATER")
                                {
                                    formDashboard.label7.Text = VALUE+ "°C";
                                    formDashboard.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                                }
                              
                            }
                            catch (Exception e) { }
                            //GAS VALUE
                            try
                            {
                                if (NAME == "GAS_SENSOR" )
                                {
                                    formDashboard.label25.Text = VALUE;
                                }
                            }
                            catch (Exception e) { }
                            //DUST VALUE
                            try
                            {
                                if (NAME == "GAS_SENSOR")
                                {
                                    formDashboard.label21.Text = VALUE;
                                }
                            }
                            catch (Exception e) { }
                           
                        }



                      

                    });
                    break;
                case "ORE":
                    Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
                    {
                        //Program.ac.MainForm.Visible = false;
                        FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                        FormOrder formOrder = (FormOrder)mainForm.currentChildForm;
                        formOrder.label18.Text = "$ " + (int)jObject["RUC"];
                        formOrder.label33.Text = "$ " + (int)jObject["CHC"];
                        formOrder.label31.Text = "$ " + (int)jObject["AUI"];
                        formOrder.label32.Text = "$ " + (int)jObject["AUC"];
                        formOrder.label15.Text = "$ " + (int)jObject["BRI"];
                        formOrder.label12.Text = "$ " + (int)jObject["CAI"];
                        formOrder.cartesianChart2.Series.Clear();
                        formOrder.cartesianChart2.Series.Add(new LiveCharts.Wpf.ColumnSeries()
                        {
                            Title="IRON",
                            Stroke = System.Windows.Media.Brushes.Silver,
                            Values = new LiveCharts.ChartValues<double>(new List<double> { (double)jObject["IRON_AMOUNT"],0})

                        });
                        formOrder.cartesianChart2.Series.Add(new LiveCharts.Wpf.ColumnSeries()
                        {
                            Title = "COAL",
                            Stroke = System.Windows.Media.Brushes.Black,
                            Values = new LiveCharts.ChartValues<double>(new List<double> {0, (double)jObject["COAL_AMOUNT"] })

                        });
                    });
                    break;
                case "CONTROL":
                    Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
                    {
                        //Program.ac.MainForm.Visible = false;
                        FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                        FormControl formControl = (FormControl)mainForm.currentChildForm;

                        //Debug.WriteLine("dddd"+((string)jObject["BELT_ONE"]).Split('_')[0]);

                         //---------------BELT1--------------
                        string OnOFF1 = ((string)jObject["BELT_ONE"]).Split('_')[0];
                        int speed1= int.Parse(((string)jObject["BELT_ONE"]).Split('_')[1]);

                        formControl.toggleButton1.Checked=(OnOFF1 == "ON" ? true : false);

                        formControl.trackBar1.Value = speed1;
                        formControl.ucConveyor1.ConveyorDirection = OnOFF1 =="OFF" || speed1 ==0 ? HZH_Controls.Controls.ConveyorDirection.None : HZH_Controls.Controls.ConveyorDirection.Forward;
                        formControl.ucConveyor1.ConveyorSpeed = 30 - (10 * speed1);
                        //---------------------------------------------------
                        string OnOFF2 = ((string)jObject["BELT_TWO"]).Split('_')[0];
                       int speed2 =int.Parse( ((string)jObject["BELT_TWO"]).Split('_')[1]);
                        formControl.toggleButton2.Checked = (OnOFF2 == "ON" ? true : false);

                        formControl.trackBar3.Value = speed2;
                        formControl.ucConveyor2.ConveyorDirection = OnOFF2 == "OFF" || speed2 == 0 ? HZH_Controls.Controls.ConveyorDirection.None : HZH_Controls.Controls.ConveyorDirection.Forward;
                        formControl.ucConveyor2.ConveyorSpeed = 30 - (10 * speed2);
                        //--------------------------------------------------------
                        if ((string)jObject["HEATER"] == "OFF")
                        {
                            formControl.toggleButton3.Checked = true;
                        }
                        else if ((string)jObject["HEATER"] == "ON")
                        {
                            formControl.toggleButton3.Checked = true;
                        }


                    });
                        break;
                case "MANAGE":
                    Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
                    {

                        FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                        FormManage formManage = (FormManage)mainForm.currentChildForm;
                        
                        JArray machineArray = (JArray)jObject["MACHINE"];
                        JArray userArray = (JArray)jObject["USER"];
                        JArray logArray = (JArray)jObject["LOG"];

                        formManage.lstSource = new List<object>();
                        formManage.luserlistSource = new List<object>();

                        foreach ( var item in machineArray)
                        {
                            TestModel model = new TestModel()
                            {
                                ID = (string)item.Value<JObject>()["ID"],
                                TYPE = (string)item.Value<JObject>()["TYPE"],
                                NAME = (string)item.Value<JObject>()["NAME"],
                                MAC_ADDRESS = (string)item.Value<JObject>()["MAC_ADDRESS"],
                                IP = (string)item.Value<JObject>()["IP"],
                                CONNECT_STATUS = (string)item.Value<JObject>()["CONNECT_STATUS"],
                            };
                            formManage.lstSource.Add(model);
                        }

                        formManage.ucDataGridView1.DataSource = formManage.lstSource;
                        formManage.ucDataGridView1.First();

                        foreach (var item in userArray)
                        {
                            TestModel2 model= new TestModel2()
                            {
                                ID = (string)item.Value<JObject>()["ID"],
                                NAME = (string)item.Value<JObject>()["NAME"],
                                ROLE = (string)item.Value<JObject>()["ROLE"],
                                ACCOUNT_STATUS = (string)item.Value<JObject>()["ACCOUNT_STATUS"],
                                CONNECT_STATUS = (string)item.Value<JObject>()["CONNECT_STATUS"]
                            };
                            formManage.luserlistSource.Add(model);
                        }
                        foreach (var item in logArray)
                        {

                            string data = (string)item.Value<JObject>()["DATA"];
                            formManage.richTextBox1.AppendText(data+"\n");
                        }

                        formManage.ucDataGridView2.DataSource = formManage.luserlistSource;
                        formManage.ucDataGridView2.First();
                    });
                    break;
                case "SEARCH":
                    //Program.ac.MainForm.Invoke((MethodInvoker)delegate ()
                    //{

                    //    FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                    //    FormSearch formSearch = (FormSearch)mainForm.currentChildForm;

                    //    JArray dataArray = (JArray)jObject["DATA"];

                    //    formSearch.lstSource2 = new List<object>();

                    //    foreach (var item in dataArray)
                    //    {
                    //        TestModel3 model = new TestModel3()
                    //        {
                    //            ACCESS_IP = (string)item.Value<JObject>()["ACCESS_IP"],
                    //            CLIENT_TYPE = (string)item.Value<JObject>()["CLIENT_TYPE"],
                    //            LOG_LEVEL = (string)item.Value<JObject>()["LOG_LEVEL"],
                    //            INFORMATION = (string)item.Value<JObject>()["INFORMATION"],
                    //            ACTIVITY = (string)item.Value<JObject>()["ACTIVITY"],
                    //            TIMESTAMP = (string)item.Value<JObject>()["TIMESTAMP"],
                    //        };
                    //        formSearch.lstSource2.Add(model);
                    //    }

                    //    formSearch.ucDataGridView1.DataSource = formSearch.lstSource2;
                    //    formSearch.ucDataGridView1.First();

                        

                        
                    //});
                    break;
                default: break;
            }
        }
        public static void login(JObject jObject)
        {
            int response = (int)jObject["RESPONSE_CODE"];
            if (response == 1)
            {
                
                string ip = "192.168.100.2";
                string port = "8000";
                Client = new TcpClient(ip, Int32.Parse(port));
                Ns = ConnectionHandler.Client.GetStream();
                rd = new StreamReader(ConnectionHandler.Ns, Encoding.UTF8);
                Program.receiveThread = new Thread(new ThreadStart(ConnectionHandler.receive));
                Program.receiveThread.Start();
                token = (String)jObject["TOKEN"];
                JObject jObject1 = new JObject(
                new JProperty("SENDER_TYPE", "USER"),
                new JProperty("MESSAGE_TYPE", "INIT"),
                new JProperty("NAME", loginForm.id),
                new JProperty("TOKEN", token)
                , new JProperty("IP", ConnectionHandler.GetExternalIPAddress())
                );
                string result = jObject1.ToString(Newtonsoft.Json.Formatting.None);
                send(result);
                Debug.WriteLine("성공");
                //formMainMenu.AutoSize = true;
                //formMainMenu.AutoScaleMode = true;
                //Program.formMainMenu.Show();
                //Application.DoEvents();
            }
            if (response == 2)
            {
                Debug.WriteLine("실패");
                Program.ac.MainForm.Invoke((MethodInvoker)delegate () {
                    Program.ac.MainForm.Controls.Find("label4", true).FirstOrDefault().Text = "존재 하지 않는 계정입니다.";
                });
            }
            if (response == 3)
            {
                Debug.WriteLine("실패");
                Program.ac.MainForm.Invoke((MethodInvoker)delegate () {
                    if ((int)jObject["NUMBER_OF_FAILURE"] <= 4)
                    {
                        Program.ac.MainForm.Controls.Find("label4", true).FirstOrDefault().Text = "비밀번호를 틀렸습니다.\n 5회 이상 실패 시 계정이 잠금됩니다.  [" + (int)jObject["NUMBER_OF_FAILURE"] + "회 실패]";
                    }
                    else
                    {
                        Program.ac.MainForm.Controls.Find("label4", true).FirstOrDefault().Text = "비밀번호 입력 5회 실패로 인하여\n 계정이 잠금됩니다.";
                    }
                });
            }
            if (response == 4)
            {
                Debug.WriteLine("실패");
                Program.ac.MainForm.Invoke((MethodInvoker)delegate () {
                    Program.ac.MainForm.Controls.Find("label4", true).FirstOrDefault().Text = "비활성화된 계정입니다.\n관리자에게 문의하세요.";
                });
                
            }
        }
        public static void chooseCountry(JObject jObject)
        {
            bool hasIron = true;
            bool hasCoal = true;
            double iron_this = 0, iron_last = 0, coal_this = 0, coal_last = 0;
            try
            {
                iron_this = (double)jObject["IT"];
                iron_last = (double)jObject["IL"];
            }
            catch (Exception e)
            {
                hasIron = false;
            }
            try
            {
                coal_this = (double)jObject["CT"];
                coal_last = (double)jObject["CL"];
            }
            catch (Exception e)
            {
                hasCoal = false;
            }
            Debug.WriteLine(iron_last);
            Program.ac.MainForm.Invoke((MethodInvoker)delegate () {
                FormMainMenu mainForm = (FormMainMenu)Program.ac.MainForm;
                FormOrder formOrder = (FormOrder)mainForm.currentChildForm;
                formOrder.cartesianChart1.Series.Clear();
                //formOrder.cartesianChart1.AxisY.Clear();

                if (hasIron)
                {
                    formOrder.cartesianChart1.Series.Add(new LiveCharts.Wpf.LineSeries()
                    {
                        Title = "IRON",
                        //Stroke = new SolidColorBrush(Colors.Green),
                        Stroke = System.Windows.Media.Brushes.Silver,
                        Values = new LiveCharts.ChartValues<double>(new List<double> { iron_last, iron_this })
                    }
                );
                }
                if (hasCoal)
                {
                    formOrder.cartesianChart1.Series.Add(new LiveCharts.Wpf.LineSeries()
                    {
                        Title = "COAL",
                        //Stroke = new SolidColorBrush(Colors.Green),
                        Stroke = System.Windows.Media.Brushes.Black,
                        Values = new LiveCharts.ChartValues<double>(new List<double> { coal_last, coal_this })
                    }
                );
                }


            });
        }
        public static string GetInternalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static string GetExternalIPAddress()
        {
            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip").Trim(); //http://icanhazip.com

            if (String.IsNullOrWhiteSpace(externalip))
            {
                externalip =GetInternalIPAddress();//null경우 Get Internal IP를 가져오게 한다.
            }

            return externalip;
        }

        public static void send(string message)
        {
            message = Convert.ToBase64String(Encoding.UTF8.GetBytes(message)); // 데이터 암호화 
            StreamWriter wr = new StreamWriter(Ns);
            wr.WriteLine(message);
            wr.Flush();
        }
    }
}