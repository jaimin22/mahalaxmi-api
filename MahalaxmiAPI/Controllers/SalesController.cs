using MahalaxmiAPI.Models.DataModels;
using MahalaxmiAPI.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MahalaxmiAPI.Controllers
{
    public class SalesController : ApiController
    {
        mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext();
        public IHttpActionResult Get(DateTime selectedDate, string soldToPartyId)
        {
            try
            {
                //string userId = User.Identity.GetUserId();
                //var UserObj = context.AspNetUsers.Where(t => t.Id == userId).FirstOrDefault();
                //string userId = "2000003415";
                //DateTime date = Convert.ToDateTime("18/MAR/2016");
                DateTime date = selectedDate;
                //List<salesOrderView> res = context.salesOrderViews.Where(t => t.Expr1 >= selectedDate && t.Expr1 <= selectedDate && t.SoldToCode == userId).ToList();
                List<salesOrderView> res = context.salesOrderViews.Where(t => t.Expr1 >= date && t.Expr1 <= date && t.SoldToCode == soldToPartyId).ToList();

                ResponseView<salesOrderView> result = new ResponseView<salesOrderView>();
                result.ResponseList = new List<salesOrderView>();
                if (res.Count > 0)
                {
                    result.ResponseList = res;
                    result.Error = "NO";
                }
                else
                {
                    result.ResponseList = res;
                    result.Message = "No Data Available.";
                    result.Error = "YES";
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
