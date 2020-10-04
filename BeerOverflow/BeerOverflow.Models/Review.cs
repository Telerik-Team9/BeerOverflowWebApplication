using System;
using System.ComponentModel.DataAnnotations;
using BeerOverflow.Models.Contracts;
using static BeerOverflow.Models.Common.ModelsConstants;

namespace BeerOverflow.Models
{
    public class Review : IEntity, IModifiable
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(ReviewContentMaxLength)]
        public string Content { get; set; }
        [Required]
        [Range(RatingMin, RatingMax)]
        public float Rating { get; set; }
        public int Likes { get; set; }
        public bool IsFlagged { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Guid BeerId { get; set; }
        public Beer Beer { get; set; }
        //TODO: Add Nav property for User
    }
}