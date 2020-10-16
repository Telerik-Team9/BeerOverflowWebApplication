using System;

namespace BeerOverflow.Models
{
    public class WishList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid BeerId { get; set; }
        public Beer Beer { get; set; }
    }
}
