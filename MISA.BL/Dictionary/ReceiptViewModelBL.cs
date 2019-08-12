using MISA.BL.Base;
using MISA.DL.Dictionary;
using MISA.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Dictionary
{
    /// <summary>
    /// Lớp xử lý nghiệp vu với view model của phiếu thu
    /// </summary>
    /// Created by NVMANH 11/8/2019
    public class ReceiptViewModelBL:BaseBL
    {
        private ReceiptViewModelDL receiptViewModelDL;
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// Created by NVMANH 11/8/2019
        public ReceiptViewModelBL()
        {
            receiptViewModelDL = new ReceiptViewModelDL();
        }
        /// <summary>
        /// Lấy một đối tượng view model của phiếu thu
        /// </summary>
        /// <param name="id">id phiếu thu</param>
        /// <returns>Đối tượng view model của phiếu thu</returns>
        public ReceiptViewModel GetReceiptViewModel(Guid id)
        {
            return receiptViewModelDL.GetDataByAttribute(Common.Commons.ConvertGuidToNvarchar(id));
        }
    }
}
