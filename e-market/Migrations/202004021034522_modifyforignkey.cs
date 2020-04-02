namespace e_market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyforignkey : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "Category_id" });
            
            RenameColumn(table: "dbo.Products", name: "Category_id", newName: "Category_id");
            
        }
        
        public override void Down()
        {
            
            
            RenameColumn(table: "dbo.Products", name: "Category_id", newName: "Category_id");
            AddColumn("dbo.Products", "Category_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_id");
        }
    }
}
