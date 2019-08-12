using MISA.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entities.Dictionary
{
    /// <summary>
    /// Lớp chi tiết đối tượng
    /// </summary>
    /// Created by NVMANH 10/8/2019
    public class ObjectDetail:BaseEntity
    {
        #region Properties
        // id đối tượng
        public Guid ObjectDetailID { get; set; }
        // Tên đối tượng
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        // Mã đối tượng
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
        // Địa chỉ
        [MaxLength(255)]
        public string Address { get; set; }
        //Loại đối tượng
        public int Type { get; set; }
        //Tên loại đối tượng
        public string TypeName {
            get {
                string TypeName;
                Enumeration.Type Type = (Enumeration.Type)(this.Type);
                switch (Type)
                {
                    case Enumeration.Type.Customer:
                        TypeName = "Khách hàng";
                        break;
                    case Enumeration.Type.Employee:
                        TypeName = "Nhân viên";
                        break;
                    case Enumeration.Type.Shipper:
                        TypeName = "Đối tác giao hàng";
                        break;
                    case Enumeration.Type.Supplier:
                        TypeName = "Nhà cung cấp";
                        break;
                    default:
                        TypeName = "Không xác định";
                        break;
                }
                return TypeName;
            }
            set
            {

            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// Created by NVMANH 10/8/2019
        public ObjectDetail()
        {
            ObjectDetailID = Guid.NewGuid();
        }
        #endregion
    }
}
