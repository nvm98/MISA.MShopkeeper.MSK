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
    /// Lớp xử lý dữ liệu với bảng ObjectDetail
    /// </summary>
    /// Created by NVMANH 10/8/2019
    public class ObjectDetailDL: BaseDL<ObjectDetail>
    {
        /// <summary>
        /// Lấy tất cả danh sách chi tiết đối tượng
        /// </summary>
        /// <returns>danh sách chi tiết đối tượng</returns>
        /// Created by NVMANH 10/8/2019
        public IEnumerable<ObjectDetail> GetAllObjectDetail()
        {
            return GetAll("[dbo].[Proc_GetAllData]", "ObjectDetail", "Type");
        }
    }
}
