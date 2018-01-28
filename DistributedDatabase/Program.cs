using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Data.SqlClient;
using System.Data;

namespace DistributedDatabase
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        public static SqlDataAdapter da;
        public static SqlDataReader myReader;
        public static String servername = "DESKTOP-QN5U73D";
        public static String servername1 = "DESKTOP-QN5U73D\\PHANMANH1";
        public static String servername2 = "DESKTOP-QN5U73D\\PHANMANH2";
        public static String username;
        public static String password;
        public static String database = "BANKING";
        public static String mlogin;
        public static String mloginDN;
        public static String passwordDN;
        public static String mGroup;
        public static String mHoten;
        public static int mChinhanh = 0;
        public static String mlogin1 = "support_connect1";
        public static String password1 = "12345";
        public static String mlogin2 = "support_connect2";
        public static String password2 = "12345";
        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open) Program.conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" + Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static SqlDataReader ExecSqlDataReader(String cmd, String connectionstring)
        {
            SqlDataReader myreader;
            //Program.conn = new SqlConnection(connectionstring);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = Program.conn;
            sqlcmd.CommandText = cmd;
            sqlcmd.CommandType = CommandType.Text;


            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;
            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static void SetEnableOfButton(Form frm, Boolean Active)
        {

            foreach (Control ctl in frm.Controls)
                if ((ctl) is Button)
                    ctl.Enabled = Active;
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            
            Application.Run(new LoginForm());
        }
    }
}