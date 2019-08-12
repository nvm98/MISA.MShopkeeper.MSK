using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entities.Dictionary
{
    /// <summary>
    /// Lớp chi tiết phiếu thu
    /// </summary>
    /// Created by NVMANH 10/8/2019
    public class ReceiptDetail:BaseEntity
    {
        #region Properties
        //Khóa chính
        public Guid ReceiptDetailID { get; set; }
        //Diễn giải
        public string Reason { get; set; }
        //Số tiền
        public decimal ReceiptDetailMoney { get; set; }
        //Loại chứng từ
        public string Type { get; set; }
        #endregion

        #region ForeignKeys
        //Khóa ngoại đến bảng Fund
        public Guid ReceiptID { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// Created by NVMANH 10/8/2019
        public ReceiptDetail()
        {
            ReceiptDetailID = Guid.NewGuid();
        }
        #endregion
    }
}
