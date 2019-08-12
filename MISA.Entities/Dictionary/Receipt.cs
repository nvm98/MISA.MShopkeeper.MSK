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
    public class Receipt:BaseEntity
    {
        #region Properties
        //Id
        public Guid ReceiptID { get; set; }
        //Mã chứng từ
        [Required]
        [MaxLength(20)]
        public string ReceiptCode { get; set; }
        //Ngày chứng từ
        [Required]
        public DateTime ReceiptDate { get; set; }
        //Tổng tiền
        [Required]
        public decimal ReceiptMoney { get; set; }
        //Người nộp/nhận
        [MaxLength(100)]
        public string ReceiptPerson { get; set; }
        //Lý do
        [MaxLength(255)]
        public string ReceiptReason { get; set; }
        //loại chứng từ
        [MaxLength(255)]
        public string ReceiptType { get; set; }
        #endregion

        #region ForeignKey
        //Khóa ngoại đến bảng staff
        [Required]
        public Guid StaffID { get; set; }

        //Khóa ngoại đến bảng ObjectDetail
        [Required]
        public Guid ObjectDetailID { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// Created by NVMANH 10/8/2019
        public Receipt()
        {
            ReceiptID = Guid.NewGuid();
            ReceiptDate = DateTime.Now;
        }

        #endregion
    }
}
