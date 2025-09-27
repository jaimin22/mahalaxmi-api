using MahalaxmiAPI.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
//using System.Net.Mail;
//using System.Text;
using System.Web.Http;
using System.Web.ModelBinding;

namespace MahalaxmiAPI.Controllers
{
    // [Authorize]
    public class EmailSentController : ApiController
    {
        public IHttpActionResult PostSendEmail([QueryString] DateTime dateTime)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {

                    DateTime cutoff = dateTime; // your DateTime parameter

                    List<salesorder> salesOrders = context.Database.SqlQuery<salesorder>(
                        @"SELECT * FROM salesorder WHERE CONVERT(datetime, DCPIDate, 121) >= @p0",
                        cutoff
                    ).ToList();
                    if (salesOrders.Any())
                    {
                        string subject = "Mahalaxmi Chemicals sales report : " + dateTime.ToString("dd/MMM/yyyy");
                        string template = "Dear ##username##,<br/><br/>Welcome to Mahalaxmi Chemicals (Age.) Pvt. Ltd. <br/><br/> Here are your sales orders:<br/>##salesorder##";

                        // Group by user (assuming each salesorder has Payer as user ID or similar)
                        var userGroups = salesOrders.GroupBy(s => s.SoldToCode);

                        foreach (var group in userGroups)
                        {
                            var currentGroup = group.ToList();
                            string salesorderHtml = BuildSalesOrderTable(currentGroup);

                            string body = template.Replace("##salesorder##", salesorderHtml)
                                                  .Replace("##username##", currentGroup[0].SoldTo ?? "User");

                            string toEmail = "sudhir@mahalaxmichemicals.com";

                            string SoldToCode = group.Key?.ToString() ?? "";
                            UserMaster customer = context.UserMasters.Where(t => t.profileid == SoldToCode).FirstOrDefault();

                            // Dummy example: replace with actual user email
                            if (customer != null)
                            {
                                toEmail = customer.email;
                            }

                            try
                            {
                                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                                {
                                    smtp.EnableSsl = true;
                                    smtp.Credentials = new System.Net.NetworkCredential(
                                        "info@mahalaxmichemicals.com",
                                        "sanf swaz mkwj kyqo"
                                    );
                                    smtp.Timeout = 30000;

                                    //var message = new MailMessage("info@mahalaxmichemicals.com", "jaimin@techgroot.com,jaimin@panchal.one", subject, body);
                                    var message = new MailMessage("info@mahalaxmichemicals.com", toEmail.Trim(), subject, body);

                                    message.IsBodyHtml = true;

                                    //message.Bcc.Add("mahalaxmimailbackup@gmail.com");
                                    message.Bcc.Add("sudhir@mahalaxmichemicals.com");
                                    message.Bcc.Add("panchaljaimin22@gmail.com");

                                    smtp.Send(message);
                                }
                            }
                            catch (Exception ex)
                            {
                                // Log exception
                                Console.WriteLine($"Error sending to {toEmail}: {ex.Message}");
                            }
                        }

                    }

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string BuildSalesOrderTable(List<salesorder> orders)
        {
            // Ensure stable grouping and subtotaling
            var ordered = orders
                .OrderBy(o => (o.ShipToCode ?? "").Trim())
                .ThenBy(o => o.DCPIDate) // secondary ordering like in your table listing
                .ToList();

            var sb = new StringBuilder();
            sb.Append(@"<table style='color:#000000; font-family: Arial,Helvetica,sans-serif; font-size: 12px; line-height: normal;
                 width:100%; border-right:1px solid #DDDDDD; border-top:1px solid #DDDDDD;' cellpadding='0' cellspacing='0'>");

            // Header
            sb.Append(@"<tr style='background-color:#cccccc;'>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; width:20px; text-align:center;'>#</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:100px;'>DCPI No</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:65px;'>DCPIDate</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:100px;'>Material</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:40px; text-align:right;'>Qty</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:40px;'>UOM</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:100px; text-align:right;'>Amt</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:70px; text-align:right;'>Tax</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:80px; text-align:right;'>Total Amt</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:100px;'>Truck No</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:240px;'>Transporter Name</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:100px;'>Tax Invoice</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:60px;'>Excise Inv</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:240px;'>Payer</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:240px;'>Ship To</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:60px;'>Pay Term</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:100px;'>SOR No.</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:100px; text-align:right;'>SOR Amount</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:100px;'>Freight Invoice</td>
        <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; font-weight:bold; width:100px; text-align:right;'>Freight Amount</td>
    </tr>");

            // Running totals (grand)
            decimal totalQty = 0m, totalAmt = 0m, totalTax = 0m, totalTotalAmt = 0m, totalFreightAmount = 0m, totalSorAmount = 0m;

            // Subtotals (per ShipToCode)
            decimal subQty = 0m, subAmt = 0m, subTax = 0m, subTotalAmt = 0m, subFreightAmount = 0m;
            string currentShipToCode = null;

            int rowIndex = 0;
            for (int i = 0; i < ordered.Count; i++)
            {
                var o = ordered[i];
                var shipToCode = (o.ShipToCode ?? string.Empty).Trim();

                // If changing ShipToCode and not first group, emit subtotal row
                if (currentShipToCode != null && shipToCode != currentShipToCode)
                {
                    sb.Append(@"<tr style='background-color:#FAF0F5; font-weight:bold;'>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;' colspan='4'>Sub Total:</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + subQty + @"</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD;'></td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + subAmt + @"</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + subTax + @"</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + subTotalAmt + @"</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD;' colspan='10'></td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + subFreightAmount + @"</td>
            </tr>");

                    // reset subtotals
                    subQty = subAmt = subTax = subTotalAmt = subFreightAmount = 0m;
                }

                currentShipToCode = shipToCode;

                // Alternate row background
                string rowBg = (rowIndex % 2 == 0) ? "" : " style='background-color:#f5f5f5;'";
                sb.Append("<tr" + rowBg + ">");

                // Parse numbers
                var qty = ParseDecimal(o.Qty);
                var amt = ParseDecimal(o.Amt);
                var tax = ParseDecimal(o.Tax);
                var totalAmtVal = ParseDecimal(o.TotalAmt);
                var freightAmt = ParseDecimal(o.FrieghtAmount);
                var sorAmt = ParseDecimal(o.SORDutyAmt); // may be blank in your data

                // Row cells
                sb.AppendFormat(@"
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>{0}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{1}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{2}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{3}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>{4}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{5}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>{6}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>{7}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'><b>{8}</b></td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{9}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{10}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{11}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{12}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{13}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{14}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{15}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{16}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>{17}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;'>{18}</td>
                                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>{19}</td>",
                    (i + 1),
                    o.DCPINo, o.DCPIDate, o.Material, qty, o.UOM, amt, tax, totalAmtVal,
                    o.TruckNo, o.Transporter, o.RetailInvoice, o.ExciseInv, o.Payer, o.ShipTo, o.PayTerm,
                    o.SORNO, sorAmt, o.FrieghtInvoice, freightAmt);

                sb.Append("</tr>");
                rowIndex++;

                // accumulate subtotals
                subQty += qty;
                subAmt += amt;
                subTax += tax;
                subTotalAmt += totalAmtVal;
                subFreightAmount += freightAmt;

                // accumulate grand totals
                totalQty += qty;
                totalAmt += amt;
                totalTax += tax;
                totalTotalAmt += totalAmtVal;
                totalFreightAmount += freightAmt;
                totalSorAmount += sorAmt;

                // If it's the last row, emit the final Sub Total and then Grand Total
                if (i == ordered.Count - 1)
                {
                    if (!string.IsNullOrEmpty(currentShipToCode))
                    {
                        sb.Append(@"<tr style='background-color:#FAF0F5; font-weight:bold;'>
                    <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;' colspan='4'>Sub Total:</td>
                    <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + subQty + @"</td>
                    <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD;'></td>
                    <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + subAmt + @"</td>
                    <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + subTax + @"</td>
                    <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + subTotalAmt + @"</td>
                    <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD;' colspan='10'></td>
                    <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + subFreightAmount + @"</td>
                </tr>");
                    }

                    sb.Append(@"<tr style='background-color:#cccccc; font-weight:bold;'>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px;' colspan='4'>Grand Total:</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + totalQty + @"</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD;'></td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + totalAmt + @"</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + totalTax + @"</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + totalTotalAmt + @"</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD;' colspan='8'></td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + totalSorAmount + @"</td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD;'></td>
                <td style='border-left:1px solid #DDDDDD; border-bottom:1px solid #DDDDDD; padding:3px; text-align:right;'>" + totalFreightAmount + @"</td>
            </tr>");
                }
            }

            sb.Append("</table>");
            return sb.ToString();
        }
        private static decimal ParseDecimal(object val)
        {
            if (val == null) return 0m;
            var s = Convert.ToString(val)?.Trim();
            if (string.IsNullOrEmpty(s)) return 0m;
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var d)) return d;
            // Try current culture too (in case original data has commas)
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out d)) return d;
            return 0m;
        }

        public partial class EmailSendReply
        {
            public string SoldToCode { get; set; }
            public string SoldTo { get; set; }
            public bool IsSuccess { get; set; }
            public string Error { get; set; }
        }
    }
}

