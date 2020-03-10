namespace Resturant_os.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addResturantTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Resutrants",
               c => new
               {
                   ResutrantId = c.Int(nullable: false, identity: true),
                   ResturantName = c.String(nullable: false),
                   Address = c.String(nullable: true),
                   PhoneNo = c.String(nullable: true),
                   Updated = c.DateTime(nullable: false),
                   Created = c.DateTime(nullable: false)
               })
               .PrimaryKey(t => t.ResutrantId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Resutrants");
        }
    }
}
