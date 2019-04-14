namespace SwiftFoodie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.Long(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        OwnerName = c.String(),
                        PhoneNumber = c.String(),
                        City = c.String(),
                        CompleteAddress = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurants");
        }
    }
}
