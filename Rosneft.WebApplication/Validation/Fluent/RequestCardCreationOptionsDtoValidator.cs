using FluentValidation;
using Rosneft.WebApplication.Dto;
using System.Text.RegularExpressions;

namespace Rosneft.WebApplication.Validation.Fluent
{
    /// <summary>
    /// Просто для примера, решил оставить валидацию в виде Атрибутов
    /// </summary>
    public class RequestCardCreationOptionsDtoValidator : AbstractValidator<RequestCardCreationOptionsDto>
    {
        private const string Pattern = @"^[^\p{N}]+$";
        public RequestCardCreationOptionsDtoValidator()
        {
            RuleFor(x => x.Initiator)
                .NotEmpty()
                .MaximumLength(150)
                .Must(initiator => IsValid(initiator))
                .WithMessage("Недопустимые символы для ввода: арабские цифры");
        }

        private bool IsValid(string initiator)
        {
            if (initiator != null)
            {
                if (!Regex.IsMatch(initiator, Pattern))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
