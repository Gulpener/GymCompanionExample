using GJ.CQRSCore.Interfaces;

namespace GymCompanion.Models.Commands
{
    public class UpdateOrAddDeviceCommand : ICommand
    {
        public UpdateOrAddDeviceCommand(DeviceModel deviceModel)
        {
            DeviceModel = deviceModel;
        }

        public DeviceModel DeviceModel { get; }
    }
}
