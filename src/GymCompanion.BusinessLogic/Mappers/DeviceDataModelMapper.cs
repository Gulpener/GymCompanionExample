using GymCompanion.Data.Models;
using GymCompanion.Models;
using MongoDB.Bson;
using System.Linq;

namespace GymCompanion.BusinessLogic.Mappers
{
    public static class DeviceDataModelMapper
    {
        public static DeviceModel MapToDeviceModel(this DeviceDataModel dataModel)
        {
            return new DeviceModel()
            {
                Id = dataModel.Id.ToString(),
                Name = dataModel.Name,
                FunctionCollection = dataModel.FunctionCollection?.Select(x => x.MapToFunctionModel()).ToList()
            };
        }
        public static FunctionModel MapToFunctionModel(this FunctionDataModel dataModel)
        {
            return new FunctionModel()
            {
                Id = dataModel.Id.ToString(),
                Name = dataModel.Name,
            };
        }

        public static DeviceDataModel MapToDeviceDataModel(this DeviceModel model)
        {
            return new DeviceDataModel()
            {
                Id = string.IsNullOrEmpty(model.Id) ? ObjectId.GenerateNewId() : ObjectId.Parse(model.Id),
                Name = model.Name,
                FunctionCollection = model.FunctionCollection?.Select(x => x.MapToFunctionDataModel()).ToList()
            };
        }

        public static FunctionDataModel MapToFunctionDataModel(this FunctionModel model)
        {
            return new FunctionDataModel()
            {
                Id = string.IsNullOrEmpty(model.Id) ? ObjectId.GenerateNewId() : ObjectId.Parse(model.Id),
                Name = model.Name
            };
        }
    }
}
