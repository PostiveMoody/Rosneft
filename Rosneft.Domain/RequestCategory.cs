using System.ComponentModel.DataAnnotations;

namespace Rosneft.Domain
{
    public enum RequestCategory
    {
        [Display(Name = "")]
        None = 0,
        [Display(Name = "Консультация")]
        Consultation = 1,
        [Display(Name = "Жалоба")]
        Сomplaint = 2,
        [Display(Name = "Инцидент")]
        Incident = 3,
        [Display(Name = "Другое")]
        Other = 4,
    }
}
