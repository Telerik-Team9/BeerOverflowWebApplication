using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BeerOverflow.Web.Models
{
    public class BeerViewModel
    {
        public BeerViewModel()
        {
        }

        public BeerViewModel(BeerDTO item)
        {
            this.Id = item.Id;
            this.Name = item.Name;
            this.ABV = item.ABV;
            this.Price = Math.Round(item.Price, 2);
            this.Description = item.Description;
            this.ImageURL = item.ImageURL;
            this.Mililiters = item.Mililiters;
            this.IsUnlisted = item.IsUnlisted;
            this.IsDeleted = item.IsDeleted;
            this.IsBeerOfTheMonth = item.IsBeerOfTheMonth;
            this.StyleId = item.StyleId;
            this.StyleName = item.StyleName;
            this.BreweryId = item.BreweryId;
            this.BreweryName = item.BreweryName;
            this.AvgRating = item.AvgRating;
            this.Reviews = item.Reviews.Select(r => new ReviewViewModel(r)).ToList();
        }

        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float ABV { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Mililiters { get; set; }
        public bool IsUnlisted { get; set; }
        public bool IsDeleted { get; set; } // TODO: da se mahne li tva
        public bool IsBeerOfTheMonth { get; set; }
        public double AvgRating { get; set; }


        public Guid StyleId { get; set; }
        [Required]
        public string StyleName { get; set; } // Porter, Ale, Lager etc.
        public Guid BreweryId { get; set; }
        [Required]
        public string BreweryName { get; set; }
        public ICollection<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();
        public ICollection<RatingViewModel> Ratings { get; set; } = new List<RatingViewModel>();
        //TODO: Add wishlist/dranklist
    }
}
