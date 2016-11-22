namespace StrongPlateEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpeedAndSteadyness : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Speed", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "Steadyness", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Steadyness");
            DropColumn("dbo.Employees", "Speed");
        }
    }
}
