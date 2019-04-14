namespace SwiftFoodie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuID = c.Long(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemCategory = c.String(),
                        ItemPrice = c.Long(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Long(nullable: false, identity: true),
                        CustomerID = c.Long(nullable: false),
                        Location = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        MenuID = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
            DropTable("dbo.Menu");
        }
    }
}
