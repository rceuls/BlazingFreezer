using MongoDB.Driver;

namespace BlazingFreezer.API.Services
{
    public class MongoService : IMongoService
    {
        private IMongoDatabase _database;

        public IMongoDatabase GetDatabase()
        {
            return _database ??= new MongoClient(new MongoUrl("mongodb://freezer:freezer-pwd@localhost:27017")).GetDatabase("freezer-dev");
        }
    }

    public interface IMongoService
    {
        IMongoDatabase GetDatabase();
    }
}