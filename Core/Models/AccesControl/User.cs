using CommunityToolkit.Mvvm.ComponentModel;
using Core.Infrastructure.DataAccess.Repositories;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.AccesControl
{
    public enum UserAccessLevel
    {
        [Description("Не авторизован")]
        None,
        [Description("Сервис")]
        Service,
        [Description("Администратор")]
        Admin
    }


    public partial class User:EntityCommon
    {
        [ObservableProperty]
        [Required]
        [MinLength(3, ErrorMessage = "Login must contain at least 3 symbols")]
        private string? _login;

        [ObservableProperty]
        [Required]
        [MinLength(3, ErrorMessage = "Password name must contain at least 3 symbols")]
        private string? _password;

        [ObservableProperty]
        [Required]
        [MinLength(3, ErrorMessage = "First name must contain at least 3 symbols")]
        private string? _firstName;

        [ObservableProperty]
        [Required]
        [MinLength(3, ErrorMessage = "Last name name must contain at least 3 symbols")]
        private string? _lastName;
        [ObservableProperty]
        private UserAccessLevel _accessLevel;
        [NotMapped]
        public string FullName => $"{LastName} {FirstName}";
    }
}
