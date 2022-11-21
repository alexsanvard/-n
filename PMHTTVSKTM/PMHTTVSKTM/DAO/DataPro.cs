using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMHTTVSKTM.DAO
{
    internal class DataPro
    {
        private static DataPro instance; // ứng dụng static để khởi tạo duy nhất
        public static DataPro Instance
        {
            get { if (instance == null) instance = new DataPro(); return DataPro.instance; } // kiểm trâ 
            private set { DataPro.instance = value; } // chỉ trong nội bộ trong class ms đc lấy 
        }
        // chỉ duy nhất 1 thằng thể hiện datapro đc thể hiện ko phải khởi tạo nhiều trong chương trình 
        private DataPro() { } // xây dựng hạm dựng để lấy dữ liệu mà ko đc sửa
        //  Chuỗi xác định kết nối vs thằng nào:
        private string connectionSTR = @"Data Source = TÙNG\SQLEXPRESS; Initial Catalog = HeThongSucKhoe; Integrated Security = True";
        // trả về datatable bằng câu lệnh bên dưới
        public DataTable ExcuteQuery(string query, object[] parameter = null)// mảng object
        {
            DataTable data = new DataTable(); 
            using (SqlConnection connection = new SqlConnection(connectionSTR)) // kết nối từ clain xuống cái server
            {
                connection.Open();// mở dữ liệu  
                SqlCommand command = new SqlCommand(query, connection);//Câu truy vấn để thực thi câu lệnh lấy dữ liệu trung gian
                if (parameter != null)//nếu parameter ko rỗng tức có parameter
                {
                    string[] listPara = query.Split(' ');//cho dữ liệu vào list và split theo khoảng trắng và Split là chích xuất chuỗi con từ 1 chuỗi 
                    int i = 0;
                    foreach (string item in listPara)// dùng các  có trong list 
                    {
                        if (item.Contains('@'))// nếu item có chữ @ đàng trc có nghĩa là có parametter
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);//sẽ add đc vs n parameter
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);// câu kết nối trung gian 
                adapter.Fill(data);// đổ dữ liệu vào data

                connection.Close();// đóng lại dữ liệu 
            }
            return data;
        }

        // chuyển về số dòng thành công  dùng để inser,up,delete :
        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();

                connection.Close();
            }
            return data;
        }
    }
}

