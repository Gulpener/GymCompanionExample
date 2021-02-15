using GJ.CQRSCore.Interfaces;
using GJ.CQRSCore.Validation;
using GymCompanion.Data.Models;
using GymCompanion.Models;
using GymCompanion.Models.Commands;
using MongoDbCore.Interfaces;
using System.Linq;

namespace GymCompanion.BusinessLogic.Validators
{
    public class UpdateOrAddDeviceCommandValidator : IValidator<UpdateOrAddDeviceCommand>
    {
        private readonly IData<DeviceDataModel> _deviceData;
        public UpdateOrAddDeviceCommandValidator(IData<DeviceDataModel> deviceData)
        {
            _deviceData = deviceData;
        }

        public ValidationResults Validate(ValidationResults results, UpdateOrAddDeviceCommand command)
        {
            results.ValidateNotNullOrEmpty(command.DeviceModel.Name, nameof(command.DeviceModel.Name));
            results = ValidateObjectWithNameExists(results, command.DeviceModel);
            return results;
        }

        private ValidationResults ValidateObjectWithNameExists(ValidationResults results, DeviceModel model)
        {
            if (string.IsNullOrEmpty(model.Id) && !string.IsNullOrEmpty(model.Name))
            {
                if (_deviceData.GetAll().Any(x => x.Name.Equals(model.Name)))
                {
                    results.AddValidationResult(nameof(model.Name), "A devicemodel with this {0}, is already in the database.");
                }
            }
            else if(!string.IsNullOrEmpty(model.Id) && !string.IsNullOrEmpty(model.Name))
            {
                if (_deviceData.GetAll().Where(x => x.Id.ToString() != model.Id).Any(x => x.Name.Equals(model.Name)))
                {
                    results.AddValidationResult(nameof(model.Name), "A devicemodel with this {0}, is already in the database.");
                }
            }
            return results;
        }
    }
}
