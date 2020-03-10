namespace Resturant_os.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFoodTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.FoodTypes",
               c => new
               {
                   FoodTypeId = c.Int(nullable: false, identity: true),
                   FoodTypeName = c.String(nullable: false),
                   MenuId = c.Int(nullable: true),
                   Updated = c.DateTime(nullable: false),
                   Created = c.DateTime(nullable: false)
               })
               .PrimaryKey(t => t.FoodTypeId);
        }
        
        public override void Down()
        {
            DropTable("dbo.FoodTypes");
        }
    }
}
