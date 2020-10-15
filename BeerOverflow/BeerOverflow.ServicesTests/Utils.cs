using BeerOverflow.Database;
using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BeerOverflow.ServicesTests
{
    public class Utils
    {
        public static DbContextOptions<BeerOverflowDbContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<BeerOverflowDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public static IEnumerable<Beer> GetBeers()
            => new Beer[]
            {
                new Beer
                {
                    Id = Guid.Parse("133e0d92-cedc-40a7-b8fd-e5669611b3dc"),
                    Name = "Kamenitza",
                    ABV = float.Parse("4.4"),
                    Price = float.Parse("1.6"),
                    Description = "Light beer with an extract content of 10.2 ° P.",
                    ImageURL = "https://www.kamenitza.bg/-/media/kamenitza/products/images/kamtnitza-1881.ashx",
                    Mililiters = 330,
                    StyleId = Guid.Parse("f32de916-9ea8-4f93-96d2-732d1b01fe8e"),
                    BreweryId = Guid.Parse("89e0215e-2726-489b-8d63-b851b997f622")
                },
                new Beer
                {
                    Id = Guid.Parse("f13cdf0f-9f3c-4435-a107-e265e016b7d3"),
                    Name = "Kamenitza Lemon Fresh",
                    ABV = float.Parse("3.0"),
                    Price = float.Parse("1.8"),
                    Description = "Light seasonal fruit beer with an extract content of 8.3 ° P.",
                    ImageURL = "https://www.kamenitza.bg/-/media/kamenitza/products/images/kamenitza-fresh-grapefruit.ashx",
                    Mililiters = 330,
                    StyleId = Guid.Parse("b06a5dbd-f993-4379-af3e-6339377503fc"),
                    BreweryId = Guid.Parse("89e0215e-2726-489b-8d63-b851b997f622")
                },
                new Beer
                {
                    Id = Guid.Parse("1855d14b-ccb6-43b8-a7b3-3936b5010293"),
                    Name = "Stella Artois",
                    ABV = float.Parse("5.2"),
                    Price = float.Parse("2.9"),
                    Description = "A Belgian pilsner of between 4.8 and 5.2 percent ABV which was first brewed by Brouwerij Artois (the Artois Brewery) in Leuven, Belgium, in 1926. Since 2008, a 4.8 percent ABV version has also been sold in Britain, Ireland, Canada and Australia. Stella Artois is now owned by Interbrew International B.V. which is a subsidiary of the world's largest brewer, Anheuser-Busch InBev SA/NV.",
                    ImageURL = "https://shortysliquor.com.au/media/catalog/product/cache/2fcc3329aef4183c8e06230d7e06f8f3/1/1/11760.1_4.png",
                    Mililiters = 500,
                    StyleId = Guid.Parse("1c7f6d85-2301-411b-a5c5-dae9fcf347a3"),
                    BreweryId = Guid.Parse("411a38dd-0600-4eac-b991-305f1031257c")
                },
                new Beer
                {
                    Id = Guid.Parse("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                    Name = "Heineken",
                    ABV = float.Parse("5.0"),
                    Price = float.Parse("2.0"),
                    Description = "A pale lager beer with 5% alcohol by volume produced by the Dutch brewing company Heineken International. Heineken beer is sold in a green bottle with a red star.",
                    ImageURL = "https://www.heineken.com/media-us/01pfxdqq/heineken-original-bottle.png?quality=85",
                    Mililiters = 450,
                    StyleId = Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"),
                    BreweryId = Guid.Parse("2a281f97-d2d4-4cde-93d3-92f8aac15b9a")
                }
            };

        public static IEnumerable<Brewery> GetBreweries()
            => new Brewery[]
            {
                new Brewery
                {
                    Id = Guid.Parse("89e0215e-2726-489b-8d63-b851b997f622"),
                    Name = "Kamenitza AD",
                    CountryId = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b")
                },
                new Brewery
                {
                    Id = Guid.Parse("411a38dd-0600-4eac-b991-305f1031257c"),
                    Name = "Anheuser–Busch InBev",
                    CountryId = Guid.Parse("e1d02d9a-263f-4871-b685-bf63de6508c4")
                },
                new Brewery
                {
                    Id = Guid.Parse("2a281f97-d2d4-4cde-93d3-92f8aac15b9a"),
                    Name = "Heineken International",
                    CountryId = Guid.Parse("ec10c1a9-eafe-4ddc-8474-cb5fec82d186")
                }
            };

        public static IEnumerable<Country> GetCountries()
            => new Country[]
            {
                new Country
                {
                    Id = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b"),
                    Name = "Bulgaria",
                    ISO = "BG"
                },
                new Country
                {
                    Id = Guid.Parse("e1d02d9a-263f-4871-b685-bf63de6508c4"),
                    Name = "Belgium",
                    ISO = "BE"
                },
                new Country
                {
                    Id = Guid.Parse("ec10c1a9-eafe-4ddc-8474-cb5fec82d186"),
                    Name = "Netherlands",
                    ISO = "NL"
                }
            };

        public static IEnumerable<Style> GetStyles()
            => new Style[]
            {
                new Style
                {
                    Id = Guid.Parse("f32de916-9ea8-4f93-96d2-732d1b01fe8e"),
                    Name = "Lager",
                    Description = "Lager is a type of beer conditioned at low temperature. Lagers can be pale, amber, or dark."
                },
                new Style
                {
                    Id = Guid.Parse("b06a5dbd-f993-4379-af3e-6339377503fc"),
                    Name = "Fruit",
                    Description = "Fruit beer is beer made with fruit added as an adjunct or flavouring. Lambics, beers originating in the valley of the Zenne (in an around Brussels) Belgium, though copied by brewers in other parts of the world, may be refermented with cherries to make kriek, or fermented with raspberries to make framboise."
                },
                new Style
                {
                    Id = Guid.Parse("1c7f6d85-2301-411b-a5c5-dae9fcf347a3"),
                    Name = "Pilsner",
                    Description = "Pilsner (also pilsener or simply pils) is a type of pale lager. It takes its name from the Czech city of Pilsen, where it was first produced in 1842 by Bavarian brewer Josef Groll. The world's first pale lager, the original Pilsner Urquell, is still produced there today."
                },
                new Style
                {
                    Id = Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"),
                    Name = "Pale Lager",
                    Description = "Pale lager is a very pale-to-golden-colored lager beer with a well-attenuated body and a varying degree of noble hop bitterness."
                }
            };

        public static IEnumerable<Review> GetReviews()
            => new Review[]
            {
                new Review
                {
                    Id = Guid.Parse("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                    Content = "I didn't really like it. Poor colour, bad taste.",
                    Likes = 8,
                    IsFlagged = false,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    DeletedOn = null,
                    ModifiedOn = DateTime.Now.Add(TimeSpan.FromDays(1)),
                    BeerId = Guid.Parse("1855d14b-ccb6-43b8-a7b3-3936b5010293"),
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5")
                },
                new Review
                {
                    Id = Guid.Parse("bc9fa1aa-d58a-4f37-a81d-7a7ca81f27bb"),
                    Content = "It's okay I guess. Very fruity aroma. Light sour, strong sweet taste. Fruity.",
                    Likes = 22,
                    IsFlagged = false,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    DeletedOn = null,
                    ModifiedOn = null,
                    BeerId = Guid.Parse("f13cdf0f-9f3c-4435-a107-e265e016b7d3"),
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619")
                }
            };

        public static IEnumerable<User> GetUsers() // TODO: Utils: Users
            => new User[]
            {

            };

        public static IEnumerable<Rating> GetRatings() // TODO: Utils: Ratings
            => new Rating[]
            {

            };
    }
}
