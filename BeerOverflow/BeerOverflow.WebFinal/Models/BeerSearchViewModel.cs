using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class BeerSearchViewModel
    {
        public string Name { get; set; }
        public string StyleName { get; set; }
        public string SortBy { get; set; }
        public int pageCount { get; set; }
        public ICollection<BeerViewModel> Beers { get; set; }
    }
}
