namespace GAP.TechnicalTest.API
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalInShelf = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalInVault = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "StoreId", "dbo.Stores");
            DropIndex("dbo.Articles", new[] { "StoreId" });
            DropTable("dbo.Stores");
            DropTable("dbo.Articles");
        }
    }
}
