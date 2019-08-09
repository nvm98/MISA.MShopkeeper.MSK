using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entities.Dictionary
{
    /// <summary>
    /// Hàm chứa các thuộc tính chung cho entity
    /// </summary>
    /// Created by NVMANH 9/8/2019
    public class BaseEntity
    {
        #region property
        // Người tạo
        [MaxLength(100)]
        public string CreatedBy { get; set; }
        // Ngày tạo
        public DateTime CreatedDate { get; set; }
        // Người sửa đổi
        [MaxLength(100)]
        public string ModifiedBy { get; set; }
        // Ngày sửa đổi
        public DateTime? ModifiedDate { get; set; }
        #endregion

        #region Constructors
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
        #endregion
    }
}
