using FluentValidation.Results;

namespace WebApiPhase3.Infrastructure.Validator
{
    /// <summary>
    /// 
    /// </summary>
    public interface IValidatorAttribute
    {
        /// <summary>
        /// Validators the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        ValidationResult Validator(object obj);
    }
}
