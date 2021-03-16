using FluentValidation;
using FluentValidation.Results;
using WebApiPhase3.Parameters;

namespace WebApiPhase3.Infrastructure.Validator
{
    public class InsertUpdateValidator : AbstractValidator<AccountParameter>, IValidatorAttribute
    {
        public InsertUpdateValidator()
        {
            this.RuleFor(rows => rows.Account)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("請輸入帳號")
                .Length(0, 30)
                .WithMessage("帳號長度過長");

            this.RuleFor(rows => rows.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("請輸入密碼")
                .Length(0, 50)
                .WithMessage("密碼長度過長");

            this.RuleFor(rows => rows.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("請輸入電話")
                .Length(0, 20)
                .WithMessage("電話長度過長");

            this.RuleFor(rows => rows.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("請輸入Email")
                .Length(0, 50)
                .WithMessage("Email 長度過長");
        }

        public ValidationResult Validator(object obj)
        {
            var validator = new InsertUpdateValidator();
            var validation = validator.Validate((AccountParameter)obj);

            return validation;
        }
    }
}
