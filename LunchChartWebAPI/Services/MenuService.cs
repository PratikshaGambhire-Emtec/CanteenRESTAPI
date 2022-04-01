using LunchChartWebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LunchChartWebAPI.Services
{
    public class MenuService
    {
        private readonly IMongoCollection<Menu> _itemsCollection;

        public MenuService(
            IOptions<MenuStoreDatabaseSettings> menuStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                menuStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
           menuStoreDatabaseSettings.Value.DatabaseName);

            _itemsCollection = mongoDatabase.GetCollection<Menu>(
                menuStoreDatabaseSettings.Value.MenuCollectionName);

        }
        public async Task<List<Menu>> GetAsync() =>
         await _itemsCollection.Find(_ => true).ToListAsync();

        public async Task<Menu> GetAsync(string Day) =>
            await _itemsCollection.Find(x => x.Day == Day).FirstOrDefaultAsync();

        public async Task CreateAsync(Menu newMenu) =>
            await _itemsCollection.InsertOneAsync(newMenu);

        public async Task UpdateAsync(string id, Menu updatedMenu) =>
              await _itemsCollection.ReplaceOneAsync(x => x.Id == id, updatedMenu);

        public async Task RemoveAsync(string id) =>
            await _itemsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
