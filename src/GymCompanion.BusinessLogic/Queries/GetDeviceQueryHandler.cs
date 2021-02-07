using CQRSCore;
using GymCompanion.BusinessLogic.Mappers;
using GymCompanion.Data.Models;
using GymCompanion.Models;
using GymCompanion.Models.Queries;
using MongoDbCore.Interfaces;

namespace GymCompanion.BusinessLogic.Queries
{
    public class GetDeviceQueryHandler : QueryHandlerBase<GetDeviceQuery, DeviceModel>
    {
        private IData<DeviceDataModel> _deviceData;
        public GetDeviceQueryHandler(IData<DeviceDataModel> deviceData)
        {
            _deviceData = deviceData;
        }

        public override DeviceModel Handle(GetDeviceQuery command)
        {
            return _deviceData.Get(command.Id).MapToDeviceModel();
        }
    }
}
