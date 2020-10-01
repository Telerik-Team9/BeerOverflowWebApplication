using System;
using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public float Rating { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; } // Is it needed?
        public bool IsFlagged { get; set; }

        public Beer Beer { get; set; }
        public Guid BeerId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        //TODO: Add Nav property for User
    }
}