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

        public async Task<Menu> GetAsync(string id) =>
            await _itemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Menu newBook) =>
            await _itemsCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Menu updatedBook) =>
              await _itemsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _itemsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
