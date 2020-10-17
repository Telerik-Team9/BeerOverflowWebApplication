using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Web.Models
{
    public class BeerViewModel
    {
        public BeerViewModel(BeerDTO item)
        {
            this.Id = item.Id;
            this.Name = item.Name;
            this.ABV = item.ABV;
            this.Price = item.Price;
            this.Description = item.Description;
            this.ImageURL = item.ImageURL;
            this.Mililiters = item.Mililiters;
            this.IsUnlisted = item.IsUnlisted;
            this.IsDeleted = item.IsDeleted;
            this.IsBeerOfTheMonth = item.IsBeerOfTheMonth;
            this.StyleId = item.StyleId;
            this.BreweryId = item.BreweryId;
            this.AvgRating = item.AvgRating;
            // this.Ratings = item.Ratings.Select(r =>r.ge) TODO:
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
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
        public string StyleName { get; set; } // Porter, Ale, Lager etc.
        public Guid BreweryId { get; set; }
        public string BreweryName { get; set; }
        public ICollection<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();
        public ICollection<RatingViewModel> Ratings { get; set; } = new List<RatingViewModel>();
        //TODO: Add wishlist/dranklist
    }
}
