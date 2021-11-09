using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailOrder.API.Models.Dtos
{
    public class PagedResultsDTO<T>
    {
        /// <summary>
        /// The page number this page represents.
        /// </summary>
        public int PageIndex { get; set; }


        /// <summary>
        /// The size of this page.
        /// </summary>
        public int PageSize { get; set; }


        /// <summary>
        /// The total number of pages available.
        /// </summary>
        public int TotalPages { get; set; }


        /// <summary>
        /// The total number of records available.
        /// </summary>
        public long TotalRecords { get; set; }


        /// <summary>
        /// The records this page represents.
        /// </summary>
        public IEnumerable<T> Results { get; set; }
    }
}
