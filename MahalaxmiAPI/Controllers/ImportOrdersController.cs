using MahalaxmiAPI.Models;
using MahalaxmiAPI.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;


//using System.Net.Mail;
//using System.Text;
using System.Web.Http;

namespace MahalaxmiAPI.Controllers
{
    [Authorize]
    public class ImportOrdersController : ApiController
    {
        public IHttpActionResult PostOrders(List<DispatchOrdersModel> dispatchOrders)
        {
            try
            {
                using (mahachem_mahalaxmichemicaContext context = new mahachem_mahalaxmichemicaContext())
                {

                    var orders = new List<salesorder>();

                    // Filter out records with no SoldTo
                    var groupedOrders = dispatchOrders
                        .Where(t => !string.IsNullOrWhiteSpace(t.SoldTo))
                        .GroupBy(t => t.SoldTo);

                    foreach (var group in groupedOrders)
                    {
                        int srNo = 1;
                        foreach (var t in group)
                        {
                            var order = new salesorder()
                            {
                                SrNo = srNo.ToString(),
                                SoldTo = t.SoldTo,
                                SoldToCode = t.CustomerNameSoldTo,
                                DCPINo = t.DcpiNo,
                                DCPIDate = t.DcpiDt,
                                Material = t.Material,
                                Qty = t.Qty?.ToString(),
                                UOM = t.Uom,
                                Amt = t.BasicAmount?.ToString(),
                                Tax = t.Tax?.ToString(),
                                TotalAmt = t.TotalAmountPayable?.ToString(),
                                Plant = t.SourcePlant,
                                Transporter = t.TransportName,
                                LRNo = t.LorryReceiptNo,
                                TruckNo = t.TruckNo,
                                ExciseInv = t.GstInvoice,
                                OrderNo = t.OrderNo,
                                ShipToCode = t.ShipTo,
                                ShipTo = t.CustomerNameShipTo,
                                Payer = decimal.TryParse(t.Payer, out decimal payerVal) ? payerVal : (decimal?)null,
                                Grade = t.BatchNo,
                                InstrumentNumber = t.PmtMethod, // Not available in DispatchOrdersModel
                                PermitNo = "", // Not available in DispatchOrdersModel
                                PayTerm = t.PmtTerms,
                                PONO = t.PoNumber,
                                PODate = t.PoDate,
                                FrieghtInvoice = t.QsplInvoice,
                                FrieghtAmount = t.QsplAmt?.ToString(),
                                SORNO = "", // Not available
                                SORDutyAmt = t.SorAmt?.ToString(),
                                SORDate = t.SorDate,
                                Orderflag = false,
                                OrderDate = t.OrderDt,
                                ReqDelDt = "", // Not available
                                OrderStatus = t.QualityStatus,
                                BillTo = t.CustomerNameBillTo,
                                TransportBy = t.TransportName,
                                RetailInvoice = t.GstInvoice
                            };

                            orders.Add(order);
                            srNo++;
                        }
                    }

                    context.salesorders.AddRange(orders);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
