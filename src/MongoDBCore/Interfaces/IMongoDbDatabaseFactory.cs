using MongoDB.Driver;

namespace MongoDbCore.Interfaces
{
    public interface IMongoDbDatabaseFactory
    {
        IMongoDatabase CreateConnection();
    }
}
