namespace StrongPlateEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnNames : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Speed", newName: "AverageSpeed");
            RenameColumn(table: "dbo.Employees", name: "Steadyness", newName: "AverageSteadyness");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Employees", name: "AverageSpeed", newName: "Speed");
            RenameColumn(table: "dbo.Employees", name: "AverageSteadyness", newName: "Steadyness");
        }
    }
}
