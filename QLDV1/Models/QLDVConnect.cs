using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLDV1.Models
{
    public partial class QLDVConnect : DbContext
    {
        public virtual DbSet<ChiDoan> ChiDoans { get; set; }
        public virtual DbSet<DoanVien> DoanViens { get; set; }
        public virtual DbSet<HoatDong> HoatDongs { get; set; }
        public virtual DbSet<XepLoai> XepLoais { get; set; }
        public virtual DbSet<DiemDanh> DiemDanhs { get; set; }
        public virtual DbSet<KhenThuong> KhenThuongs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<AccountModel> AccountModels { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public QLDVConnect()
            : base("name=QLDVConnect")
        {
        
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        
    }
}
