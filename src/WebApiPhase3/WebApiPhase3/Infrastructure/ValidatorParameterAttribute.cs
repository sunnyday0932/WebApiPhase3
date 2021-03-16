using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPhase3.ViewModels;

namespace WebApiPhase3.Infrastructure
{
    public class ValidatorParameterAttribute : ActionFilterAttribute
    {
        private readonly Type _type;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorParameterAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public ValidatorParameterAttribute(Type type)
        {
            this._type = type;
        }

        public override async Task OnActionExecutionAsync(
            ActionExecutingContext actionContext,
            ActionExecutionDelegate next)
        {
            var errorMessage = string.Empty;

            var validator = (IValidator)Activator.CreateInstance(this._type);

            var type = actionContext.ActionArguments.First().Value.GetType().Name;

            try
            {
                var context = new ValidationContext<object>(actionContext.ActionArguments.First().Value);
                var validationResult = validator.Validate(context);

                if (!validationResult.IsValid)
                {
                    errorMessage = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                }

                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    var modelState = new FailResultViewModel()
                    {
                        Method = $"{actionContext.HttpContext.Request.Path}.{actionContext.HttpContext.Request.Method}",
                        Status = "ValidatorError",
                        Error = new FailInforMation()
                        {
                            Domain = "localhost",
                            ErrorCode = 40000,
                            Message = errorMessage,
                        }
                    };
                    actionContext.Result = new ObjectResult(modelState)
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }

                await base.OnActionExecutionAsync(actionContext, next);
            }
            catch
            { 
                await base.OnActionExecutionAsync(actionContext, next);
            }
        }
    }
}
