using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Controllers;
using InternetShop.Domain;
using InternetShop.Domain.Repositories;

namespace UnitTestApp
{
    public class ProductDetailControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void IndexViewBagMessageTest()
        //{
        //    // Arrange
        //    IStoreRepository repo = new StoreRepository();
        //    IStoreRepository repo = new DataManager(repo);
        //    ProductDetailController controller = new ProductDetailController(dataManager);

        //    // Act
        //    ViewResult result = controller.Index(new System.Guid("ec516a6f-c93b-4a74-91ae-070f46076665")) as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Hello world!", result?.ViewData["Message"]);
        //}
    }
}