using BeerOverflow.Services.DTOs;
using System;

namespace BeerOverflow.Web.Models
{
    public class ReviewViewModel
    {
        public ReviewViewModel(ReviewDTO DTO)
        {
            this.Id = DTO.Id;
            this.Content = DTO.Content;
            this.Rating = DTO.Rating;
            this.Likes = DTO.Likes;
            this.BeerId = DTO.BeerId;
            this.BeerName = DTO.BeerName;
            this.UserId = DTO.UserId;
            this.UserName = DTO.UserName;
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; }
        public int Likes { get; set; }
        public Guid BeerId { get; set; }
        public string BeerName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}