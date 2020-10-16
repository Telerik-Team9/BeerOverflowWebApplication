using System;

namespace BeerOverflow.Models
{
    public class DrankList
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid BeerId { get; set; }
        public Beer Beer { get; set; }
    }
}
