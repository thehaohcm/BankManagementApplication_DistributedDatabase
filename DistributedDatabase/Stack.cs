using DistributedDatabase.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedDatabase
{
    public enum StackType
    {
        ADD, REMOVE, EDIT, CHUYENCHINHANH
    }

    public class NhanVien
    {
        public string hoten, diachi, manv, phai, sodt, macn;
        public StackType type;

        public NhanVien(string hoten, string diachi, string manv, string phai, string sodt, string macn, StackType type)
        {
            this.hoten = hoten;
            this.diachi = diachi;
            this.manv = manv;
            this.phai = phai;
            this.sodt = sodt;
            this.macn = macn;
            this.type = type;
        }
    }

    public class KhachHang
    {
        public string hoten, diachi, cmnd, ngaycap, sodt, phai, macn;
        public StackType type;

        public KhachHang(string hoten, string diachi, string cmnd, string ngaycap, string sodt, string phai, string macn, StackType type)
        {
            this.hoten = hoten;
            this.diachi = diachi;
            this.cmnd = cmnd;
            this.ngaycap = ngaycap;
            this.sodt = sodt;
            this.phai = phai;
            this.macn = macn;
            this.type = type;
        }
    }

    public class TaiKhoan
    {
        public string sotk, cmnd, sodu;
        public StackType type;

        public TaiKhoan(string sotk, string cmnd, string sodu, StackType type)
        {
            this.sotk = sotk;
            this.cmnd = cmnd;
            this.sodu = sodu;
            this.type = type;
        }
    }

    public class ChiNhanh
    {
        public string macn, tencn, diachi, sodt;
        public StackType type;

        public ChiNhanh(string macn, string tencn, string diachi, string sodt, StackType type)
        {
            this.macn = macn;
            this.tencn = tencn;
            this.diachi = diachi;
            this.sodt = sodt;
            this.type = type;
        }
    }

    public class MyStack
    {
        public StackTaiKhoan stackTaiKhoan;
        public StackKhachHang stackKhachHang;
        public StackNhanVien stackNhanVien;

        public MyStack(SqlConnection kn)
        {
            stackKhachHang = new StackKhachHang(kn);
            stackNhanVien = new StackNhanVien(kn);
            stackTaiKhoan = new StackTaiKhoan(kn);
        }
        public class StackTaiKhoan
        {
            int i = 0, n = 0;
            Stack<TaiKhoan> stackUndo, stackRedo;
            SqlConnection kn;
            public StackTaiKhoan(SqlConnection kn)
            {
                i = 0;
                n = 0;
                stackUndo = new Stack<TaiKhoan>();
                stackRedo = new Stack<TaiKhoan>();
                this.kn = kn;
            }

            public void add(TaiKhoan tk)
            {
                if (tk != null)
                {
                    resetRedo();
                    stackUndo.Push(tk);
                    n++;
                    i++;

                }
            }

            public void undo()
            {
                TaiKhoan tkcu = null;
                if (i <= n && i > 0)
                {
                    TaiKhoan tk = stackUndo.Pop();
                    string str = "sp_getTaiKhoan_UndoRedo";
                    SqlCommand com = new SqlCommand(str, kn);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@sotk", tk.sotk);
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string sotk, cmnd, sodu;
                            sotk = reader["SOTK"].ToString().Trim();
                            cmnd = reader["CMND"].ToString().Trim();
                            sodu = reader["SODU"].ToString().Trim();
                            tkcu = new TaiKhoan(sotk, cmnd, sodu, StackType.EDIT);

                        }
                    }

                    if (workUndo(tk) && (tkcu != null))
                    {
                        stackRedo.Push(tkcu);
                        i--;
                    }
                }
            }

            public void redo()
            {
                TaiKhoan tkcu = null;
                if (i < n && i >= 0)
                {
                    TaiKhoan tk = stackRedo.Pop();
                    string str = "sp_getTaiKhoan_UndoRedo";
                    SqlCommand com = new SqlCommand(str, kn);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@sotk", tk.sotk);
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string sotk, cmnd, sodu;
                            sotk = reader["SOTK"].ToString().Trim();
                            cmnd = reader["CMND"].ToString().Trim();
                            sodu = reader["SODU"].ToString().Trim();
                            tkcu = new TaiKhoan(sotk, cmnd, sodu, StackType.EDIT);

                        }
                    }

                    if (workRedo(tk) && (tkcu != null))
                    {
                        stackUndo.Push(tkcu);
                        i++;
                    }
                }
            }

            public bool statusUndo()
            {
                if (i <= n && i > 0)
                    return true;
                return false;
            }

            public bool statusRedo()
            {
                if (i < n && i >= 0)
                    return true;
                return false;
            }

            public void resetRedo()
            {
                n = n - stackRedo.Count;
                stackRedo.Clear();
                //if (i > n)
                    i = n;
            }


            public bool workUndo(TaiKhoan tk)
            {
                switch (tk.type)
                {
                    case StackType.ADD: //->REMOVE
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_removeTaiKhoan";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@sotk", tk.sotk);

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
                                return false;
                            }
                            if (Convert.ToInt32(retstt.Value) == 0)
                            {
                                return true;
                            }
                        }
                        break;
                    case StackType.EDIT: //->EDIT (Old Data)
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_updateTaiKhoan";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@SOTK", tk.sotk);
                            spCommand.Parameters.AddWithValue("@CMND", tk.cmnd);
                            spCommand.Parameters.AddWithValue("@SODU", tk.sodu);

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

                                return false;
                            }
                            if (Convert.ToInt32(retstt.Value) == 0)
                            {
                                return true;
                            }
                        }
                        break;
                    case StackType.REMOVE: //->ADD
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "SP_THEMTAIKHOAN";

                            //spCommand.CommandText = "sp_updateTaiKhoan";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@SOTK", tk.sotk);
                            spCommand.Parameters.AddWithValue("@CMND", tk.cmnd);
                            spCommand.Parameters.AddWithValue("@SODU", tk.sodu);

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

                                return false;
                            }
                            if (Convert.ToInt32(retstt.Value) == 0)
                            {
                                return true;
                            }
                        }
                        break;
                }
                return false;
            }


            public bool workRedo(TaiKhoan tk)
            {
                switch (tk.type)
                {
                    case StackType.ADD: //->Add
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "SP_THEMTAIKHOAN";

                            //spCommand.CommandText = "sp_updateTaiKhoan";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@SOTK", tk.sotk);
                            spCommand.Parameters.AddWithValue("@CMND", tk.cmnd);
                            spCommand.Parameters.AddWithValue("@SODU", tk.sodu);

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

                                return false;
                            }
                            if (Convert.ToInt32(retstt.Value) == 0)
                            {
                                return true;
                            }
                        }
                        break;
                    case StackType.EDIT: // Sai -> Dang sửa
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_updateTaiKhoan";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@SOTK", tk.sotk);
                            spCommand.Parameters.AddWithValue("@CMND", tk.cmnd);
                            spCommand.Parameters.AddWithValue("@SODU", tk.sodu);

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

                                return false;
                            }
                            if (Convert.ToInt32(retstt.Value) == 0)
                            {
                                return true;
                            }
                        }
                        break;
                    case StackType.REMOVE: //->ADD
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_removeTaiKhoan";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@sotk", tk.sotk);

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
                                return false;
                            }
                            if (Convert.ToInt32(retstt.Value) == 0)
                            {
                                return true;
                            }
                        }
                        break;
                }
                return false;
            }
        }

        public class StackNhanVien
        {
            int i = 0, n = 0;
            Stack<NhanVien> stackUndo;
            Stack<NhanVien> stackRedo;
            SqlConnection kn;
            public StackNhanVien(SqlConnection kn)
            {
                i = 0;
                n = 0;
                stackUndo = new Stack<NhanVien>();
                stackRedo = new Stack<NhanVien>();
                this.kn = kn;
            }

            public void add(NhanVien nv)
            {
                if (nv != null)
                {
                    resetRedo();
                    stackUndo.Push(nv);
                    n++;
                    i++;
                }
            }

            public void undo()
            {

                NhanVien nvcu = null;
                if (i <= n && i > 0)
                {
                    NhanVien nv = stackUndo.Pop();
                    if (nv.type == StackType.ADD || nv.type == StackType.EDIT)
                    {
                        string str = "sp_getNhanVien_UndoRedo";
                        SqlCommand com = new SqlCommand(str, kn);
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@manv", nv.manv);
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hoten, diachi, manv, phai, sodt, macn;
                                hoten = reader["HOTEN"].ToString().Trim();
                                diachi = reader["DIACHI"].ToString().Trim();
                                manv = reader["MANV"].ToString().Trim();
                                phai = reader["PHAI"].ToString().Trim();
                                sodt = reader["SODT"].ToString().Trim();
                                macn = reader["MACN"].ToString().Trim();
                                if(nv.type==StackType.EDIT)
                                    nvcu = new NhanVien(hoten, diachi, manv, phai, sodt, macn, StackType.EDIT);
                                else if(nv.type==StackType.ADD)
                                    nvcu = new NhanVien(hoten, diachi, manv, phai, sodt, macn, StackType.ADD);

                            }
                        }
                    }else if (nv.type == StackType.REMOVE)
                    {
                        nvcu = new NhanVien(nv.hoten, nv.diachi, nv.manv, nv.phai, nv.sodt, nv.macn, StackType.REMOVE);
                    }

                    if (workUndo(nv) && (nvcu != null))
                    {
                        stackRedo.Push(nvcu);
                        i--;
                    }
                    else
                    {
                        stackUndo.Push(nv);
                    }
                }
            }

            public void redo()
            {
                NhanVien nvcu = null;
                if (i < n && i >= 0)
                {
                    NhanVien nv = stackRedo.Pop();
                    if (nv.type == StackType.EDIT||nv.type==StackType.ADD)
                    {
                        string str = "sp_getNhanVien_UndoRedo";
                        SqlCommand com = new SqlCommand(str, kn);
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@manv", nv.manv);
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hoten, diachi, manv, phai, sodt, macn;
                                hoten = reader["HOTEN"].ToString().Trim();
                                diachi = reader["DIACHI"].ToString().Trim();
                                manv = reader["MANV"].ToString().Trim();
                                phai = reader["PHAI"].ToString().Trim();
                                sodt = reader["SODT"].ToString().Trim();
                                macn = reader["MACN"].ToString().Trim();
                                if(nv.type==StackType.EDIT)
                                    nvcu = new NhanVien(hoten, diachi, manv, phai, sodt, macn, StackType.EDIT);
                                else if (nv.type == StackType.ADD)
                                    nvcu = new NhanVien(hoten, diachi, manv, phai, sodt, macn, StackType.ADD);
                            }
                        }
                    }
                    else if (nv.type == StackType.REMOVE)
                    {
                        nvcu = nv;
                        nvcu.type = StackType.REMOVE;
                    }

                    if (workRedo(nv) && (nvcu != null))
                    {
                        stackUndo.Push(nvcu);
                        i++;
                    }
                    else
                    {
                        stackRedo.Push(nv);
                    }
                }
            }

            public bool statusUndo()
            {
                if (i <= n && i > 0)
                    return true;
                return false;
            }

            public bool statusRedo()
            {
                if (i < n && i >= 0)
                    return true;
                return false;
            }

            public void resetRedo()
            {
                n = n - stackRedo.Count;
                stackRedo.Clear();
                i = n;
            }

            public bool workUndo(NhanVien nv)
            {
                switch (nv.type)
                {
                    case StackType.ADD: //->REMOVE
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_removeNhanVien";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@manv", nv.manv);

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
                                return false;
                            }
                            if (Convert.ToInt32(retstt.Value) == 0)
                            {
                                return true;
                            }
                        }
                        break;
                    case StackType.EDIT: //->EDIT (Old Data)
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            //spCommand.CommandText = "SP_THEMNHANVIEN";
                            spCommand.CommandText = "sp_updateNhanVien";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@HOTEN", nv.hoten);
                            spCommand.Parameters.AddWithValue("@DIACHI", nv.diachi);
                            spCommand.Parameters.AddWithValue("@MANV", nv.manv);
                            spCommand.Parameters.AddWithValue("@PHAI", nv.phai);
                            spCommand.Parameters.AddWithValue("@SODT", nv.sodt);
                            spCommand.Parameters.AddWithValue("@MACN", nv.macn);

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
                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                    case StackType.REMOVE: //->ADD
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "SP_THEMNHANVIEN";
                            //spCommand.CommandText = "sp_updateNhanVien";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@HOTEN", nv.hoten);
                            spCommand.Parameters.AddWithValue("@DIACHI", nv.diachi);
                            spCommand.Parameters.AddWithValue("@MANV", nv.manv);
                            spCommand.Parameters.AddWithValue("@PHAI", nv.phai);
                            spCommand.Parameters.AddWithValue("@SODT", nv.sodt);
                            spCommand.Parameters.AddWithValue("@MACN", nv.macn);

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
                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                    case StackType.CHUYENCHINHANH: //transferNV->ChiNhanh
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_FindandTransferNV_UNDO";
                            //spCommand.CommandText = "sp_updateNhanVien";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@MANV", nv.manv);
                            spCommand.Parameters.AddWithValue("@MACNCU", nv.macn);

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

                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                }
                return false;
            }

            public bool workRedo(NhanVien nv)
            {
                switch (nv.type)
                {
                    case StackType.ADD: //->Add
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "SP_THEMNHANVIEN";
                            //spCommand.CommandText = "sp_updateNhanVien";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@HOTEN", nv.hoten);
                            spCommand.Parameters.AddWithValue("@DIACHI", nv.diachi);
                            spCommand.Parameters.AddWithValue("@MANV", nv.manv);
                            spCommand.Parameters.AddWithValue("@PHAI", nv.phai);
                            spCommand.Parameters.AddWithValue("@SODT", nv.sodt);
                            spCommand.Parameters.AddWithValue("@MACN", nv.macn);

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
                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                    case StackType.EDIT: //->EDIT (Old Data)
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            //spCommand.CommandText = "SP_THEMNHANVIEN";
                            spCommand.CommandText = "sp_updateNhanVien";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@HOTEN", nv.hoten);
                            spCommand.Parameters.AddWithValue("@DIACHI", nv.diachi);
                            spCommand.Parameters.AddWithValue("@MANV", nv.manv);
                            spCommand.Parameters.AddWithValue("@PHAI", nv.phai);
                            spCommand.Parameters.AddWithValue("@SODT", nv.sodt);
                            spCommand.Parameters.AddWithValue("@MACN", nv.macn);

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
                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                    case StackType.REMOVE: //->Remov
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_removeNhanVien";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@manv", nv.manv);

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
                                return false;
                            }
                            if (Convert.ToInt32(retstt.Value) == 0)
                            {
                                return true;
                            }
                        }
                        break;

                    case StackType.CHUYENCHINHANH: //transferNV->ChiNhanh
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_FindandTransferNV_UNDO";
                            //spCommand.CommandText = "sp_updateNhanVien";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@MANV", nv.manv);
                            spCommand.Parameters.AddWithValue("@MACNCU", nv.macn);

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

                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                }
                return false;
            }
        }

        public class StackKhachHang
        {
            int i = 0, n = 0;
            Stack<KhachHang> stackUndo, stackRedo;
            SqlConnection kn;
            public StackKhachHang(SqlConnection kn)
            {
                i = 0;
                n = 0;
                //stackUndo = stackRedo = new Stack<KhachHang>();
                stackUndo = new Stack<KhachHang>();
                stackRedo = new Stack<KhachHang>();
                this.kn = kn;
            }

            public void add(KhachHang kh)
            {
                if (kh != null)
                {
                    resetRedo();
                    stackUndo.Push(kh);
                    n++;
                    i++;
                }
            }

            public void undo()
            {
                KhachHang khcu = null;
                if (i <= n && i > 0)
                {
                    KhachHang kh = stackUndo.Pop();
                    if (kh.type == StackType.ADD || kh.type == StackType.EDIT)
                    {
                        string str = "sp_getKhachHang_UndoRedo";
                        SqlCommand com = new SqlCommand(str, kn);
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@cmnd", kh.cmnd);
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hoten, diachi, cmnd, ngaycap, sodt, phai, macn;
                                hoten = reader["HOTEN"].ToString().Trim();
                                diachi = reader["DIACHI"].ToString().Trim();
                                cmnd = reader["CMND"].ToString().Trim();
                                ngaycap = reader["NGAYCAP"].ToString().Trim();
                                sodt = reader["SODT"].ToString().Trim();
                                phai = reader["PHAI"].ToString().Trim();
                                macn = reader["MACN"].ToString().Trim();
                                if(kh.type==StackType.EDIT)
                                    khcu = new KhachHang(hoten, diachi, cmnd, ngaycap, sodt, phai, macn, StackType.EDIT);
                                else if(kh.type==StackType.ADD)
                                    khcu=new KhachHang(hoten, diachi, cmnd, ngaycap, sodt, phai, macn, StackType.ADD);

                            }
                        }
                    }else if (kh.type == StackType.REMOVE)
                    {
                        khcu = new KhachHang(kh.hoten, kh.diachi, kh.cmnd, kh.ngaycap, kh.sodt, kh.phai, kh.macn, StackType.REMOVE);
                    }

                    if (workUndo(kh) && (khcu != null))
                    {
                        stackRedo.Push(khcu);
                        i--;
                    }
                    else
                    {
                        stackUndo.Push(kh);
                    }
                }
            }

            public void redo()
            {
                KhachHang khcu = null;
                if (i < n && i >= 0)
                {
                    KhachHang kh = stackRedo.Pop();
                    if (kh.type == StackType.EDIT || kh.type == StackType.ADD)
                    {
                        string str = "sp_getKhachHang_UndoRedo";
                        SqlCommand com = new SqlCommand(str, kn);
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@cmnd", kh.cmnd);
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hoten, diachi, cmnd, ngaycap, sodt, phai, macn;
                                hoten = reader["HOTEN"].ToString().Trim();
                                diachi = reader["DIACHI"].ToString().Trim();
                                cmnd = reader["CMND"].ToString().Trim();
                                ngaycap = reader["NGAYCAP"].ToString().Trim();
                                sodt = reader["SODT"].ToString().Trim();
                                phai = reader["PHAI"].ToString().Trim();
                                macn = reader["MACN"].ToString().Trim();
                                if (kh.type == StackType.EDIT)
                                    khcu = new KhachHang(hoten, diachi, cmnd, ngaycap, sodt, phai, macn, StackType.EDIT);
                                else if (kh.type == StackType.ADD)
                                    khcu = new KhachHang(hoten, diachi, cmnd, ngaycap, sodt, phai, macn, StackType.ADD);
                            }
                        }
                    }
                    else if (kh.type == StackType.REMOVE)
                    {
                        khcu = kh;
                        khcu.type = StackType.REMOVE;
                    }
                    if (workRedo(kh) && (khcu != null))
                    {
                        stackUndo.Push(khcu);
                        i++;
                    }
                    else
                    {
                        stackRedo.Push(kh);
                    }
                }
            }

            public bool statusUndo()
            {
                if (i <= n && i > 0)
                    return true;
                return false;
            }

            public bool statusRedo()
            {
                if (i < n && i >= 0)
                    return true;
                return false;
            }

            public void resetRedo()
            {
                n = n - stackRedo.Count;
                stackRedo.Clear();
                i = n;
            }

            public bool workUndo(KhachHang kh)
            {
                switch (kh.type)
                {
                    case StackType.ADD: //->REMOVE
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_removeKhachHang";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@cmnd", kh.cmnd);

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
                                //MessageBox.Show("Không thể xóa Khách Hàng trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            if (Convert.ToInt32(retstt.Value) == 0)
                            {
                                //MessageBox.Show("Đã xóa thành công Khách Hàng trong cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                        }
                        break;
                    case StackType.EDIT: //->EDIT(Old Data)
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            //spCommand.CommandText = "SP_THEMKH";
                            spCommand.CommandText = "sp_updateKhachHang";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@HOTEN", kh.hoten);
                            spCommand.Parameters.AddWithValue("@DIACHI", kh.diachi);
                            spCommand.Parameters.AddWithValue("@CMND", kh.cmnd);
                            spCommand.Parameters.AddWithValue("@NGAYCAP", kh.ngaycap);
                            spCommand.Parameters.AddWithValue("@SODT", kh.sodt);
                            spCommand.Parameters.AddWithValue("@PHAI", kh.phai);
                            spCommand.Parameters.AddWithValue("@MACN", kh.macn);

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
                                    return true;
                                }
                                else
                                {
                                    //MessageBox.Show("Đã có khách hàng có cùng số chứng minh nhân dân. Mời bạn xem lại", "Không thể thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                    case StackType.REMOVE: //->ADD
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "SP_THEMKH";
                            //spCommand.CommandText = "sp_updateKhachHang";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@HOTEN", kh.hoten);
                            spCommand.Parameters.AddWithValue("@DIACHI", kh.diachi);
                            spCommand.Parameters.AddWithValue("@CMND", kh.cmnd);
                            spCommand.Parameters.AddWithValue("@NGAYCAP", kh.ngaycap);
                            spCommand.Parameters.AddWithValue("@SODT", kh.sodt);
                            spCommand.Parameters.AddWithValue("@PHAI", kh.phai);
                            spCommand.Parameters.AddWithValue("@MACN", kh.macn);

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
                                    return true;
                                }
                                else
                                {
                                    //MessageBox.Show("Đã có khách hàng có cùng số chứng minh nhân dân. Mời bạn xem lại", "Không thể thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                }
                return false;
            }

            public bool workRedo(KhachHang kh)
            {
                switch (kh.type)
                {
                    case StackType.ADD: //->Add
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "SP_THEMKH";
                            //spCommand.CommandText = "sp_updateKhachHang";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@HOTEN", kh.hoten);
                            spCommand.Parameters.AddWithValue("@DIACHI", kh.diachi);
                            spCommand.Parameters.AddWithValue("@CMND", kh.cmnd);
                            spCommand.Parameters.AddWithValue("@NGAYCAP", kh.ngaycap);
                            spCommand.Parameters.AddWithValue("@SODT", kh.sodt);
                            spCommand.Parameters.AddWithValue("@PHAI", kh.phai);
                            spCommand.Parameters.AddWithValue("@MACN", kh.macn);

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
                                    return true;
                                }
                                else
                                {
                                    //MessageBox.Show("Đã có khách hàng có cùng số chứng minh nhân dân. Mời bạn xem lại", "Không thể thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                    case StackType.EDIT: //->EDIT(Old Data)
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            //spCommand.CommandText = "SP_THEMKH";
                            spCommand.CommandText = "sp_updateKhachHang";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@HOTEN", kh.hoten);
                            spCommand.Parameters.AddWithValue("@DIACHI", kh.diachi);
                            spCommand.Parameters.AddWithValue("@CMND", kh.cmnd);
                            spCommand.Parameters.AddWithValue("@NGAYCAP", kh.ngaycap);
                            spCommand.Parameters.AddWithValue("@SODT", kh.sodt);
                            spCommand.Parameters.AddWithValue("@PHAI", kh.phai);
                            spCommand.Parameters.AddWithValue("@MACN", kh.macn);

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
                                    return true;
                                }
                                else
                                {
                                    //MessageBox.Show("Đã có khách hàng có cùng số chứng minh nhân dân. Mời bạn xem lại", "Không thể thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                    case StackType.REMOVE: //->Remove
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_removeKhachHang";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@cmnd", kh.cmnd);

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
                                //MessageBox.Show("Không thể xóa Khách Hàng trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            if (Convert.ToInt32(retstt.Value) == 0)
                            {
                                //MessageBox.Show("Đã xóa thành công Khách Hàng trong cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                        }
                        break;
                }
                return false;
            }
        }

        public class StackChiNhanh
        {
            int i = 0, n = 0;
            Stack<ChiNhanh> stackUndo, stackRedo;
            SqlConnection kn;
            public StackChiNhanh(SqlConnection kn)
            {
                i = 0;
                n = 0;
                stackUndo = stackRedo = new Stack<ChiNhanh>();
                this.kn = kn;
            }

            public void add(ChiNhanh cn)
            {
                if (cn != null)
                {
                    stackUndo.Push(cn);
                    n++;
                    i++;
                }
            }

            public void undo()
            {
                if (i <= n && i > 0)
                {
                    ChiNhanh cn = stackUndo.Pop();
                    if (work(cn))
                    {
                        stackRedo.Push(cn);
                        i--;
                    }
                }
            }

            public void redo()
            {
                if (i < n && i >= 0)
                {
                    ChiNhanh cn = stackRedo.Pop();
                    if (work(cn))
                    {
                        stackUndo.Push(cn);
                        i++;
                    }
                }
            }

            public bool statusUndo()
            {
                if (i <= n && i > 0)
                    return true;
                return false;
            }

            public bool statusRedo()
            {
                if (i < n && i >= 0)
                    return true;
                return false;
            }

            public bool work(ChiNhanh cn)
            {
                switch (cn.type)
                {
                    case StackType.ADD: //->REMOVE
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {

                            spCommand.CommandText = "sp_removeChiNhanh";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@macn", cn.macn);

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
                                    //MessageBox.Show("Đã xóa thành công Khách Hàng trong cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show("Không thể xóa Khách Hàng trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        break;
                    case StackType.EDIT: //->EDIT(Old Data)
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            //spCommand.CommandText = "SP_THEMKH";
                            spCommand.CommandText = "sp_updateChiNhanh";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@MACN", cn.macn);
                            spCommand.Parameters.AddWithValue("@TENCN", cn.tencn);
                            spCommand.Parameters.AddWithValue("@DIACHI", cn.diachi);
                            spCommand.Parameters.AddWithValue("@SOTK", cn.sodt);

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
                                    return true;
                                }
                                else
                                {
                                    //MessageBox.Show("Đã có khách hàng có cùng số chứng minh nhân dân. Mời bạn xem lại", "Không thể thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                        break;
                    case StackType.REMOVE: //->ADD
                        using (SqlCommand spCommand = kn.CreateCommand())
                        {
                            spCommand.CommandText = "sp_THEMCN";
                            spCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            spCommand.Parameters.AddWithValue("@MACN", cn.macn);
                            spCommand.Parameters.AddWithValue("@TENCN", cn.tencn);
                            spCommand.Parameters.AddWithValue("DIACHI", cn.diachi);
                            spCommand.Parameters.AddWithValue("SODT", cn.sodt);

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
                                    //MessageBox.Show("Đã xóa thành công Khách Hàng trong cơ sở dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show("Không thể xóa Khách Hàng trong cơ sở dữ liệu", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        break;
                }
                return false;
            }
        }
    }

}
