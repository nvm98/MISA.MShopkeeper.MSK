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
    [RoutePrefix("receiptview")]
    public class ReceiptViewController : ApiController
    {
        /// <summary>
        /// Lấy đối tượng view model của phiếu thu
        /// </summary>
        /// <param name="id">id phiếu thu</param>
        /// <returns>đối tượng ajaxResult</returns>
        /// Created by NVMANH 11/8/2019
        [HttpGet]
        [Route("{id}")]
        public AjaxResult Get(Guid id)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                using (ReceiptViewModelBL receiptViewModelBL = new ReceiptViewModelBL())
                {
                    ajaxResult.Data = receiptViewModelBL.GetReceiptViewModel(id);
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
