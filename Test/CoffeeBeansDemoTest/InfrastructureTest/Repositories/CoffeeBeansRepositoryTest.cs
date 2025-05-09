using CoffeeBeansDemo.Domain.Entities;
using CoffeeBeansDemo.Infrastructure.Repository;
using CoffeeBeansDemo.Persistence;
using CoffeeBeansDemo.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CoffeeBeansDemoTest.InfrastructureTest.Repositories
{
    [TestClass]
    public class CoffeeBeansRepositoryTest
    {
        
        [TestMethod]
        public async Task Should_GetIQueryable_work_as_expected()
        {
            var databaseContextOption = new DbContextOptionsBuilder<CoffeeBeansDemoContext>()
            .UseInMemoryDatabase(databaseName: "CoffeeBeansDbUnitTest1")
            .Options;

            CoffeeBeansDemoContext context = new CoffeeBeansDemoContext(databaseContextOption);

            var filePath = Directory.GetCurrentDirectory() + @"\TestData\data.json";
            string fileTojson = await File.ReadAllTextAsync(filePath, CancellationToken.None);

            var seedCoffeeBeandProductsList = new List<CoffeeBean>();
            List<CoffeeBean> data = JsonConvert.DeserializeAnonymousType(fileTojson, seedCoffeeBeandProductsList) ?? [];
            await context.AddRangeAsync(data, CancellationToken.None);
            await context.SaveChangesAsync();

            CoffeeBeansRepository repo = new (context);
            var records = await repo.GetIQueryable().ToListAsync();

            Assert.IsTrue(records.Count == data.Count); 

            await context.DisposeAsync();
        }

        [TestMethod]
        public async Task Should_AddAsync_work_as_expected()
        {
            var databaseContextOption = new DbContextOptionsBuilder<CoffeeBeansDemoContext>()
            .UseInMemoryDatabase(databaseName: "CoffeeBeansDbUnitTest2")
            .Options;

            CoffeeBeansDemoContext context = new CoffeeBeansDemoContext(databaseContextOption);

            var filePath = Directory.GetCurrentDirectory() + @"\TestData\data.json";
            string fileTojson = await File.ReadAllTextAsync(filePath, CancellationToken.None);

            var seedCoffeeBeandProductsList = new List<CoffeeBean>();
            List<CoffeeBean> data = JsonConvert.DeserializeAnonymousType(fileTojson, seedCoffeeBeandProductsList) ?? [];
            await context.AddRangeAsync(data, CancellationToken.None);
            await context.SaveChangesAsync();

            var maxIndex = data.Select(x => x.Index).Max();
            var maxIndexElement = data.SingleOrDefault( x=> x.Index == maxIndex);
            Assert.IsNotNull(maxIndexElement);

            var newElement = new CoffeeBeanDto(maxIndexElement);
            newElement.Id = Guid.Empty;
            newElement.Index = maxIndex+1;
            newElement.Name = "TestBeans";
            
            CoffeeBeansRepository repo = new(context);
            var newRecord = await repo.AddAsync(newElement,CancellationToken.None);
            var records = await repo.GetIQueryable().ToListAsync();

            var newMaxIndex = records.Select(x => x.Index).Max();
            Assert.IsTrue(records.Count == data.Count+1);
            Assert.IsTrue(newMaxIndex == maxIndex + 1);
            await context.DisposeAsync();
        }

        // Disabled because In-Mememory not supportd transection can me used in Integration test
        //[TestMethod]
        //public async Task Should_RemoveAsync_work_as_expected()
        //{
        //    var databaseContextOption = new DbContextOptionsBuilder<CoffeeBeansDemoContext>()
        //    .UseInMemoryDatabase(databaseName: "CoffeeBeansDbUnitTest3")
        //    .Options;

        //    CoffeeBeansDemoContext context = new CoffeeBeansDemoContext(databaseContextOption);

        //    var filePath = Directory.GetCurrentDirectory() + @"\TestData\data.json";
        //    string fileTojson = await File.ReadAllTextAsync(filePath, CancellationToken.None);

        //    var seedCoffeeBeandProductsList = new List<CoffeeBean>();
        //    List<CoffeeBean> data = JsonConvert.DeserializeAnonymousType(fileTojson, seedCoffeeBeandProductsList) ?? [];
        //    await context.AddRangeAsync(data, CancellationToken.None);
        //    await context.SaveChangesAsync();

        //    var maxIndex = data.Select(x => x.Index).Max();
        //    var maxIndexElement = data.SingleOrDefault(x => x.Index == maxIndex);
        //    Assert.IsNotNull(maxIndexElement);

        //    CoffeeBeansRepository repo = new(context);
        //    var newRecord = await repo.RemoveAsync(maxIndexElement.Id, CancellationToken.None);
          
        //    Assert.IsTrue(newRecord == 1);
        //    await context.DisposeAsync();
        //}

        // Disabled because In-Mememory not supportd transection can me used in Integration test
        //[TestMethod]
        //public async Task Should_MakeBOTDAsync_work_as_expected()
        //{
        //    var databaseContextOption = new DbContextOptionsBuilder<CoffeeBeansDemoContext>()
        //    .UseInMemoryDatabase(databaseName: "CoffeeBeansDbUnitTest3")
        //    .Options;

        //    CoffeeBeansDemoContext context = new CoffeeBeansDemoContext(databaseContextOption);

        //    var filePath = Directory.GetCurrentDirectory() + @"\TestData\data.json";
        //    string fileTojson = await File.ReadAllTextAsync(filePath, CancellationToken.None);

        //    var seedCoffeeBeandProductsList = new List<CoffeeBean>();
        //    List<CoffeeBean> data = JsonConvert.DeserializeAnonymousType(fileTojson, seedCoffeeBeandProductsList) ?? [];
        //    await context.AddRangeAsync(data, CancellationToken.None);
        //    await context.SaveChangesAsync();


        //    var currantBOTD = data.Where(x => x.IsBOTD == true).SingleOrDefault();
        //    Assert.IsNotNull(currantBOTD);

        //    var nextElement = data.Where(x => x.Index == currantBOTD.Index+1).SingleOrDefault();
        //    Assert.IsNotNull(nextElement);

        //    CoffeeBeansRepository repo = new(context);
        //    var result = await repo.MakeBOTDAsync(nextElement.Id, CancellationToken.None);
        //    var records = await repo.GetIQueryable().ToListAsync();
        //    Assert.IsNotNull(records);


        //    var newCurrantBOTD = records.Where(x => x.IsBOTD == true).SingleOrDefault();
        //    var newOldCurrantBOTD = records.Where(x => x.Id == currantBOTD.Id).SingleOrDefault();
        //    Assert.IsNotNull(newCurrantBOTD);
        //    Assert.IsNotNull(newOldCurrantBOTD);
        //    Assert.IsTrue(newCurrantBOTD.IsBOTD == true);
        //    Assert.IsTrue(newOldCurrantBOTD.IsBOTD == false);

        //    await context.DisposeAsync();
        //}
    }
}
