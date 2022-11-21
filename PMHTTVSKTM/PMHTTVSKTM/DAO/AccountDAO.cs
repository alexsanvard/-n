using PMHTTVSKTM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMHTTVSKTM.DAO
{
    internal class AccountDAO
    {
        private static AccountDAO instance; //tạo ra 1 hàm hằng
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }

        }
        private AccountDAO() { }
        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";// kết nối vs câu lệnh trong SQL
            // trả ra datatable 
            DataTable result = DataPro.Instance.ExcuteQuery(query, new object[] {userName,passWord});
            return result.Rows.Count > 0; // trả ra số dòng phải lớn hơn 0
        }

        public Account GetAccountByUserName(string userName)// lấy ra account từ tên đăng nhập
        {
            DataTable data = DataPro.Instance.ExcuteQuery("SELECT * FROM ACC WHERE userName = '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);//chạy các item trong data trùng vs tên sẽ ra account
            }
            return null;
        }
        //chạy ra kết quả là số dòng thực hiện thành công 
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataPro.Instance.ExcuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }
    }
}
