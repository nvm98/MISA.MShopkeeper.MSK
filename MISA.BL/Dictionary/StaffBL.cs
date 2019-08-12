using MISA.BL.Base;
using MISA.DL.Dictionary;
using MISA.Entities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Dictionary
{
    /// <summary>
    /// xử lý nghiệp vụ nhân viên
    /// </summary>
    /// Created by NVMANH 10/8/2019
    public class StaffBL:BaseBL
    {
        private StaffDL staffDL;
        /// <summary>
        /// Khơi tạo
        /// </summary>
        /// Created by NVMANH 10/8/2019
        public StaffBL()
        {
            staffDL = new StaffDL();
        }
        /// <summary>
        /// Lấy tất cả danh sách nhân viên
        /// </summary>
        /// <returns>danh sách nhân viên</returns>
        /// Created by NVMANH 10/8/2019
        public IEnumerable<Staff> GetAll()
        {
            return staffDL.GetAllStaff();
        }
    }
}
