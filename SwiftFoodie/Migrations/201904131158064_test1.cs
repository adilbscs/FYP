namespace SwiftFoodie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "EmployeeNo");
            DropColumn("dbo.Users", "Designation");
            DropColumn("dbo.Users", "ShiftTiming");
            DropColumn("dbo.Users", "UserPic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserPic", c => c.String());
            AddColumn("dbo.Users", "ShiftTiming", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Designation", c => c.String());
            AddColumn("dbo.Users", "EmployeeNo", c => c.String());
        }
    }
}
