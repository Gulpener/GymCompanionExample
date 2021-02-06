using System;
using System.Collections.Generic;
using System.Text;

namespace GymCompanion.Models.Commands
{
    public class UpdateOrAddDeviceCommand
    {
        public UpdateOrAddDeviceCommand(DeviceModel deviceModel)
        {
            DeviceModel = deviceModel;
        }

        public DeviceModel DeviceModel { get; }
    }
}
