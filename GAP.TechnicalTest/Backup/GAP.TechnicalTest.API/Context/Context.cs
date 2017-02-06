using System;
using System.Data.Entity;

namespace GAP.TechnicalTest.API
{
	/// <summary>
	/// Context.
	/// </summary>
	public class Context : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:GAP.TechnicalTest.API.Context"/> class.
		/// </summary>
		public Context() : base("name=SuperShoesDBConnection")
		{
			
		}
		/// <summary>
		/// Gets or sets the articles.
		/// </summary>
		/// <value>The articles.</value>
		public DbSet<Article> Articles { get; set; }
		/// <summary>
		/// Gets or sets the stores.
		/// </summary>
		/// <value>The stores.</value>
		public DbSet<Store> Stores { get; set; }

	}
}
