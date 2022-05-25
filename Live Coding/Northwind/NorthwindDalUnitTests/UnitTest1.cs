using NorthwindDal.Model;

namespace NorthwindDalUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountCustomers()
        {
            NorthwindContext context = new NorthwindContext();

            var customers = context.Customers.ToList();

            Assert.AreEqual(92, customers.Count());
        }
    }
}