//-----------------------------------------------------------------------
// <copyright file="Article.cs" company="GAP">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace GAP.TechnicalTest.API
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// 
	/// </summary>
	public class Article
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		/// <value>The article identifier.</value>
		public int ArticleId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		/// <value>The name.</value>
		[Required]
		public string Name { get; set; }
		/// <summary>
		/// 
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }
		/// <summary>
		/// 
		/// </summary>
		/// <value>The price.</value>
		[Required]
		public decimal Price { get; set; }
		/// <summary>
		/// 
		/// </summary>
		/// <value>The total in shelf.</value>
		[Required]
		public decimal TotalInShelf { get; set; }
		/// <summary>
		/// 
		/// </summary>
		/// <value>The total in vault.</value>
		[Required]
		public decimal TotalInVault { get; set; }

		// Foreign key for store
		public int StoreId { get; set; }
		// Navigation property
		public Store Store { get; set; }

		#endregion

	}
}
