using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedDatabase
{
    public partial class LoginForm : Form
    {
        #region khai bao
        string ServerName="DESKTOP-QN5U73D",Server= "DESKTOP-QN5U73D";
        string DataBaseName = "Banking";
        DataTable dt;

        #endregion

        public void layPhanManh()
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-QN5U73D;Initial Catalog=distribution;User ID=sa;Password=12345");
            kn.Open();
            string str = "exec getChiNhanh";
            SqlCommand com = new SqlCommand(str, kn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = dt.Columns["description"].ToString();
            comboBox1.ValueMember = dt.Columns["subscriber"].ToString();

            kn.Close();
        }
        public LoginForm()
        {
            InitializeComponent();
            layPhanManh();

            thoigianToolTxt.Text = DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            timer1.Start();
        }

        public void logoutForm(MainForm mainFrm)
        {
            this.Show();
            mainFrm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string roleTypestr = "";
            SqlConnection kn = new SqlConnection(@"Data Source="+ServerName+";Initial Catalog="+DataBaseName+";User ID="+textBox1.Text+";Password="+textBox2.Text);
            try {
                kn.Open();
                using (IDbCommand spCommand = kn.CreateCommand())
                {
                    spCommand.CommandText = "sp_login";
                    spCommand.CommandType = CommandType.StoredProcedure;
                    IDbDataParameter carIdPara = spCommand.CreateParameter();
                    carIdPara.ParameterName = "@TENLOGIN"; 
                    carIdPara.Value = textBox1.Text; //???
                    spCommand.Parameters.Add(carIdPara);

                    IDbDataParameter role = spCommand.CreateParameter();
                    role.ParameterName = "@ROLE";
                    role.Direction = System.Data.ParameterDirection.Output;
                    role.DbType = System.Data.DbType.String;
                    role.Size = 50;
                    spCommand.Parameters.Add(role);
                    spCommand.ExecuteNonQuery();
                    roleTypestr = role.Value.ToString();
                }
                kn.Close();
                
                MessageBox.Show("Đã đăng nhập thành công vào hệ thống, tài khoản đăng nhập thuộc kiểu "+roleTypestr, "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm mainfrm = new MainForm(ServerName,DataBaseName,comboBox1.Text,textBox1.Text,textBox2.Text,roleTypestr,dt,comboBox1,this);
                mainfrm.Show();
                this.Hide();
                
            }catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, chương trình không thể truy cập vào cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // sp này trả về các fields theo thứ tự:
            //Username Groupname    LoginName    DfDBName  UserID  SID

            //try
            //{
            //    Program.myReader = Program.ExecSqlDataReader(strLenh, Program.connstr);

            //}
            //catch (InvalidOperationException)
            //{
            //    MessageBox.Show("Login đăng nhập chưa có quyền truy cập.", "", MessageBoxButtons.OK);
            //    return;
            //}

            //// Lấy user name, group name từ login name
            //if (Program.myReader.Read())
            //{
            //    Program.username = Program.myReader.GetString(0);
            //    Program.mHoten = Program.myReader.GetString(1);
            //    Program.mGroup = Program.myReader.GetString(2);
            //}
            //else
            //{
            //    MessageBox.Show("Lỗi xác định nhóm quyền của nhân viên. ", "", MessageBoxButtons.OK);
            //    return;
            //}

            //Program.myReader.Close();


            //Program.conn.Close();
            //menuStrip1.Enabled = true;

            //MANV.Text = "Mã NV : " + Program.username;
            //MANV.Visible = true;
            //HOTEN.Text = "Họ tên : " + Program.mHoten;
            //HOTEN.Visible = true;
            //NHOM.Text = "Nhóm : " + Program.mGroup;
            //NHOM.Visible = true;
            //menuStrip1.Enabled = true;

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            ServerName = comboBox1.SelectedValue.ToString();
            //comboBox1.Items.Add("Chi nhánh 1");
            //comboBox1.Items.Add("Chi nhánh 2");
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerName = comboBox1.SelectedValue.ToString();
            Console.WriteLine("gia tri: " + comboBox1.SelectedValue.ToString());

            if (textBox1.Text != "" && textBox2.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;

            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            thoigianToolTxt.Text = DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
