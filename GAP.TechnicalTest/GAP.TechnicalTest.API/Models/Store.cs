using System;
using System.ComponentModel.DataAnnotations;

namespace GAP.TechnicalTest.API
{
	/// <summary>
	/// Store.
	/// </summary>
	public class Store
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:GAP.TechnicalTest.API.Store"/> class.
		/// </summary>
		public Store()
		{
		}

		#region Properties

		/// <summary>
		/// Gets or sets the store identifier.
		/// </summary>
		/// <value>The store identifier.</value>
		public int StoreId { get; set; }
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[Required]
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		/// <value>The address.</value>
		[Required]
		public string Address { get; set; }

		#endregion
	}
}
