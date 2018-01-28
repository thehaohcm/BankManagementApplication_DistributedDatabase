using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedDatabase
{
    public static class DatabaseConnection
    {
        private static string usersupport1="support_connect1", passsupport1="12345", usersupport2="support_connect2", passsupport2="12345",
            link1= "DESKTOP-QN5U73D\\PHANMANH1",link2= "DESKTOP-QN5U73D\\PHANMANH2";

        public static string username1
        {
            get{
                return usersupport1;
            }
        }

        public static string password1
        {
            get
            {
                return passsupport1;
            }
        }

        public static string username2
        {
            get
            {
                return usersupport2;
            }
        }

        public static string password2
        {
            get
            {
                return passsupport2;
            }
        }

        public static string linkServer1
        {
            get
            {
                return link1;
            }
        }

        public static string linkServer2
        {
            get
            {
                return link2;
            }
        }

    }
}
