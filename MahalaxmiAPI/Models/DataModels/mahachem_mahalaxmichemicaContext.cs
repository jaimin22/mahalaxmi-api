namespace MahalaxmiAPI.Models.DataModels
{
    using System.Data.Entity;

    public partial class mahachem_mahalaxmichemicaContext : DbContext
    {
        public mahachem_mahalaxmichemicaContext()
            : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<ContractStatu> ContractStatus { get; set; }
        public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }
        public virtual DbSet<CustomerUserMapping> CustomerUserMappings { get; set; }
        public virtual DbSet<Favriote> Favriotes { get; set; }
        public virtual DbSet<Favriote1> Favriote1 { get; set; }
        public virtual DbSet<MyOrder> MyOrders { get; set; }
        public virtual DbSet<MyPlanning> MyPlannings { get; set; }
        public virtual DbSet<PE_Deemed> PE_Deemed { get; set; }
        public virtual DbSet<PE_Deemed1> PE_Deemed1 { get; set; }
        public virtual DbSet<PE_Depot> PE_Depot { get; set; }
        public virtual DbSet<PE_Plant> PE_Plant { get; set; }
        public virtual DbSet<PP_Deemed> PP_Deemed { get; set; }
        public virtual DbSet<PP_Depot> PP_Depot { get; set; }
        public virtual DbSet<PP_Plant> PP_Plant { get; set; }
        public virtual DbSet<PVC_Deemed> PVC_Deemed { get; set; }
        public virtual DbSet<PVC_Depot> PVC_Depot { get; set; }
        public virtual DbSet<PVC_Plant> PVC_Plant { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<UserProfileDetail> UserProfileDetails { get; set; }
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<cm> cms { get; set; }
        public virtual DbSet<contentpage> contentpages { get; set; }
        public virtual DbSet<emailformate> emailformates { get; set; }
        public virtual DbSet<pdffile> pdffiles { get; set; }
        public virtual DbSet<PE_Depot1> PE_Depot1 { get; set; }
        public virtual DbSet<PE_Plant1> PE_Plant1 { get; set; }
        public virtual DbSet<polymer> polymers { get; set; }
        public virtual DbSet<PP_Deemed1> PP_Deemed1 { get; set; }
        public virtual DbSet<PP_Depot1> PP_Depot1 { get; set; }
        public virtual DbSet<PP_Plant1> PP_Plant1 { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<productMember> productMembers { get; set; }
        public virtual DbSet<salesent> salesents { get; set; }
        public virtual DbSet<salesorder> salesorders { get; set; }
        public virtual DbSet<salesOrderView> salesOrderViews { get; set; }
        public virtual DbSet<UserAndCompanyDetailsView> UserAndCompanyDetailsViews { get; set; }
        public virtual DbSet<UserCustomerMappingView> UserCustomerMappingViews { get; set; }
        public virtual DbSet<AppVersion> AppVersions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.profileid)
                .IsUnicode(false);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.studyyear)
                .IsUnicode(false);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.langstudies)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.phoneno)
                .IsUnicode(false);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.degree)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.major)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.countryid)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.University)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.phonecode)
                .IsUnicode(false);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.secretcode)
                .IsUnicode(false);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.cname)
                .IsUnicode(false);

            modelBuilder.Entity<UserMaster>()
                .Property(e => e.nickname)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.admin_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<admin>()
                .Property(e => e.administrator_name)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.admin_password)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.admin_type)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.admin_email)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<category>()
                .Property(e => e.parentid)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cm>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cm>()
                .Property(e => e.video)
                .IsUnicode(false);

            modelBuilder.Entity<contentpage>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<contentpage>()
                .Property(e => e.topimage)
                .IsUnicode(false);

            modelBuilder.Entity<emailformate>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<pdffile>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<pdffile>()
                .Property(e => e.topimage)
                .IsUnicode(false);

            modelBuilder.Entity<pdffile>()
                .Property(e => e.productname)
                .IsUnicode(false);

            modelBuilder.Entity<polymer>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<polymer>()
                .Property(e => e.morder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<polymer>()
                .Property(e => e.topimage)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<product>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.product_code)
                .IsUnicode(false);

            modelBuilder.Entity<productMember>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<productMember>()
                .Property(e => e.productid)
                .HasPrecision(18, 0);

            modelBuilder.Entity<productMember>()
                .Property(e => e.userid)
                .HasPrecision(18, 0);

            modelBuilder.Entity<productMember>()
                .Property(e => e.product_code)
                .IsUnicode(false);

            modelBuilder.Entity<productMember>()
                .Property(e => e.payerid)
                .IsUnicode(false);

            modelBuilder.Entity<salesent>()
                .Property(e => e.admin_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.SrNo)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.SoldToCode)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.SoldTo)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.DCPINo)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.DCPIDate)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.Material)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.Qty)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.UOM)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.Amt)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.Tax)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.TotalAmt)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.Plant)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.Transporter)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.LRNo)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.TruckNo)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.ExciseInv)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.OrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.ShipToCode)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.ShipTo)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.Payer)
                .HasPrecision(18, 0);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.Grade)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.InstrumentNumber)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.PermitNo)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.PayTerm)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.PONO)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.PODate)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.FrieghtInvoice)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.FrieghtAmount)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.SORNO)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.SORDutyAmt)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.SORDate)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.OrderDate)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.ReqDelDt)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.OrderStatus)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.BillTo)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.TransportBy)
                .IsUnicode(false);

            modelBuilder.Entity<salesorder>()
                .Property(e => e.RetailInvoice)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.SrNo)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.SoldToCode)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.SoldTo)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.DCPINo)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.Material)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.Qty)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.UOM)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.Amt)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.Tax)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.TotalAmt)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.Plant)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.Transporter)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.LRNo)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.TruckNo)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.ExciseInv)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.OrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.ShipToCode)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.ShipTo)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.Payer)
                .HasPrecision(18, 0);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.Grade)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.InstrumentNumber)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.PermitNo)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.PayTerm)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.PONO)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.PODate)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.FrieghtInvoice)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.FrieghtAmount)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.SORNO)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.SORDutyAmt)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.SORDate)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.OrderDate)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.ReqDelDt)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.OrderStatus)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.BillTo)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.TransportBy)
                .IsUnicode(false);

            modelBuilder.Entity<salesOrderView>()
                .Property(e => e.RetailInvoice)
                .IsUnicode(false);
        }
    }
}
