using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entities.ViewModels
{
    /// <summary>
    /// Lớp chứa kết quả khi gọi Ajax
    /// </summary>
    /// Created by NVMANH 9/8/2019
    public class AjaxResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int Code { get; set; }
        public AjaxResult()
        {
            Success = true;
        }
    }
}
