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
    /// Lớp xử nghiệp vụ với chi tiết phiếu thu
    /// </summary>
    public class ReceiptDetailBL:BaseBL
    {
        private ReceiptDetailDL receiptDetailDL;
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// Created by NVMANH 10/8/2019
        public ReceiptDetailBL()
        {
            receiptDetailDL = new ReceiptDetailDL();
        }
        /// <summary>
        /// Lấy chi tiết phiếu thu theo ID phiếu thu
        /// </summary>
        /// <param name="id">ID phiếu thu</param>
        /// <returns>chi tiết phiếu thu</returns>
        /// Created by NVMANH  10/8/2019
        public IEnumerable<ReceiptDetail> GetReceiptDetailByReceiptID(Guid id)
        {
            return receiptDetailDL.GetReceiptDetailByReceiptID(Common.Commons.ConvertGuidToNvarchar(id));
        }
    }
}
