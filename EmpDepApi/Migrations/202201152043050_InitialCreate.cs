namespace EmpDepApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartamentId = c.Int(nullable: false, identity: true),
                        Departamento = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartamentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DataContratacao = c.String(nullable: false),
                        PathImagem = c.String(),
                        Departmento_DepartamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.Departmento_DepartamentId, cascadeDelete: true)
                .Index(t => t.Departmento_DepartamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Departmento_DepartamentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Departmento_DepartamentId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
