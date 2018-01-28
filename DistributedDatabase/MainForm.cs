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
using DevExpress.XtraTabbedMdi;
using System.Windows.Forms.Design;

namespace DistributedDatabase
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        string Type;
        string ServerName, DataBaseName, username, password;
        string branchCode;

        string brandName;

        DataRowView choosedItem;

        SqlConnection kn;
        
        RoleType role;

        MyStack mystack;

        LoginForm lgForm;

        string linkServer;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm form = Test_Ketnoi(typeof(XtraForm), SubApp.KHACHHANG);
            AddClient formAddClient = new AddClient(kn, branchCode, form,mystack);
            formAddClient.ShowDialog();
            disableKH();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddAccount formAddAccount = new AddAccount(kn, branchCode, mystack);
            formAddAccount.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm form = Test_Ketnoi(typeof(XtraForm), SubApp.NHANVIEN);
            if (choosedItem != null && form != null)
            {
                AddStaff staffForm = new AddStaff(kn, choosedItem,form,mystack);
                staffForm.ShowDialog();
            }
            disableNV();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddStaff formAddStaff = new AddStaff(kn, branchCode,mystack);
            formAddStaff.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //CrystalReport1 crRp1 = new CrystalReport1();
            //crRp1.SetParameterValue("sotk", "19213");
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            editKHBtn.Enabled = false;
            removeKHBtn.Enabled = false;
            editTKBtn.Enabled = false;
            removeTKBtn.Enabled = false;
            editNVBtn.Enabled = false;
            removeNVBtn.Enabled = false;
            editCNBtn.Enabled = false;
            removeCNBtn.Enabled = false;
        }

        public void enableKH(DataRowView item)
        {
            this.choosedItem = item;
            editKHBtn.Enabled = true;
            removeKHBtn.Enabled = true;
        }

        public void disableKH()
        {
            editKHBtn.Enabled = false;
            removeKHBtn.Enabled = false;
        }

        public void enableNV(DataRowView item)
        {
            this.choosedItem = item;
            editNVBtn.Enabled = true;
            removeNVBtn.Enabled = true;
        }

        public void disableNV()
        {
            editNVBtn.Enabled = false;
            removeNVBtn.Enabled = false;
        }

        public void enableCN(DataRowView item)
        {
            this.choosedItem = item;
            editCNBtn.Enabled = true;
            removeCNBtn.Enabled = true;
        }

        public void disableCN()
        {
            editCNBtn.Enabled = false;
            removeCNBtn.Enabled = false;
        }

        public void enableTK(DataRowView item)
        {
            this.choosedItem = item;
            editTKBtn.Enabled = true;
            removeTKBtn.Enabled = true;
        }

        public void disableTK()
        {
            editTKBtn.Enabled = false;
            removeTKBtn.Enabled = false;
        }

        public void removeNV()
        {
            if (choosedItem != null)
            {
                string manv = choosedItem["MANV"].ToString().Trim();
                DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa Nhân Viên: " + manv, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlCommand spCommand = kn.CreateCommand())
                    {
                        spCommand.CommandText = "sp_removeNhanVien";
                        spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        spCommand.Parameters.AddWithValue("@manv", manv);

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
                            MessageBox.Show("Không thể xóa Nhân Viên trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (Convert.ToInt32(retstt.Value) == 0)
                        {
                            MessageBox.Show("Đã xóa thành công Nhân Viên trong cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        public void removeKH()
        {
            if (choosedItem != null)
            {
                string cmnd = choosedItem["CMND"].ToString().Trim();
                string hoten = choosedItem["HOTEN"].ToString().Trim();
                DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa Khách Hàng: " + hoten, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlCommand spCommand = kn.CreateCommand())
                    {
                        spCommand.CommandText = "sp_removeKhachHang";
                        spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        spCommand.Parameters.AddWithValue("@cmnd", cmnd);

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
                            MessageBox.Show("Không thể xóa Khách Hàng trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (Convert.ToInt32(retstt.Value) == 0)
                        {
                            MessageBox.Show("Đã xóa thành công Khách Hàng trong cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        public void removeTK()
        {
            if (choosedItem != null)
            {
                string sotk = choosedItem["SOTK"].ToString().Trim();
                DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa Tài Khoản: " + sotk, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlCommand spCommand = kn.CreateCommand())
                    {
                        spCommand.CommandText = "sp_removeTaiKhoan";
                        spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        spCommand.Parameters.AddWithValue("@sotk", sotk);

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
                            MessageBox.Show("Không thể xóa Nhân Viên trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (Convert.ToInt32(retstt.Value) == 0)
                        {
                            MessageBox.Show("Đã xóa thành công Tài Khoảng trong cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        public void permissionAccess()
        {
            switch (role)
            {
                case RoleType.CHINHANH:

                    break;
                case RoleType.NGANHANG:

                    break;
            }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.Test_Ketnoi(typeof(XtraForm), SubApp.NHANVIEN);
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                XtraForm frm1 = new XtraForm(kn, SubApp.NHANVIEN,mystack,branchCode);//(kn,"nhanvien");
                frm1.MdiParent = this;
                frm1.Show();
            }
        }

        public MainForm(string ServerName, string DataBaseName,string brandName, string username, string password, string Type,DataTable dt,ComboBox cmb,LoginForm lgForm)
        {
            InitializeComponent();
            //chinhanhCmbStrip.DataSource = cmb.DataSource;
            ////comboBox1.DataSource = dt;
            //chinhanhCmbStrip.DisplayMember = cmb.DisplayMember;
            //comboBox1.ValueMember = dt.Columns["subscriber"].ToString();
            chinhanhCmbTlS.ComboBox.DataSource = dt;
            chinhanhCmbTlS.ComboBox.DisplayMember = dt.Columns["description"].ToString();
            chinhanhCmbTlS.ComboBox.ValueMember = dt.Columns["subscriber"].ToString();

            chinhanhCmbTlS.ComboBox.Text = cmb.Text;

            
            this.ServerName = ServerName;
            this.linkServer = ServerName;
            this.DataBaseName = DataBaseName;
            this.username = username;
            this.password = password;
            this.Type = Type;
            if (Type == "NGANHANG")
                role = RoleType.NGANHANG;
            else
                role = RoleType.CHINHANH;

            if (Type == "")
                Type = "Chi Nhánh";

            kn = new SqlConnection(@"Data Source=" + ServerName + ";Initial Catalog=BANKING;User ID=" + username + ";Password=" + password);
            kn.Open();

            mystack = new MyStack(kn);
            string str = "exec sp_getBranchCode";
            SqlCommand com = new SqlCommand(str, kn);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                if (reader.Read())
                {
                    branchCode = reader["MACN"].ToString().Trim().ToUpper();
                }
            }

            this.brandName = brandName;
            this.lgForm = lgForm;

            manvToolTxt.Text = "Mã Nhân Viên: " + username;
            typeToolTxt.Text = "Kiểu: " + Type;
            chinhanhToolTxt.Text = brandName;

            thoigianToolTxt.Text = DateTime.Now.Date.ToShortDateString()+" "+ DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            timer1.Start();

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm frm = this.Test_Ketnoi(typeof(XtraForm), SubApp.NHANVIEN);

            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                Console.Write(frm);
                XtraForm frm1 = new XtraForm(kn, SubApp.NHANVIEN,mystack,branchCode);//(kn,"nhanvien");
                frm1.MdiParent = this;
                frm1.Show();
            }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm frm = this.Test_Ketnoi(typeof(XtraForm), SubApp.KHACHHANG);

            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                XtraForm frm1 = new XtraForm(kn, SubApp.KHACHHANG,mystack,branchCode);//(kn,"nhanvien");
                frm1.MdiParent = this;
                frm1.Show();
            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm frm = this.Test_Ketnoi(typeof(XtraForm), SubApp.TAIKHOAN);
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                XtraForm frm1 = new XtraForm(kn, SubApp.TAIKHOAN,mystack,branchCode);//(kn,"nhanvien");
                frm1.MdiParent = this;
                frm1.Show();
            }
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm frm = this.Test_Ketnoi(typeof(XtraForm), SubApp.GIAODICH);
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frm = new XtraForm(kn, SubApp.GIAODICH,mystack,branchCode);//(kn,"nhanvien");
                frm.MdiParent = this;
                frm.Show();
            }
            GiaoDichOption giaoDichForm = new GiaoDichOption(frm, kn);
            giaoDichForm.ShowDialog();
        }

        private void editKHBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm form = Test_Ketnoi(typeof(XtraForm), SubApp.KHACHHANG);
            if (choosedItem != null&&form!=null)
            {
                AddClient clientForm = new AddClient(kn, choosedItem,form,mystack);
                clientForm.ShowDialog();
            }
            disableKH();
            
        }

        private void editTKBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm form = Test_Ketnoi(typeof(XtraForm), SubApp.TAIKHOAN);
            if (choosedItem != null && form != null)
            {
                AddAccount accountForm = new AddAccount(kn, choosedItem,form,mystack);
                accountForm.ShowDialog();
            }
            disableTK();
        }

        private void removeTKBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            removeTK();
            XtraForm choosedForm = Test_Ketnoi(typeof(XtraForm), SubApp.TAIKHOAN);
            if (choosedForm != null)
                choosedForm.updateGridView();
            disableTK();
        }

        private void removeNVBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            removeNV();
            XtraForm choosedForm = Test_Ketnoi(typeof(XtraForm), SubApp.NHANVIEN);
            if(choosedForm!=null)
                choosedForm.updateGridView();
            disableNV();
        }

        private void removeKHBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            removeKH();
            XtraForm choosedForm = Test_Ketnoi(typeof(XtraForm), SubApp.KHACHHANG);
            if (choosedForm != null)
                choosedForm.updateGridView();
            disableKH();
        }

        private void editCNBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TransferMoneyForm transferForm = new TransferMoneyForm(kn,username,branchCode);
            transferForm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            thoigianToolTxt.Text =  DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

        }

        private void timeToolTxt_Click(object sender, EventArgs e)
        {

        }

        private void thoigianToolTxt_Click(object sender, EventArgs e)
        {

        }

        private void manvToolTxt_Click(object sender, EventArgs e)
        {

        }

        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }

        private void chinhanhCmbTlS_Click(object sender, EventArgs e)
        {
            
        }

        private void chinhanhCmbTlS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (linkServer != null && !linkServer.Equals(chinhanhCmbTlS.ComboBox.SelectedValue.ToString()))
                {

                    linkServer = chinhanhCmbTlS.ComboBox.SelectedValue.ToString();
                    if (ServerName.Equals(DatabaseConnection.linkServer1))
                    {
                        if (linkServer.Equals(DatabaseConnection.linkServer2))
                        {
                            kn.Close();
                            kn = new SqlConnection(@"Data Source=" + DatabaseConnection.linkServer2 + ";Initial Catalog=BANKING;User ID=" +
                                DatabaseConnection.username2 + ";Password=" + DatabaseConnection.password2);
                            kn.Open();
                        }
                        else
                        {
                            kn.Close();
                            kn = new SqlConnection(@"Data Source=" + ServerName + ";Initial Catalog=BANKING;User ID=" + username + ";Password=" + password);
                            kn.Open();
                        }
                    }
                    else if (ServerName.Equals(DatabaseConnection.linkServer2))
                    {
                        if (linkServer.Equals(DatabaseConnection.linkServer1))
                        {
                            kn.Close();
                            kn = new SqlConnection(@"Data Source=" + DatabaseConnection.linkServer1 + ";Initial Catalog=BANKING;User ID=" +
                                DatabaseConnection.username1 + ";Password=" + DatabaseConnection.password1);
                            kn.Open();
                        }
                        else
                        {
                            kn.Close();
                            kn = new SqlConnection(@"Data Source=" + ServerName + ";Initial Catalog=BANKING;User ID=" + username + ";Password=" + password);
                            kn.Open();
                        }
                    }

                    mystack = new MyStack(kn);
                    foreach (XtraForm f in this.MdiChildren)
                    {
                        SubApp type = f.getType();
                        f.Close();
                        XtraForm ff = new XtraForm(kn, type, mystack,branchCode);
                        ff.MdiParent = this;
                        ff.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, chương trình không thể truy cập vào CSDL. Vui lòng kiểm tra lại tài khoản đăng nhập", "Không thể truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private XtraForm Test_Ketnoi(Type fType, SubApp type)
        {
            foreach (XtraForm f in this.MdiChildren)
            {
                if (f.GetType() == fType && f.getType() == type)
                    return f;
            }
            return null;
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

    [ToolboxBitmapAttribute("image path or use another overload..."),
  ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip |
                                   ToolStripItemDesignerAvailability.ContextMenuStrip |
                                   ToolStripItemDesignerAvailability.StatusStrip)]
    public class ComboBoxItem : ToolStripComboBox
    {
    }

}
