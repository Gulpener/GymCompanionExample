using CQRSCore;
using GymCompanion.BusinessLogic.Mappers;
using GymCompanion.Data.Models;
using GymCompanion.Models;
using GymCompanion.Models.Queries;
using MongoDbCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GymCompanion.BusinessLogic.Queries
{
    public class GetDeviceListQueryHandler : QueryHandlerBase<GetDeviceListQuery, IList<DeviceModel>>
    {
        private IData<DeviceDataModel> _deviceData;
        public GetDeviceListQueryHandler(IData<DeviceDataModel> deviceData)
        {
            _deviceData = deviceData;
        }

        public override IList<DeviceModel> Handle(GetDeviceListQuery query)
        {
            return _deviceData.GetAll().Select(x=>x.MapToDeviceModel()).ToList();
        }
    }
}
