namespace Resturant_os.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrderTypesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderTypes",
               c => new
               {
                   OrderTypeId = c.Int(nullable: false, identity: true),
                   OrderTypeName = c.String(nullable: false),
                   Updated = c.DateTime(nullable: false),
                   Created = c.DateTime(nullable: false)
               })
               .PrimaryKey(t => t.OrderTypeId);
        }

        public override void Down()
        {
            DropTable("OrderTypes");
        }
    }
}
