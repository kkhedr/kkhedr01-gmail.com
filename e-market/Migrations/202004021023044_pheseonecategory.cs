namespace e_market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pheseonecategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_id" });
            
            AlterColumn("dbo.Products", "Category_id", c => c.Int(nullable: false));
            
            
        }
        
        public override void Down()
        {
            
            
            AlterColumn("dbo.Products", "Category_id", c => c.Int());
            
            CreateIndex("dbo.Products", "Category_id");
            AddForeignKey("dbo.Products", "Category_id", "dbo.Categories", "id");
        }
    }
}
