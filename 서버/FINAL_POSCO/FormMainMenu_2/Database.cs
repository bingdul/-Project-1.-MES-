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
    class Database
    {
        string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));" +
                "User Id=SYSTEM;Password=dlehdgml;";
        public Database()
        {

        }
        public OracleConnection dbConnect()
        {
            OracleConnection conn = new OracleConnection(strConn);
            conn.Open();

            return conn;
        }

        public int[] select_COIL()
        {
            OracleConnection conn = dbConnect();
            string sql = "select * from PRODUCT";
            int[] COIL_Count = new int[3];
            int i = 0;

            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                COIL_Count[i] = int.Parse(reader.GetOracleValue(1).ToString());
                i++;
            }
            dbClose(conn);
            return COIL_Count;
        }

        public int[] select_IRON()
        {
            OracleConnection conn = dbConnect();
            string sql = "select * from STOCK";
            int[] IRON_Count = new int[5];
            int i = 0;

            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                IRON_Count[i] = int.Parse(reader.GetOracleValue(1).ToString());
                i++;
            }
            dbClose(conn);
            return IRON_Count;
        }
        /*
        public int[] select_STEEL()
        {
            OracleConnection conn = dbConnect();
            string sql = "select * from STEEL";
            int[] STEEL_Count = new int[3];
            int i = 0;

            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                STEEL_Count[i] = int.Parse(reader.GetOracleValue(1).ToString());
                i++;
            }
            dbClose(conn);
            return STEEL_Count;
        }*/

        public void dbClose(OracleConnection conn)
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

}

