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
    public partial class TransferMoneyForm : Form
    {
        List<string> items;
        SqlConnection kn;
        string manv, macn;
        public TransferMoneyForm(SqlConnection kn, string manv, string macn)
        {
            this.kn = kn;
            this.manv = manv;
            this.macn = macn;
            InitializeComponent();
        }

        private void getInfo(string makh)
        {

        }

        private void clearInfo()
        {

        }

        private void tkGuiTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void infoBtn_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void TransferMoneyForm_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            tabPage2.Hide();
            panel1.Enabled = false;
            sotienTxt.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ListViewItem lvi = listView1.Items.Add("666");
            //lvi.SubItems.Add("665");
            clearInfo();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void sotienTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tkGuiTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void sotienTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            manv = "NV0001";
            if (giaodichCmb.Text == "Chuyển Tiền" && ((tkGuiTxt.Text == tkNhanTxt1.Text) || (checkBox2.Checked == true && (tkGuiTxt.Text == tkNhanTxt2.Text))))
            {
                MessageBox.Show("Tài khoản gửi và nhận giống nhau, mời bạn xem lại", "Trùng tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check hoten và cmnd cua cac doi tuong
            using (SqlCommand spCommand = kn.CreateCommand())
            {
                spCommand.CommandText = "sp_checkAllSoTKHoTenKH";
                spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                spCommand.Parameters.AddWithValue("@sotk1", tkGuiTxt.Text);
                spCommand.Parameters.AddWithValue("@hoten1", hotenGuiTxt.Text);

                if (tkNhanTxt1.Enabled == true)
                {
                    spCommand.Parameters.AddWithValue("@sotk2", tkNhanTxt1.Text);
                    spCommand.Parameters.AddWithValue("@hoten2", hotenNhanTxt1.Text);
                }

                if (tkNhanTxt2.Enabled == true)
                {
                    spCommand.Parameters.AddWithValue("@sotk3", tkNhanTxt2.Text);
                    spCommand.Parameters.AddWithValue("@hoten3", hotenNhanTxt2.Text);
                }

                IDbDataParameter retstt = spCommand.CreateParameter();
                retstt.ParameterName = "@RETURN";
                retstt.Direction = System.Data.ParameterDirection.ReturnValue;
                retstt.DbType = System.Data.DbType.Int32;
                spCommand.Parameters.Add(retstt);
                try
                {
                    spCommand.ExecuteNonQuery();
                    switch (Convert.ToInt32(retstt.Value))
                    {
                        case -1:
                            MessageBox.Show("Không tìm thấy Khách Hàng gửi tiền như vậy. Mời bạn xem lại", "Không tìm thấy khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case -2:
                            MessageBox.Show("Không tìm thấy Khách Hàng nhận tiền như vậy. Mời bạn xem lại", "Không tìm thấy khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case -3:
                            MessageBox.Show("Không tìm thấy Khách Hàng nhận tiền như vậy. Mời bạn xem lại", "Không tìm thấy khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 1:
                            using (SqlCommand spCommand1 = kn.CreateCommand())
                            {
                                try
                                {
                                    spCommand1.CommandText = "sp_tranferMoney";
                                    spCommand1.CommandType = System.Data.CommandType.StoredProcedure;
                                    spCommand1.Parameters.AddWithValue("@sotk", tkGuiTxt.Text);

                                    switch (giaodichCmb.Text)
                                    {
                                        case "Gửi Tiền":
                                            spCommand1.Parameters.AddWithValue("@sotknhan", tkGuiTxt.Text);
                                            spCommand1.Parameters.AddWithValue("@moneychr", sotienTxt.Text);
                                            spCommand1.Parameters.AddWithValue("@loaigd", "GT");
                                            break;
                                        case "Chuyển Tiền":
                                            spCommand1.Parameters.AddWithValue("@sotknhan", tkNhanTxt1.Text);
                                            spCommand1.Parameters.AddWithValue("@moneychr", sotienTxt1.Text);
                                            spCommand1.Parameters.AddWithValue("@loaigd", "CT");
                                            break;
                                        case "Rút Tiền":
                                            spCommand1.Parameters.AddWithValue("@sotknhan", tkGuiTxt.Text);
                                            spCommand1.Parameters.AddWithValue("@moneychr", sotienTxt.Text);
                                            spCommand1.Parameters.AddWithValue("@loaigd", "RT");
                                            break;
                                    }
                                    spCommand1.Parameters.AddWithValue("@manv", manv);
                                    spCommand1.Parameters.AddWithValue("@macn", macn);
                                    IDbDataParameter retstt1 = spCommand1.CreateParameter();
                                    retstt1.ParameterName = "@RETURN";
                                    retstt1.Direction = System.Data.ParameterDirection.ReturnValue;
                                    retstt1.DbType = System.Data.DbType.Int32;
                                    spCommand1.Parameters.Add(retstt1);
                                    try
                                    {
                                        spCommand1.ExecuteNonQuery();
                                        int kq = Convert.ToInt32(retstt1.Value);
                                        switch (kq)
                                        {
                                            case -2:
                                                MessageBox.Show("Sai loại giao dịch, mong bạn xem lại", "Sai loại giao dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                break;
                                            case -1:
                                                MessageBox.Show("Tài khoản gửi không đủ tiền thực hiện giao dịch, xin vui lòng xem lại", "Không đủ tiền thực hiện giao dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                break;
                                            case 0:
                                                MessageBox.Show("Có tài khoản không tồn tại, mong bạn xem lại", "Trùng tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                break;
                                            case 1:
                                                MessageBox.Show("Đã giao dịch thành công", "Giao dịch thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Đã có lỗi xảy ra, chương trình không thể giao dịch", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Đã có lỗi xảy ra, chương trình không thể giao dịch", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            if (giaodichCmb.Text == "Chuyển Tiền" && checkBox2.Checked == true && !tkNhanTxt1.Text.Trim().Equals("") && !sotienTxt2.Text.Trim().Equals(""))
                            {
                                using (SqlCommand spCommand1 = kn.CreateCommand())
                                {
                                    try
                                    {
                                        spCommand1.CommandText = "sp_tranferMoney";
                                        spCommand1.CommandType = System.Data.CommandType.StoredProcedure;
                                        spCommand1.Parameters.AddWithValue("@sotk", tkGuiTxt.Text);
                                        spCommand1.Parameters.AddWithValue("@sotknhan", tkNhanTxt2.Text);
                                        spCommand1.Parameters.AddWithValue("@moneychr", sotienTxt2.Text);
                                        spCommand1.Parameters.AddWithValue("@loaigd", "CT");
                                        spCommand1.Parameters.AddWithValue("@manv", manv);
                                        spCommand1.Parameters.AddWithValue("@macn", macn);
                                        IDbDataParameter retstt1 = spCommand1.CreateParameter();
                                        retstt1.ParameterName = "@RETURN";
                                        retstt1.Direction = System.Data.ParameterDirection.ReturnValue;
                                        retstt1.DbType = System.Data.DbType.Int32;
                                        spCommand1.Parameters.Add(retstt1);
                                        try
                                        {
                                            spCommand1.ExecuteNonQuery();
                                            int kq = Convert.ToInt32(retstt1.Value);
                                            switch (kq)
                                            {
                                                case -2:
                                                    MessageBox.Show("Sai loại giao dịch, mong bạn xem lại", "Sai loại giao dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    break;
                                                case -1:
                                                    MessageBox.Show("Tài khoản gửi không đủ tiền thực hiện giao dịch, xin vui lòng xem lại", "Không đủ tiền thực hiện giao dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    break;
                                                case 0:
                                                    MessageBox.Show("Có tài khoản không tồn tại, mong bạn xem lại", "Trùng tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    break;
                                                case 1:
                                                    MessageBox.Show("Đã giao dịch thành công", "Giao dịch thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.Close();
                                                    break;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Đã có lỗi xảy ra, chương trình không thể giao dịch chuyển tiền cho tài khoản thứ 2", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Đã có lỗi xảy ra, chương trình không thể giao dịch chuyển tiền cho tài khoản thứ 2", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể gọi yêu cầu cho máy chủ", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void tkNhanTxt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void sotienTxt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void giaodichCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (giaodichCmb.Text.Equals("Chuyển Tiền"))
            {
                groupBox2.Enabled = true;
                tabPage2.Show();
                sotienTxt.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = false;
                tabPage2.Hide();
                sotienTxt.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                panel1.Enabled = true;
            else
                panel1.Enabled = false;
        }
    }
}
