namespace GAP.TechnicalTest.API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GAP.TechnicalTest.API.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            this.CommandTimeout = 60 * 5;
        }

        protected override void Seed(GAP.TechnicalTest.API.Context context)
        {
            context.Articles.AddOrUpdate(x => x.ArticleId,
                                         new Article
                                         {
                                             Name = "green shoes",
                                             Description = "The best quality of shoes in a green color",
                                             Price = Decimal.Parse("20.15"),
                                             TotalInShelf = Decimal.Parse("25"),
                                             TotalInVault = Decimal.Parse("40"),
                                             Image = ""
                                         },
                                         new Article
                                         {
                                             Name = "white shoes",
                                             Description = "The best quality of shoes in a white color",
                                             Price = Decimal.Parse("30.15"),
                                             TotalInShelf = Decimal.Parse("35"),
                                             TotalInVault = Decimal.Parse("50"),
                                             Image = ""
                                         }
            );
            context.Stores.AddOrUpdate(x => x.StoreId,
                                       new Store
                                       {
                                           Name = "Super Store",
                                           Address = "Somewhere over the rainbow"
                                       }
                                      );
        }
    }
}
