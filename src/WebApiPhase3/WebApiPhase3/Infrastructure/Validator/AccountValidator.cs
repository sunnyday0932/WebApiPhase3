using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPhase3.Parameters;

namespace WebApiPhase3.Infrastructure.Validator
{
    public class AccountValidator : AbstractValidator<AccountParameter>, IValidatorAttribute
    {
        public AccountValidator()
        {
            this.RuleFor(x => x.Account)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("請輸入帳號")
                .Length(0, 30)
                .WithMessage("帳號長度過長");
        }

        public ValidationResult Validator(object obj)
        {
            var validator = new AccountValidator();
            var validation = validator.Validate((AccountParameter)obj);

            return validation;
        }
    }
}
