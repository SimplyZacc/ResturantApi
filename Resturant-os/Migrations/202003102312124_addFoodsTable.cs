namespace Resturant_os.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFoodsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Foods",
               c => new
               {
                   FoodId = c.Int(nullable: false, identity: true),
                   FoodName = c.String(nullable: false),
                   FoodDescription = c.String(nullable: true),
                   FoodPrice = c.Double(nullable: true),
                   FoodTypeId = c.Int(nullable: false),
                   Updated = c.DateTime(nullable: false),
                   Created = c.DateTime(nullable: false)
               })
               .PrimaryKey(t => t.FoodId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Foods");
        }
    }
}
