using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DistributedDatabase
{
    public partial class TaiKhoanUC : UserControl
    {

        SqlConnection kn;
        string branchCode;
        UpdateInterface infForm;
        MyStack mystack;

        TaiKhoan tkcu;
        public TaiKhoanUC()
        {
            InitializeComponent();
        }

        private void TaiKhoanUC_Load(object sender, EventArgs e)
        {

        }

        public void setBefore(SqlConnection kn, string branchCode, MyStack mystack)
        {
            this.kn = kn;
            this.branchCode = branchCode;
            chinhanhTxt.Text = branchCode;
            this.Text = "Thêm Tài Khoản";
            this.mystack = mystack;
            string str = "exec sp_getLastSoTaiKhoan";
            SqlCommand com = new SqlCommand(str, kn);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                if (reader.Read())
                {
                    string a_str = reader["SOTK"].ToString().Trim().ToUpper();
                    int a = Convert.ToInt32(a_str) + 1;
                    maTKTxt.Text = a.ToString();
                }
            }
            if (maTKTxt.Text.Trim() == "")
                maTKTxt.Text = "";

            removeBtn.Visible = false;
            cmndTxt.Text = "";
            soduTxt.Text = "";
            themcsBtn.Text = "Thêm";

        }

        public void setBeforeEdit(SqlConnection kn, DataRowView dataview, UpdateInterface infForm, MyStack mystack)
        {
            this.kn = kn;
            this.infForm = infForm;
            this.mystack = mystack;
            this.Text = "Chỉnh sửa thông tin tài khoản";
            themcsBtn.Text = "Chỉnh sửa";
            maTKTxt.ReadOnly = true;
            cmndTxt.ReadOnly = true;
            removeBtn.Visible = true;
            //themcsBtn.Enabled = true;
            maTKTxt.Text = dataview["SOTK"].ToString().Trim();
            cmndTxt.Text = dataview["CMND"].ToString().Trim();
            soduTxt.Text = dataview["SODU"].ToString().Trim();

            tkcu = new TaiKhoan(maTKTxt.Text, cmndTxt.Text, soduTxt.Text, StackType.EDIT);
        }

        private void themcsBtn_Click(object sender, EventArgs e)
        {
            string sotk = maTKTxt.Text;
            string cmnd = cmndTxt.Text;
            string sodu = soduTxt.Text;
            using (SqlCommand spCommand = kn.CreateCommand())
            {
                if (themcsBtn.Text == "Thêm")
                    spCommand.CommandText = "SP_THEMTAIKHOAN";
                else if (themcsBtn.Text == "Chỉnh sửa")
                    spCommand.CommandText = "sp_updateTaiKhoan";
                spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                spCommand.Parameters.AddWithValue("@SOTK", sotk);
                spCommand.Parameters.AddWithValue("@CMND", cmnd);
                spCommand.Parameters.AddWithValue("@SODU", sodu);

                IDbDataParameter retstt = spCommand.CreateParameter();
                retstt.ParameterName = "@RETURN";
                retstt.Direction = System.Data.ParameterDirection.ReturnValue;
                retstt.DbType = System.Data.DbType.Int32;
                spCommand.Parameters.Add(retstt);
                try
                {
                    spCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (themcsBtn.Text == "Thêm")
                        MessageBox.Show("Không thể thêm Tài Khoản" + sotk + " vào cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (themcsBtn.Text == "Chỉnh sửa")
                        MessageBox.Show("Không thể chỉnh sửa thông tin của Tài Khoản " + sotk + " trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToInt32(retstt.Value) == 0)
                {
                    if (themcsBtn.Text == "Thêm")
                    {
                        mystack.stackTaiKhoan.add(new TaiKhoan(sotk, cmnd, sodu, StackType.ADD));
                        MessageBox.Show("Đã thêm thành công Tài Khoản " + sotk + " vào cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (themcsBtn.Text == "Chỉnh sửa")
                    {
                        mystack.stackTaiKhoan.add(tkcu);
                        MessageBox.Show("Đã thay đổi thành công thông tin của Tài Khoản " + sotk + " trong cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    infForm.updateGridView();
                    //mystack.stackTaiKhoan.resetRedo();
                    
                }
            }
        }
    }
}
