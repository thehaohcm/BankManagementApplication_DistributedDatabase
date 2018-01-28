using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedDatabase.DAO
{
    class NhanVien
    {
        string hoten, diachi, manv, phai, sodt, macn;
        public NhanVien(string hoten,string diachi,string manv,string phai,string sodt,string macn)
        {
            this.hoten = hoten;
            this.diachi = diachi;
            this.manv = manv;
            this.phai = phai;
            this.sodt = sodt;
            this.macn = macn;
        }
    }
}
