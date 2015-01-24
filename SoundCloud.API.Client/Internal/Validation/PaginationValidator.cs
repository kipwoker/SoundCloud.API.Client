using System;
using System.Collections.Generic;

#if DEBUG
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("SoundCloud.API.Client.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
#endif

namespace SoundCloud.API.Client.Internal.Validation
{
    internal class PaginationValidator : IPaginationValidator
    {
        internal static readonly IPaginationValidator Default = new PaginationValidator();

        private readonly Dictionary<ValidationParams, ValidationModel> validations = new Dictionary<ValidationParams, ValidationModel>
        {
            {ValidationParams.Offset, new ValidationModel{ PublicPropertyName = "offset", MinValue = 0, MaxValue = 8000}},
            {ValidationParams.Count, new ValidationModel{ PublicPropertyName = "limit", MinValue = 0, MaxValue = 200}},
        };

        public bool IsValid(int offset, int count, out string errorMessage)
        {
            string offsetErrorMessage, countErrorMessage;

            var errorMessages = new List<string>();

            if (!IsValid(offset, validations[ValidationParams.Offset], out offsetErrorMessage))
            {
                errorMessages.Add(offsetErrorMessage);
            }

            if (!IsValid(count, validations[ValidationParams.Count], out countErrorMessage))
            {
                errorMessages.Add(countErrorMessage);
            }

            if (errorMessages.Count > 0)
            {
                errorMessage = string.Join(Environment.NewLine, errorMessages);
                return false;
            }

            errorMessage = null;
            return true;
        }

        private static bool IsValid(int value, ValidationModel validationModel, out string errorMessage)
        {
            if (validationModel.MinValue < value || value > validationModel.MaxValue)
            {
                errorMessage = string.Format("Parameter '{0}' out of range [{1};{2}]. Current value: {3}", validationModel.PublicPropertyName, validationModel.MinValue, validationModel.MaxValue, value);
                return false;
            }

            errorMessage = null;
            return true;
        }

        private class ValidationModel
        {
            public string PublicPropertyName { get; set; }
            public int MaxValue { get; set; }
            public int MinValue { get; set; }
        }

        private enum ValidationParams
        {
            Offset,
            Count
        }
    }
}