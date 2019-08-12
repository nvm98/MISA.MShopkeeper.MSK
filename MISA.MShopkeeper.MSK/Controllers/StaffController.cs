using MISA.BL.Dictionary;
using MISA.Entities.ViewModels;
using MISA.MShopkeeper.MSK.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MISA.MShopkeeper.MSK.Controllers
{
    [RoutePrefix("staff")]
    public class StaffController : ApiController
    {
        /// <summary>
        /// Lấy tất cả danh sách nhân viên
        /// </summary>
        /// <returns>Đối tượng AjaxResult</returns>
        /// Created by NVMANH 10/8/2019
        [HttpGet]
        [Route("")]
        public AjaxResult Get()
        {
            var ajaxResult = new AjaxResult();
            try
            {
                using (StaffBL staffBL = new StaffBL())
                {
                    ajaxResult.Data = staffBL.GetAll();
                    ajaxResult.Success = true;
                    ajaxResult.Message = Resources.Success;
                }
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Data = ex;
                ajaxResult.Message = Resources.Error;
            }
            return ajaxResult;
        }
    }
}
