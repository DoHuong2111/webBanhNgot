namespace Web_banh_ngot.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BanhNgotModelData : DbContext
    {
        public BanhNgotModelData()
            : base("name=BanhNgotModelData")
        {
        }

        public virtual DbSet<BILL> BILLs { get; set; }
        public virtual DbSet<BILL_DETAIL> BILL_DETAIL { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<PHOTO> Photos { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<TYPE_PRODUCT> TYPE_PRODUCT { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BILL_DETAIL>()
                .Property(e => e.PRICE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.PHONE_CUS)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRICE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRICE_OLD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<USER>()
                .Property(e => e.PASSWORD_)
                .IsUnicode(false);
        }
    }
}
