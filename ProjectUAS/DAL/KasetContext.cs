using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUAS.DAL
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    public partial class kasetContext : DbContext
    {
        public kasetContext()
            : base("name=kasetContext")
        {
        }

        public virtual DbSet<Kaset> Kasets { get; set; }
        public virtual DbSet<Pembatalan> Pembatalans { get; set; }
        public virtual DbSet<Pembelian> Pembelians { get; set; }
        public virtual DbSet<Pemesanan> Pemesanans { get; set; }
        public virtual DbSet<Peminjaman> Peminjamen { get; set; }
        public virtual DbSet<Pengembalian> Pengembalians { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<kasetContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}