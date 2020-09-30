using System;

namespace BeerOverflow.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public float Rating { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; } // Is it needed?

        public bool IsFlagged { get; set; }


        public Beer Beer { get; set; }
        //TODO: Add Nav property for User
    }
}