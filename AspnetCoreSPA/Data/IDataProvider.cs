using AspnetCoreSPATemplate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreSPATemplate.Data
{
    public interface IDataProvider
    {
        List<Customer> GetCustomers(int pageNumber, int itemsPerPage, string searchString);
        int GetCustomerCount();
        int GetCustomerFilteredCount(string searchString);
    }
}
