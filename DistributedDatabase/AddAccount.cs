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
    public partial class AddAccount : Form
    {
        SqlConnection kn;
        string branchCode;
        UpdateInterface infForm;
        MyStack mystack;

        TaiKhoan tkcu;
        public AddAccount(SqlConnection kn, string branchCode,MyStack mystack)
        {
            InitializeComponent();
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

        }

        public AddAccount(SqlConnection kn, DataRowView dataview, UpdateInterface infForm,MyStack mystack)
        {
            InitializeComponent();
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
            string sotk =maTKTxt.Text;
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
                    this.Close();
                }
            }
        }

        private void AddAccount_Load(object sender, EventArgs e)
        {
            hotenCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmndTxt.ReadOnly = true;
            sdtCbb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void maKHRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            hotenCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmndTxt.ReadOnly = true;
            sdtCbb.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void hotenRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            hotenCbb.DropDownStyle = ComboBoxStyle.DropDown;
            cmndTxt.ReadOnly = true;
            sdtCbb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmndRdb_CheckedChanged(object sender, EventArgs e)
        {
            hotenCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmndTxt.ReadOnly = false;
            sdtCbb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void sdtRdb_CheckedChanged(object sender, EventArgs e)
        {
            hotenCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmndTxt.ReadOnly = true;
            sdtCbb.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void cmndTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void sdtCbb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void maTKTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa Tài Khoản " + maTKTxt.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                string cmnd, sodu;
                string sotk = maTKTxt.Text;
                cmnd = cmndTxt.Text;
                sodu = soduTxt.Text;
                using (SqlCommand spCommand = kn.CreateCommand())
                {
                    spCommand.CommandText = "sp_removeTaiKhoan";
                    spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    spCommand.Parameters.AddWithValue("@SOTK", maTKTxt.Text);

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
                        MessageBox.Show("Không thể xóa Tài Khoản " + maTKTxt.Text, "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Convert.ToInt32(retstt.Value) == 0)
                    {
                        mystack.stackTaiKhoan.add(new TaiKhoan(sotk, cmnd, sodu, StackType.REMOVE));
                        MessageBox.Show("Đã xóa thành công Tài Khoản " + maTKTxt.Text, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (cmndRdb.Checked && cmndTxt.Text.Trim() != "")
                {
                    using (SqlCommand spCommand = kn.CreateCommand())
                    {
                        spCommand.CommandText = "sp_searchKH_TaoTK";
                        spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        spCommand.Parameters.AddWithValue("@cmnd", cmndTxt.Text);

                        SqlDataAdapter da = new SqlDataAdapter(spCommand);
                        DataTable dt = new DataTable();
                        dt.Rows.Clear();
                        spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        dt.Load(spCommand.ExecuteReader());

                        if (dt.Rows.Count > 0)
                        {
                            hotenCbb.Items.Add(dt.Rows[0]["HOTEN"].ToString());
                            sdtCbb.Items.Add(dt.Rows[0]["SODT"].ToString());
                            chinhanhTxt.Text = dt.Rows[0]["MACN"].ToString();
                            hotenCbb.Text = hotenCbb.Items[0].ToString();
                            sdtCbb.Text = sdtCbb.Items[0].ToString();
                        }
                        //else
                        //{

                        //}
                    }
                }
                //else if (sdtRdb.Checked && sdtCbb.Text.Trim() != null)
                //{
                //    using (SqlCommand spCommand = kn.CreateCommand())
                //    {
                //        spCommand.CommandText = "sp_searchSDT_TaoTK";
                //        spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                //        spCommand.Parameters.AddWithValue("@sodt", sdtCbb.Text);

                //        SqlDataAdapter da = new SqlDataAdapter(spCommand);
                //        DataTable dt = new DataTable();
                //        dt.Rows.Clear();
                //        spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                //        dt.Load(spCommand.ExecuteReader());

                //        //comboBox1.DataSource = dt;
                //        comboBox1.DisplayMember = dt.Columns["description"].ToString();
                //        //comboBox1.ValueMember = dt.Columns["subscriber"].ToString();
                //    }
                //}
            }catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, chương trình không thể tìm thấy thông tin Khách Hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
