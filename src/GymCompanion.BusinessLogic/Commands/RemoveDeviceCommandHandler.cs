using CQRSCore;
using GymCompanion.Data.Models;
using GymCompanion.Models.Commands;
using MongoDbCore.Interfaces;

namespace GymCompanion.BusinessLogic.Commands
{
    public class RemoveDeviceCommandHandler : ICommandHandler<RemoveDeviceCommand>
    {
        private IData<DeviceDataModel> _deviceData;
        public RemoveDeviceCommandHandler(IData<DeviceDataModel> deviceData)
        {
            _deviceData = deviceData;
        }

        public void Execute(RemoveDeviceCommand command)
        {
            _deviceData.Remove(command.Id);
        }
    }
}
