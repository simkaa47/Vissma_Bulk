using Core.Models.AccesControl;

namespace Core.Contracts.Access
{
    public interface IUserAccessService
    {
        Task<IEnumerable<User>> GetAllUsersAsync(); 
        Task<IEnumerable<User>> AddUserAsync(User user);
        Task<IEnumerable<User>> DeleteUserAsync(User user);
        Task<IEnumerable<User>> UpdateUserAsync(User user);
        Task<User?> Login(Login login);


    }
}
