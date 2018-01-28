using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using System.Data.SqlClient;

namespace DistributedDatabase
{
    public partial class XtraForm : DevExpress.XtraEditors.XtraForm,UpdateInterface
    {
        SqlConnection kn;
        SubApp type;
        DataRowView selRow;
        MyStack mystack;
        String branchCode;

        public XtraForm(SqlConnection kn, SubApp type,MyStack mystack,String branchCode)
        {
            InitializeComponent();
            barEditItem1.Edit.KeyPress += new KeyPressEventHandler(Edit_KeyPress);

            this.kn = kn;
            this.type = type;
            this.mystack = mystack;
            this.branchCode = branchCode;

            switch (type)
            {
                case SubApp.NHANVIEN:
                    //KhachHangControl khControl=new KhachHangControl(kn,)
                    nVCtrlFrm.setBefore(kn, branchCode, mystack);
                    break;
                case SubApp.KHACHHANG:
                    kHCtrlFrm.setBefore(kn, branchCode, this, mystack);
                    break;
                case SubApp.TAIKHOAN:
                    tKCtrlFrm.setBefore(kn, branchCode, mystack);
                    break;
            }
        }

        public SubApp getType()
        {
            return type;
        }

        private void XtraForm_Load(object sender, EventArgs e)
        {
            //if (type != null && kn != null)
            //{
                switch (type)
                {
                    case SubApp.NHANVIEN:
                        nVCtrlFrm.Visible = true;
                        this.Text = "Nhân Viên";
                        string str = "exec sp_getTableNhanVien";
                        SqlCommand com = new SqlCommand(str, kn);
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        gridControl3.DataSource = dt;

                        redoBarBtn.Enabled = mystack.stackNhanVien.statusRedo();
                        undoBarBtn.Enabled = mystack.stackNhanVien.statusUndo();
                        break;
                    case SubApp.KHACHHANG:
                        kHCtrlFrm.Visible = true;
                        this.Text = "Khách Hàng";
                        str = "exec sp_getTableKhachHang";
                        com = new SqlCommand(str, kn);
                        da = new SqlDataAdapter(com);
                        dt = new DataTable();
                        da.Fill(dt);
                        gridControl3.DataSource = dt;

                        redoBarBtn.Enabled = mystack.stackKhachHang.statusRedo();
                        undoBarBtn.Enabled = mystack.stackKhachHang.statusUndo();
                    break;
                    case SubApp.TAIKHOAN:
                        tKCtrlFrm.Visible = true;
                        this.Text = "Tài Khoản";
                        str = "exec sp_getTableTaiKhoan";
                        com = new SqlCommand(str, kn);
                        da = new SqlDataAdapter(com);
                        dt = new DataTable();
                        da.Fill(dt);
                        gridControl3.DataSource = dt;
                        redoBarBtn.Enabled = mystack.stackTaiKhoan.statusRedo();
                        undoBarBtn.Enabled = mystack.stackTaiKhoan.statusUndo();
                    break;
                    case SubApp.GIAODICH:
                        this.Text = "Giao Dịch";
                    panel1.Visible = false;
                        //str = "exec sp_getTableGiaoDich";

                        //com = new SqlCommand(str, kn);
                        //da = new SqlDataAdapter(com);
                        //dt = new DataTable();
                        //da.Fill(dt);
                        //gridControl3.DataSource = dt;
                        break;
                }
            //}
        }

        public void getGiaoDich(string fromDate,string toDate,string matk,string loaigd)
        {
            Console.WriteLine("Loai gd: " + loaigd);
            gridControl3.DataSource = null;
            this.Text = "Giao Dịch";
            string str = "sp_getGiaoDich";
            SqlCommand com = new SqlCommand(str, kn);
            com.Parameters.AddWithValue("@matk", matk);
            com.Parameters.AddWithValue("@loaigd", loaigd);
            com.Parameters.AddWithValue("@fromdate", fromDate);
            com.Parameters.AddWithValue("@todate", toDate);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            com.CommandType = System.Data.CommandType.StoredProcedure;
            dt.Load(com.ExecuteReader());          
            //da.Fill(dt);

            gridControl3.DataSource = dt;
        }

        private void gridView3_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {

            switch (type)
            {
                case SubApp.KHACHHANG:
                    int[] selRows = gridView3.GetSelectedRows();//((GridView)gridControl3.MainView).GetSelectedRows();
                    selRow = (DataRowView)(gridView3.GetRow(selRows[0]));
                    //AddClient clientForm = new AddClient(kn, selRow, this,mystack);
                    //clientForm.ShowDialog();
                    kHCtrlFrm.setBeforeEdit(kn, selRow, this, mystack);

                    break;
                case SubApp.TAIKHOAN:
                    selRows = gridView3.GetSelectedRows();//((GridView)gridControl3.MainView).GetSelectedRows();
                    selRow = (DataRowView)(gridView3.GetRow(selRows[0]));
                    tKCtrlFrm.setBeforeEdit(kn, selRow, this, mystack);
                    //AddAccount accountForm = new AddAccount(kn, selRow,this,mystack);
                    //accountForm.ShowDialog();

                    break;
                case SubApp.NHANVIEN:
                    //CODE Xoa tai khoan NHANVIEN

                    //string manv = gridView3.GetFocusedDataRow()["MANV"].ToString().Trim();
                    //DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa nhân viên: " + manv, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    //if (result == DialogResult.Yes)
                    //{
                    //    using (SqlCommand spCommand = kn.CreateCommand())
                    //    {
                    //        spCommand.CommandText = "sp_removeNhanVien";
                    //        spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    //        spCommand.Parameters.AddWithValue("@manv", manv);

                    //        IDbDataParameter retstt = spCommand.CreateParameter();
                    //        retstt.ParameterName = "@RETURN";
                    //        retstt.Direction = System.Data.ParameterDirection.ReturnValue;
                    //        retstt.DbType = System.Data.DbType.Int32;
                    //        spCommand.Parameters.Add(retstt);
                    //        try
                    //        {
                    //            spCommand.ExecuteNonQuery();
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            MessageBox.Show("Không thể xóa Nhân Viên trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            return;
                    //        }
                    //        if (Convert.ToInt32(retstt.Value) == 0)
                    //        {
                    //            MessageBox.Show("Đã thêm thành công Khách Hàng vào cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            this.Close();
                    //        }
                    //    }
                    //}

                    selRows = gridView3.GetSelectedRows();//((GridView)gridControl3.MainView).GetSelectedRows();
                    selRow = (DataRowView)(gridView3.GetRow(selRows[0]));
                    //AddStaff staffForm = new AddStaff(kn, selRow,this,mystack);
                    //staffForm.ShowDialog();
                    nVCtrlFrm.setBeforeEdit(kn, selRow, this, mystack);
                    break;
            }
        }

        private void gridControl3_Click(object sender, EventArgs e)
        {

        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            searchAndChooseItem();
        }

        public void updateGridView()
        {
            string str = "";
            bool undoFlag = false, redoFlag = false;
            switch (type)
            {
                case SubApp.NHANVIEN:
                    str = "exec sp_getTableNhanVien";
                    undoFlag = mystack.stackNhanVien.statusUndo();
                    redoFlag = mystack.stackNhanVien.statusRedo();
                    break;
                case SubApp.KHACHHANG:
                    str = "exec sp_getTableKhachHang";
                    undoFlag = mystack.stackKhachHang.statusUndo();
                    redoFlag = mystack.stackKhachHang.statusRedo();
                    break;
                case SubApp.TAIKHOAN:
                    str = "exec sp_getTableTaiKhoan";
                    undoFlag = mystack.stackTaiKhoan.statusUndo();
                    redoFlag = mystack.stackTaiKhoan.statusRedo();
                    break;
                //case SubApp.GIAODICH:
                //    str = "exec sp_getTableGiaoDich";
                //    break;
                case SubApp.CHINHANH:
                    str = "exec sp_getTableChiNhanh";
                    break;
            }
            if (str != "")
            {
                SqlCommand com = new SqlCommand(str, kn);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl3.DataSource = null;
                gridControl3.DataSource = dt;
            }

            undoBarBtn.Enabled = undoFlag;
            redoBarBtn.Enabled = redoFlag;
        }

        private void manvTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void removeBtn_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void themcsBtn_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void femaleRdBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void hotenTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void maleRdBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chinhanhTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void diachiTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void sdtTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (type)
            {
                case SubApp.KHACHHANG:
                    //AddClient formAddClient = new AddClient(kn, "CN001",null,mystack);
                    //formAddClient.ShowDialog();
                    kHCtrlFrm.setBefore(kn, branchCode, this, mystack);
                    break;
                case SubApp.NHANVIEN:
                    nVCtrlFrm.setBefore(kn, branchCode, mystack);
                    break;
                case SubApp.TAIKHOAN:
                    tKCtrlFrm.setBefore(kn, branchCode, mystack);
                    break;
            }
        }

        private void gridControl3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gridView3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void gridView3_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    searchAndChooseItem();
                    break;
            }
        }

        private void searchAndChooseItem()
        {
            MainForm mainForm = this.ParentForm as MainForm;
            int[] selRows = gridView3.GetSelectedRows();//((GridView)gridControl3.MainView).GetSelectedRows();
            selRow = (DataRowView)(gridView3.GetRow(selRows[0]));
            switch (type)
            {
                case SubApp.KHACHHANG:
                    mainForm.disableCN();
                    mainForm.disableNV();
                    mainForm.disableTK();
                    mainForm.enableKH(selRow);
                    break;
                case SubApp.NHANVIEN:
                    mainForm.disableTK();
                    mainForm.disableKH();
                    mainForm.disableCN();
                    mainForm.enableNV(selRow);
                    break;
                case SubApp.TAIKHOAN:
                    mainForm.disableCN();
                    mainForm.disableKH();
                    mainForm.disableNV();
                    mainForm.enableTK(selRow);
                    break;
                case SubApp.CHINHANH:
                    mainForm.disableKH();
                    mainForm.disableNV();
                    mainForm.disableTK();
                    break;
            }
        }

        private void barEditItem1_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            
        }

        private void barEditItem1_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str = "";
            switch (type)
            {
                case SubApp.CHINHANH:
                    str = "sp_searchChiNhanh";
                    break;
                case SubApp.GIAODICH:
                    str = "sp_searchGiaoDich";
                    break;
                case SubApp.KHACHHANG:
                    str = "sp_searchKhachHang";
                    break;
                case SubApp.NHANVIEN:
                    str = "sp_searchNhanVien";
                    break;
                case SubApp.TAIKHOAN:
                    str = "sp_searchTaiKhoan";
                    break;
            }
            if (str != "")
            {

                using (SqlCommand spCommand = kn.CreateCommand())
                {
                    spCommand.CommandText = str;
                    spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    spCommand.Parameters.AddWithValue("@searchTxt", barEditItem1.EditValue.ToString());

                    SqlDataAdapter da = new SqlDataAdapter(spCommand);
                    DataTable dt = new DataTable();
                    dt.Rows.Clear();
                    spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    dt.Load(spCommand.ExecuteReader());
                    
                    gridControl3.DataSource = null;
                    gridControl3.Refresh();
                    gridControl3.DataSource = dt;
                    gridControl3.Refresh();
                    
                }
                
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool undoFlag = false, redoFlag = false;
            switch (type)
            {
                case SubApp.NHANVIEN:
                    mystack.stackNhanVien.undo();
                    undoFlag = mystack.stackNhanVien.statusUndo();
                    redoFlag = mystack.stackNhanVien.statusRedo();
                    break;
                case SubApp.TAIKHOAN:
                    mystack.stackTaiKhoan.undo();
                    undoFlag = mystack.stackTaiKhoan.statusUndo();
                    redoFlag = mystack.stackTaiKhoan.statusRedo();
                    break;
                case SubApp.KHACHHANG:
                    mystack.stackKhachHang.undo();
                    undoFlag = mystack.stackKhachHang.statusUndo();
                    redoFlag = mystack.stackKhachHang.statusRedo();
                    break;
                case SubApp.CHINHANH:
                    
                    break;
            }

            undoBarBtn.Enabled = undoFlag;
            redoBarBtn.Enabled = redoFlag;

            updateGridView();
        }

        private void redoBarBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool undoFlag = false, redoFlag = false;
            switch (type)
            {
                case SubApp.NHANVIEN:
                    mystack.stackNhanVien.redo();
                    undoFlag = mystack.stackNhanVien.statusUndo();
                    redoFlag = mystack.stackNhanVien.statusRedo();
                    break;
                case SubApp.TAIKHOAN:
                    mystack.stackTaiKhoan.redo();
                    undoFlag = mystack.stackTaiKhoan.statusUndo();
                    redoFlag = mystack.stackTaiKhoan.statusRedo();
                    break;
                case SubApp.KHACHHANG:
                    mystack.stackKhachHang.redo();
                    undoFlag = mystack.stackKhachHang.statusUndo();
                    redoFlag = mystack.stackKhachHang.statusRedo();
                    break;
                case SubApp.CHINHANH:

                    break;
            }

            undoBarBtn.Enabled = undoFlag;
            redoBarBtn.Enabled = redoFlag;

            updateGridView();
        }

        private void barButtonItem6_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter)
            {
                //e.Handled = true;
                string str = "";
                switch (type)
                {
                    case SubApp.CHINHANH:
                        str = "sp_searchChiNhanh";
                        break;
                    case SubApp.GIAODICH:
                        str = "sp_searchGiaoDich";
                        break;
                    case SubApp.KHACHHANG:
                        str = "sp_searchKhachHang";
                        break;
                    case SubApp.NHANVIEN:
                        str = "sp_searchNhanVien";
                        break;
                    case SubApp.TAIKHOAN:
                        str = "sp_searchTaiKhoan";
                        break;
                }
                if (str != "")
                {

                    using (SqlCommand spCommand = kn.CreateCommand())
                    {
                        spCommand.CommandText = str;
                        spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        spCommand.Parameters.AddWithValue("@searchTxt", barEditItem1.EditValue.ToString());

                        SqlDataAdapter da = new SqlDataAdapter(spCommand);
                        DataTable dt = new DataTable();
                        dt.Rows.Clear();
                        spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        dt.Load(spCommand.ExecuteReader());

                        gridControl3.DataSource = null;
                        gridControl3.Refresh();
                        gridControl3.DataSource = dt;
                        gridControl3.Refresh();

                    }

                }

                //MessageBox.Show("fae");
            }
            // your code here
        }

        private void nVCtrlFrm_Load(object sender, EventArgs e)
        {

        }
    }
}