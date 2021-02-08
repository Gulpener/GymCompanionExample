﻿using System;

namespace CQRSCore
{
    public class ValidationException : Exception
    {
        public ValidationResults ValidationResults { get; }
        public ValidationException(ValidationResults validationResults)
        {
            ValidationResults = validationResults;
        }
    }
}
