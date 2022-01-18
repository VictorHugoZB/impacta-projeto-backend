namespace EmpDepApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class again : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Departmento_DepartamentId", "dbo.Departments");
            DropPrimaryKey("dbo.Departments");
            DropColumn("dbo.Departments", "DepartamentId");
            RenameColumn(table: "dbo.Employees", name: "Departmento_DepartamentId", newName: "Departmento_DepartamentoId");
            RenameIndex(table: "dbo.Employees", name: "IX_Departmento_DepartamentId", newName: "IX_Departmento_DepartamentoId");
            AddColumn("dbo.Departments", "DepartamentoId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Departments", "DepartamentoId");
            AddForeignKey("dbo.Employees", "Departmento_DepartamentoId", "dbo.Departments", "DepartamentoId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "DepartamentId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Employees", "Departmento_DepartamentoId", "dbo.Departments");
            DropPrimaryKey("dbo.Departments");
            DropColumn("dbo.Departments", "DepartamentoId");
            AddPrimaryKey("dbo.Departments", "DepartamentId");
            RenameIndex(table: "dbo.Employees", name: "IX_Departmento_DepartamentoId", newName: "IX_Departmento_DepartamentId");
            RenameColumn(table: "dbo.Employees", name: "Departmento_DepartamentoId", newName: "Departmento_DepartamentId");
            AddForeignKey("dbo.Employees", "Departmento_DepartamentId", "dbo.Departments", "DepartamentId", cascadeDelete: true);
        }
    }
}
