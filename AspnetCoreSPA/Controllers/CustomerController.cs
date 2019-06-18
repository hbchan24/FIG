using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreSPATemplate.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreSPATemplate.Controllers
{
 
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        static List<Customer> customers = new List<Customer>();
        public CustomerController()
        {
            if (customers.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    customers.Add(new Customer
                    {
                        FirstName = "FirstName " + i,
                        LastName = "LastName " + i,
                        Email = "email@email.com " + i,
                        Phone1 = "Phone1 " + i
                    });
                }
            }
        }

        [Route("get")]
        [HttpGet]
        public ActionResult GetCustomers(int pageNumber, int itemsPerPage, string searchString)
        {
            PagedResponse<List<Customer>> pagedData = new PagedResponse<List<Customer>>();
            pagedData.Total = customers.Count();
            double pageCount = (double)(pagedData.Total / itemsPerPage);
            pagedData.NumberOfPages = (int)Math.Ceiling(pageCount);

            int pageToSkip = (pageNumber - 1) * itemsPerPage;

            if (!string.IsNullOrEmpty(searchString))
            {
                pagedData.Data = customers
                                .Skip(pageToSkip)
                                .Take(itemsPerPage)
                                .Where(x => x.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                        || x.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                        || x.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                        || x.Phone1.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                      )
                                .ToList();

            }
            else
            {
                pagedData.Data = customers
                       .Skip(pageToSkip)
                       .Take(itemsPerPage)
                       .ToList();
            }

            return Ok(pagedData);
        }
    }
}