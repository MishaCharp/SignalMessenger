using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace SignalMessenger.ViewModels
{
	public class LoginViewModel : BindableBase
	{
        private IRegionManager _regionManager;

        private string login;
        public string Login
        {
            get => login;
            set
            {
                SetProperty(ref login, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        private string password;
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

        public LoginViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            LoginCommand = new DelegateCommand(loginCommand, CanLogin);
        }

        bool CanLogin()
        {
            if(!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password)) return true;
            else return false;
        }

        private void loginCommand()
        {
            _regionManager.RequestNavigate("MainRegion","WorkplaceView");
        }

	}
}
