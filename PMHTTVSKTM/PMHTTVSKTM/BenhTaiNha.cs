using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PMHTTVSKTM
{
    public partial class fBenhTaiNha : Form
    {
        SqlConnection cnn = null;       
        DataSet ds = new DataSet();
        string strcnn = @"Data Source=TÙNG\SQLEXPRESS;Initial Catalog=QLBT;Integrated Security=True";
        SqlDataAdapter dta = null;
        public fBenhTaiNha()
        {
            InitializeComponent();
        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            if (cnn == null)
                cnn = new SqlConnection(strcnn);
            dta = new SqlDataAdapter("Select * from BTinh", cnn);   
            SqlCommandBuilder builder = new SqlCommandBuilder(dta);

            dta.Fill(ds, "BT");
            DS_BenhNhe.DataSource = ds.Tables["BT"];
            DS_BenhNhe.Columns[0].HeaderText = "Mã bệnh"; 
            DS_BenhNhe.Columns[1].HeaderText = "Triệu chứng";
            DS_BenhNhe.Columns[2].HeaderText = "Tên bệnh";
            DS_BenhNhe.Columns[3].Width = 150;
            DS_BenhNhe.Columns[3].HeaderText = "Cách chữa";
            DS_BenhNhe.Columns[4].Width = 150;
            DS_BenhNhe.Columns[4].HeaderText = "Cách phòng tránh";
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "Trieuchung", "*" + txtTimKiem.Text + "*");
            (DS_BenhNhe.DataSource as DataTable).DefaultView.RowFilter = rowFilter;  
        }

        private void DS_BenhNhe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = DS_BenhNhe.Rows[e.RowIndex];
            txtBox1.Text = Convert.ToString(row.Cells["TenBenh"].Value);
            txtBox2.Text = Convert.ToString(row.Cells["Trieuchung"].Value);
            txtBox3.Text = Convert.ToString(row.Cells["CachChua"].Value);
            txtBox4.Text = Convert.ToString(row.Cells["LoiKhuyen"].Value);

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
