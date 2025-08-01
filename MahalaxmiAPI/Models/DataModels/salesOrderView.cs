namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("salesOrderView")]
    public partial class salesOrderView
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [StringLength(50)]
        public string SrNo { get; set; }

        [StringLength(1000)]
        public string SoldToCode { get; set; }

        [StringLength(50)]
        public string SoldTo { get; set; }

        [StringLength(50)]
        public string DCPINo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Expr1 { get; set; }

        [StringLength(50)]
        public string Material { get; set; }

        [StringLength(50)]
        public string Qty { get; set; }

        [StringLength(50)]
        public string UOM { get; set; }

        [StringLength(50)]
        public string Amt { get; set; }

        [StringLength(50)]
        public string Tax { get; set; }

        [StringLength(50)]
        public string TotalAmt { get; set; }

        [StringLength(50)]
        public string Plant { get; set; }

        [StringLength(1000)]
        public string Transporter { get; set; }

        [StringLength(50)]
        public string LRNo { get; set; }

        [StringLength(50)]
        public string TruckNo { get; set; }

        [StringLength(50)]
        public string ExciseInv { get; set; }

        [StringLength(50)]
        public string OrderNo { get; set; }

        [StringLength(50)]
        public string ShipToCode { get; set; }

        [StringLength(50)]
        public string ShipTo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Payer { get; set; }

        [StringLength(50)]
        public string Grade { get; set; }

        [StringLength(50)]
        public string InstrumentNumber { get; set; }

        [StringLength(50)]
        public string PermitNo { get; set; }

        [StringLength(50)]
        public string PayTerm { get; set; }

        [StringLength(50)]
        public string PONO { get; set; }

        [StringLength(50)]
        public string PODate { get; set; }

        [StringLength(50)]
        public string FrieghtInvoice { get; set; }

        [StringLength(50)]
        public string FrieghtAmount { get; set; }

        [StringLength(50)]
        public string SORNO { get; set; }

        [StringLength(50)]
        public string SORDutyAmt { get; set; }

        [StringLength(50)]
        public string SORDate { get; set; }

        public bool? Orderflag { get; set; }

        [StringLength(100)]
        public string OrderDate { get; set; }

        [StringLength(100)]
        public string ReqDelDt { get; set; }

        [StringLength(100)]
        public string OrderStatus { get; set; }

        [StringLength(500)]
        public string BillTo { get; set; }

        [StringLength(500)]
        public string TransportBy { get; set; }

        [StringLength(50)]
        public string RetailInvoice { get; set; }
    }
}
