using System.ComponentModel.DataAnnotations;

namespace Colegio.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}