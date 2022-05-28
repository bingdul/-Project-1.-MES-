using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace WinFormsApp16
{
    class Json
    {
        string send_json;
        string result;
        JObject jObject;
        public Json()
        {

        }
        public void sendJson(string id, string password)
        {
            send_json = "" +
               "{" +
               "  'members' : [ " +
               "                     { 'ID' : '" + id + "', " +
                                   "   'Password' : '" + password + "' }]";
        }
        //콘솔 출력용
        public void print_console_json()
        {
            jObject = JObject.Parse(send_json);

            // Json Data 전체 출력
            Console.WriteLine(jObject.ToString());


        }
        //스트링화 ( 직렬화)
        public string tostring()
        {
            result = jObject.ToString();
            return result; //직렬화된 아이디,비번 데이터
        }

        //바이트화
        public byte[] toByte(string result)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(result);
            return StrByte;

        }
    }
}
