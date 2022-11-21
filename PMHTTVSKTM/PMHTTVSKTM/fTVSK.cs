using PMHTTVSKTM.DTO;
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
    public partial class fTVSK : Form
    {
        private Account loginAccount;

        public Account LoginAccount //mỗi khi đc gọi sẽ thực hiện tính đóng gói vừa đăng nhập vừa kiểm tra type
        {
            get { return loginAccount; }
            set { loginAccount = value;ChangeAccount(loginAccount.Type); }
        }
        public fTVSK(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }

        void ChangeAccount(int type)
        {
            thôngTinCáNhânToolStripMenuItem.Enabled = type == 1;//1 là sẽ dùng riêng còn ko thì dùng chung
        }
        private void button3_Click(object sender, EventArgs e)
        {
            fDatLich f = new fDatLich();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fTuVan f = new fTuVan();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fBenhTaiNha f = new fBenhTaiNha();
            f.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        private void sửaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fUpdateTK f = new fUpdateTK(LoginAccount); //Mình sẽ login account vào sửa tk
            f.ShowDialog();
        }
    }
}
