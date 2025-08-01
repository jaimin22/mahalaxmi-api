using MahalaxmiAPI.Models.DataModels;
using MahalaxmiAPI.ModelView;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;

//using System.Net.Mail;
//using System.Text;
using System.Web;
using System.Web.Http;

namespace MahalaxmiAPI.Controllers
{
    [Authorize]
    public class MyOrderController : ApiController
    {
        public IHttpActionResult PostMyOrder(MyOrder myOrder)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {
                    myOrder.CreatedBy = User.Identity.GetUserId();
                    myOrder.Status = "Pending";
                    myOrder.CreatedDate = DateTime.Now;
                    myOrder.IsDeleted = false;
                    context.MyOrders.Add(myOrder);
                    context.SaveChanges();

                    string body = emailTemplate();

                    string userId = User.Identity.GetUserId();
                    var userDetails = context.UserAndCompanyDetailsViews.Where(t => t.UserId == userId && t.SoldToPartyId == myOrder.SoldToPartyId).FirstOrDefault();


                    body = body.Replace("##OrderDate", DateTime.Now.ToString("dd/MMM/yyyy"));
                    body = body.Replace("##CompanyName", userDetails.CustomerName);
                    body = body.Replace("##Product", myOrder.Product);
                    body = body.Replace("##Grade", myOrder.Grade);
                    body = body.Replace("##Quantity", myOrder.Qty.ToString());
                    body = body.Replace("##Type", myOrder.Type);
                    body = body.Replace("##ScheduleDate", myOrder.ScheduledDate.Value.ToString("dd/MMM/yyyy"));
                    body = body.Replace("##PaymentTerms", myOrder.PaymentTerms);



                    body += "<b>User </b> : " + userDetails.UserName;
                    body += "<br />";
                    body += "<b>Product </b> : " + myOrder.Product;
                    body += "<br />";
                    body += "<b>Grade </b> : " + myOrder.Grade;
                    body += "<br />";
                    body += "<b>Qty </b> : " + myOrder.Qty;
                    body += "<br />";
                    body += "<b>Type </b> : " + myOrder.Type;
                    body += "<br />";
                    body += "<b>ScheduledDate </b> : " + myOrder.ScheduledDate.Value.ToString("dd/MMM/yyyy");
                    body += "<br />";

                    //const string SERVER = "relay-hosting.secureserver.net";
                    //const string SERVER = "smtp.gmail.com";
                    //System.Web.Mail.MailMessage oMail = new System.Web.Mail.MailMessage();
                    //oMail.From = "info@mahalaxmichemicals.com";
                    //oMail.To = "info@mahalaxmichemicals.com";
                    //oMail.Bcc = "panchaljaimin22@gmail.com";
                    //oMail.Subject = "New Order From " + userDetails.CustomerName + " by " + userDetails.UserName + ".";
                    //oMail.BodyFormat = MailFormat.Html; // enumeration
                    ////oMail.Priority = System.Net.Mail.MailPriority.High; // enumeration
                    //oMail.Body = body;
                    //SmtpMail.SmtpServer = SERVER;
                    //SmtpMail.Send(oMail);
                    //oMail = null; // free up resources

                    //SmtpClient client = new SmtpClient();
                    string email = ConfigurationManager.AppSettings["email"];
                    string password = ConfigurationManager.AppSettings["email"];
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                    {
                        Credentials = new NetworkCredential(email, password),
                        EnableSsl = true
                    };
                    client.Timeout = 30000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    string toEmailId = "info@mahalaxmichemicals.com";

                    if (!string.IsNullOrEmpty(userDetails.CustomerEmailId))
                    {
                        toEmailId = toEmailId + "," + userDetails.CustomerEmailId;
                    }

                    System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage("info@mahalaxmichemicals.com", toEmailId, "New Order From " + userDetails.CustomerName + " by " + userDetails.UserName + ".", body);
                    mm.Bcc.Add("panchaljaimin22@gmail.com");
                    mm.IsBodyHtml = true;
                    client.Send(mm);

                    ResponseView<MyOrder> response = new ResponseView<MyOrder>()
                    {
                        ResponseObject = myOrder
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public IHttpActionResult PutMyOrder(MyOrder myOrder)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {


                    MyOrder order = context.MyOrders.Where(t => t.Id == myOrder.Id).FirstOrDefault();
                    order.Product = myOrder.Product;
                    order.ScheduledDate = myOrder.ScheduledDate;
                    order.Grade = myOrder.Grade;
                    order.Qty = myOrder.Qty;
                    order.Type = myOrder.Type;
                    order.Grade = myOrder.Grade;
                    order.IsDeleted = myOrder.IsDeleted;
                    order.CreatedBy = myOrder.CreatedBy;
                    order.CreatedDate = DateTime.Now;
                    context.SaveChanges();

                    ResponseView<MyOrder> response = new ResponseView<MyOrder>()
                    {
                        ResponseObject = myOrder
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public IHttpActionResult GetList(string month, string year)
        {
            try
            {
                mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext();
                string userId = User.Identity.GetUserId();
                List<MyOrder> res = context.Database.SqlQuery<MyOrder>(" exec GetMyOrder @month,@year,@userId"
                    , new SqlParameter("@month", month)
                    , new SqlParameter("@year", year)
                    , new SqlParameter("@userId", userId)).ToList();

                ResponseView<MyOrder> response = new ResponseView<MyOrder>()
                {
                    ResponseList = res
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [Route("api/MyOrder/GetGrade")]
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


        private string emailTemplate()
        {
            var str = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/email-template/order-email.html"));
            return str;
        }
    }
}
