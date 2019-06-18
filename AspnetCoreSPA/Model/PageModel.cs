using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreSPATemplate.Model
{
    public class PagedModel
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        public string SearchString { get; set; }

    }
}
