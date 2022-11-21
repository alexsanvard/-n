using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMHTTVSKTM.DTO
{
    public class Account //tạo class account chưa các thuộc tính của dữ liệu
    {
        public Account(string userName, string displayName, int type, string password = null) //hàm dựng
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;
            this.PassWord = password;
        }

        public Account(DataRow row) //tạo model
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.Type = (int)row["type"];
            this.PassWord = row["password"].ToString();
        }
        private string userName;
        private string password;
        private string displayName;
        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        public string PassWord
        {
            get { return password; }
            set { password = value; }

        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}

