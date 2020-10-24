using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class WishListSearchViewModel
    {
        public string Name { get; set; }
        public ICollection<BeerViewModel> WishList { get; set; }
    }
}
