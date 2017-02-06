//-----------------------------------------------------------------------
// <copyright file="ArticleController.cs" company="GAP">
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
    using System.Web.Http;
    using Utilities;

    [RoutePrefix("articles")]
    public class ArticleController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
		private Context db = new Context();

		#region Methods
		/// <summary>
		/// Gets all articles.
		/// </summary>
		/// <returns>The all articles.</returns>
		[System.Web.Http.HttpGet]
		public HttpResponseMessage GetAllArticles()
		{
            var result = new ArticleApiCollection();

            try
            {
                List<Article> articles = db.Articles.ToList();

                result.Articles = articles;
                result.Success = "true";
                result.Total_Elments = articles.Count;
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing GetEmployee");
            }

            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Get the articles filtered by storeid.
        /// </summary>
        /// <param name="storeId">Id of the store.</param>
        /// <returns>Articles by store</returns>
        [ActionName("stores")]
        public HttpResponseMessage GetArticlesByStore(int storeId)
        {
            var result = new ArticleApiCollection();

            try
            {
                List<Article> article = db.Articles.Where(o => o.StoreId == storeId).ToList();

                int numArticles = article.Count;

                switch (numArticles)
                {
                    case 0:
                        result.Success = "false";
                        result.Error_Msg = HttpStatusCode.NotFound.ToString();
                        result.Error_Code = "404";
                        break;
                    case 1:
                        result.Article = article;
                        result.Success = "true";
                        break;
                    default:
                        result.Articles = article;
                        result.Success = "true";
                        result.Total_Elments = article.Count;
                        break;
                }
            }
            catch (Exception)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing GetEmployee");
            }
            
            return Request.CreateResponse(result);
        }

		/// <summary>
		/// Get the article by id.
		/// </summary>
		/// <returns>The article by his id.</returns>
		/// <param name="id">Id of the article.</param>
		public Article Get(int id)
		{
			Article article = db.Articles.Find(id);
			if (article == null)
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
			}

			return article;
		}

		/// <summary>
		/// Post the specified article.
		/// </summary>
		/// <returns>The post.</returns>
		/// <param name="article">Article.</param>
		public HttpResponseMessage Post(Article article)
		{
			if (ModelState.IsValid)
			{
				db.Articles.Add(article);
				db.SaveChanges();

				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, article);

				response.Headers.Location = new Uri(Url.Link("DeafultApi", new { id = article.ArticleId }));

				return response;
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
		}

		/// <summary>
		/// Put the specified id and article.
		/// </summary>
		/// <returns>The put.</returns>
		/// <param name="id">Identifier.</param>
		/// <param name="article">Article.</param>
		public HttpResponseMessage Put(int id, Article article)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

			if (id != article.ArticleId)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}

			db.Entry(article).State = EntityState.Modified;

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
		public HttpResponseMessage Delete(int id)
		{
			Article article = db.Articles.Find(id);

			if (article == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.Articles.Remove(article);

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

			return Request.CreateResponse(HttpStatusCode.OK, article);
		}
		#endregion

	}
}
