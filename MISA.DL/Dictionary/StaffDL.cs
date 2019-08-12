using MISA.DL.Base;
using MISA.Entities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Dictionary
{
    /// <summary>
    /// Lớp xử lý dữ liệu với bảng Staff
    /// </summary>
    /// Created by NVMANH 10/8/2019
    public class StaffDL:BaseDL<Staff>
    {
        /// <summary>
        /// Lấy tất cả danh sách nhân viên
        /// </summary>
        /// <returns>danh sách nhân viên</returns>
        /// Created by NVMANH 10/8/2019
        public IEnumerable<Staff> GetAllStaff()
        {
            return GetAll("[dbo].[Proc_GetAllData]", "Staff", "Code");
        }
    }
}
