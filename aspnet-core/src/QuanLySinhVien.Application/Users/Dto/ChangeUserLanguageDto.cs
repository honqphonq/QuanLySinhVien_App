using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}