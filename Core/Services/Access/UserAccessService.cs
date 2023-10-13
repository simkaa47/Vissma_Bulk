using Core.Contracts.Access;
using Core.Infrastructure.DataAccess.Repositories;
using Core.Models.AccesControl;

namespace Core.Services.Access
{
    public class UserAccessService : IUserAccessService
    {
        private readonly IRepository<User> _userRepository;

        public UserAccessService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return await _userRepository.ListAllAsync();
        }

        public async Task<IEnumerable<User>> DeleteUserAsync(User user)
        {
            await _userRepository.DeleteAsync(user);
            return await _userRepository.ListAllAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return UserDataFactory.GetUsers();
        }

        public async Task<User?> Login(Login login)
        {
            var user = UserDataFactory.GetUsers().Where(u => u.Login == login.LoginName && u.Password == login.Password).FirstOrDefault();
            return user;
        }

        public async Task<IEnumerable<User>> UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
            return await _userRepository.ListAllAsync();
        }
    }
}
