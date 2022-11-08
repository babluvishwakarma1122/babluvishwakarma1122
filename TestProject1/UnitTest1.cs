using NUnit.Framework;
using WebApplication1.Controllers;
using WebApplication1.Services;

namespace TestProject1
{
    public class Tests
    {
        private readonly IStores st;
        public Tests(IStores st1)
        {
            st = st1;
        }
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            MobileController home = new MobileController(st);
            //string result = home.Post();
            //Assert.AreEqual(name, result);
            Assert.Pass();
        }
    }
}