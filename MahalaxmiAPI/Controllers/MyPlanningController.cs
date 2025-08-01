using MahalaxmiAPI.Models.DataModels;
using MahalaxmiAPI.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Globalization;

namespace MahalaxmiAPI.Controllers
{
    [Authorize]
    public class MyPlanningController : ApiController
    {

        [Route("api/MyPlanning/GetWeekList")]
        public IHttpActionResult Get(string Month, string Year)
        {
            try
            {
                DateTime reference = Convert.ToDateTime(Year + "/" + Month + "/01");

                Calendar calendar = CultureInfo.CurrentCulture.Calendar;

                IEnumerable<int> daysInMonth = Enumerable.Range(1, calendar.GetDaysInMonth(reference.Year, reference.Month));

                List<weekView> weeks = daysInMonth.Select(day => new DateTime(reference.Year, reference.Month, day))
                    .GroupBy(d => calendar.GetWeekOfYear(d, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                    .Select((g, index) => new weekView()
                    {
                        id = index + 1,
                        endDate = g.Last(),
                        startDate = g.First(),
                        endDay = g.Last().DayOfWeek.ToString(),
                        startDay = g.First().DayOfWeek.ToString()
                    })
                    .ToList();

                return Ok(weeks);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [Route("api/MyPlanning/GetList")]
        public IHttpActionResult GetList(string startDate, string endDate)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {
                    string userid = User.Identity.GetUserId();
                    List<MyPlanning> res = context.Database.SqlQuery<MyPlanning>(" exec GetMyPlanning @startDate,@endDate,@userId"
                        , new SqlParameter("@startDate", startDate)
                        , new SqlParameter("@endDate", endDate)
                        , new SqlParameter("@userid", userid)).ToList();

                    ResponseView<MyPlanning> response = new ResponseView<MyPlanning>()
                    {
                        ResponseList = res
                    };

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public IHttpActionResult Post(MyPlanning myPlanning)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {
                    myPlanning.CreatedBy = User.Identity.GetUserId();
                    myPlanning.Status = "Pending";
                    myPlanning.CreatedDate = DateTime.Now;
                    myPlanning.IsDeleted = false;

                    context.MyPlannings.Add(myPlanning);
                    context.SaveChanges();

                    ResponseView<MyPlanning> response = new ResponseView<MyPlanning>()
                    {
                        ResponseObject = myPlanning
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public IHttpActionResult Put(MyPlanning myPlanning)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {


                    MyPlanning myPlanningTemp = context.MyPlannings.Where(t => t.PlanningId == myPlanning.PlanningId).FirstOrDefault();
                    myPlanningTemp.Grade = myPlanning.Grade;
                    myPlanningTemp.Product = myPlanning.Product;
                    myPlanning.Qty = myPlanning.Qty;
                    context.SaveChanges();

                    ResponseView<MyPlanning> response = new ResponseView<MyPlanning>()
                    {
                        ResponseObject = myPlanningTemp
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/MyPlanning/GetGrade")]
        public IHttpActionResult Get(string product)
        {
            try
            {
                int id = product == "PP" ? 1 : (product == "PE" ? 2 : (product == "PVC" ? 3 : 0));

                mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext();
                List<polymerView> pv = context.polymers.Where(t => t.mid == id).ToList().Select(t => new polymerView
                {
                    id = t.id,
                    mcontent = t.mcontent,
                    mid = t.mid,
                    mname = t.mname,
                    morder = t.morder,
                    topimage = t.topimage,

                }).ToList();

                List<polymerView> result = new List<polymerView>();
                foreach (var item in pv)
                {
                    result.AddRange(getList(item.id));
                }

                return Ok(result);
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
            }).ToList();
            return pv;
        }
    }
}
