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
        /// <summary>
        /// Lấy tất cả dữ liệu của bảng
        /// </summary>
        /// <param name="storeName">Tên store</param>
        /// <param name="tableName">Tên bảng</param>
        /// <returns>Danh sách bản ghi của bảng</returns>
        public IEnumerable<T> GetAll(string storeName, string tableName, string orderBy)
        {
            var entities = new List<T>();
            using (DataAccess dataAccess = new DataAccess())
            {
                // Khởi tạo đối tượng SqlDataReader hứng dữ liệu trả về:
                var sqlCommand = dataAccess.SqlCommand;
                sqlCommand.CommandText = storeName;
                sqlCommand.Parameters.AddWithValue("@TableName", tableName);
                sqlCommand.Parameters.AddWithValue("@Orderby", orderBy);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var entity = Activator.CreateInstance<T>();
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        // Lấy ra tên propertyName dựa vào tên cột của field hiện tại:
                        var propertyName = sqlDataReader.GetName(i);
                        // Lấy ra giá trị của field hiện tại:
                        var propertyValue = sqlDataReader.GetValue(i);
                        // Gán Value cho Property tương ứng:
                        var propertyInfo = entity.GetType().GetProperty(propertyName);
                        if (propertyInfo != null && propertyValue != DBNull.Value)
                        {
                            propertyInfo.SetValue(entity, propertyValue);
                        }
                    }
                    entities.Add(entity);
                }
            }
            return entities;
        }
        /// <summary>
        /// Lấy danh sách bản ghi theo điều kiện
        /// </summary>
        /// <param name="storeName">Tên store</param>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="columnName">Tên cột</param>
        /// <param name="value">Điều kiện</param>
        /// <returns>danh sách bản ghi thỏa mãn điều kiện</returns>
        /// Created by NVMANH 10/8/2019
        public IEnumerable<T> GetAllDataByAttribute(string storeName, string tableName, string columnName, string value)
        {
            var entities = new List<T>();
            using (DataAccess dataAccess = new DataAccess())
            {
                // Khởi tạo đối tượng SqlDataReader hứng dữ liệu trả về:
                var sqlCommand = dataAccess.SqlCommand;
                sqlCommand.CommandText = storeName;
                sqlCommand.Parameters.AddWithValue("@TableName", tableName);
                sqlCommand.Parameters.AddWithValue("@ColumnName", columnName);
                sqlCommand.Parameters.AddWithValue("@Value", value);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var entity = Activator.CreateInstance<T>();
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        // Lấy ra tên propertyName dựa vào tên cột của field hiện tại:
                        var propertyName = sqlDataReader.GetName(i);
                        // Lấy ra giá trị của field hiện tại:
                        var propertyValue = sqlDataReader.GetValue(i);
                        // Gán Value cho Property tương ứng:
                        var propertyInfo = entity.GetType().GetProperty(propertyName);
                        if (propertyInfo != null && propertyValue != DBNull.Value)
                        {
                            propertyInfo.SetValue(entity, propertyValue);
                        }
                    }
                    entities.Add(entity);
                }
            }
            return entities;
        }
        /// <summary>
        /// Hàm lấy một bản ghi theo điều kiện
        /// </summary>
        /// <param name="storeName">Tên store thực hiện</param>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="columnName">Tên cột cần lọc</param>
        /// <param name="value">Giá trị cần lọc</param>
        /// <returns>Một bản ghi với điều kiện tương ứng</returns>
        /// Created by NVMANH 11/8/2019
        public T GetDataByAttribute(string storeName, string tableName, string columnName, string value)
        {
            var entity = Activator.CreateInstance<T>();
            using (DataAccess dataAccess = new DataAccess())
            {
                var sqlCommand = dataAccess.SqlCommand;
                sqlCommand.CommandText = storeName;
                sqlCommand.Parameters.AddWithValue("@TableName", tableName);
                sqlCommand.Parameters.AddWithValue("@ColumnName", columnName);
                sqlCommand.Parameters.AddWithValue("@Value", value);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        // Lấy ra tên propertyName dựa vào tên cột của field hiện tại:
                        var propertyName = sqlDataReader.GetName(i);
                        // Lấy ra giá trị của field hiện tại:
                        var propertyValue = sqlDataReader.GetValue(i);
                        // Gán Value cho Property tương ứng:
                        var propertyInfo = entity.GetType().GetProperty(propertyName);
                        if (propertyInfo != null && propertyValue != DBNull.Value)
                        {
                            propertyInfo.SetValue(entity, propertyValue);
                        }
                    }
                }
            }
            return entity;
        }
    }
}
