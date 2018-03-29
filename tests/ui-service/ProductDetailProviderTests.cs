using NUnit.Framework;
using Core;
using Moq;
using System.Threading.Tasks;
using PdService;
using System.Collections.Generic;

namespace UiService.Tests 
{
    [TestFixture]
    public class ProductDetailsProviderrTests
    {
        private ProductDetailsProvider sut;
        private Mock<IProductDetailsService> productDetailsService;

        [SetUp]
        public void SetUp() 
        {
            this.productDetailsService = new Mock<IProductDetailsService>();
            sut = new ProductDetailsProvider(productDetailsService.Object);
        }

        [Test]
        public void ShouldReturnDetailModel() 
        {
            var productDetais = new ProductDetail 
            {
                Code = "Code1",
                Name = "Name1",
                Description = "Description1",
                Brand = "Brand1"
            };
            productDetailsService
                .Setup( m => m.GetDetail("Code1") )
                .Returns(Task.FromResult(productDetais));
            
            var result = sut.GetDetail("Code1").Result;
            Assert.AreEqual(result.Code, "Code1");
            Assert.AreEqual(result.Name, "Name1");
        }
    }
}