using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreSPATemplate.Data;
using AspnetCoreSPATemplate.Model;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreSPATemplate.Controllers
{
 
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private IDataProvider _dataProvider;
        public CustomerController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [Route("get")]
        [HttpGet]
        public ActionResult GetCustomers(int pageNumber, int itemsPerPage, string searchString)
        {
            PagedResponse<List<Customer>> pagedData = new PagedResponse<List<Customer>>();
            double pageCount = (double)(pagedData.Total / itemsPerPage);
            pagedData.NumberOfPages = (int)Math.Ceiling(pageCount);
            int pageToSkip = (pageNumber - 1) * itemsPerPage;

            if (string.IsNullOrEmpty(searchString))
            {
                pagedData.Total = _dataProvider.GetCustomerCount();
            }
            else
            {
                pagedData.Total = _dataProvider.GetCustomerFilteredCount(searchString);
            }
            
            pagedData.Data = _dataProvider.GetCustomers(pageNumber, itemsPerPage, searchString);

            return Ok(pagedData);
        }
    }
}