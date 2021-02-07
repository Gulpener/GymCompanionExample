using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MongoDbCore
{
    public class GenericData<T> : IData<T> where T: MongoDbBaseModel
    {
        private readonly IMongoCollection<T> modelCollection;

        public GenericData(IMongoDbDatabaseFactory databaseFactory)
        {
            var database = databaseFactory.CreateConnection();
       
            modelCollection = database.GetCollection<T>(typeof(T).Name);
        }

        public T Get(string id)
        {
            return modelCollection.Find(x => x.Id == ObjectId.Parse(id)).FirstOrDefault();
        }        

        public IList<T> GetAll()
        {
            return modelCollection
                .Find(Builders<T>.Filter.Empty)
                .ToList()
                .Select(x=> x)
                .ToList();
        }

        public void Add(T model)
        {
            modelCollection.InsertOne(model);
        }

        public void Remove(string id)
        {
            modelCollection.FindOneAndDelete(x => x.Id == ObjectId.Parse(id));
        }

        public void Update(T model)
        {
            modelCollection.FindOneAndReplace(x=>x.Id == model.Id, model);
        }
    }
}
