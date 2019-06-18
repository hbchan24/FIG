using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreSPATemplate.Model
{
    public class PagedResponse<T>
    {
        public int Total { get; set; }
        public int NumberOfPages { get; set; }
        public T Data { get; set; }
    }
}
