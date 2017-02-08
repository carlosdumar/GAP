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
                                             Image = "https://n1.sdlcdn.com/imgs/a/3/q/Puma-Drongos-Black-Casual-Shoes-SDL443719751-1-282eb.jpg"
                                         },
                                         new Article
                                         {
                                             Name = "white shoes",
                                             Description = "The best quality of shoes in a white color",
                                             Price = Decimal.Parse("30.15"),
                                             TotalInShelf = Decimal.Parse("35"),
                                             TotalInVault = Decimal.Parse("50"),
                                             Image = "http://fionabella.com/demoshop/wp-content/uploads/2016/04/nike.png"
                                         },
                                         new Article
                                         {
                                             Name = "blac shoes",
                                             Description = "The best quality of shoes in a white color",
                                             Price = Decimal.Parse("30.15"),
                                             TotalInShelf = Decimal.Parse("35"),
                                             TotalInVault = Decimal.Parse("50"),
                                             Image = "http://m.champssports.com/images/products/zoom/19175101_z.jpg"
                                         },
                                         new Article
                                         {
                                             Name = "red shoes",
                                             Description = "The best quality of shoes in a white color",
                                             Price = Decimal.Parse("30.15"),
                                             TotalInShelf = Decimal.Parse("35"),
                                             TotalInVault = Decimal.Parse("50"),
                                             Image = "https://s-media-cache-ak0.pinimg.com/236x/30/79/b4/3079b409e89b7074e93ee13d5831636e.jpg"
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
