using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Base
{
    /// <summary>
    /// Lớp kết nối với Database
    /// </summary>
    /// Created by NVMANH 8/8/2019
    class DataAccess : IDisposable
    {

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private string connectionString;
        public SqlCommand SqlCommand
        {
            get { return sqlCommand; }
        }
        //Khởi tạo lớp kết nối DB
        public DataAccess()
        {
            //Chuổi kết nối database
            connectionString = @"Data Source=DATABASE\SQL2014;Initial Catalog=MISAMshopkeeper.NVANMANH_Development;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";
            //connectionString = @"Data Source=DESKTOP-O4AU6I3;Initial Catalog=MISAMShopkeeper.NVANMANH_Development;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";
            // Khởi tạo đối tượng SqlConnection để kết nối tới Database:
            sqlConnection = new SqlConnection(connectionString);

            // Khởi tạo đối tượng SqlCommand để thao tác với Database:
            sqlCommand = sqlConnection.CreateCommand();

            // Khai báo CommandType kiểu thao tác với Database
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Mở kết nối:
            sqlConnection.Open();
        }

        /// <summary>
        /// Hàm thực thi câu lệnh trả về dữ liệu
        /// </summary>
        /// <param name="commandText">Chuỗi</param>
        /// <returns>Đối tượng SqlDataReader</returns>
        /// Created by NVMANH 8/8/2019
        public SqlDataReader ExecuteReader(string commandText)
        {
            sqlCommand.CommandText = commandText;
            return sqlCommand.ExecuteReader();
        }
        /// <summary>
        /// Hàm thực thi cậu lệnh cho trả về ID bản ghi cuối cùng
        /// </summary>
        /// <param name="commandText">Chuỗi</param>
        /// <returns>Đối tượng sqlCommand</returns>
        /// Created by NVMANH 8/8/2019
        public object ExecuteScalar(string commandText)
        {
            sqlCommand.CommandText = commandText;
            return sqlCommand.ExecuteScalar();
        }
        public void Dispose()
        {

        }
    }
}
