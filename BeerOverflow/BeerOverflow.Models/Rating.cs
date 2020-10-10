using BeerOverflow.Models.Abstracts;
using System;

namespace BeerOverflow.Models
{
    public class Rating : Entity
    {
        public Guid Id { get; set; } 
        //[Range(1, 5)] TODO
        public int RatingGiven { get; set; }
        public Guid BeerId { get; set; }
        public Beer Beer { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
