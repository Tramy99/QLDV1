namespace QLDV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TinTucs",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        tieude = c.String(),
                        mota = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TinTucs");
        }
    }
}
