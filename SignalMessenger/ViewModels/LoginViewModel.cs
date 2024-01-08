using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SignalMessenger.Services;
using SignalMessenger.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SignalMessenger.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private IDatabaseService _databaseRepository;
        private IUserService _userService;
        private IRegionManager _regionManager;

        private string login = "mishacharp";
        public string Login
        {
            get => login;
            set
            {
                SetProperty(ref login, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        private string password = "test";
        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand LoginCommand { get; }

        public LoginViewModel(IRegionManager regionManager, IDatabaseService databaseService, IUserService userService)
        {
            _databaseRepository = databaseService;
            _userService = userService;
            _regionManager = regionManager;

            LoginCommand = new DelegateCommand(loginCommand, CanLogin);
        }

        bool CanLogin()
        {
            if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password)) return true;
            else return false;
        }

        private async void loginCommand()
        {
            var allUsers = await _databaseRepository.GetAllUsers();
            var user = allUsers.FirstOrDefault(x => x.Login == Login && x.Password == Password);
            


            if (user != null)
            {
                _userService.SetCurrentUser(user);
                _regionManager.RequestNavigate("MainRegion", "WorkplaceView");
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }

    }
}
