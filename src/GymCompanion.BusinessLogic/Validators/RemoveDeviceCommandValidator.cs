using GJ.CQRSCore;
using GJ.CQRSCore.Interfaces;
using GJ.CQRSCore.Validation;
using GymCompanion.Data.Models;
using GymCompanion.Models.Commands;
using MongoDbCore.Interfaces;

namespace GymCompanion.BusinessLogic.Validators
{
    public class RemoveDeviceCommandValidator : IValidator<RemoveDeviceCommand>
    {
        private readonly IData<DeviceDataModel> _deviceData;
        public RemoveDeviceCommandValidator(IData<DeviceDataModel> deviceData)
        {
            _deviceData = deviceData;
        }

        public ValidationResults Validate(ValidationResults results, RemoveDeviceCommand command)
        {
            results = ValidateIdNotNull(results, command.Id);
            results = ValidateObjectWithIdExists(results, command.Id);
            return results;
        }

        private ValidationResults ValidateIdNotNull(ValidationResults results, string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                results.AddValidationResult(nameof(id), "{0} cannot be null or empty");
            }
            return results;
        }

        private ValidationResults ValidateObjectWithIdExists(ValidationResults results, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var device = _deviceData.Get(id);
                if (device == null)
                {
                    results.AddValidationResult(nameof(id), "There is no object found with {0}");
                }
            }
            return results;
        }
    }
}
