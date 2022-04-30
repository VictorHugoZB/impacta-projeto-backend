﻿namespace EmpDepApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "PathImagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "PathImagem", c => c.String());
        }
    }
}
