using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedDatabase
{
    public enum SubApp
    {
        NHANVIEN,KHACHHANG,TAIKHOAN,GIAODICH,CHINHANH
    }

    public enum Action
    {
        CREATE,EDIT,DELETE,READ
    }

    public enum RoleType
    {
        CHINHANH,NGANHANG
    }
}
