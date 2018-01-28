using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedDatabase.DAO
{
    class TaiKhoan
    {
        string sotk, cmnd, sodu;
        public TaiKhoan(string sotk,string cmnd,string sodu)
        {
            this.sotk = sotk;
            this.cmnd = cmnd;
            this.sodu = sodu;
        }
    }
}
