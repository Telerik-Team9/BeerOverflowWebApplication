using BeerOverflow.Web.Models;
using System.Collections.Generic;

namespace BeerOverflow.Web.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<BeerViewModel> TopRatedBeers { get; set; }
    }
}
