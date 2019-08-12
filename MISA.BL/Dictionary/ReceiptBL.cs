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
    /// Xử lý nghiệp vụ của phiếu thu
    /// </summary>
    /// Created by NVMANH 10/8/2019
    public class ReceiptBL:BaseBL
    {
        private ReceiptDL receiptDL;
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// Created by NVMANH 10/8/2019
        public ReceiptBL()
        {
            receiptDL = new ReceiptDL();
        }
        /// <summary>
        /// Lấy tất cả danh sách phiếu thu
        /// </summary>
        /// <returns>tất cả danh sách phiếu thu</returns>
        /// Craeted by NVMANH 10/8/2019
        public IEnumerable<Receipt> GetAll()
        {
            return receiptDL.GetAllReceipt();
        }
    }
}
