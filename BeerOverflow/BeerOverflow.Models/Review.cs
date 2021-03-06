﻿using BeerOverflow.Models.Abstracts;
using BeerOverflow.Models.Contracts;
using System;

namespace BeerOverflow.Models
{
    public class Review : Entity, IModifiable
    {
        //[Key]
        public Guid Id { get; set; }
        // [Required]
        // [MaxLength(ReviewContentMaxLength)]
        public string Content { get; set; }
        // [Required]
        // [Range(RatingMin, RatingMax)]
        public int Likes { get; set; }
        public bool IsFlagged { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Guid BeerId { get; set; }
        public Beer Beer { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}