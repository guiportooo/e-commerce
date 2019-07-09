using AutoMapper;
using ECommerce.Api.Controllers;
using ECommerce.Api.Domain;
using ECommerce.Api.Extensions;
using ECommerce.Api.Mapping;
using ECommerce.Api.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.UnitTests.Controllers
{
    public class ProductsControllerTests
    {
        private AutoMocker mocker;
        private IMapper mapper;
        private ProductsController productsController;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMocker();

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });
            mapper = mappingConfig.CreateMapper();

            mocker.Use(mapper);

            productsController = mocker.CreateInstance<ProductsController>();
        }

        [Test]
        public async Task ShouldGetAllProducts()
        {
            IEnumerable<Product> allProducts = new List<Product>
            {
                new Product(1, "Walden", 40.0m, "Description 1", Category.Books, 100),
                new Product(2, "A hundred years of solitude", 80.0m, "Description 3", Category.Books, 50),
                new Product(3, "iPhone 7", 2400.0m, "Description 2", Category.Eletronics, 100)
            };

            mocker.GetMock<ICatalog>()
                .Setup(x => x.GetAllProducts())
                .Returns(Task.FromResult(allProducts));

            var expectedProducts = new List<ProductModel>
            {
                new ProductModel { Id = 1, Name = "Walden", Price = 40.0m, Description = "Description 1", Category = Category.Books.ToString(), Available = true },
                new ProductModel { Id = 2, Name = "A hundred years of solitude", Price = 80.0m, Description = "Description 3", Category = Category.Books.ToString(), Available = true },
                new ProductModel { Id = 3, Name = "iPhone 7", Price = 2400.0m, Description = "Description 2", Category = Category.Eletronics.ToString(), Available = true }
            };

            var action = await productsController.Get();

            var productsReturned = ((OkObjectResult)action.Result).Value;

            productsReturned.Should().BeEquivalentTo(expectedProducts);
        }

        [Test]
        public async Task ShouldGetProductWithId()
        {
            const int idProduct = 1;
            var product = new Product(idProduct, "Walden", 40.0m, "Description 1", Category.Books, 100);

            mocker.GetMock<ICatalog>()
                .Setup(x => x.GetProductWithId(idProduct))
                .Returns(Task.FromResult(product));

            var expectedProduct = new ProductModel
            {
                Id = idProduct,
                Name = "Walden",
                Price = 40.0m,
                Description = "Description 1",
                Category = Category.Books.ToString(),
                Available = true
            };

            var action = await productsController.Get(idProduct);

            var productReturned = ((OkObjectResult)action.Result).Value;

            productReturned.Should().BeEquivalentTo(expectedProduct);
        }

        [Test]
        public async Task ShouldGetProductsFromCategory()
        {
            var category = "Books";

            IEnumerable<Product> productsFromCategory = new List<Product>
            {
                new Product(1, "Walden", 40.0m, "Description 1", category.ToCategory(), 100),
                new Product(2, "A hundred years of solitude", 80.0m, "Description 3", category.ToCategory(), 50)
            };

            mocker.GetMock<ICatalog>()
                .Setup(x => x.GetProductsFromCategory(category))
                .Returns(Task.FromResult(productsFromCategory));

            var expectedProducts = new List<ProductModel>
            {
                new ProductModel { Id = 1, Name = "Walden", Price = 40.0m, Description = "Description 1", Category = category, Available = true },
                new ProductModel { Id = 2, Name = "A hundred years of solitude", Price = 80.0m, Description = "Description 3", Category = category, Available = true }
            };

            var action = await productsController.GetByCategory(category);

            var productsReturned = ((OkObjectResult)action.Result).Value;

            productsReturned.Should().BeEquivalentTo(expectedProducts);
        }
    }
}