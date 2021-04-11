using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Controllers;
using InternetShop.Domain;
using InternetShop.Domain.Repositories;
using Moq;
using System.Collections.Generic;
using System;
using InternetShop.Domain.Entities;

namespace UnitTestApp
{
    public class HomeController_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HomeController_Index_Tests()
        {
            // Arrange
            var mockProduct = new Mock<IProductRepository>();
            var mockUser = new Mock<IUserRepository>();
            mockProduct.Setup(repo => repo.GetFilteredProducts(null, null, null)).Returns(GetFilteredProducts_Test());
            mockUser.Setup(repo => repo.GetUserByEmail("User")).Returns(GetUserByEmail_Test());
            var controller = new HomeController(mockProduct.Object, mockUser.Object);

            // Act
            var result = controller.Index();
            ViewResult result2 = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<User>>(viewResult.Model);
            //Assert.Equal(GetTestUsers().Count, model.Count());
        }
        private List<Product> GetFilteredProducts_Test()
        {
            return new List<Product>()
            {
                new Product() { Name = "TestName1", Brand = "TestBrand1", Category = "TestCategory", Description = "TestDescription1", Id = new Guid("aa1a1111-a1a1-11a1-1111-1a1111aa1111"), Picter = "TestPicter1", Price = 1 },
                new Product() { Name = "TestName2", Brand = "TestBrand2", Category = "TestCategory", Description = "TestDescription2", Id = new Guid("aa1a1111-a1a1-11a1-1111-1a1111aa1112"), Picter = "TestPicter2", Price = 2 }
            };
        }

        private User GetUserByEmail_Test()
        {
            return new User();
        }
    }
}