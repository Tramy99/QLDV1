namespace QLDV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Column_XepLoai_PhanLoai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.XepLoais", "phanloai", c => c.String(nullable: false));
            DropColumn("dbo.XepLoais", "xeploai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.XepLoais", "xeploai", c => c.String(nullable: false));
            DropColumn("dbo.XepLoais", "phanloai");
        }
    }
}
