using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreSPATemplate.Model;
using CsvHelper;

namespace AspnetCoreSPATemplate.Data.Implementation
{
    public class CSVDataProvider : IDataProvider
    {
        public int GetCustomerCount()
        {
            int count = -1;
            try
            {
                using(TextReader reader = new StreamReader("SampleData.csv"))
                {
                    using(var csvReader = new CsvReader(reader))
                    {
                        count = csvReader.GetRecords<Customer>().Count();
                    }
                } 
            }
            catch(Exception ex)
            {
                //TODO: Log error
            }

            return count;
        }

        public int GetCustomerFilteredCount(string searchString)
        {
            int count = -1;
            try
            {
                using (TextReader reader = new StreamReader("SampleData.csv"))
                {
                    using (var csvReader = new CsvReader(reader))
                    {
                        count = csvReader.GetRecords<Customer>()
                                                             .Where(x => x.first_name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                                                || x.last_name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                                                || x.email.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                                                || x.phone1.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                                              ).Count();
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log error
            }

            return count;
        }

        public List<Customer> GetCustomers(int pageNumber, int itemsPerPage, string searchString)
        {
            List<Customer> result = new List<Customer>();
            try
            {
                using (TextReader reader = new StreamReader("SampleData.csv"))
                {
                    using (var csvReader = new CsvReader(reader))
                    {
                        int pageToSkip = (pageNumber - 1) * itemsPerPage;

                        if (!string.IsNullOrEmpty(searchString))
                        {
                            result = csvReader.GetRecords<Customer>()
                                            .Where(x => x.first_name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                                                || x.last_name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                                                || x.email.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                                                || x.phone1.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                                              )
                                            .Skip(pageToSkip)
                                            .Take(itemsPerPage)
                                            .ToList();

                        }
                        else
                        {

                            result = csvReader.GetRecords<Customer>()
                                           .Skip(pageToSkip)
                                           .Take(itemsPerPage)
                                           .ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log error
            }
            return result;
        }
    }
}
