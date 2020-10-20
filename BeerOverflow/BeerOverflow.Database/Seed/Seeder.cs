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
                // Bulgarian
                new Beer
                {
                    Id = Guid.Parse("133e0d92-cedc-40a7-b8fd-e5669611b3dc"),
                    Name = "Kamenitza",
                    ABV = float.Parse("4.4"),
                    Price = float.Parse("1.6"),
                    Description = "Light beer with an extract content of 10.2 ° P.",
                    ImageURL = "kamenitza.png",
                    Mililiters = 330,
                    StyleId = Guid.Parse("f32de916-9ea8-4f93-96d2-732d1b01fe8e"),   //Lager
                    BreweryId = Guid.Parse("89e0215e-2726-489b-8d63-b851b997f622")  //Kamenitza AD
                },
                new Beer
                {
                    Id = Guid.Parse("f13cdf0f-9f3c-4435-a107-e265e016b7d3"),
                    Name = "Kamenitza Lemon Fresh",
                    ABV = float.Parse("3.0"),
                    Price = float.Parse("1.8"),
                    Description = "Light seasonal fruit beer with an extract content of 8.3 ° P.",
                    ImageURL = "kamenitza-fresh-grapefruit.png",
                    Mililiters = 330,
                    StyleId = Guid.Parse("b06a5dbd-f993-4379-af3e-6339377503fc"),   //Fruit
                    BreweryId = Guid.Parse("89e0215e-2726-489b-8d63-b851b997f622")  //Kamenitza AD
                },
                new Beer
                {
                    Id = Guid.Parse("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                    Name = "Zagorka",
                    ABV = float.Parse("6.0"),
                    Price = float.Parse("1.9"),
                    Description = "A high-quality lager beer, the main ingredients of which are barley malt, water, hops and yeast. It is characterized by light golden color, moderate carbonation, fresh taste, with a slight aroma of malt and hops. Available on the market in glass bottles of 0.5 liters, as well as in PET bottles of 1 and 2 liters.",
                    ImageURL = "zagorka.png",
                    Mililiters = 1000,
                    StyleId = Guid.Parse("f32de916-9ea8-4f93-96d2-732d1b01fe8e"),   //Lager
                    BreweryId = Guid.Parse("0d56076c-82cb-469d-80db-afb64c7516f7")  //Zagorka AD
                },
                new Beer
                {
                    Id = Guid.Parse("f0e83b17-1a70-4b1a-9d77-05822eb6ca44"),
                    Name = "Basi Kefa",
                    ABV = float.Parse("6.7"),
                    Price = float.Parse("4.9"),
                    Description = "This beer really is BASI KEFA! White IPA with added wheat and tons of aromatic hops. Intense aroma of citrus and tropical fruits, and the taste is memorable, you can feel grapefruit, tangerine, mango. medium sweet, medium bitter fruit finish. Extremely easy to drink despite the alcohol content - 6.7!",
                    ImageURL = "basi-kefa.png",
                    Mililiters = 330,
                    IsBeerOfTheMonth = true,
                    StyleId = Guid.Parse("e662a6bf-b3e4-4c18-8e77-efd31e587b2c"),   //IPA - White
                    BreweryId = Guid.Parse("59aeb9e3-a5e9-432e-bae7-b2f5b1e45fc0")  //Beer Bastards
                },

                // Belgium
                new Beer
                {
                    Id = Guid.Parse("1855d14b-ccb6-43b8-a7b3-3936b5010293"),
                    Name = "Stella Artois",
                    ABV = float.Parse("5.2"),
                    Price = float.Parse("2.9"),
                    Description = "A Belgian pilsner of between 4.8 and 5.2 percent ABV which was first brewed by Brouwerij Artois (the Artois Brewery) in Leuven, Belgium, in 1926. Since 2008, a 4.8 percent ABV version has also been sold in Britain, Ireland, Canada and Australia. Stella Artois is now owned by Interbrew International B.V. which is a subsidiary of the world's largest brewer, Anheuser-Busch InBev SA/NV.",
                    ImageURL = "stella-artois.png",
                    Mililiters = 500,
                    StyleId = Guid.Parse("1c7f6d85-2301-411b-a5c5-dae9fcf347a3"),   //Pilsner
                    BreweryId = Guid.Parse("411a38dd-0600-4eac-b991-305f1031257c")  //Anheuser–Busch
                },
                new Beer
                {
                    Id = Guid.Parse("629bff51-3e11-4996-ac98-365a8d8a7a66"),
                    Name = "Busch",
                    ABV = float.Parse("4.3"),
                    Price = float.Parse("4.0"),
                    Description = "Busch Beer is made with the finest ingredients, including a blend of premium hops, exceptional barley malt, fine grains and crisp water. This recipe delivers a refreshingly smooth taste & easy finish.",
                    ImageURL = "busch.png",
                    Mililiters = 550,
                    StyleId = Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"),   //Pale Lager
                    BreweryId = Guid.Parse("411a38dd-0600-4eac-b991-305f1031257c")  //Anheuser–Busch
                },
                new Beer
                {
                    Id = Guid.Parse("d71a9d9d-706f-412d-adce-30c6af6a6af1"),
                    Name = "Budweiser Light",
                    ABV = float.Parse("5.0"),
                    Price = float.Parse("4.9"),
                    Description = "Budweiser is brewed with only the finest two-row and six-row barley malt, hand-selected from regional growers all across America.",
                    ImageURL = "budweiser-light.png",
                    Mililiters = 550,
                    IsBeerOfTheMonth = true,
                    StyleId = Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"),   //Pale Lager
                    BreweryId = Guid.Parse("411a38dd-0600-4eac-b991-305f1031257c")  //Anheuser–Busch
                },
                new Beer
                {
                    Id = Guid.Parse("3c40cffd-1cda-4b0b-bc8e-bd117407a98d"),
                    Name = "Duvel",
                    ABV = float.Parse("8.5"),
                    Price = float.Parse("3.0"),
                    Description = "Duvel is a natural beer with a subtle bitterness, a refined flavour and a distinctive hop character. The unique brewing process, which takes about 90 days, guarantees a pure character, delicate effervescence and a pleasant sweet taste of alcohol.",
                    ImageURL = "duvel.png",
                    Mililiters = 100,
                    StyleId = Guid.Parse("ec61fe34-c639-433d-acac-98f092392099"),   //Stout
                    BreweryId = Guid.Parse("9e2c5791-92a4-4593-add9-6530391572f9")  //Duvel Moortgat
                },
                new Beer
                {
                    Id = Guid.Parse("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"),
                    Name = "Duvel Tripel Hop",
                    ABV = float.Parse("4.5"),
                    Price = float.Parse("3.5"),
                    Description = "Ever since 2007 the brewers at Duvel have been busy innovating with a third hop variety to give Duvel a surprising twist and some extra bitterness. Each spring this results in the launch of a unique Tripel Hop, which complements the rest of the Duvel range.",
                    ImageURL = "duvel-tripel-hop.png",
                    Mililiters = 100,
                    StyleId = Guid.Parse("b06a5dbd-f993-4379-af3e-6339377503fc"),   //Fruit
                    BreweryId = Guid.Parse("9e2c5791-92a4-4593-add9-6530391572f9")  //Duvel Moortgat
                },

                // Other
                new Beer
                {
                    Id = Guid.Parse("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                    Name = "Heineken",
                    ABV = float.Parse("5.0"),
                    Price = float.Parse("2.0"),
                    Description = "A pale lager beer with 5% alcohol by volume produced by the Dutch brewing company Heineken International. Heineken beer is sold in a green bottle with a red star.",
                    ImageURL = "heineken.png",
                    Mililiters = 450,
                    StyleId = Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"),   //Pale Lager
                    BreweryId = Guid.Parse("2a281f97-d2d4-4cde-93d3-92f8aac15b9a")  //Heineken International
                },
                new Beer
                {
                    Id = Guid.Parse("6210036f-3e9e-4e90-81d3-aaafd0251391"),
                    Name = "Guinness Original",
                    ABV = float.Parse("4.2"),
                    Price = float.Parse("3.1"),
                    Description = "4.2 to 5.6% in the United States. 5% in Canada, and most of Europe; 4.2 or 4.3% ABV in Ireland and some European countries, 4.1% in Germany, 4.8% in Namibia and South Africa, and 6% in Australia and Japan.",
                    ImageURL = "guinness.png",
                    Mililiters = 500,
                    StyleId = Guid.Parse("ec61fe34-c639-433d-acac-98f092392099"),   //Stout
                    BreweryId = Guid.Parse("b35ef87f-d03a-4777-a900-3c5e2af3c4e9")  //Diageo
                },
                new Beer
                {
                    Id = Guid.Parse("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"),
                    Name = "Amstel",
                    ABV = float.Parse("3.5"),
                    Price = float.Parse("2.1"),
                    Description = "According to the Amstel website, Amstel beer is pure - filtered which creates a full-strength beer without the calories and carbohydrates.",
                    ImageURL = "amstel.png",
                    Mililiters = 660,
                    StyleId = Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"),   //Pale Lager
                    BreweryId = Guid.Parse("f51b60cc-33fb-4ad2-afb5-6248c0a2b6ab")  //Amstel Brouwerij
                },
                new Beer
                {
                    Id = Guid.Parse("14af2a6c-5376-459e-91de-b6078c5435ac"),
                    Name = "Corona",
                    ABV = float.Parse("4.5"),
                    Price = float.Parse("3.0"),
                    Description = "Corona Extra is a pale lager produced by Mexican brewery Cervecería Modelo and owned by Belgian company AB InBev. It is commonly served with a wedge of lime or lemon in the neck of the bottle to add tartness and flavour.",
                    ImageURL = "corona.png",
                    Mililiters = 330,
                    IsBeerOfTheMonth = true,
                    StyleId = Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"),   //Pale Lager
                    BreweryId = Guid.Parse("8582b4e3-3e97-47f6-a1c9-358252ddaf43")  //Grupo Modelo
                },
                new Beer
                {
                    Id = Guid.Parse("365ed501-0156-4d62-aef4-1e04c68b8ed6"),
                    Name = "London's Pride",
                    ABV = float.Parse("4.7"),
                    Price = float.Parse("3.0"),
                    Description = "London Pride is the flagship beer of Fuller's Brewery. It is sold both cask-conditioned and bottled. London Pride has been brewed at the Griffin Brewery since 1958.",
                    ImageURL = "londons-pride.png",
                    Mililiters = 550,
                    StyleId = Guid.Parse("ae339a73-e8cb-47f3-b250-a3d25c4cdedb"),   //Old Ale
                    BreweryId = Guid.Parse("2b2ee52d-89e3-4229-a704-bbfb3724cc11")  //Fuller's Brewery
                },
                new Beer
                {
                    Id = Guid.Parse("0e2cff6f-b42a-414b-8e3c-81c157909a2a"),
                    Name = "Honey Dew",
                    ABV = float.Parse("5.0"),
                    Price = float.Parse("2.7"),
                    Description = "The UK’s best-selling organic beer, Fuller’s Organic Honey Dew buzzes with a zesty edge and subtle sweetness. Approved by the Soil Association, it’s a thing of natural beauty – pure, golden sunshine in a glass.",
                    ImageURL = "honey-dew.png",
                    Mililiters = 350,
                    StyleId = Guid.Parse("b06a5dbd-f993-4379-af3e-6339377503fc"),   //Fruit
                    BreweryId = Guid.Parse("2b2ee52d-89e3-4229-a704-bbfb3724cc11")  //Fuller's Brewery
                }
            };
            builder.Entity<Beer>().HasData(beers);

            var breweries = new List<Brewery>
            {
                // Bulgaria
                new Brewery
                {
                    Id = Guid.Parse("89e0215e-2726-489b-8d63-b851b997f622"),
                    Name = "Kamenitza AD",
                    CountryId = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b")  //Bulgaria
                },
                new Brewery
                {
                    Id = Guid.Parse("0d56076c-82cb-469d-80db-afb64c7516f7"),
                    Name = "Zagorka AD",
                    CountryId = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b")  //Bulgaria
                },
                new Brewery
                {
                    Id = Guid.Parse("59aeb9e3-a5e9-432e-bae7-b2f5b1e45fc0"),
                    Name = "Beer Bastards",
                    CountryId = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b")  //Bulgaria
                },

                // Belgium
                new Brewery
                {
                    Id = Guid.Parse("411a38dd-0600-4eac-b991-305f1031257c"),
                    Name = "Anheuser–Busch",
                    CountryId = Guid.Parse("e1d02d9a-263f-4871-b685-bf63de6508c4")  //Belgium
                },
                new Brewery
                {
                    Id = Guid.Parse("9e2c5791-92a4-4593-add9-6530391572f9"),
                    Name = "Duvel Moortgat",
                    CountryId = Guid.Parse("e1d02d9a-263f-4871-b685-bf63de6508c4")  //Belgium
                },

                // Netherlands
                new Brewery
                {
                    Id = Guid.Parse("2a281f97-d2d4-4cde-93d3-92f8aac15b9a"),
                    Name = "Heineken International",
                    CountryId = Guid.Parse("ec10c1a9-eafe-4ddc-8474-cb5fec82d186")  //Netherlands
                },
                new Brewery
                {
                    Id = Guid.Parse("f51b60cc-33fb-4ad2-afb5-6248c0a2b6ab"),
                    Name = "Amstel Brouwerij",
                    CountryId = Guid.Parse("ec10c1a9-eafe-4ddc-8474-cb5fec82d186")  //Netherlands
                },

                // Other
                new Brewery
                {
                    Id = Guid.Parse("b35ef87f-d03a-4777-a900-3c5e2af3c4e9"),
                    Name = "Diageo",
                    CountryId = Guid.Parse("d60e1413-fac0-45a5-a020-c1b7e5221a67")
                },
                new Brewery
                {
                    Id = Guid.Parse("8582b4e3-3e97-47f6-a1c9-358252ddaf43"),
                    Name = "Grupo Modelo",
                    CountryId = Guid.Parse("0305d3f1-56ad-4ada-a854-30640b17120a")
                },
                new Brewery
                {
                    Id = Guid.Parse("2b2ee52d-89e3-4229-a704-bbfb3724cc11"),
                    Name = "Fuller's Brewery",
                    CountryId = Guid.Parse("71c1e52c-2f50-4ef6-99c8-451483d3df09")
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
                new Country
                {
                    Id = Guid.Parse("0305d3f1-56ad-4ada-a854-30640b17120a"),
                    Name = "Mexico",
                    ISO = "MX"
                },
                new Country
                {
                    Id = Guid.Parse("71c1e52c-2f50-4ef6-99c8-451483d3df09"),
                    Name = "United Kingdom",
                    ISO = "UK"
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
                new Style
                {
                    Id = Guid.Parse("ae339a73-e8cb-47f3-b250-a3d25c4cdedb"),
                    Name = "Old Ale",
                    Description = "The Old Ale is an light amber to very dark reddish-brown colored English ale of moderate to fairly significant alcoholic strength, bigger than standard beers, though usually not as strong or rich as barleywine and often tilted towards a maltier balance. The predominant defining quality for this style is the impression of age, which can manifest itself in different ways (complexity, lactic, Brett, oxidation, leather, vinous qualities are some recurring examples). Roughly overlapping the British Strong Ale and the lower end of the English Barley Wine styles, but always having an aged quality. Barley Wines tend to develop more of an overall mature quality, while Old Ales can show more of the barrel qualities. Old Peculier are also considered as an Old Ale."
                },
                new Style
                {
                    Id = Guid.Parse("e662a6bf-b3e4-4c18-8e77-efd31e587b2c"),
                    Name = "IPA - White",
                    Description = "White IPAs are clear or hazy, golden-colored beers that are a hybrid of the hop-forward American India pale ale style and the traditional Belgian wit style."
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
                    BeerId = Guid.Parse("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),    //Zagorka
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619")
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
                    BeerId = Guid.Parse("1855d14b-ccb6-43b8-a7b3-3936b5010293"),    //Stella Artois
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
                    BeerId = Guid.Parse("f13cdf0f-9f3c-4435-a107-e265e016b7d3"),    //Kamenitza Lemon Fresh
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619")
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
                    BeerId = Guid.Parse("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),    //Zagorka
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")
                },
                new Review
                {
                    Id = Guid.Parse("ea4c9558-3832-403c-b70e-7ad0ef13b0a9"),
                    Content = "50/50. Sometimes win, sometimes lun.",
                    Likes = 14,
                    IsFlagged = false,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    DeletedOn = null,
                    ModifiedOn = null,
                    BeerId = Guid.Parse("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),     //Heineken
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")
                },
                new Review
                {
                    Id = Guid.Parse("ad9f46e6-5bcf-44f7-89cc-0325be7c20de"),
                    Content = "Very unexpected. Be careful around it!",
                    Likes = 19,
                    IsFlagged = false,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    DeletedOn = null,
                    ModifiedOn = null,
                    BeerId = Guid.Parse("14af2a6c-5376-459e-91de-b6078c5435ac"),    //Corona
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619")
                },
                new Review
                {
                    Id = Guid.Parse("f404463b-440d-4a45-ae57-6a00df49212e"),
                    Content = "I am scared of that beer.",
                    Likes = 200,
                    IsFlagged = false,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    DeletedOn = null,
                    ModifiedOn = null,
                    BeerId = Guid.Parse("14af2a6c-5376-459e-91de-b6078c5435ac"),    //Corona
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619")
                }
            };
            builder.Entity<Review>().HasData(reviews);

            var users = new List<User>
            {
                new User
                {
                    Id = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                    //Name = "Maggie",
                    UserName = "Maggie",
                    Email = "maggieemail@gmail.com",
                    //Password = "MaggiePass",
                    //Birthday = DateTime.Now,
                    //IsBanned = false,
                    //IsAdmin = true
                },
                new User
                {
                    Id = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                    //Name = "Ali",
                    UserName = "Ali",
                    Email = "aliemail@gmail.com",
                    //Password = "AliPass",
                    //Birthday = DateTime.Now,
                    //IsBanned = false,
                    //IsAdmin = true
                },
                new User
                {
                    Id = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),
                    //Name = "Telerik",
                    UserName = "Telerik",
                    Email = "telerikemail@gmail.com",
                    //Password = "TelerikPass",
                    //Birthday = DateTime.Now,
                    //IsBanned = false,
                    //IsAdmin = false
                }
            };
            builder.Entity<User>().HasData(users);

            var ratings = new List<Rating>()
            {
                new Rating
                {
                    Id = Guid.Parse("8361b282-628c-4a5f-85c0-7ff31b62f8ce"),
                    RatingGiven = 3,
                    BeerId = Guid.Parse("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                },
                new Rating
                {
                    Id = Guid.Parse("c5f9dde1-b7c4-4e82-8a25-56e4bd80f529"),
                    RatingGiven = 1,
                    BeerId = Guid.Parse("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                },
                new Rating
                {
                    Id = Guid.Parse("20d56571-b75b-4786-8ed0-8ea0f0d52b30"),
                    RatingGiven = 5,
                    BeerId = Guid.Parse("6210036f-3e9e-4e90-81d3-aaafd0251391"),
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                },
                new Rating
                {
                    Id = Guid.Parse("288283ac-3bc8-478e-9dbf-15f02a26b6c9"),
                    RatingGiven = 4,
                    BeerId = Guid.Parse("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),    //Heineken
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),
                },
                new Rating
                {
                    Id = Guid.Parse("e0abf438-1977-44d9-b2c6-67dc12d589e7"),
                    RatingGiven = 2,
                    BeerId = Guid.Parse("14af2a6c-5376-459e-91de-b6078c5435ac"),    //Corona
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),
                },
                new Rating
                {
                    Id = Guid.Parse("11d42d94-5526-4a32-bb14-622d5ee84fa5"),
                    RatingGiven = 5,
                    BeerId = Guid.Parse("14af2a6c-5376-459e-91de-b6078c5435ac"),    //Corona
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // TODO: There shouldn't be more then one raiting from a user!
                }
            };
            builder.Entity<Rating>().HasData(ratings);
        }
        //TODO: Map
    }
}