using Rosneft.Domain;
using Rosneft.WebApplication.Validation;
using System.ComponentModel.DataAnnotations;
using CustomValidationAttribute = Rosneft.WebApplication.Validation.CustomValidationAttribute;

namespace Rosneft.WebApplication.Dto
{
    public class RequestCardUpdateOptionsDto
    {
        [Required(ErrorMessage = $"Поле не может быть пустым")]
        [MaxLength(150, ErrorMessage = $"Максимальное количество символов для ввода в поле «Инициатор» - 150 символов.")]
        [CustomValidation]
        public string Initiator { get; set; }

        [Required(ErrorMessage = $"Поле не может быть пустым")]
        [CustomValidation]
        public string SubjectOfAppeal { get; set; }

        [Required(ErrorMessage = $"Поле не может быть пустым")]
        [MaxLength(1000, ErrorMessage = $"Максимальное количество символов для ввода в поле «Описание» - 1000 символов.")]
        public string Description { get; set; }

        [CustomDate(ErrorMessage = $"Крайний срок взятия обращения в работу должен быть позднее текущей даты")]
        public DateTime DeadlineForHiring { get; set; }
        public RequestCategory Category { get; set; }
        public int RequestCardVersion { get; set; }
    }
}
