using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Controllers;
using InternetShop.Domain.Repositories;
using Moq;
using System.Collections.Generic;
using System;
using InternetShop.Domain.Entities;

namespace UnitTestApp
{
    public class HomeController_Tests
    {
        [Test]
        public void HomeController_Index_Tests()
        {
            // Arrange
            var mockProduct = new Mock<IProductRepository>();
            var mockUser = new Mock<IUserRepository>();
            mockProduct.Setup(repo => repo.GetFilteredProducts(It.IsAny<string>(), null, null)).Returns(GetFilteredProducts_Test());
            mockUser.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).Returns(GetUserByEmail_Test());
            var controller = new HomeController(mockProduct.Object, mockUser.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(3, (result as ViewResult).ViewData.Count);
        }

        private List<ProductModel> GetFilteredProducts_Test()
        {
            return new List<ProductModel>()
            {
                new ProductModel() { Name = "TestName1", Brand = "TestBrand1", Category = "TestCategory1", Description = "TestDescription1", Id = new Guid("aa1a1111-a1a1-11a1-1111-1a1111aa1111"), Picter = "TestPicter1", Price = 1 },
                new ProductModel() { Name = "TestName2", Brand = "TestBrand2", Category = "TestCategory2", Description = "TestDescription2", Id = new Guid("aa1a1111-a1a1-11a1-1111-1a1111aa1112"), Picter = "TestPicter2", Price = 2 }
            };
        }

        private UserModel GetUserByEmail_Test()
        {
            UserModel user = new UserModel()
            {
                Email = "TestEmail",
                Password = "TestPassword",
                Cart = new CartModel()
                {
                    CartItems = new Dictionary<ProductModel, int>()
                    {
                        { new ProductModel() { Name = "TestName1", Brand = "TestBrand1", Category = "TestCategory", Description = "TestDescription1", Id = new Guid("aa1a1111-a1a1-11a1-1111-1a1111aa1111"), Picter = "TestPicter1", Price = 1 }, 1 }
                    },
                }
            };
            return user;
        }
    }
}