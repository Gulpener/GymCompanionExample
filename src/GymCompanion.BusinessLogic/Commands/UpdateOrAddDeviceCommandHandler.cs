using CQRSCore;
using CQRSCore.Interfaces;
using GymCompanion.BusinessLogic.Mappers;
using GymCompanion.Data.Models;
using GymCompanion.Models.Commands;
using MongoDbCore.Interfaces;

namespace GymCompanion.BusinessLogic.Commands
{
    public class UpdateOrAddDeviceCommandHandler : CommandHandlerBase<UpdateOrAddDeviceCommand>
    {
        private IData<DeviceDataModel> _deviceData;
        public UpdateOrAddDeviceCommandHandler(IValidator<UpdateOrAddDeviceCommand> validator,IData<DeviceDataModel> deviceData) : base(validator)
        {
            _deviceData = deviceData;
        }

        public override void Handle(UpdateOrAddDeviceCommand command)
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
