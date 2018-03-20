using NUnit.Framework;
using PdService;

namespace UiService.Tests 
{
    [TestFixture]
    public class ProductDetailTests
    {   
        private ProductDetailProvider sut;

        [SetUp]
        public void SetUp() 
        {
            sut = new ProductDetailProvider();
        }

        [Test]
        public void ShouldReturnEmptyDetail() 
        {
            var item = sut.Get("Item");
            Assert.IsNull(item.Code);
        }

        [Test]
        public void ShouldReturnFullDetails() 
        {
            var item = sut.Get("Item2");
            Assert.AreEqual(item.Code, "Item2");
            Assert.AreEqual(item.Name, "Name 2");
            Assert.AreEqual(item.Description, "Description 2");
            Assert.AreEqual(item.Brand, "Brand 2");
        }        
    }
}