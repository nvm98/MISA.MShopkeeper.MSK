using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entities.Dictionary
{
    /// <summary>
    /// Lớp chi tiết nhân viên
    /// </summary>
    /// Created by NVMANH 10/8/2019
    public class Staff:BaseEntity
    {
        #region Properties
        // id nhân viên
        public Guid StaffID { get; set; }
        // Tên nhân viên
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        // Mã nhân viên
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
        // Địa chỉ
        [MaxLength(255)]
        public string Address { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// Created by NVMANH 10/8/2019
        public Staff()
        {
            StaffID = Guid.NewGuid();
        }
        #endregion
    }
}
