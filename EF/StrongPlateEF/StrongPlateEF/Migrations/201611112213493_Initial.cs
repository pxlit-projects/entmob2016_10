namespace StrongPlateEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "AverageSpeed");
            DropColumn("dbo.Employees", "AverageSteadyness");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "AverageSteadyness", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "AverageSpeed", c => c.Double(nullable: false));
        }
    }
}
