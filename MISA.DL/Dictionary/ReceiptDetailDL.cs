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
    /// Lớp xử lý dữ liệu với bảng ReceiptDetail
    /// </summary>
    /// Created by NVMANH 10/8/2019
    public class ReceiptDetailDL:BaseDL<ReceiptDetail>
    {
        /// <summary>
        /// Lấy danh sách chi tiết phiếu thu
        /// </summary>
        /// <param name="value">Chuỗi giá trị điều kiện</param>
        /// <returns>danh sách chi tiết phiếu thu</returns>
        /// Created by NVMANH 10/8/2019
        public IEnumerable<ReceiptDetail> GetReceiptDetailByReceiptID(string value)
        {
            return GetAllDataByAttribute("[dbo].[Proc_GetAllDataByAttribute]", "ReceiptDetail", "ReceiptID", value);
        }
    }
}
