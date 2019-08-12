using MISA.Entities.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entities.ViewModels
{
    public class ReceiptViewModel:BaseEntity
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
        //Mã đối tượng
        [MaxLength(100)]
        public string ObjectCode { get; set; }
        //Tên đối tượng
        [MaxLength(100)]
        public string ObjectName { get; set; }
        //Mã nhân viên
        [MaxLength(100)]
        public string StaffCode { get; set; }
        //Tên nhân viên
        [MaxLength(100)]
        public string StaffName { get; set; }
        //Địa chỉ
        [MaxLength(255)]
        public string Address { get; set; }
        #endregion

        #region ForeignKey
        //Khóa ngoại đến bảng staff
        [Required]
        public Guid StaffID { get; set; }

        //Khóa ngoại đến bảng ObjectDetail
        [Required]
        public Guid ObjectDetailID { get; set; }
        #endregion
    }
}
