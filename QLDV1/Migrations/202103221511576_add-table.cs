namespace QLDV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiDoans",
                c => new
                    {
                        macd = c.String(nullable: false, maxLength: 128),
                        tencd = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.macd);
            
            CreateTable(
                "dbo.DoanViens",
                c => new
                    {
                        madv = c.String(nullable: false, maxLength: 128),
                        tendv = c.String(nullable: false, maxLength: 50),
                        ns = c.DateTime(nullable: false),
                        gioitinh = c.String(nullable: false),
                        quequan = c.String(nullable: false),
                        ngayvd = c.DateTime(nullable: false),
                        dantoc = c.String(nullable: false),
                        macd = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.madv)
                .ForeignKey("dbo.ChiDoans", t => t.macd)
                .Index(t => t.macd);
            
            CreateTable(
                "dbo.DiemDanhs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        madv = c.String(nullable: false, maxLength: 128),
                        mahd = c.Int(nullable: false),
                        ghichu = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DoanViens", t => t.madv, cascadeDelete: true)
                .ForeignKey("dbo.HoatDongs", t => t.mahd, cascadeDelete: true)
                .Index(t => t.madv)
                .Index(t => t.mahd);
            
            CreateTable(
                "dbo.HoatDongs",
                c => new
                    {
                        mahd = c.Int(nullable: false, identity: true),
                        tenhd = c.String(nullable: false),
                        thoigiantc = c.DateTime(nullable: false),
                        ghichu = c.String(),
                    })
                .PrimaryKey(t => t.mahd);
            
            CreateTable(
                "dbo.KhenThuongs",
                c => new
                    {
                        makt = c.Int(nullable: false, identity: true),
                        tenkt = c.String(nullable: false),
                        madv = c.String(nullable: false, maxLength: 128),
                        thanhtich = c.String(nullable: false),
                        namhoc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.makt)
                .ForeignKey("dbo.DoanViens", t => t.madv, cascadeDelete: true)
                .Index(t => t.madv);
            
            CreateTable(
                "dbo.XepLoais",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        madv = c.String(nullable: false, maxLength: 128),
                        namhoc = c.Int(nullable: false),
                        nhanxet = c.String(),
                        xeploai = c.String(nullable: false),
                        mahd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DoanViens", t => t.madv, cascadeDelete: true)
                .ForeignKey("dbo.HoatDongs", t => t.mahd, cascadeDelete: true)
                .Index(t => t.madv)
                .Index(t => t.mahd);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.XepLoais", "mahd", "dbo.HoatDongs");
            DropForeignKey("dbo.XepLoais", "madv", "dbo.DoanViens");
            DropForeignKey("dbo.KhenThuongs", "madv", "dbo.DoanViens");
            DropForeignKey("dbo.DiemDanhs", "mahd", "dbo.HoatDongs");
            DropForeignKey("dbo.DiemDanhs", "madv", "dbo.DoanViens");
            DropForeignKey("dbo.DoanViens", "macd", "dbo.ChiDoans");
            DropIndex("dbo.XepLoais", new[] { "mahd" });
            DropIndex("dbo.XepLoais", new[] { "madv" });
            DropIndex("dbo.KhenThuongs", new[] { "madv" });
            DropIndex("dbo.DiemDanhs", new[] { "mahd" });
            DropIndex("dbo.DiemDanhs", new[] { "madv" });
            DropIndex("dbo.DoanViens", new[] { "macd" });
            DropTable("dbo.XepLoais");
            DropTable("dbo.KhenThuongs");
            DropTable("dbo.HoatDongs");
            DropTable("dbo.DiemDanhs");
            DropTable("dbo.DoanViens");
            DropTable("dbo.ChiDoans");
        }
    }
}
