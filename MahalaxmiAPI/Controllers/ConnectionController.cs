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
    public class ConnectionController : ApiController
    {
        public IHttpActionResult GetConnection()
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {
                    context.Database.SqlQuery<string>("ConnectionReady").FirstOrDefault();
                }
                return Ok();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
