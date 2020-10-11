using System;
using System.Collections.Generic;
using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerOverflow.Database.Seed
{
    public static class Seeder // Should we name it DataExtensions?
    {
/*        public static ICollection<Beer> Beers { get; set; } = new List<Beer>();
        public static ICollection<Brewery> Breweries { get; set; } = new List<Brewery>();
        public static ICollection<Country> Countries { get; set; } = new List<Country>();
        public static ICollection<Style> Styles { get; set; } = new List<Style>();
        public static ICollection<Review> Reviews { get; set; } = new List<Review>();*/

        public static void Seed(this ModelBuilder builder)
        {
            var beers = new List<Beer>
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
                },
                new Beer
                {
                    Id = Guid.Parse("6210036f-3e9e-4e90-81d3-aaafd0251391"),
                    Name = "Guinness Original",
                    ABV = float.Parse("4.2"),
                    Price = float.Parse("3.1"),
                    Description = "4.2 to 5.6% in the United States. 5% in Canada, and most of Europe; 4.2 or 4.3% ABV in Ireland and some European countries, 4.1% in Germany, 4.8% in Namibia and South Africa, and 6% in Australia and Japan.",
                    ImageURL = "https://carlsbergukraine.com/media/9616/guinness_ophoto_shot_02_1_go_sr.png",
                    Mililiters = 500,
                    StyleId = Guid.Parse("ec61fe34-c639-433d-acac-98f092392099"),
                    BreweryId = Guid.Parse("b35ef87f-d03a-4777-a900-3c5e2af3c4e9")
                },
                new Beer
                {
                    Id = Guid.Parse("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"),
                    Name = "Amstel",
                    ABV = float.Parse("3.5"),
                    Price = float.Parse("2.1"),
                    Description = "According to the Amstel website, Amstel beer is pure - filtered which creates a full-strength beer without the calories and carbohydrates.",
                    ImageURL = "https://grocerytrader.co.uk/wp-content/uploads/2016/05/Amstel-650ml-btl5.jpg",
                    Mililiters = 660,
                    StyleId = Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"),
                    BreweryId = Guid.Parse("f51b60cc-33fb-4ad2-afb5-6248c0a2b6ab")
                },
                new Beer
                {
                    Id = Guid.Parse("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                    Name = "Zagorka",
                    ABV = float.Parse("6.0"),
                    Price = float.Parse("1.9"),
                    Description = "A high-quality lager beer, the main ingredients of which are barley malt, water, hops and yeast. It is characterized by light golden color, moderate carbonation, fresh taste, with a slight aroma of malt and hops. Available on the market in glass bottles of 0.5 liters, as well as in PET bottles of 1 and 2 liters.",
                    ImageURL = "https://www.zagorka.bg/img/product/specialno/img-1l.png",
                    Mililiters = 1000,
                    StyleId = Guid.Parse("f32de916-9ea8-4f93-96d2-732d1b01fe8e"),
                    BreweryId = Guid.Parse("0d56076c-82cb-469d-80db-afb64c7516f7")
                }
            };
            builder.Entity<Beer>().HasData(beers);

            var breweries = new List<Brewery>
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
                },
                new Brewery
                {
                    Id = Guid.Parse("b35ef87f-d03a-4777-a900-3c5e2af3c4e9"),
                    Name = "Diageo",
                    CountryId = Guid.Parse("d60e1413-fac0-45a5-a020-c1b7e5221a67")
                },
                new Brewery
                {
                    Id = Guid.Parse("f51b60cc-33fb-4ad2-afb5-6248c0a2b6ab"),
                    Name = "Amstel Brouwerij",
                    CountryId = Guid.Parse("ec10c1a9-eafe-4ddc-8474-cb5fec82d186")
                },
                new Brewery
                {
                    Id = Guid.Parse("0d56076c-82cb-469d-80db-afb64c7516f7"),
                    Name = "Zagorka AD",
                    CountryId = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b")
                }
            };
            builder.Entity<Brewery>().HasData(breweries);

            var countries = new List<Country>
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
                },
                new Country
                {
                    Id = Guid.Parse("d60e1413-fac0-45a5-a020-c1b7e5221a67"),
                    Name = "Ireland",
                    ISO = "IE"
                },
                
                // No breweries with the next countries
                new Country
                {
                    Id = Guid.Parse("f444594e-5626-4c1e-b285-571f33930022"),
                    Name = "Serbia",
                    ISO = "RS"
                },
                new Country
                {
                    Id = Guid.Parse("e0932858-11cb-4a27-87f2-8756649b8c88"),
                    Name = "Germany",
                    ISO = "DE"
                },
            };
            builder.Entity<Country>().HasData(countries);

            var styles = new List<Style>
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
                },
                new Style
                {
                    Id = Guid.Parse("ec61fe34-c639-433d-acac-98f092392099"),
                    Name = "Stout",
                    Description = "Stout is a dark, top-fermented beer with a number of variations, including dry stout, oatmeal stout, milk stout, and imperial stout. The first known use of the word stout for beer was in a document dated 1677 found in the Egerton Manuscripts, the sense being that a \"stout beer\" was a strong beer, not a dark beer."
                },

                // No beers with the next styles
                new Style
                {
                    Id = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                    Name = "Pale Ale",
                    Description = "The classic Pale Ale is generally a deep-golden to copper colored, hop-forward ale with a balanced malt profile. This style specifically represents all generic Pale Ales (sometime called International Pale Ale) which are marketed as such and which cannot be defined as a specific regional Pale Ale style such as the American Pale Ale. This also includes beers marketed as Extra Pale Ale (XPA), a non-defined style that usually sits between an American Pale Ale and an India Pale Ale, a hop forward beer and generally more intense than an APA but not as hop-forward as an IPA. Sometimes, the XPA also refers to a session-strength or simply paler Pale Ale."
                },
                new Style
                {
                    Id = Guid.Parse("96cc020a-753d-4483-9531-02b0a83b0a66"),
                    Name = "IPA - Brut",
                    Description = "The Brut India Pale Ale (IPA) is a very pale to light golden, very dry, highly effervescent variant of American IPA, usually highly hopped with aromatic hops, but with far less actual bitterness. Enzymes are used in the mash and/or fermenter along with highly fermentable wort and often adjuncts like rice and corn to achieve close to total attenuation, resulting in an absent residual malt sweetness. Hopped in a similar fashion to New England IPA, but without sweetness. Pale like a West Coast IPA, but without high bitterness. Highly carbonated like a Belgian Golden Strong ale, but even drier, and without Belgian spice and phenol character."
                },
                new Style
                {
                    Id = Guid.Parse("bad58025-7855-482b-8f96-e74c4c122a9b"),
                    Name = "IPA - English",
                    Description = "The English India Pale Ale (IPA) is a hoppy, moderately-strong, very well-attenuated pale golden to deep amber British ale with a dry finish and a hoppy aroma and flavor. Generally will have more finish hops and less fruitiness and/or caramel than British pale ales and bitter and has less hop intensity and a more pronounced malt flavor than typical American versions. The modern IPA style generally refers to American IPA and its derivatives but this does not imply that English IPA isn't a proper IPA. Originally, the attributes of IPA that were important to its arrival in good condition from England to India by ship were that it was very well-attenuated, and heavily hopped."
                },
                new Style
                {
                    Id = Guid.Parse("ae339a73-e8cb-47f3-b250-a3d25c4cdedb"),
                    Name = "Old Ale",
                    Description = "The Old Ale is an light amber to very dark reddish-brown colored English ale of moderate to fairly significant alcoholic strength, bigger than standard beers, though usually not as strong or rich as barleywine and often tilted towards a maltier balance. The predominant defining quality for this style is the impression of age, which can manifest itself in different ways (complexity, lactic, Brett, oxidation, leather, vinous qualities are some recurring examples). Roughly overlapping the British Strong Ale and the lower end of the English Barley Wine styles, but always having an aged quality. Barley Wines tend to develop more of an overall mature quality, while Old Ales can show more of the barrel qualities. Old Peculier are also considered as an Old Ale."
                }
            };
            builder.Entity<Style>().HasData(styles);

            var reviews = new List<Review>
            {
                new Review
                {
                    Id = Guid.Parse("03461e43-1ebb-4035-8fa4-e5acf5c923f1"),
                    Content = "This is exellent beer!",
                    Likes = 120,
                    IsFlagged = false,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    DeletedOn = null,
                    ModifiedOn = null,
                    BeerId = Guid.Parse("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                },
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
                },
                new Review
                {
                    Id = Guid.Parse("766d9e58-68da-479c-ab97-dc9d1de06bbc"),
                    Content = "Absolutely amazing!. One of the best Bulgarian beers.",
                    Likes = 0,
                    IsFlagged = false,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    DeletedOn = null,
                    ModifiedOn = null,
                    BeerId = Guid.Parse("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                }
            };
            builder.Entity<Review>().HasData(reviews);
        }
        //TODO: Map
    }
}