//-----------------------------------------------------------------------
// <copyright file="StoreController.cs" company="GAP">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace GAP.TechnicalTest.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using Utilities;

    /// <summary>
    /// Store controller.
    /// </summary>
    public class StoreController : ApiController
    {
		/// <summary>
		/// The db.
		/// </summary>
        private Context db = new Context();

		#region Methods
		/// <summary>
		/// Gets all stores.
		/// </summary>
		/// <returns>The all stores.</returns>
		[System.Web.Http.HttpGet]
		public HttpResponseMessage GetAllStores()
		{
            var result = new StoreApiCollection();

            try
            {
                List<Store> stores = db.Stores.ToList();

                result.Stores = stores;
                result.Success = "true";
                result.Total_Elments = stores.Count;
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing GetEmployee");
            }

            return Request.CreateResponse(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
		public Store Get(int id)
		{
			Store store = db.Stores.Find(id);

			if (store == null)
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
			}

			return store;
		}

		/// <summary>
		/// Post the specified store.
		/// </summary>
		/// <returns>The post.</returns>
		/// <param name="store">Store.</param>
        [System.Web.Http.HttpPost]
        [System.Web.Http.AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Post(Store store)
		{
			if (ModelState.IsValid)
			{
				db.Stores.Add(store);
				db.SaveChanges();

				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, store);

				response.Headers.Location = new Uri(Url.Link("DeafultApi", new { id = store.StoreId }));

				return response;
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
		}

		/// <summary>
		/// Put the specified id and store.
		/// </summary>
		/// <returns>The put.</returns>
		/// <param name="id">Identifier.</param>
		/// <param name="store">Store.</param>
        [System.Web.Http.HttpPut]
        [System.Web.Http.AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Put(int id, Store store)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

			if (id != store.StoreId)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}

			db.Entry(store).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException cEx)
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, cEx);
			}
			catch (Exception ex)
			{
				throw new Exception("The following error was launch " + ex);
			}

			return Request.CreateResponse(HttpStatusCode.OK);
		}

		/// <summary>
		/// Delete the specified id.
		/// </summary>
		/// <returns>The delete.</returns>
		/// <param name="id">Identifier.</param>
        [System.Web.Http.HttpDelete]
        [System.Web.Http.AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Delete(int id)
		{
			Store store = db.Stores.Find(id);

			if (store == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.Stores.Remove(store);

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException cEx)
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, cEx);
			}
			catch (Exception ex)
			{
				throw new Exception("The following error was launch " + ex);
			}

			return Request.CreateResponse(HttpStatusCode.OK, store);
		}
		#endregion

	}
}
