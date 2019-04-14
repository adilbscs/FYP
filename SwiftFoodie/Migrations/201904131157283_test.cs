namespace SwiftFoodie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmployeeNo = c.String(),
                        Designation = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Role = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ShiftTiming = c.Int(nullable: false),
                        UserPic = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
