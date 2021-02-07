using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRSCore
{
    public class ValidationResults
    {
        private readonly ICollection<ValidationResult> validationResults = new List<ValidationResult>();

        public void AddValidationResult(string propertyName, string message)
        {
            validationResults.Add(new ValidationResult(propertyName, message));
        }

        internal void Handle()
        {
            if(validationResults.Any())
            {
                throw new ArgumentException(); // Todo:  Create new exception
            }    
        }
    }
}
