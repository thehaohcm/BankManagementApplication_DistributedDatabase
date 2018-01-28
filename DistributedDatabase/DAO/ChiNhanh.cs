using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedDatabase.DAO
{
    class ChiNhanh
    {
        string macn, tencn, diachi, sodt;
        public ChiNhanh(string macn,string tencn,string diachi,string sodt)
        {
            this.macn = macn;
            this.tencn = tencn;
            this.diachi = diachi;
            this.sodt = sodt;
        }
    }
}
