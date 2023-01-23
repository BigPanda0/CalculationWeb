using System.ComponentModel.DataAnnotations;

namespace WebApplication_Aimagambetov.Models.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{4,16}$", ErrorMessage = "Логин должен иметь длину от 4 до 16 символов")]
        public string Login { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8 до 20 символов")]
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
