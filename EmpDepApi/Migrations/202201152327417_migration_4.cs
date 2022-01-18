namespace EmpDepApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Departamento", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "DepartmentoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "DepartmentoId", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "Departamento");
        }
    }
}
