using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Utility
{
    /// <summary>
    /// Sinh ra các chuỗi tên Store truy vấn dữ liệu
    /// </summary>
    /// Created by NVMANH 8/8/2019
    public static class GenerateProcUtility<T>
    {
        private static string _tableName;
        private static string _storeName = string.Empty;
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// Created by NVMANH 8/8/2019
        static GenerateProcUtility()
        {
            var entity = Activator.CreateInstance<T>();
            _tableName = entity.GetType().Name;
        }
        /// <summary>
        /// Lấy tên store tất cả danh sách Entities
        /// </summary>
        /// <returns>Tên store lấy tất cả các Entities</returns>
        /// Created by NVMANH 8/8/2019
        public static string GetEntities()
        {
            _storeName = String.Format("Proc_Get{0}s", _tableName);
            return _storeName;
        }
        /// <summary>
        /// Lấy tên store một danh sách các Entity
        /// </summary>
        /// <returns>Tên store lấy danh sách các Entity</returns>
        /// Created by NVMANH 8/8/2019
        public static string GetListEntity()
        {
            _storeName = String.Format("Proc_GetList{0}", _tableName);
            return _storeName;
        }
        /// <summary>
        /// Lấy tên store lấy Entity theo ID
        /// </summary>
        /// <returns>tên store lấy Entity theo ID</returns>
        /// Created by NVMANH 8/8/2019
        public static string GetEntityByID()
        {
            _storeName = String.Format("Proc_Get{0}ByID", _tableName);
            return _storeName;
        }
        /// <summary>
        /// Lấy tên store lấy List Entity theo nhiều tham số
        /// </summary>
        /// <returns>Tên store lấy list entity thep nhiều tham số</returns>
        /// Created by NVMANH 8/8/2019
        public static string GetListEntity_ByMultiParam()
        {
            _storeName = String.Format("dbo.Proc_GetList{0}_ByMultiParam", _tableName);
            return _storeName;
        }
        /// <summary>
        /// Lấy tên store để phân trang
        /// </summary>
        /// <returns>Tên store để phân trang</returns>
        /// Created by NVMANH 8/8/2019
        public static string SelectEntitiesPaging()
        {
            _storeName = String.Format("[dbo].[Select{0}sPaging]", _tableName);
            return _storeName;
        }
        /// <summary>
        /// lấy tên store thêm mới bản ghi
        /// </summary>
        /// <returns>Tên store thêm mới bản ghi</returns>
        /// Created by NVMANH 8/8/2019
        public static string InsertEntity()
        {
            _storeName = String.Format("dbo.Proc_Insert{0}", _tableName);
            return _storeName;
        }
        /// <summary>
        /// Lấy tên store để sửa bản ghi
        /// </summary>
        /// <returns>Tên store sửa bản ghi</returns>
        /// Created by NVMANH 8/8/2019
        public static string UpdateEntity()
        {
            _storeName = String.Format("dbo.Proc_Update{0}", _tableName);
            return _storeName;
        }
        /// <summary>
        /// Lấy tên store để xóa bản ghi theo khóa chính
        /// </summary>
        /// <returns>Tên store xóa bản ghi theo khóa chính</returns>
        /// Created by NVMANH 8/8/2019
        public static string DeleteEntityByPrimaryKey()
        {
            _storeName = String.Format("dbo.Proc_Delete{0}By{0}ID", _tableName);
            return _storeName;
        }
    }
}
