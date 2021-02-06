using MongoDbCore;

namespace GymCompanion.Data.Models
{
    public class FunctionDataModel : MongoDbBaseModel
    {
        public string Name { get; set; }
    }
}
