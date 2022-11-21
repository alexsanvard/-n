using PMHTTVSKTM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMHTTVSKTM
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            dtgvAccount.DataSource = DataPro.Instance.ExcuteQuery("SELECT * FROM dbo.ACC WHERE UserName = N'' OR 1=1--");
        }

        private void btnDathen_Click(object sender, EventArgs e)
        {
            fAdminDatHen f = new fAdminDatHen();
            f.ShowDialog();
        }
        private void btnChuanDoan_Click(object sender, EventArgs e)
        {
            fAdminChuanDoan f = new fAdminChuanDoan();
            f.ShowDialog();
        }
    }
}
