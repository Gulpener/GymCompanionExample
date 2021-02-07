using CQRSCore.Interfaces;
using GymCompanion.Data.Models;
using GymCompanion.Models.Commands;
using MongoDbCore.Interfaces;
using System;

namespace GymCompanion.BusinessLogic.Validators
{
    public class RemoveDeviceCommandValidator : IValidator<RemoveDeviceCommand>
    {
        private readonly IData<DeviceDataModel> _deviceData;
        public RemoveDeviceCommandValidator(IData<DeviceDataModel> deviceData)
        {
            _deviceData = deviceData;
        }

        public void Validate(RemoveDeviceCommand command)
        {
            ValidateIdNotNull(command.Id);
            ValidateObjectWithIdExists(command.Id);
        }

        private void ValidateIdNotNull(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Is null or empty", id);
            }
        }

        private void ValidateObjectWithIdExists(string id)
        {
            var device = _deviceData.Get(id);
            if(device == null)
            {
                throw new ArgumentException("No object exist with that id", id);
            }
        }
    }
}
