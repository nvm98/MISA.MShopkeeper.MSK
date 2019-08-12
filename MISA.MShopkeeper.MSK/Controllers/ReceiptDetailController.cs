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
    [RoutePrefix("detail")]
    public class ReceiptDetailController : ApiController
    {
        /// <summary>
        /// Lấy danh sách chi tiết phiếu thu theo id phiếu thu
        /// </summary>
        /// <param name="id">id phiếu thu</param>
        /// <returns>Chi tiết của phiếu thu</returns>
        [HttpGet]
        [Route("{id}")]
        public AjaxResult Get(Guid id)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                using (ReceiptDetailBL receiptDetailBL = new ReceiptDetailBL())
                {
                    ajaxResult.Data = receiptDetailBL.GetReceiptDetailByReceiptID(id);
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
        public void Post([FromBody]string value)
        {
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public void Delete(int id)
        {
        }
    }
}
