using System;
using System.Data.Entity.Migrations;

namespace GAP.TechnicalTest.API
{
	internal sealed class Configuration : DbMigrationsConfiguration<Context>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			ContextKey = "Context";
            this.CommandTimeout = 60 * 5;
        }

		protected override void Seed(Context context)
		{
			context.Articles.AddOrUpdate(x => x.ArticleId,
			                             new Article { 
											Name = "green shoes",
                                            Description = "The best quality of shoes in a green color", 
											Price = Decimal.Parse("20.15"),
                                            TotalInShelf = Decimal.Parse("25"),
                                            TotalInVault = Decimal.Parse("40")
										}, 
                                         new Article
                                         {
                                             Name = "white shoes",
                                             Description = "The best quality of shoes in a white color",
                                             Price = Decimal.Parse("30.15"),
                                             TotalInShelf = Decimal.Parse("35"),
                                             TotalInVault = Decimal.Parse("50")
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
