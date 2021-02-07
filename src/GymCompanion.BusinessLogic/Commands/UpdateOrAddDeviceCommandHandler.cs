using CQRSCore;
using GymCompanion.BusinessLogic.Mappers;
using GymCompanion.Data.Models;
using GymCompanion.Models;
using GymCompanion.Models.Commands;
using MongoDbCore.Interfaces;
using System.Collections.Generic;

namespace GymCompanion.BusinessLogic.Commands
{
    public class UpdateOrAddDeviceCommandHandler : ICommandHandler<UpdateOrAddDeviceCommand>
    {
        private IData<DeviceDataModel> _deviceData;
        public UpdateOrAddDeviceCommandHandler(IData<DeviceDataModel> deviceData)
        {
            _deviceData = deviceData;
        }

        public void Execute(UpdateOrAddDeviceCommand command)
        {
            if (!string.IsNullOrEmpty(command.DeviceModel.Id))
            {
                _deviceData.Update(command.DeviceModel.MapToDeviceDataModel());
            }
            else
            {
                _deviceData.Add(command.DeviceModel.MapToDeviceDataModel());
            }
        }
    }
}
