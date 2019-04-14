namespace SwiftFoodie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "MenuID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "MenuID", c => c.String());
        }
    }
}
