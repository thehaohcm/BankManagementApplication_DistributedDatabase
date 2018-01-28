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

    public partial class AddStaff : Form
    {
        SqlConnection kn;
        string branchCode;
        UpdateInterface infForm;
        string chinhanhcu;
        MyStack mystack;

        NhanVien nvCuEdit,nvCuRemove;
        public AddStaff(SqlConnection kn, string branchCode, MyStack mystack)
        {
            InitializeComponent();
            this.kn = kn;
            this.branchCode = branchCode;
            this.mystack = mystack;
            chinhanhCmb.Items.Add(branchCode);
            chinhanhCmb.Text = branchCode;
            //if (aType == AppType.Add)
            //{
            this.Text = "Thêm Nhân Viên";
            string str = "exec sp_getLastMaNhanVien";
            SqlCommand com = new SqlCommand(str, kn);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                if (reader.Read())
                {
                    string a_str = reader["MANV"].ToString().Trim().ToUpper();
                    //int a = Convert.ToInt32(a_str.Substring(3))+1;
                    manvTxt.Text = a_str.ToString();
                }
            }
            if (manvTxt.Text.Trim() == "")
                manvTxt.Text = "NV";
            //}
            //else
            //    this.Text = "Chỉnh sửa thông tin Nhân Viên";
        }

        public AddStaff(SqlConnection kn, DataRowView dataview, UpdateInterface infForm,MyStack mystack)
        {
            InitializeComponent();
            this.kn = kn;
            getChiNhanh();
            
            this.infForm = infForm;
            this.mystack = mystack;
            this.Text = "Chỉnh sửa thông tin Nhân Viên";
            themcsBtn.Text = "Chỉnh sửa";
            manvTxt.ReadOnly = true;
            removeBtn.Visible = true;
            //themcsBtn.Enabled = true;
            manvTxt.Text = dataview["MANV"].ToString().Trim();
            hotenTxt.Text = dataview["HOTEN"].ToString().Trim();
            diachiTxt.Text = dataview["DIACHI"].ToString().Trim();
            string phai = dataview["PHAI"].ToString().Trim();
            if (phai == "NAM")
                maleRdBtn.Checked = true;
            else
                femaleRdBtn.Checked = true;

            sdtTxt.Text = dataview["SODT"].ToString().Trim();
            chinhanhCmb.Text = dataview["MACN"].ToString().Trim();
            chinhanhcu = dataview["MACN"].ToString().Trim();

            nvCuEdit = new NhanVien(hotenTxt.Text, diachiTxt.Text, manvTxt.Text, phai, sdtTxt.Text, chinhanhcu, StackType.EDIT);
            nvCuRemove=new NhanVien(hotenTxt.Text, diachiTxt.Text, manvTxt.Text, phai, sdtTxt.Text, chinhanhcu, StackType.REMOVE);
        }

        private void getChiNhanh()
        {
            //SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-QN5U73D;Initial Catalog=BANKING;User ID=Support_Connect;Password=12345");
            //kn.Open();
            string str = "exec sp_GetMaCNAsCode";
            SqlCommand com = new SqlCommand(str, kn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            chinhanhCmb.DataSource = dt;
            chinhanhCmb.DisplayMember = dt.Columns["MACN"].ToString();
            chinhanhCmb.ValueMember = dt.Columns["MACN"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (manvTxt.Text.Trim() != "" && (maleRdBtn.Checked == true || femaleRdBtn.Checked == true) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && chinhanhCmb.Text.Trim() != "")
            {
                string manv = manvTxt.Text;
                string phai = "";
                if (maleRdBtn.Checked)
                    phai = "NAM";
                else if (femaleRdBtn.Checked)
                    phai = "NU";
                if (phai == "")
                {
                    MessageBox.Show("Bạn chưa chọn giới tính của khách hàng", "Vui lòng chọn giới tính của khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string hoten = hotenTxt.Text;
                string diachi = diachiTxt.Text;
                string sdt = sdtTxt.Text;
                string macn = chinhanhCmb.Text;

                using (SqlCommand spCommand = kn.CreateCommand())
                {
                    if (themcsBtn.Text == "Thêm")
                    {

                        spCommand.CommandText = "SP_THEMNHANVIEN";
                    }
                    else if (themcsBtn.Text == "Chỉnh sửa")
                    {
                        spCommand.CommandText = "sp_updateNhanVien";
                    }
                    spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    spCommand.Parameters.AddWithValue("@HOTEN", hoten);
                    spCommand.Parameters.AddWithValue("@DIACHI", diachi);
                    spCommand.Parameters.AddWithValue("@MANV", manv);
                    spCommand.Parameters.AddWithValue("@PHAI", phai);
                    spCommand.Parameters.AddWithValue("@SODT", sdt);
                    spCommand.Parameters.AddWithValue("@MACN", macn);

                    IDbDataParameter retstt = spCommand.CreateParameter();
                    retstt.ParameterName = "@RETURN";
                    retstt.Direction = System.Data.ParameterDirection.ReturnValue;
                    retstt.DbType = System.Data.DbType.Int32;
                    spCommand.Parameters.Add(retstt);
                    try
                    {
                        spCommand.ExecuteNonQuery();
                        if (Convert.ToInt32(retstt.Value) == 0)
                        {
                            if (themcsBtn.Text == "Thêm")
                            {
                                mystack.stackNhanVien.add(new NhanVien(hoten, diachi, manv, phai, sdt, macn, StackType.ADD));
                                MessageBox.Show("Đã thêm thành công Nhân Viên " + hotenTxt.Text + " vào cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                mystack.stackNhanVien.add(nvCuEdit);
                                MessageBox.Show("Đã chỉnh sửa thành công Nhân Viên "+hotenTxt.Text,"Thành công",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                if (!macn.Trim().Equals(chinhanhcu.Trim()))
                                {
                                    using (SqlCommand spCommand1 = kn.CreateCommand())
                                    {
                                        spCommand1.CommandText = "sp_transferNV";
                                        spCommand1.CommandType = System.Data.CommandType.StoredProcedure;
                                        spCommand1.Parameters.AddWithValue("@MANV", manv);
                                        spCommand1.Parameters.AddWithValue("@MACN", macn);

                                        IDbDataParameter retstt1 = spCommand1.CreateParameter();
                                        retstt1.ParameterName = "@RETURN";
                                        retstt1.Direction = System.Data.ParameterDirection.ReturnValue;
                                        retstt1.DbType = System.Data.DbType.Int32;
                                        spCommand.Parameters.Add(retstt1);
                                        try
                                        {
                                            spCommand.ExecuteNonQuery();
                                            //mystack.stackNhanVien.add(new NhanVien(hoten, diachi, manv, phai, sdt, macn, StackType.CHUYENCHINHANH));
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Không thể chuyển nhân viên", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                    }
                                }
                            }
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Đã có Nhân Viên trong Ngân Hàng có cùng Mã Nhân Viên như vậy. Mời bạn xem lại", "Không thể thêm Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (infForm != null)
                        {
                            infForm.updateGridView();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (themcsBtn.Text == "Thêm")
                            MessageBox.Show("Không thể thêm Nhân Viên " + hotenTxt.Text + " vào cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (themcsBtn.Text == "Chỉnh sửa")
                            MessageBox.Show("Không thể chỉnh sửa thông tin Nhân Viên " + hotenTxt.Text + "trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }

                
            }
            else
            {
                MessageBox.Show("Bạn vui lòng nhập vào đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void manvTxt_TextChanged(object sender, EventArgs e)
        {
            if (manvTxt.Text.Trim() != "" && (maleRdBtn.Checked == true || femaleRdBtn.Checked == true) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && chinhanhCmb.Text.Trim() != "")
            {
                themcsBtn.Enabled = true;
            }
            else
            {
                themcsBtn.Enabled = false;
            }
        }

        private void hotenTxt_TextChanged(object sender, EventArgs e)
        {
            if (manvTxt.Text.Trim() != "" && (maleRdBtn.Checked == true || femaleRdBtn.Checked == true) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && chinhanhCmb.Text.Trim() != "")
            {
                themcsBtn.Enabled = true;
            }
            else
            {
                themcsBtn.Enabled = false;
            }
        }

        private void diachiTxt_TextChanged(object sender, EventArgs e)
        {
            if (manvTxt.Text.Trim() != "" && (maleRdBtn.Checked == true || femaleRdBtn.Checked == true) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && chinhanhCmb.Text.Trim() != "")
            {
                themcsBtn.Enabled = true;
            }
            else
            {
                themcsBtn.Enabled = false;
            }
        }

        private void sdtTxt_TextChanged(object sender, EventArgs e)
        {
            if (manvTxt.Text.Trim() != "" && (maleRdBtn.Checked == true || femaleRdBtn.Checked == true) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && chinhanhCmb.Text.Trim() != "")
            {
                themcsBtn.Enabled = true;
            }
            else
            {
                themcsBtn.Enabled = false;
            }
        }

        private void chinhanhCmb_TextChanged(object sender, EventArgs e)
        {
            if (manvTxt.Text.Trim() != "" && (maleRdBtn.Checked == true || femaleRdBtn.Checked == true) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && chinhanhCmb.Text.Trim() != "")
            {
                themcsBtn.Enabled = true;
            }
            else
            {
                themcsBtn.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maleRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (manvTxt.Text.Trim() != "" && (maleRdBtn.Checked == true || femaleRdBtn.Checked == true) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && chinhanhCmb.Text.Trim() != "")
            {
                themcsBtn.Enabled = true;
            }
            else
            {
                themcsBtn.Enabled = false;
            }
        }

        private void femaleRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (manvTxt.Text.Trim() != "" && (maleRdBtn.Checked == true || femaleRdBtn.Checked == true) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && chinhanhCmb.Text.Trim() != "")
            {
                themcsBtn.Enabled = true;
            }
            else
            {
                themcsBtn.Enabled = false;
            }
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            //chinhanhCmb.Text = branchCode;
            //manvTxt.GotFocus += delegate { manvTxt.Select(3, manvTxt.Text.Length); };
            //manvTxt.SelectionStart = manvTxt.Text.Length - 1; // add some logic if length is 0
            //manvTxt.SelectionLength = 0;
        }

        private void sdtTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void manvTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (manvTxt.SelectionStart > 2)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            else if (manvTxt.SelectionStart == 2)
                e.Handled = !char.IsDigit(e.KeyChar);
            else
                e.Handled = true;

        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa Nhân Viên " + hotenTxt.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                string phai="NAM";
                if (maleRdBtn.Checked)
                    phai = "NAM";
                else if (femaleRdBtn.Checked)
                    phai = "NU";
                using (SqlCommand spCommand = kn.CreateCommand())
                {
                    spCommand.CommandText = "sp_removeNhanVien";
                    spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    spCommand.Parameters.AddWithValue("@MANV", manvTxt.Text);

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
                        MessageBox.Show("Không thể xóa Nhân Viên " + hotenTxt.Text, "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Convert.ToInt32(retstt.Value) == 0)
                    {
                        mystack.stackNhanVien.add(nvCuRemove);
                        MessageBox.Show("Đã xóa thành công Nhân Viên " + hotenTxt.Text, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void chinhanhCmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
