namespace e_market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forignnkeycreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_id" });
            AlterColumn("dbo.Products", "Category_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_id");
            AddForeignKey("dbo.Products", "Category_id", "dbo.Categories", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_id" });
            AlterColumn("dbo.Products", "Category_id", c => c.Int());
            CreateIndex("dbo.Products", "Category_id");
            AddForeignKey("dbo.Products", "Category_id", "dbo.Categories", "id");
        }
    }
}
