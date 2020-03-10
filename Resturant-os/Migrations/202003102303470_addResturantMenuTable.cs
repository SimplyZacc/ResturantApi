namespace Resturant_os.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addResturantMenuTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.ResutrantMenus",
               c => new
               {
                   ResutrantMenuId = c.Int(nullable: false, identity: true),
                   ResturantMenuName = c.String(nullable: false),
                   Updated = c.DateTime(nullable: false),
                   Created = c.DateTime(nullable: false)
               })
               .PrimaryKey(t => t.ResutrantMenuId);
        }
        
        public override void Down()
        {
            DropTable("dbo.ResutrantMenus");
        }
    }
}
