using BeerOverflow.Database;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.CountryServiceTests
{
    [TestClass]
    public class RetrieveById_Should
    {
        [TestMethod]
        public async Task ReturnCorrectCountryDTOWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString()); // Can also use Utils.GetOptions(nameof(ReturnCorrectCountryDTOWhen_ValidParams));
            var country = Utils.GetCountries().First();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);

                var actual = await sut.RetrieveByIdAsync(country.Id);

                Assert.AreEqual(country.Id, actual.Id);
                Assert.AreEqual(country.Name, actual.Name);
                Assert.AreEqual(country.ISO, actual.ISO);
            }
        }

        [TestMethod]
        public async Task ReturnNullWhen_NoSuchCountry()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                var actual = await sut.RetrieveByIdAsync(Guid.NewGuid());

                Assert.IsNull(actual);
            }
        }
    }
}
