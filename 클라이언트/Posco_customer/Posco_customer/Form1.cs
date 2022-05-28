using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Posco_customer
{
    public partial class Form1 : Form
    {
        private string bindIp = "127.0.0.1";
        private string serverIp = "127.0.0.1";
        const int serverPort = 5458;
        public int i = 10004, k = 0;

        IPEndPoint clientAddress;
        IPEndPoint serverAddress;
        TcpClient client;
        NetworkStream stream;

        public void socket(string str)
        {
            int bindPort = Convert.ToInt32(i);
            string responseData = "";




            string message = str;

            clientAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);
            serverAddress = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

            //Console.WriteLine("클라이언트 : {0}, 서버 : {1}", clientAddress.ToString(), serverAddress.ToString());

            client = new TcpClient(clientAddress);
            client.Connect(serverAddress);
            byte[] data = System.Text.Encoding.Default.GetBytes(message);
            stream = client.GetStream();
            stream.Write(data, 0, data.Length);
            // Console.WriteLine("송신 : {0}", message);
            data = new byte[256];

            int bytes = stream.Read(data, 0, data.Length);
            responseData = Encoding.Default.GetString(data, 0, bytes);
            Console.WriteLine("수신 : {0}", responseData);

            if(responseData == "1000")
            {
                MessageBox.Show("배송을 완료함!");
            }
            stream.Close();
            client.Close();
            i++;
        }
        public Form1()
        {
            InitializeComponent();
            msg1.Text = "0";
            msg1.MaxLength = 101;
            msg2.Text = "0";
            msg2.MaxLength = 101;
            textBox1.Text = "0";
            textBox1.MaxLength = 101;
        }
        
       
       
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("코일이 주문되었습니다!");
            string str = string.Empty;
            str = msg1.Text+" 1";
            socket(str);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("철근이 주문되었습니다!");
            string str = string.Empty;
            str = msg2.Text+" 100";
            socket(str);
           
        }


        //mt_Server_Listen_Click_1
        private void button3_Click(object sender, EventArgs e)
        {
   
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("코일이 주문되었습니다!");
            string str = string.Empty;
            str = textBox1.Text + " 1000";
            socket(str);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void msg1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
