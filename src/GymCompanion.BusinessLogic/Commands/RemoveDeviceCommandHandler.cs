using CQRSCore;
using CQRSCore.Interfaces;
using GymCompanion.Data.Models;
using GymCompanion.Models.Commands;
using MongoDbCore.Interfaces;

namespace GymCompanion.BusinessLogic.Commands
{
    public class RemoveDeviceCommandHandler : CommandHandlerBase<RemoveDeviceCommand>
    {
        private IData<DeviceDataModel> _deviceData;
        public RemoveDeviceCommandHandler(IValidator<RemoveDeviceCommand> validator, IData<DeviceDataModel> deviceData) : base(validator)
        {
            _deviceData = deviceData;
        }

        public override void Handle(RemoveDeviceCommand command)
        {
            _deviceData.Remove(command.Id);
        }
    }
}
