using CQRSCore;
using CQRSCore.Interfaces;
using GymCompanion.Models.Queries;

namespace GymCompanion.BusinessLogic.Validators
{
    public class GetDeviceQueryValidator : IValidator<GetDeviceQuery>
    {
        public ValidationResults Validate(ValidationResults results, GetDeviceQuery query)
        {
            results = ValidateIdNotNull(results, query.Id);

            return results;
        }

        private ValidationResults ValidateIdNotNull(ValidationResults results, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                results.AddValidationResult(nameof(id), "{0} cannot be null or empty");
            }
            return results;
        }
    }
}
