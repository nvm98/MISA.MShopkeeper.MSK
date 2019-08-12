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
    [RoutePrefix("receipt")]
    public class ReceiptsController : ApiController
    {   
        /// <summary>
        /// Lấy tất cả danh sách phiếu thu
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
                using (ReceiptBL receiptBL = new ReceiptBL())
                {
                    ajaxResult.Data = receiptBL.GetAll();
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
        // GET: api/Receipts/5
        public string Get(int id)
        {
            return "value";
        }
        // POST: api/Receipts
        public void Post([FromBody]string value)
        {
        }
        // PUT: api/Receipts/5
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE: api/Receipts/5
        public void Delete(int id)
        {
        }
    }
}