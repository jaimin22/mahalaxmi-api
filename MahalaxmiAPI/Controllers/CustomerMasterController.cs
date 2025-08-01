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
    public class CustomerMasterController : ApiController
    {
        public IHttpActionResult Get(string userId)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {
                    List<UserCustomerMappingView> result = new List<UserCustomerMappingView>();//;
                    var users = System.Configuration.ConfigurationManager.AppSettings["adminIds"].Split(',').ToList();
                    bool isAdmin = false;
                    long ProfileId = 0;
                    foreach (var item in users)
                    {
                        if(userId == item)
                        {
                            isAdmin = true;
                            if ("04468a4f-58da-47d2-a89a-39f8696704a5" == item)
                            {
                                ProfileId = 2;
                            }
                            else
                            {
                                ProfileId = 3;
                            }
                        }
                        

                    }

                    if (isAdmin)
                    {
                        var customers = context.CustomerMasters.Where(t => t.IsDeleted == false).ToList();
                        result = customers.Select(t => new UserCustomerMappingView()
                        {
                            SoldToPartyId = t.SoldToPartyId,
                            CustomerName = t.CustomerName,
                            UserId = userId,
                            ProfileId = ProfileId
                        }).OrderBy(t => t.CustomerName).ToList();
                    }
                    else
                    {
                        result = context.UserCustomerMappingViews.Where(t => t.UserId == userId).ToList();
                    }
                    
                    ResponseView<UserCustomerMappingView> response = new ResponseView<UserCustomerMappingView>()
                    {
                        ResponseList = result
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
