using CoffeeBeansDemo.Domain.Entities;
using CoffeeBeansDemo.Infrastructure.Repository;
using CoffeeBeansDemo.Persistence;
using CoffeeBeansDemo.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using CoffeeBeansDemo.Domain.Models;

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

            await context.Database.EnsureDeletedAsync();
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
            await context.Database.EnsureDeletedAsync();
            await context.DisposeAsync();
        }

        [TestMethod]
        public async Task Should_GetCurrentBOTDAsync_work_as_expected()
        {
            var databaseContextOption = new DbContextOptionsBuilder<CoffeeBeansDemoContext>()
            .UseInMemoryDatabase(databaseName: "CoffeeBeansDbUnitTest3")
            .Options;

            CoffeeBeansDemoContext context = new CoffeeBeansDemoContext(databaseContextOption);

            var filePath = Directory.GetCurrentDirectory() + @"\TestData\data.json";
            string fileTojson = await File.ReadAllTextAsync(filePath, CancellationToken.None);

            var seedCoffeeBeandProductsList = new List<CoffeeBean>();
            List<CoffeeBean> data = JsonConvert.DeserializeAnonymousType(fileTojson, seedCoffeeBeandProductsList) ?? [];

            await context.AddRangeAsync(data, CancellationToken.None);
            await context.SaveChangesAsync();

            var inDataBOTDItem = data.Where(x => x.IsBOTD == true);
          
            CoffeeBeansRepository repo = new(context);
            var inDatabaseTbaleBOTDElment = await repo.GetCurrentBOTDAsync(CancellationToken.None);

            Assert.IsNotNull(inDataBOTDItem.First()?.Id);
            Assert.IsNotNull(inDatabaseTbaleBOTDElment?.Id);
            Assert.AreEqual(inDataBOTDItem.First().Id, inDatabaseTbaleBOTDElment.Id);
            await context.Database.EnsureDeletedAsync();
            await context.DisposeAsync();
        }


        [TestMethod]
        public async Task Should_GetSearchAsync__work_as_expected()
        {
            var databaseContextOption = new DbContextOptionsBuilder<CoffeeBeansDemoContext>()
            .UseInMemoryDatabase(databaseName: "CoffeeBeansDbUnitTest4")
            .Options;

            CoffeeBeansDemoContext context = new CoffeeBeansDemoContext(databaseContextOption);

            var filePath = Directory.GetCurrentDirectory() + @"\TestData\data.json";
            string fileTojson = await File.ReadAllTextAsync(filePath, CancellationToken.None);


            var seedCoffeeBeansProductsList = new List<CoffeeBean>() {
                new (){
                    Id = new Guid("7699A2AC-20CE-4E7A-298E-08DD8EF5890E"),
                    Index = 0,
                    Name = "ZILLAN",
                    IsBOTD  =false,
                    Cost = "23.25",
                    Image = "https://images.unsplash.com/photo-1522809269485-981d0c303355",
                    Colour = "dark roast",
                    Description = "Labore aliqua dolore quis sunt aliquip commodo aute excepteur",
                    Country = "Peru"
                },
                new CoffeeBean() {
                    Id = new Guid("5F761443-16B7-435D-298D-08DD8EF5890E"),
                    Index = 1,
                    Name = "ISONUS",
                    IsBOTD = true,
                    Cost = "23.25",
                    Image = "https://images.unsplash.com/photo-1522809269485-981d0c303355",
                    Colour = "geen",
                    Description = "description",
                    Country = "Peru"
                },
                new CoffeeBean() {
                    Id = new Guid("B83E590C-4B4C-4202-2999-08DD8EF5890E"),
                    Index = 2,
                    Name = "ZILNUS",
                    IsBOTD = false,
                    Cost = "23.25",
                    Image = "https://images.unsplash.com/photo-1522809269485-981d0c303355",
                    Colour = "geen",
                    Description = "description",
                    Country = "Peru"
                }
            };

            await context.AddRangeAsync(seedCoffeeBeansProductsList, CancellationToken.None);
            await context.SaveChangesAsync();

            CoffeeBeansRepository repo = new(context);
            // should work wih all lowercase
            var result1 = await repo.GetSearchAsync(new SearchParams() { Name = "zil"}, CancellationToken.None);
            Assert.IsTrue(result1.Count() == 2);
            
            //shoud work with mix upper and lowercase
            var result2 = await repo.GetSearchAsync(new SearchParams() { Name = "Zil" }, CancellationToken.None);
            Assert.IsTrue(result2.Count() == 2);
            
            //shoud work with uppercase
            var result3 = await repo.GetSearchAsync(new SearchParams() { Name = "ISON" }, CancellationToken.None);
            Assert.IsTrue(result3.Count() == 1);
            
            //shoud work with conatin in Description filed
            var result4 = await repo.GetSearchAsync(new SearchParams() { Description= "aliquip commodo" }, CancellationToken.None);
            Assert.IsTrue(result4.Count() == 1);

            //should work with multiple fields with and condition
            var result5 = await repo.GetSearchAsync(new SearchParams() { Name = "ISON", Description = "aliquip commodo"  }, CancellationToken.None);
            Assert.IsTrue(result5.Count() == 0);
            var result6 = await repo.GetSearchAsync(new SearchParams() { Name = "zil", Description = "aliquip commodo" }, CancellationToken.None);
            Assert.IsTrue(result6.Count() == 1);

            //shoud work with color
            var result7 = await repo.GetSearchAsync(new SearchParams() { Colour = "geen" }, CancellationToken.None);
            Assert.IsTrue(result7.Count() == 2);

            //shoud work with color
            var result8 = await repo.GetSearchAsync(new SearchParams() { Country = "Peru" }, CancellationToken.None);
            Assert.IsTrue(result8.Count() == 3);

            //shoud work with Index
            var result9 = await repo.GetSearchAsync(new SearchParams() { Index = 2 }, CancellationToken.None);
            Assert.IsTrue(result9.Count() == 1);

            //shoud work with BOTD
            var result10 = await repo.GetSearchAsync(new SearchParams() { IsBOTD =false }, CancellationToken.None);
            Assert.IsTrue(result10.Count() == 2);

            //shoud work with Id
            var result11 = await repo.GetSearchAsync(new SearchParams() { Id = "B83E590C-4B4C-4202-2999-08DD8EF5890E" }, CancellationToken.None);
            Assert.IsTrue(result11.Count() == 1);

            //shoud work with All fields  +
            var result12 = await repo.GetSearchAsync(new SearchParams()
            {
                Id = "7699A2AC-20CE-4E7A-298E-08DD8EF5890E",
                Index = 0,
                Name = "ZILLAN",
                IsBOTD = false,
                Cost = "23.25",
                Colour = "dark roast",
                Description = "Labore aliqua dolore quis sunt aliquip commodo aute excepteur",
                Country = "Peru"
            }, CancellationToken.None);
            Assert.IsTrue(result12.Count() == 1);
            //shoud work with All fields  -
            var result13 = await repo.GetSearchAsync(new SearchParams()
            {
                Id = "7699A2AC-20CE-4E7A-298E-08DD8EF5890E",
                Index = 0,
                Name = "test", // one field not matched
                IsBOTD = false,
                Cost = "23.25",
                Colour = "dark roast",
                Description = "Labore aliqua dolore quis sunt aliquip commodo aute excepteur",
                Country = "Peru"
            }, CancellationToken.None);
            Assert.IsTrue(result13.Count() == 0);

            await context.Database.EnsureDeletedAsync();
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
