using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GAP.TechnicalTest.API.Utilities;
using GAP.TechnicalTest.API.Controllers;
using GAP.TechnicalTest.API;

namespace GAP.TechnicalTest.UnitTests.Controllers
{
    [TestClass]
    public class ArticleControllerTest
    {
        [TestMethod]
        public void GetAllArticles_TestMethod()
        {
            var response = new ArticleApiCollection();

            var testArticle = GetAllArticles();
            var controller = new ArticleController();
            var result = controller.GetAllArticles();

            response.Articles = testArticle;
            response.Success = "true";
            response.Total_Elments = testArticle.Count;

            Assert.AreEqual(response, result);
        }

        private List<Article> GetAllArticles()
        {

            List<Article> testArticle = new List<Article>();
            testArticle.Add(new Article
            {
                ArticleId = 1,
                Name = "Green Shoes",
                Description = "The best quality of shoes in a gree color",
                Price = Decimal.Parse("20.15"),
                TotalInShelf = Decimal.Parse("25"),
                TotalInVault = Decimal.Parse("40"),
                StoreId = 1
            });
            testArticle.Add(new Article
            {
                ArticleId = 2,
                Name = "Red Shoes",
                Description = "The best quality of shoes in a red color",
                Price = Decimal.Parse("20.15"),
                TotalInShelf = Decimal.Parse("25"),
                TotalInVault = Decimal.Parse("40"),
                StoreId = 1
            });

            return testArticle;
        }
    }
}