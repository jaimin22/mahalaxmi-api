using MahalaxmiAPI.Models.DataModels;
using MahalaxmiAPI.ModelView;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
namespace MahalaxmiAPI.Controllers
{
    [Authorize]
    public class PriceListController : ApiController
    {
        //1. Product Select
        //2. Location Select
        //3. Product Select
        //Display Plant Price, Depo Price, Deemed Price.
        [Route("api/PriceList/GetOptions")]
        public IHttpActionResult GetOptions(string product,string soldToPartyId)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {
                    
                    ProductOptionView productOption = new ProductOptionView();
                    productOption.location = new List<LocationView>();
                    productOption.locationForDepot = new List<LocationView>();
                    productOption.product = new List<ProductView>();
                    productOption.Favriote = new List<Favriote>();
                    productOption.location = context.Database.SqlQuery<LocationView>("exec GetProductLocation @Product", new SqlParameter("@Product", product)).ToList();
                    productOption.locationForDepot = context.Database.SqlQuery<LocationView>("exec GetProductLocation @Product", new SqlParameter("@Product", product+"_Depot")).ToList();
                    productOption.product = context.Database.SqlQuery<ProductView>("exec GetSubProducts @Product", new SqlParameter("@Product", product)).ToList();
                    productOption.Favriote = context.Favriotes.Where(t => t.ProfileID == soldToPartyId).ToList();
                    ResponseView<ProductOptionView> response = new ResponseView<ProductOptionView>()
                    {
                        ResponseObject = productOption
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("api/PriceList/GetPrice")]
        public IHttpActionResult GetPrice(string product, long locationId, string childProduct)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {
                    ResponseView<PriceListView> response = new ResponseView<PriceListView>()
                    {
                        ResponseObject = context.Database.SqlQuery<PriceListView>("exec GetProductPrice @Product,@LocationId,@ChildProduct",
                        new SqlParameter("@Product", product),
                        new SqlParameter("@LocationId", locationId),
                        new SqlParameter("@ChildProduct", childProduct)).FirstOrDefault()
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("api/PriceList/GetDepotPrice")]
        public IHttpActionResult GetDepotPrice(string product, long locationId, string childProduct)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {
                    ResponseView<PriceListView> response = new ResponseView<PriceListView>()
                    {
                        ResponseObject = context.Database.SqlQuery<PriceListView>("exec GetProductDepotPrice @Product,@LocationId,@ChildProduct",
                        new SqlParameter("@Product", product),
                        new SqlParameter("@LocationId", locationId),
                        new SqlParameter("@ChildProduct", childProduct)).FirstOrDefault()
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("api/PriceList/Favourite")]
        public IHttpActionResult GetFavourite(string soldToPartyId)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {
                   
                    ResponseView<Favriote> response = new ResponseView<Favriote>()
                    {
                        ResponseList = context.Favriotes.Where(t => t.ProfileID == soldToPartyId).ToList()
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
