using NUnit.Framework;
using Utils;
using System.Linq;

namespace UiService.Tests 
{
    [TestFixture]
    public class OptionalTests
    {
        private string[] testArray = new [] {
            "test1",
            "test2",
            "test3"
        };

        [Test]
        public void ShouldCallNoneIfEmpty() 
        {
            var result = testArray
                            .FirstOrDefault(s => s == "test")
                            .ToOption()
                            .Match<bool>(_ => false,
                                         () => true);
            Assert.IsTrue (result);
        }

        [Test]
        public void ShouldCallSomeIfExist() 
        {
            var result = testArray
                            .FirstOrDefault(s => s == "test2")
                            .ToOption()
                            .Match<bool>(_ => true,
                                         () => false);
            Assert.IsTrue (result);
        }
    }
}
