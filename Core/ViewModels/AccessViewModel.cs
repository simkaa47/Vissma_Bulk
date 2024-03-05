using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Contracts.Access;
using Core.Models.AccesControl;
using Microsoft.Extensions.Logging;

namespace Core.ViewModels
{
    public partial class AccessViewModel : ViewModelBase
    {

        private readonly IUserAccessService _accessService;
        private readonly ILogger<AccessViewModel> _logger;
        

        public AccessViewModel(IUserAccessService accessService, ILogger<AccessViewModel> logger)
        {
            _accessService = accessService;
            _logger = logger;            
            InitAsync();
        }


        [ObservableProperty]
        private IEnumerable<User>? _users;

        [ObservableProperty]
        private User? _selectedUser;
        
        private User? _currentUser;
        public User? CurrentUser
        {
            get => _currentUser;
            set
            {
                if(SetProperty(ref _currentUser, value) && value is not null)
                {
                    UserId = value.Id;  
                }
            }
        }

        public static int UserId;

        public async void InitAsync()
        {
            Users = await _accessService.GetAllUsersAsync();
        }

        #region Commands        

        [RelayCommand]
        public async void DeleteUserAsync(object parameter)
        {

            if (!(parameter is User user)) return;
            await Task.Run(() =>
            {
                SafetyAction(async () =>
                {
                    Users = await _accessService.DeleteUserAsync(user);
                });
            });
        }        

        #endregion
        [RelayCommand]
        public async Task Login(object parameter)
        {
            if (!(parameter is Login login)) return;
            var user = await _accessService.Login(login);
            login.IsSuccessLogin = user is not null;
            login.FaliledLogin = user is null;
            if (login.IsSuccessLogin)
            {
                CurrentUser = user;
                _logger.LogInformation($"Пользователь {user.FullName} был авторизован");
            }

        }
        [RelayCommand]
        public void Logout()
        {
            CurrentUser = null;
        }


        private void SafetyAction(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }



    }
}
