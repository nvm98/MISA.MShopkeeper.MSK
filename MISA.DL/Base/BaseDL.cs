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
    /// Lớp base xử lý dữ liệu với các bảng
    /// </summary>
    /// Created by NVMANH 8/8/2019
    public class BaseDL<T>
    {
        public int ExecuteNonQuery(string storeName, object[] param)
        {
            var result = 0;
            using (DataAccess dataAccess = new DataAccess())
            {

            }
            return result;
        }
    }
}
