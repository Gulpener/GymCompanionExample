using System.Collections.Generic;

namespace MongoDbCore.Interfaces
{
    public interface IData<T> where T: MongoDbBaseModel
    {
        IList<T> GetAll();
        T Get(string id);

        void Add(T model);
        void Update(T model);
        void Remove(string id);
    }
}
