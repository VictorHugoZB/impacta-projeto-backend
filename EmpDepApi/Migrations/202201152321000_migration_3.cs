namespace EmpDepApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Departmento_DepartamentoId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Departmento_DepartamentoId" });
            AddColumn("dbo.Employees", "DepartmentoId", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "Departmento_DepartamentoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Departmento_DepartamentoId", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "DepartmentoId");
            CreateIndex("dbo.Employees", "Departmento_DepartamentoId");
            AddForeignKey("dbo.Employees", "Departmento_DepartamentoId", "dbo.Departments", "DepartamentoId", cascadeDelete: true);
        }
    }
}
