namespace QLDV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chang_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountModels", "Role_id", c => c.Int(nullable: false));
            CreateIndex("dbo.AccountModels", "Role_id");
            AddForeignKey("dbo.AccountModels", "Role_id", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountModels", "Role_id", "dbo.Roles");
            DropIndex("dbo.AccountModels", new[] { "Role_id" });
            DropColumn("dbo.AccountModels", "Role_id");
        }
    }
}
