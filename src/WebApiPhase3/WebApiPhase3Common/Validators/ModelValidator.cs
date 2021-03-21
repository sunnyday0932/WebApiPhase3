using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApiPhase3Common
{
    public class ModelValidator
    {
        /// <summary>
        /// Validates the specified model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void Validate<T>(T model, string parameterName) where T : class
        {
            if (model is null)
            {
                if (string.IsNullOrWhiteSpace(parameterName))
                {
                    parameterName = nameof(model);
                }
                throw new ArgumentNullException(paramName: parameterName, message: $"{parameterName}不可為空");
            }
            var errors = new List<ValidationResult>();
            var validation = Validator.TryValidateObject(model, new ValidationContext(model), errors, true);
            if (validation.Equals(false) &&
                errors.Any().Equals(true))
            {
                var error = errors.FirstOrDefault();
                throw new ArgumentException(message: "請檢查輸入欄位", paramName: error.MemberNames.FirstOrDefault());
            }
        }
    }
}
