namespace Resturant_os.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrdersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
               c => new
               {
                   OrderId = c.Int(nullable: false, identity: true),
                   OrderTypeId = c.Int(nullable: false),
                   Updated = c.DateTime(nullable: false),
                   Created = c.DateTime(nullable: false)
               })
               .PrimaryKey(t => t.OrderId);
        }
        
        public override void Down()
        {
            DropTable("Orders");
        }
    }
}
