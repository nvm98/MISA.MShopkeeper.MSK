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
    /// Xử lý nghiệp vụ với chi tiết đối tượng
    /// </summary>
    public class ObjectDetailBL: BaseBL
    {
        private ObjectDetailDL objectDetailDL;
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// Created by NVMANH 10/8/2019
        public ObjectDetailBL()
        {
            objectDetailDL = new ObjectDetailDL(); 
        }
        /// <summary>
        /// Lấy tất cả chi tiết của đối tượng
        /// </summary>
        /// <returns>tất cả danh sách chi tiết đối tượng</returns>
        /// Created by NVMANH 10//8/2019
        public IEnumerable<ObjectDetail> GetAll()
        {
            return objectDetailDL.GetAllObjectDetail();
        }
    }
}
