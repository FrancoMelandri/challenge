using NUnit.Framework;
using UiService.Engine;
using Moq;
using System.Threading.Tasks;
using PlService;
using System.Collections.Generic;

namespace UiService.Tests 
{
    [TestFixture]
    public class ProductListFinderTests
    {
        private ProductListFinder sut;
        private Mock<IProductListService> productListService;

        [SetUp]
        public void SetUp() 
        {
            productListService = new Mock<IProductListService>();
            sut = new ProductListFinder(productListService.Object);
        }

        [Test]
        public void ShouldReturnEmptySearchModel() 
        {
            productListService
                .Setup( m => m.GeProducts("search") )
                .Returns(Task.FromResult(new ProductList { 
                                                Items = new List<ProductListItem>()
                                                }));
            
            var result = sut.Search("search").Result;
            Assert.AreEqual(result.Items.Length, 0);
        }

        [Test]
        public void ShouldReturnFilledSearchModel() 
        {
            var products = new ProductList 
            {
                Items = new List<ProductListItem>
                {
                    new ProductListItem 
                    {
                        Code = "Code1",
                        Name = "Name1"
                    },
                    new ProductListItem 
                    {
                        Code = "Code2",
                        Name = "Name2"
                    },
                }
            };
            productListService
                .Setup( m => m.GeProducts("search") )
                .Returns(Task.FromResult(products));
            
            var result = sut.Search("search").Result;
            Assert.AreEqual(result.Items.Length, 2);
            Assert.AreEqual(result.Items[0].Code, "Code1");
            Assert.AreEqual(result.Items[0].Name, "Name1");
        }
    }
}