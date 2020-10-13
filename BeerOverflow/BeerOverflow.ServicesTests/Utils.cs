using BeerOverflow.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
