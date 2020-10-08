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
                   Name = "Basi Kefa",
                   Description = "Clear medium yellow colour with a large, frothy, good lacing, mostly lasting, white head. Aroma is moderate malty, pale malt, moderate hoppy, flowers, citrus, light passion fruit. Flavor is moderate sweet and bitter with a long duration, passion fruit, fruity hops, citrus, fruity, pale malt. Body is medium, texture is oily to watery, carbonation is soft.",
                   ImageURL = "https://birka.bg/wp-content/uploads/2018/10/baso.jpg",
                   StyleId = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                   BreweryId = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"), //BeerBastards
                   ABV = float.Parse("6.7"),
               },
               new Beer
               {
                   Id = Guid.Parse("e13fe243-c8b3-494d-acca-39ea27cd8d41"),
                   Name = "Ailyak Cryo Mosaic",
                   Description = "Pours cloudy with a brief frothy head, plenty of lacing but no bead. Mid amber/ dirty orange in colour. Aromas of orange, banana and cereal. Very smooth in the mouth with flavours of banana, orange and pineapple over a base of honeyed cereal. Quite bitter in the finish, but scarcely any sweetness. Overall, another very enjoyable and well made Bulgarian IPA that is actually from Greece.",
                   ImageURL = "https://cdn.dribbble.com/users/1621762/screenshots/4008898/dribble.png",
                   StyleId = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                   BreweryId = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"), //BeerBastards
                   Mililiters = 330,
                   ABV = float.Parse("6"),
               },
               new Beer
               {
                   Id = Guid.Parse("bacfedee-043c-4c26-b135-76cb2a092f1d"),
                   Name = "Opasen Char",
                   Description = "Complex IPA, with rich aroma of citrus, pine, red fruit",
                   ImageURL = "https://birka.bg/wp-content/uploads/2018/08/%D0%BE%D0%BF%D0%B0%D1%81%D0%B5%D0%BD.jpg",
                   StyleId = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                   BreweryId = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"), //BeerBastards
                   ABV = float.Parse("5.5"),
               },
               new Beer
               {
                   Id = Guid.Parse("631a4aff-5de7-4609-b7e1-6d8ba402adcc"),
                   Name = "Po Poleka",
                   Description = "Slightly cloudy, faint amber colour with average, frothy, slowoly osteoporosing, minimally lacing, white head. Caramel malty and citrusy, slightly leafy, hoppy aroma, hints of lemon tea, cautious doughy yeasty overtones. Taste is slightly dry, citrusy, minimally leafy, hoppy, minimally sweet caramel malty basis, hints of lemon tea, instant lemon tea, cautious smoky overtones; slightly overcarbonated.",
                   ImageURL = "https://birka.bg/wp-content/uploads/2018/10/po.jpg",
                   StyleId = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                   BreweryId = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"), //BeerBastards
                   ABV = float.Parse("5.3"),
               },
               new Beer
               {
                   Id = Guid.Parse("b9c4fd4c-dd66-4418-add3-4e8199913413"),
                   Name = "Freigeist Dirty Flamingo",
                   Description = "Unclear red, small foamy head. Rose hip, hibiscus lemon, tart notes, ice tea, grenadine, red currant Dry sourness. Medium bodied, oily watery texture, lively carbonated, tart dry sour finish. Lovely tasty beer.",
                   ImageURL = "https://birka.bg/wp-content/uploads/2019/08/dirty.jpg",
                   StyleId = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                   BreweryId = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"), //BeerBastards
                   ABV = float.Parse("5.5"),
               },
               new Beer
               {
                   Id = Guid.Parse("4d65361e-c387-463c-b7ba-deff805032e5"),
                   Name = "Bash Maistora",
                   Description = " Pours clear deep gold, almost pale amber with a thin fluffy head, some lacing but no visible rising carbonation. On the nose, brilliant ripe citrus - orange, grapefruit and tangerine. In the mouth, a touch of caramel and honey add to the citrus flavours, very slight astringency, minimal sweetness with a short - crisp - mid-bitter finish. An almost perfect IPL.",
                   ImageURL = "https://birka.bg/wp-content/uploads/2019/04/bas.jpg",
                   StyleId = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                   BreweryId = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"), //BeerBastards
                   ABV = float.Parse("4.6"),
                   Mililiters = 355
               },
               new Beer
               {
                   Id = Guid.Parse("9af21ad7-d997-4fdb-b61e-8a32b780ef8e"),
                   Name = "Faster Bastard IPA",
                   Description = "Pours clear honey-gold with a fluffy, pure white head. Rather a nice pithy, citrusy pale ale, with some bread crust, semi-ripe citrus, nips of pine. Light bodied with fine to average carbonation. Well balanced finish. ",
                   ImageURL = "https://birka.bg/wp-content/uploads/2019/11/%D0%B8%D0%BB%D0%BB.png",
                   StyleId = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                   BreweryId = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"), //BeerBastards
                   ABV = float.Parse("5.8"),
               },
               new Beer
               {
                   Id = Guid.Parse("d14758c8-3840-4b45-a861-bca2dca49de6"),
                   Name = "1 Vreme",
                   Description = " Lightly hazy straw, heavy lacing but not much head or rising carbonation. On the nose, soft floral hops with bread and honey. In the mouth, soft rich flavours similar to the aromas, smooth texture, mild bitterness into a clean finish. A really good beer-flavoured beer.",
                   ImageURL = "https://birka.bg/wp-content/uploads/2019/10/8.jpg",
                   StyleId = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                   BreweryId = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"), //BeerBastards
                   ABV = float.Parse("5.5"),
               },
               new Beer
               {
                   Id = Guid.Parse("781a1380-ad56-4717-94de-89fbe6997213"),
                   Name = "Hot Takova",
                   Description = "Smoked chilli porter brewed with Rhombus Craft Brewery",
                   ImageURL = "https://birka.bg/wp-content/uploads/2018/10/%D1%85%D0%BE.jpg",
                   StyleId = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                   BreweryId = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"), //BeerBastards
                   ABV = float.Parse("5.5"),
               },
               new Beer
               {
                   Id = Guid.Parse("e2e4bfd0-95e8-4b19-8666-731594961eb1"),
                   Name = "Dami Kanyat",
                   Description = "A stout brewed with bulgarian chestnut.",
                   ImageURL = "https://birka.bg/wp-content/uploads/2018/11/da.png",
                   StyleId = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                   BreweryId = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"), //BeerBastards
                   ABV = float.Parse("5.5")
               }
            };
            builder.Entity<Beer>().HasData(beers);

            var breweries = new List<Brewery>
            {
                new Brewery
                {
                    Id = Guid.Parse("89e0215e-2726-489b-8d63-b851b997f622"),
                    Name = "KamenitzaAD",
                    CountryId = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b")
                },
                new Brewery
                {
                    Id = Guid.Parse("3d046341-8215-453d-8647-cc5a63d039fb"),
                    Name = "Beer Bastards - Papa Brewery - Burgas",
                    CountryId = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b")
                },
                 new Brewery
                 {
                     Id = Guid.Parse("70dc3f24-6681-4ca0-9a67-9e3e78fa8b93"),
                     Name = "Unknown",
                     CountryId = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b")
                 }};
            builder.Entity<Brewery>().HasData(breweries);

            var countries = new List<Country>
            {
                new Country
                {
                    Id = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b"),
                    Name = "Bulgaria"
                },
                new Country
                {
                    Id = Guid.Parse("f444594e-5626-4c1e-b285-571f33930010"),
                    Name = "Serbia",
                },
                new Country
                {
                    Id = Guid.Parse("e0932858-11cb-4a27-87f2-8756649b8c86"),
                    Name = "Germany",
                },
                new Country
                {
                    Id = Guid.Parse("56e91350-598b-4f55-94d9-eefd329f1861"),
                    Name = "Romania",
                },
                new Country
                {
                    Id = Guid.Parse("7c1703b1-3f2a-4979-a9f0-7a176960c470"),
                    Name = "Unknown",
                }
            };
            builder.Entity<Country>().HasData(countries);

            var styles = new List<Style>
            {
                new Style
                {
                    Id = Guid.Parse("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                    Name = "Pale Ale",
                    Description = "The classic Pale Ale is generally a deep-golden to copper colored, hop-forward ale with a balanced malt profile. This style specifically represents all generic Pale Ales (sometime called International Pale Ale) which are marketed as such and which cannot be defined as a specific regional Pale Ale style such as the American Pale Ale. This also includes beers marketed as Extra Pale Ale (XPA), a non-defined style that usually sits between an American Pale Ale and an India Pale Ale, a hop forward beer and generally more intense than an APA but not as hop-forward as an IPA. Sometimes, the XPA also refers to a session-strength or simply paler Pale Ale."

                },
                 new Style
                 {
                     Id = Guid.Parse("f32de916-9ea8-4f93-96d2-732d1b01fe8e"),
                     Name = "Unknown",
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
                    Content = "This is exellent beer",
                    Rating = 5,
                    Likes = 120,
                    IsFlagged = false,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    DeletedOn = null,
                    ModifiedOn = null,
                    BeerId = Guid.Parse("133e0d92-cedc-40a7-b8fd-e5669611b3dc"),
                }
            };
            builder.Entity<Review>().HasData(reviews);
        }
        //TODO: Map
    }
}