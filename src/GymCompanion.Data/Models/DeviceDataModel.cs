using MongoDbCore;
using System.Collections.Generic;

namespace GymCompanion.Data.Models
{
    public class DeviceDataModel : MongoDbBaseModel
    {
        public string Name { get; set; }

        public IList<FunctionDataModel> FunctionCollection { get; set; }
    }
}
