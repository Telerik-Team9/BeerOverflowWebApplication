using System;

namespace BeerOverflow.Services.DTOs
{
    public class WishListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public Guid BeerId { get; set; }
        public string BeerName { get; set; }
    }
}
