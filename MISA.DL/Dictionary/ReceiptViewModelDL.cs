using MISA.DL.Base;
using MISA.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Dictionary
{
    /// <summary>
    /// Lớp xử lý dữ liệu view model phiếu thu
    /// </summary>
    /// Created by NVMANH 11/8/2019
    public class ReceiptViewModelDL:BaseDL<ReceiptViewModel>
    {
        /// <summary>
        /// Lấy view model phiếu thu theo mã phiếu thu
        /// </summary>
        /// <returns>View model phiếu thu</returns>
        /// Created by NVMANH 11/8/2019
        public ReceiptViewModel GetDataByAttribute(string value)
        {
            return GetDataByAttribute("[dbo].[Proc_GetAllDataByAttribute]", "[dbo].[View_Receipt]", "ReceiptID", value);
        }
    }
}
