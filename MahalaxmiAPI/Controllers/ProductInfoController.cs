using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MahalaxmiAPI.ModelView;
using System.Configuration;
using MahalaxmiAPI.Models.DataModels;

namespace MahalaxmiAPI.Controllers
{
    public class ProductInfoController : ApiController
    {
        

        public IHttpActionResult Get(int id)
        {
            try
            {
                mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext();
                List<polymerView> pv = context.polymers.Where(t => t.mid == id).ToList().Select(t => new polymerView
                {
                    id = t.id,
                    mcontent = t.mcontent,
                    mid = t.mid,
                    mname = t.mname,
                    morder = t.morder,
                    topimage = t.topimage,
                    polimarViewList = getList(t.id)
                }).ToList();

                return Ok(pv);
            }
            catch (Exception ex)
            {
                throw ex;
            }

          
        }

        private List<polymerView> getList(decimal p)
        {
            mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext();
            List<polymerView> pv = context.polymers.Where(t => t.mid == p).ToList().Select(t => new polymerView
            {
                id = t.id,
                mcontent = t.mcontent,
                mid = t.mid,
                mname = t.mname,
                morder = t.morder,
                topimage = ConfigurationManager.AppSettings["pdfPath"].ToString() + "/" +t.topimage
            }).ToList();
            return pv;
        }

        //private List<polymerView> getList(decimal id)
        //{
        //    List<polymerView> pv = context.polymers.Where(t => t.mid == id).Select(t => new polymerView
        //    {
        //        id = t.id,
        //        mcontent = t.mcontent,
        //        mid = t.mid,
        //        mname = t.mname,
        //        morder = t.morder,
        //        topimage = t.topimage
        //    }).ToList();

        //    return pv;
        //}

    }
}
