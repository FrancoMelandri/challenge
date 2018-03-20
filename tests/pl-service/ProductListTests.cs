using NUnit.Framework;
using PlService;

namespace UiService.Tests 
{
    [TestFixture]
    public class ProductListTests
    {    
        private ProductListProvider sut;

        [SetUp]
        public void SetUp() 
        {
            sut = new ProductListProvider();
        }

        [Test]
        public void ShouldReturnSameSearch() 
        {
            var products = sut.Get("test");
            Assert.AreEqual(products.Search, "test");
        }

        [Test]
        public void ShouldReturnAllItemsInCatalog() 
        {
            var products = sut.Get("Name");
            Assert.AreEqual(products.Items.Count, 5);
        }

        [Test]
        [TestCase("Name 1")]
        [TestCase("Name 2")]
        [TestCase("Name 3")]
        [TestCase("Name 4")]
        [TestCase("Name 5")]
        public void ShouldReturnOnlyOneInCatalog(string code) 
        {
            var products = sut.Get(code);
            Assert.AreEqual(products.Items.Count, 1);
        }

        [Test]
        public void ShouldReturnEmptyItems() 
        {
            var products = sut.Get("NoItem");
            Assert.AreEqual(products.Items.Count, 0);
        }

        [Test]
        public void ShouldMapItemInCatalog() 
        {
            var product = sut.Get("Name 3").Items[0];
            Assert.AreEqual(product.Code, "Item3");
            Assert.AreEqual(product.Name, "Name 3");
        }        
    }
}