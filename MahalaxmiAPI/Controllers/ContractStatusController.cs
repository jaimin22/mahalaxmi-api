using MahalaxmiAPI.Models.DataModels;
using MahalaxmiAPI.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace MahalaxmiAPI.Controllers
{
    [Authorize]
    public class ContractStatusController : ApiController
    {
        public IHttpActionResult Get(string soldToPartyId)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {
                    ResponseView<ContractStatu> response = new ResponseView<ContractStatu>()
                    {
                        ResponseList = context.ContractStatus.Where(t => t.SoldToParty == soldToPartyId).ToList()
                    };
                    return Ok(response);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
