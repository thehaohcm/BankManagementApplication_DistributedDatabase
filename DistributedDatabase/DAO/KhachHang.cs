using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedDatabase.DAO
{
    class KhachHang
    {
        string hoten, diachi, cmnd, ngaycap, sodt, phai, macn;
        public KhachHang(string hoten,string diachi,string cmnd,string ngaycap,string sodt,string phai,string macn)
        {
            this.hoten = hoten;
            this.diachi = diachi;
            this.cmnd = cmnd;
            this.ngaycap = ngaycap;
            this.sodt = sodt;
            this.phai = phai;
            this.macn = macn;
        }
    }
}
