using AspnetCoreSPATemplate.Data.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspnetCoreSPATemplate.Test
{
    [TestClass]
    public class DataProvider_Tests
    {
        private CSVDataProvider _dataProvider;
        [TestInitialize]
        public void Init()
        {
            _dataProvider = new CSVDataProvider();
        }

        [TestMethod]
        public void GetCustomers()
        {
            var customers = _dataProvider.GetCustomers(1, 10, string.Empty);

            Assert.AreEqual(10, customers.Count);
        }

        [TestMethod]
        public void GetCustomerCount()
        {
            var count = _dataProvider.GetCustomerCount();

            Assert.AreEqual(500, count);
        }

        [TestMethod]
        public void GetCustomerFilteredCount()
        {
            var count = _dataProvider.GetCustomerFilteredCount("brigette");

            Assert.AreNotEqual(count, 500);
        }
        
    }
}
