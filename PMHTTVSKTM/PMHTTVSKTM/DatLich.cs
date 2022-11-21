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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PMHTTVSKTM
{
    public partial class fDatLich : Form
    {
        SqlConnection cnn = null;
        DataSet ds = new DataSet();
        string strcnn = @"Data Source=TÙNG\SQLEXPRESS;Initial Catalog=QL_BVien;Integrated Security=True";
        SqlDataAdapter dta = null;
        public fDatLich()
        {
            InitializeComponent();
        }
        private void textTimKiem2_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "Hospital", "*" + textTimKiem2.Text + "*");
            (DS_HaNoi.DataSource as DataTable).DefaultView.RowFilter = rowFilter;         
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "Hospital", "*" + txtTimKiem.Text + "*");
            (DS_SaiGon.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cnn == null)
                cnn = new SqlConnection(strcnn);
            dta = new SqlDataAdapter("Select * from SaiGon ", cnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(dta);

            dta.Fill(ds, "SG");
            DS_SaiGon.DataSource = ds.Tables["SG"];
            DS_SaiGon.Columns[0].HeaderText = "Bệnh viện";
            DS_SaiGon.Columns[1].HeaderText = "Chuyên khoa";
            DS_SaiGon.Columns[2].HeaderText = "Mã bác sĩ";
            DS_SaiGon.Columns[3].HeaderText = "Bác sĩ ";
            DS_SaiGon.Columns[4].HeaderText = "Phòng hẹn";
            DS_SaiGon.Columns[5].HeaderText = "Tiền đặt ";
            DS_SaiGon.Columns[6].HeaderText = "Khách hàng";
            DS_SaiGon.Columns[7].HeaderText = "Số Đt khách hàng";
        }
        int vt = -1;
        private void DS_SaiGon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt == -1)
                return;
            DataRow row = ds.Tables["SG"].Rows[vt];
            textBox1.Text = row["Hospital"] + "";
            textBox2.Text = row["Specialist"] + "";
            textBox3.Text = row["Doctor"] + "";
            textBox4.Text = row["Address"] + "";
            textBox5.Text = row["Cost"] + "";
            textBox6.Text = row["CostomerName"] + "";
            textBox7.Text = row["SoDT"] + "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text == "" || textBox7.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                if (vt == -1)
                    return;
                DataRow row = ds.Tables["SG"].Rows[vt];
                row.BeginEdit();
                row["CostomerName"] = textBox6.Text;
                row["SoDT"] = textBox7.Text;
                row.EndEdit();
                int kq = dta.Update(ds.Tables["SG"]);
                if (kq > 0)
                {
                    MessageBox.Show("Đăng ký thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }     
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void button6_Click(object sender, EventArgs e)
        {
            if (cnn == null)
                cnn = new SqlConnection(strcnn);
            dta = new SqlDataAdapter("Select * from HaNoi ", cnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(dta);

            dta.Fill(ds, "HN");
            DS_HaNoi.DataSource = ds.Tables["HN"];
            DS_HaNoi.Columns[0].HeaderText = "Bệnh viện";
            DS_HaNoi.Columns[1].HeaderText = "Chuyên khoa";
            DS_HaNoi.Columns[2].HeaderText = "Mã bác sĩ";
            DS_HaNoi.Columns[3].HeaderText = "Bác sĩ ";
            DS_HaNoi.Columns[4].HeaderText = "Phòng hẹn";
            DS_HaNoi.Columns[5].HeaderText = "Tiền đặt ";
            DS_HaNoi.Columns[6].HeaderText = "Khách hàng";
            DS_HaNoi.Columns[7].HeaderText = "Số Đt khách hàng";

        }

        private void DS_HN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt == -1)
                return;
            DataRow row = ds.Tables["HN"].Rows[vt];
            textBox8.Text = row["Hospital"] + "";
            textBox9.Text = row["Specialist"] + "";
            textBox10.Text = row["Doctor"] + "";
            textBox11.Text = row["Address"] + "";
            textBox12.Text = row["Cost"] + "";
            textBox13.Text = row["CostomerName"] + "";
            textBox14.Text = row["SoDT"] + "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox13.Text == "" || textBox14.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                if (vt == -1)
                    return;
                DataRow row = ds.Tables["HN"].Rows[vt];
                row.BeginEdit();
                row["CostomerName"] = textBox13.Text;
                row["SoDT"] = textBox14.Text;
                row.EndEdit();
                int kq = dta.Update(ds.Tables["HN"]);
                if (kq > 0)
                {
                    MessageBox.Show("Đăng ký thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (vt == -1)
                return;
            DataRow row = ds.Tables["SG"].Rows[vt];
            row.BeginEdit();
            row["CostomerName"] = null;
            row["SoDT"] = null;
            row.EndEdit();
            int kq = dta.Update(ds.Tables["SG"]);
            if (kq > 0)
            {
                MessageBox.Show("Xóa thành công");
            }
        }
        private void btnXoa1_Click(object sender, EventArgs e)
        {
            if (vt == -1)
                return;
            DataRow row = ds.Tables["HN"].Rows[vt];
            row.BeginEdit();
            row["CostomerName"] = null;
            row["SoDT"] = null;
            row.EndEdit();
            int kq = dta.Update(ds.Tables["HN"]);
            if (kq > 0)
            {
                MessageBox.Show("Xóa thành công");
            }
        }
    }
}
