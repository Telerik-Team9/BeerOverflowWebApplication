using System;

namespace BeerOverflow.Services.DTOs
{
    public class DrankListDTO
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid BeerId { get; set; }
        public string BeerName { get; set; }
    }
}
