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
    /// Lớp thực hiện xử lý dữ liệu với bảng Receipt
    /// </summary>
    /// Created by NVMANH 10/8/2019
    public class ReceiptDL:BaseDL<Receipt>
    {
        /// <summary>
        /// Lấy tất cả danh sách phiếu thu
        /// </summary>
        /// <returns>danh sách phiếu thu</returns>
        /// Created by NVMANH 10/8/2019
        public IEnumerable<Receipt> GetAllReceipt()
        {
            return GetAll("[dbo].[Proc_GetAllData]", "Receipt", "ReceiptDate");
        }
    }
}
