using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedDatabase
{
    public partial class AddClient : Form
    {
        SqlConnection kn;
        string branchCode;
        string clientCode;
        UpdateInterface infForm;
        MyStack mystack;

        KhachHang khCu;
        public AddClient(SqlConnection kn, string branchCode,UpdateInterface infForm,MyStack mystack)
        {
            InitializeComponent();
            this.kn = kn;
            this.infForm = infForm;
            this.mystack = mystack;
            //if (atype == AppType.Edit)
            //{
            this.Text = "Thêm thông tin Khách Hàng";
            addBtn.Text = "Thêm";
            //addBtn.Enabled = true;
            this.clientCode = branchCode;
            string str = "exec sp_getKhachHang";
            SqlCommand com = new SqlCommand(str, kn);
            //com.CommandType = CommandType.TableDirecte.StoredProcedure;
            //com.Parameters.AddWithValue("@cmnd", clientCode);

            //SqlDataReader reader = com.e

            //int rowAffected = com.Exe;
            //Console.WriteLine("rowAffected: " + rowAffected);
            //SqlDataReader reader = com.ExecuteReader();
            //}
            //else {
            //    this.Text = "Thêm Khách Hàng";
            //    this.branchCode = branchCode;
            //    chinhanhTxt.Text = branchCode;
            //}
        }

        public AddClient(SqlConnection kn, DataRowView dataview, UpdateInterface infForm,MyStack mystack)
        {
            InitializeComponent();
            this.infForm = infForm;
            this.kn = kn;
            this.mystack = mystack;
            this.Text = "Chỉnh sửa thông tin Khách Hàng";
            addBtn.Text = "Chỉnh sửa";
            addBtn.Enabled = true;
            removeBtn.Visible = true;

            hotenTxt.Text = dataview["HOTEN"].ToString();
            diachiTxt.Text = dataview["DIACHI"].ToString().Trim();
            cmndTxt.Text = dataview["CMND"].ToString().Trim();
            //string pattern = "dd-MM-yyyy";
            string dataValue = dataview["NGAYCAP"].ToString().Trim();
            DateTime result = Convert.ToDateTime(dataValue);
            ngaycapDateTime.Value = result;
            //DateTime.TryParseExact(dataValue, pattern, null, DateTimeStyles.None, out parsedDate);
            //ngaycapDateTime.Value = DateTime.ParseExact("MM/dd/yyyy",dataValue, CultureInfo.InvariantCulture);
            sdtTxt.Text = dataview["SODT"].ToString().Trim();
            string phai = dataview["PHAI"].ToString().Trim();
            if (phai == "NAM")
                maleRdBtn.Checked = true;
            else
                femaleRdBtn.Checked = true;
            chinhanhTxt.Text = dataview["MACN"].ToString().Trim();

            khCu = new KhachHang(hotenTxt.Text, diachiTxt.Text, cmndTxt.Text, dataValue, sdtTxt.Text, phai, dataview["MACN"].ToString().Trim(), StackType.EDIT);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manvTxt_TextChanged(object sender, EventArgs e)
        {
            if ((maleRdBtn.Checked || femaleRdBtn.Checked) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && cmndTxt.Text.Trim() != "")
            {
                addBtn.Enabled = true;
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void hotenTxt_TextChanged(object sender, EventArgs e)
        {
            if ((maleRdBtn.Checked || femaleRdBtn.Checked) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && cmndTxt.Text.Trim() != "")
            {
                addBtn.Enabled = true;
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void diachiTxt_TextChanged(object sender, EventArgs e)
        {
            if ((maleRdBtn.Checked || femaleRdBtn.Checked) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && cmndTxt.Text.Trim() != "")
            {
                addBtn.Enabled = true;
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void sdtTxt_TextChanged(object sender, EventArgs e)
        {
            if ((maleRdBtn.Checked || femaleRdBtn.Checked) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && cmndTxt.Text.Trim() != "")
            {
                addBtn.Enabled = true;
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void cmndTxt_TextChanged(object sender, EventArgs e)
        {
            if ((maleRdBtn.Checked || femaleRdBtn.Checked) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && cmndTxt.Text.Trim() != "")
            {
                addBtn.Enabled = true;
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if ((maleRdBtn.Checked || femaleRdBtn.Checked) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && cmndTxt.Text.Trim() != "")
            {
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
                string cmnd = cmndTxt.Text;
                string ngaycap = ngaycapDateTime.Value.ToString("yyyy-MM-dd");
                string macn = chinhanhTxt.Text;

                using (SqlCommand spCommand = kn.CreateCommand())
                {
                    if (addBtn.Text == "Thêm")
                        spCommand.CommandText = "SP_THEMKH";
                    else if (addBtn.Text == "Chỉnh sửa")
                        spCommand.CommandText = "sp_updateKhachHang";
                    spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    spCommand.Parameters.AddWithValue("@HOTEN", hoten);
                    spCommand.Parameters.AddWithValue("@DIACHI", diachi);
                    spCommand.Parameters.AddWithValue("@CMND", cmnd);
                    spCommand.Parameters.AddWithValue("@NGAYCAP", ngaycap);
                    spCommand.Parameters.AddWithValue("@SODT", sdt);
                    spCommand.Parameters.AddWithValue("@PHAI", phai);
                    spCommand.Parameters.AddWithValue("@MACN", macn);

                    IDbDataParameter retstt = spCommand.CreateParameter();
                    retstt.ParameterName = "@RETURN";
                    retstt.Direction = System.Data.ParameterDirection.ReturnValue;
                    retstt.DbType = System.Data.DbType.Int32;
                    spCommand.Parameters.Add(retstt);
                    try
                    {
                        spCommand.ExecuteNonQuery();

                        if (Convert.ToInt32(retstt.Value) == 1)
                        {
                            if (addBtn.Text == "Thêm") {
                                mystack.stackKhachHang.add(new KhachHang(hoten, diachi, cmnd, ngaycap, sdt, phai, macn, StackType.ADD));
                                MessageBox.Show("Đã thêm thành công Khách Hàng " + hoten + " vào cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (addBtn.Text == "Chỉnh sửa") {
                                mystack.stackKhachHang.add(khCu);
                                MessageBox.Show("Đã thay đổi thành công thông tin của Khách Hàng " + hoten + " trong cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                            if(infForm!=null)
                                infForm.updateGridView();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Đã có khách hàng có cùng số chứng minh nhân dân. Mời bạn xem lại", "Không thể thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (addBtn.Text == "Thêm")
                            MessageBox.Show("Không thể thêm Khách Hàng " + hoten + " vào cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (addBtn.Text == "Chỉnh sửa")
                            MessageBox.Show("Không thể chỉnh sửa thông tin của Khách Hàng " + hoten + " trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn vui lòng nhập vào đầy đủ thông tin", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void maleRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if ((maleRdBtn.Checked || femaleRdBtn.Checked) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && cmndTxt.Text.Trim() != "")
            {
                addBtn.Enabled = true;
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void femaleRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if ((maleRdBtn.Checked || femaleRdBtn.Checked) && hotenTxt.Text.Trim() != "" && diachiTxt.Text.Trim() != "" && sdtTxt.Text.Trim() != "" && cmndTxt.Text.Trim() != "")
            {
                addBtn.Enabled = true;
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void AddClient_Load(object sender, EventArgs e)
        {

        }

        private void sdtTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmndTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void manvTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa Khách Hàng "+hotenTxt.Text+"?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if(result==DialogResult.Yes)
            {
                string hoten, diachi, cmnd, ngaycap, sodt, phai, macn;
                hoten = hotenTxt.Text;
                diachi = diachiTxt.Text;
                cmnd = cmndTxt.Text;
                ngaycap=ngaycapDateTime.Value.ToString("yyyy-MM-dd");
                sodt = sdtTxt.Text;
                phai = "NAM";
                if (maleRdBtn.Checked)
                    phai = "NAM";
                else if (femaleRdBtn.Checked)
                    phai = "NU";
                macn = chinhanhTxt.Text;
                using (SqlCommand spCommand = kn.CreateCommand())
                {
                    spCommand.CommandText = "sp_removeKhachHang";
                    spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    spCommand.Parameters.AddWithValue("@CMND",cmndTxt.Text);

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
                        MessageBox.Show("Không thể xóa Khách Hàng "+hotenTxt.Text, "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Convert.ToInt32(retstt.Value) == 0)
                    {
                        mystack.stackKhachHang.add(new KhachHang(hoten, diachi, cmnd, ngaycap, sodt, phai, macn, StackType.REMOVE));
                        MessageBox.Show("Đã xóa thành công Khách Hàng "+hotenTxt.Text, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }
    }
}
