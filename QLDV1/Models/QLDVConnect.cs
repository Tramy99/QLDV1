using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLDV1.Models
{
    public partial class QLDVConnect : DbContext
    {
        public DbSet<ChiDoan> ChiDoans { get; set; }
        public DbSet<DoanVien> DoanViens { get; set; }
        public DbSet<HoatDong> HoatDongs { get; set; }
        public DbSet<XepLoai> XepLoais { get; set; }
        public DbSet<DiemDanh> DiemDanhs { get; set; }
        public DbSet<KhenThuong> KhenThuongs { get; set; }
        public QLDVConnect()
            : base("name=QLDVConnect")
        {
        
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<QLDV1.Models.AccountModel> AccountModels { get; set; }

        public System.Data.Entity.DbSet<QLDV1.Models.TinTuc> TinTucs { get; set; }
    }
}
