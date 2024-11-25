namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTask1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeTasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        EmployeeCode = c.String(),
                        TaskName = c.String(nullable: false),
                        TaskStatus = c.String(nullable: false),
                        TaskDescription = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastUpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeTasks");
        }
    }
}
