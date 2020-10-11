using System;

namespace BeerOverflow.Web.Models
{
    public class RatingViewModel
    {
        public Guid Id { get; set; }
        public int RatingGiven { get; set; }
        public Guid BeerId { get; set; }
        public string BeerName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
