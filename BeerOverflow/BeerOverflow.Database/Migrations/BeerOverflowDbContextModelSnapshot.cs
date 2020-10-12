﻿// <auto-generated />
using System;
using BeerOverflow.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeerOverflow.Database.Migrations
{
    [DbContext(typeof(BeerOverflowDbContext))]
    partial class BeerOverflowDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerOverflow.Models.Beer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ABV")
                        .HasColumnType("real");

                    b.Property<Guid>("BreweryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBeerOfTheMonth")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnlisted")
                        .HasColumnType("bit");

                    b.Property<int>("Mililiters")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("StyleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.HasIndex("StyleId");

                    b.ToTable("Beers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("133e0d92-cedc-40a7-b8fd-e5669611b3dc"),
                            ABV = 4.4f,
                            BreweryId = new Guid("89e0215e-2726-489b-8d63-b851b997f622"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Light beer with an extract content of 10.2 ° P.",
                            ImageURL = "https://www.kamenitza.bg/-/media/kamenitza/products/images/kamtnitza-1881.ashx",
                            IsBeerOfTheMonth = false,
                            IsDeleted = false,
                            IsUnlisted = false,
                            Mililiters = 330,
                            Name = "Kamenitza",
                            Price = 1.6000000238418579,
                            StyleId = new Guid("f32de916-9ea8-4f93-96d2-732d1b01fe8e")
                        },
                        new
                        {
                            Id = new Guid("f13cdf0f-9f3c-4435-a107-e265e016b7d3"),
                            ABV = 3f,
                            BreweryId = new Guid("89e0215e-2726-489b-8d63-b851b997f622"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Light seasonal fruit beer with an extract content of 8.3 ° P.",
                            ImageURL = "https://www.kamenitza.bg/-/media/kamenitza/products/images/kamenitza-fresh-grapefruit.ashx",
                            IsBeerOfTheMonth = false,
                            IsDeleted = false,
                            IsUnlisted = false,
                            Mililiters = 330,
                            Name = "Kamenitza Lemon Fresh",
                            Price = 1.7999999523162842,
                            StyleId = new Guid("b06a5dbd-f993-4379-af3e-6339377503fc")
                        },
                        new
                        {
                            Id = new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"),
                            ABV = 5.2f,
                            BreweryId = new Guid("411a38dd-0600-4eac-b991-305f1031257c"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A Belgian pilsner of between 4.8 and 5.2 percent ABV which was first brewed by Brouwerij Artois (the Artois Brewery) in Leuven, Belgium, in 1926. Since 2008, a 4.8 percent ABV version has also been sold in Britain, Ireland, Canada and Australia. Stella Artois is now owned by Interbrew International B.V. which is a subsidiary of the world's largest brewer, Anheuser-Busch InBev SA/NV.",
                            ImageURL = "https://shortysliquor.com.au/media/catalog/product/cache/2fcc3329aef4183c8e06230d7e06f8f3/1/1/11760.1_4.png",
                            IsBeerOfTheMonth = false,
                            IsDeleted = false,
                            IsUnlisted = false,
                            Mililiters = 500,
                            Name = "Stella Artois",
                            Price = 2.9000000953674316,
                            StyleId = new Guid("1c7f6d85-2301-411b-a5c5-dae9fcf347a3")
                        },
                        new
                        {
                            Id = new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                            ABV = 5f,
                            BreweryId = new Guid("2a281f97-d2d4-4cde-93d3-92f8aac15b9a"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A pale lager beer with 5% alcohol by volume produced by the Dutch brewing company Heineken International. Heineken beer is sold in a green bottle with a red star.",
                            ImageURL = "https://www.heineken.com/media-us/01pfxdqq/heineken-original-bottle.png?quality=85",
                            IsBeerOfTheMonth = false,
                            IsDeleted = false,
                            IsUnlisted = false,
                            Mililiters = 450,
                            Name = "Heineken",
                            Price = 2.0,
                            StyleId = new Guid("77f9496e-0475-4165-ac5e-ee57039f108c")
                        },
                        new
                        {
                            Id = new Guid("6210036f-3e9e-4e90-81d3-aaafd0251391"),
                            ABV = 4.2f,
                            BreweryId = new Guid("b35ef87f-d03a-4777-a900-3c5e2af3c4e9"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "4.2 to 5.6% in the United States. 5% in Canada, and most of Europe; 4.2 or 4.3% ABV in Ireland and some European countries, 4.1% in Germany, 4.8% in Namibia and South Africa, and 6% in Australia and Japan.",
                            ImageURL = "https://carlsbergukraine.com/media/9616/guinness_ophoto_shot_02_1_go_sr.png",
                            IsBeerOfTheMonth = false,
                            IsDeleted = false,
                            IsUnlisted = false,
                            Mililiters = 500,
                            Name = "Guinness Original",
                            Price = 3.0999999046325684,
                            StyleId = new Guid("ec61fe34-c639-433d-acac-98f092392099")
                        },
                        new
                        {
                            Id = new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"),
                            ABV = 3.5f,
                            BreweryId = new Guid("f51b60cc-33fb-4ad2-afb5-6248c0a2b6ab"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "According to the Amstel website, Amstel beer is pure - filtered which creates a full-strength beer without the calories and carbohydrates.",
                            ImageURL = "https://grocerytrader.co.uk/wp-content/uploads/2016/05/Amstel-650ml-btl5.jpg",
                            IsBeerOfTheMonth = false,
                            IsDeleted = false,
                            IsUnlisted = false,
                            Mililiters = 660,
                            Name = "Amstel",
                            Price = 2.0999999046325684,
                            StyleId = new Guid("77f9496e-0475-4165-ac5e-ee57039f108c")
                        },
                        new
                        {
                            Id = new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                            ABV = 6f,
                            BreweryId = new Guid("0d56076c-82cb-469d-80db-afb64c7516f7"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A high-quality lager beer, the main ingredients of which are barley malt, water, hops and yeast. It is characterized by light golden color, moderate carbonation, fresh taste, with a slight aroma of malt and hops. Available on the market in glass bottles of 0.5 liters, as well as in PET bottles of 1 and 2 liters.",
                            ImageURL = "https://www.zagorka.bg/img/product/specialno/img-1l.png",
                            IsBeerOfTheMonth = false,
                            IsDeleted = false,
                            IsUnlisted = false,
                            Mililiters = 1000,
                            Name = "Zagorka",
                            Price = 1.8999999761581421,
                            StyleId = new Guid("f32de916-9ea8-4f93-96d2-732d1b01fe8e")
                        });
                });

            modelBuilder.Entity("BeerOverflow.Models.Brewery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Breweries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("89e0215e-2726-489b-8d63-b851b997f622"),
                            CountryId = new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Kamenitza AD"
                        },
                        new
                        {
                            Id = new Guid("411a38dd-0600-4eac-b991-305f1031257c"),
                            CountryId = new Guid("e1d02d9a-263f-4871-b685-bf63de6508c4"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Anheuser–Busch InBev"
                        },
                        new
                        {
                            Id = new Guid("2a281f97-d2d4-4cde-93d3-92f8aac15b9a"),
                            CountryId = new Guid("ec10c1a9-eafe-4ddc-8474-cb5fec82d186"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Heineken International"
                        },
                        new
                        {
                            Id = new Guid("b35ef87f-d03a-4777-a900-3c5e2af3c4e9"),
                            CountryId = new Guid("d60e1413-fac0-45a5-a020-c1b7e5221a67"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Diageo"
                        },
                        new
                        {
                            Id = new Guid("f51b60cc-33fb-4ad2-afb5-6248c0a2b6ab"),
                            CountryId = new Guid("ec10c1a9-eafe-4ddc-8474-cb5fec82d186"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Amstel Brouwerij"
                        },
                        new
                        {
                            Id = new Guid("0d56076c-82cb-469d-80db-afb64c7516f7"),
                            CountryId = new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Zagorka AD"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ISO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISO = "BG",
                            IsDeleted = false,
                            Name = "Bulgaria"
                        },
                        new
                        {
                            Id = new Guid("e1d02d9a-263f-4871-b685-bf63de6508c4"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISO = "BE",
                            IsDeleted = false,
                            Name = "Belgium"
                        },
                        new
                        {
                            Id = new Guid("ec10c1a9-eafe-4ddc-8474-cb5fec82d186"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISO = "NL",
                            IsDeleted = false,
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = new Guid("d60e1413-fac0-45a5-a020-c1b7e5221a67"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISO = "IE",
                            IsDeleted = false,
                            Name = "Ireland"
                        },
                        new
                        {
                            Id = new Guid("f444594e-5626-4c1e-b285-571f33930022"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISO = "RS",
                            IsDeleted = false,
                            Name = "Serbia"
                        },
                        new
                        {
                            Id = new Guid("e0932858-11cb-4a27-87f2-8756649b8c88"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISO = "DE",
                            IsDeleted = false,
                            Name = "Germany"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Models.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BeerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RatingGiven")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8361b282-628c-4a5f-85c0-7ff31b62f8ce"),
                            BeerId = new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            RatingGiven = 3,
                            UserId = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5")
                        },
                        new
                        {
                            Id = new Guid("c5f9dde1-b7c4-4e82-8a25-56e4bd80f529"),
                            BeerId = new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            RatingGiven = 1,
                            UserId = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270")
                        },
                        new
                        {
                            Id = new Guid("20d56571-b75b-4786-8ed0-8ea0f0d52b30"),
                            BeerId = new Guid("6210036f-3e9e-4e90-81d3-aaafd0251391"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            RatingGiven = 5,
                            UserId = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5")
                        });
                });

            modelBuilder.Entity("BeerOverflow.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BeerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFlagged")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("03461e43-1ebb-4035-8fa4-e5acf5c923f1"),
                            BeerId = new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                            Content = "This is exellent beer!",
                            CreatedOn = new DateTime(2020, 10, 12, 0, 37, 13, 205, DateTimeKind.Local).AddTicks(178),
                            IsDeleted = false,
                            IsFlagged = false,
                            Likes = 120,
                            UserId = new Guid("3753d26b-5a35-491f-ae82-5238d243b619")
                        },
                        new
                        {
                            Id = new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                            BeerId = new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"),
                            Content = "I didn't really like it. Poor colour, bad taste.",
                            CreatedOn = new DateTime(2020, 10, 12, 0, 37, 13, 208, DateTimeKind.Local).AddTicks(4003),
                            IsDeleted = false,
                            IsFlagged = false,
                            Likes = 8,
                            ModifiedOn = new DateTime(2020, 10, 13, 0, 37, 13, 208, DateTimeKind.Local).AddTicks(4086),
                            UserId = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5")
                        },
                        new
                        {
                            Id = new Guid("bc9fa1aa-d58a-4f37-a81d-7a7ca81f27bb"),
                            BeerId = new Guid("f13cdf0f-9f3c-4435-a107-e265e016b7d3"),
                            Content = "It's okay I guess. Very fruity aroma. Light sour, strong sweet taste. Fruity.",
                            CreatedOn = new DateTime(2020, 10, 12, 0, 37, 13, 208, DateTimeKind.Local).AddTicks(4715),
                            IsDeleted = false,
                            IsFlagged = false,
                            Likes = 22,
                            UserId = new Guid("3753d26b-5a35-491f-ae82-5238d243b619")
                        },
                        new
                        {
                            Id = new Guid("766d9e58-68da-479c-ab97-dc9d1de06bbc"),
                            BeerId = new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"),
                            Content = "Absolutely amazing!. One of the best Bulgarian beers.",
                            CreatedOn = new DateTime(2020, 10, 12, 0, 37, 13, 208, DateTimeKind.Local).AddTicks(4730),
                            IsDeleted = false,
                            IsFlagged = false,
                            Likes = 0,
                            UserId = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270")
                        });
                });

            modelBuilder.Entity("BeerOverflow.Models.Style", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Styles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f32de916-9ea8-4f93-96d2-732d1b01fe8e"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lager is a type of beer conditioned at low temperature. Lagers can be pale, amber, or dark.",
                            IsDeleted = false,
                            Name = "Lager"
                        },
                        new
                        {
                            Id = new Guid("b06a5dbd-f993-4379-af3e-6339377503fc"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Fruit beer is beer made with fruit added as an adjunct or flavouring. Lambics, beers originating in the valley of the Zenne (in an around Brussels) Belgium, though copied by brewers in other parts of the world, may be refermented with cherries to make kriek, or fermented with raspberries to make framboise.",
                            IsDeleted = false,
                            Name = "Fruit"
                        },
                        new
                        {
                            Id = new Guid("1c7f6d85-2301-411b-a5c5-dae9fcf347a3"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pilsner (also pilsener or simply pils) is a type of pale lager. It takes its name from the Czech city of Pilsen, where it was first produced in 1842 by Bavarian brewer Josef Groll. The world's first pale lager, the original Pilsner Urquell, is still produced there today.",
                            IsDeleted = false,
                            Name = "Pilsner"
                        },
                        new
                        {
                            Id = new Guid("77f9496e-0475-4165-ac5e-ee57039f108c"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pale lager is a very pale-to-golden-colored lager beer with a well-attenuated body and a varying degree of noble hop bitterness.",
                            IsDeleted = false,
                            Name = "Pale Lager"
                        },
                        new
                        {
                            Id = new Guid("ec61fe34-c639-433d-acac-98f092392099"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Stout is a dark, top-fermented beer with a number of variations, including dry stout, oatmeal stout, milk stout, and imperial stout. The first known use of the word stout for beer was in a document dated 1677 found in the Egerton Manuscripts, the sense being that a \"stout beer\" was a strong beer, not a dark beer.",
                            IsDeleted = false,
                            Name = "Stout"
                        },
                        new
                        {
                            Id = new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The classic Pale Ale is generally a deep-golden to copper colored, hop-forward ale with a balanced malt profile. This style specifically represents all generic Pale Ales (sometime called International Pale Ale) which are marketed as such and which cannot be defined as a specific regional Pale Ale style such as the American Pale Ale. This also includes beers marketed as Extra Pale Ale (XPA), a non-defined style that usually sits between an American Pale Ale and an India Pale Ale, a hop forward beer and generally more intense than an APA but not as hop-forward as an IPA. Sometimes, the XPA also refers to a session-strength or simply paler Pale Ale.",
                            IsDeleted = false,
                            Name = "Pale Ale"
                        },
                        new
                        {
                            Id = new Guid("96cc020a-753d-4483-9531-02b0a83b0a66"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Brut India Pale Ale (IPA) is a very pale to light golden, very dry, highly effervescent variant of American IPA, usually highly hopped with aromatic hops, but with far less actual bitterness. Enzymes are used in the mash and/or fermenter along with highly fermentable wort and often adjuncts like rice and corn to achieve close to total attenuation, resulting in an absent residual malt sweetness. Hopped in a similar fashion to New England IPA, but without sweetness. Pale like a West Coast IPA, but without high bitterness. Highly carbonated like a Belgian Golden Strong ale, but even drier, and without Belgian spice and phenol character.",
                            IsDeleted = false,
                            Name = "IPA - Brut"
                        },
                        new
                        {
                            Id = new Guid("bad58025-7855-482b-8f96-e74c4c122a9b"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The English India Pale Ale (IPA) is a hoppy, moderately-strong, very well-attenuated pale golden to deep amber British ale with a dry finish and a hoppy aroma and flavor. Generally will have more finish hops and less fruitiness and/or caramel than British pale ales and bitter and has less hop intensity and a more pronounced malt flavor than typical American versions. The modern IPA style generally refers to American IPA and its derivatives but this does not imply that English IPA isn't a proper IPA. Originally, the attributes of IPA that were important to its arrival in good condition from England to India by ship were that it was very well-attenuated, and heavily hopped.",
                            IsDeleted = false,
                            Name = "IPA - English"
                        },
                        new
                        {
                            Id = new Guid("ae339a73-e8cb-47f3-b250-a3d25c4cdedb"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Old Ale is an light amber to very dark reddish-brown colored English ale of moderate to fairly significant alcoholic strength, bigger than standard beers, though usually not as strong or rich as barleywine and often tilted towards a maltier balance. The predominant defining quality for this style is the impression of age, which can manifest itself in different ways (complexity, lactic, Brett, oxidation, leather, vinous qualities are some recurring examples). Roughly overlapping the British Strong Ale and the lower end of the English Barley Wine styles, but always having an aged quality. Barley Wines tend to develop more of an overall mature quality, while Old Ales can show more of the barrel qualities. Old Peculier are also considered as an Old Ale.",
                            IsDeleted = false,
                            Name = "Old Ale"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                            Birthday = new DateTime(2020, 10, 12, 0, 37, 13, 209, DateTimeKind.Local).AddTicks(3931),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "maggieemail@gmail.com",
                            IsAdmin = true,
                            IsBanned = false,
                            IsDeleted = false,
                            Name = "Maggie",
                            Password = "MaggiePass",
                            Username = "MaggieUser"
                        },
                        new
                        {
                            Id = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                            Birthday = new DateTime(2020, 10, 12, 0, 37, 13, 209, DateTimeKind.Local).AddTicks(6724),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "aliemail@gmail.com",
                            IsAdmin = true,
                            IsBanned = false,
                            IsDeleted = false,
                            Name = "Ali",
                            Password = "AliPass",
                            Username = "AliUser"
                        },
                        new
                        {
                            Id = new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                            Birthday = new DateTime(2020, 10, 12, 0, 37, 13, 209, DateTimeKind.Local).AddTicks(6784),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "telerikemail@gmail.com",
                            IsAdmin = false,
                            IsBanned = false,
                            IsDeleted = false,
                            Name = "Telerik",
                            Password = "TelerikPass",
                            Username = "TelerikUser"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Models.Beer", b =>
                {
                    b.HasOne("BeerOverflow.Models.Brewery", "Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Models.Style", "Style")
                        .WithMany("Beers")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeerOverflow.Models.Brewery", b =>
                {
                    b.HasOne("BeerOverflow.Models.Country", "Country")
                        .WithMany("Breweries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeerOverflow.Models.Rating", b =>
                {
                    b.HasOne("BeerOverflow.Models.Beer", "Beer")
                        .WithMany("Ratings")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Models.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeerOverflow.Models.Review", b =>
                {
                    b.HasOne("BeerOverflow.Models.Beer", "Beer")
                        .WithMany("Reviews")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
