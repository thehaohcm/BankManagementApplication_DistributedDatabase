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
    public partial class GiaoDichOption : Form
    {
        XtraForm parrent;
        SqlConnection kn;
        public GiaoDichOption(XtraForm parrent,SqlConnection kn)
        {
            InitializeComponent();
            this.parrent = parrent;
            this.kn = kn;
        }

        private void GiaoDichOption_Load(object sender, EventArgs e)
        {
            giaodichCmb.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void giaodichCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strGD = null;
            string tk = null;
            switch (giaodichCmb.Text)
            {
                case "Chuyển Tiền":
                    strGD = "CT";
                    break;
                case "Rút Tiền":
                    strGD = "RT";
                    break;
                case "Gửi tiền":
                    strGD = "GT";
                    break;
            }
            if (matkCmb.Text.Trim() != "")
                tk = matkCmb.Text;
            parrent.getGiaoDich(fromDatePicker.Value.ToShortDateString(),toDatePicker.Value.ToShortDateString(),tk,strGD);
            this.Close();
        }
    }
}
