using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SignalMessenger.ViewModels
{
	public class LoginViewModel : BindableBase
	{
        private IRegionManager _regionManager;

        public DelegateCommand LoginCommand { get; }

        public LoginViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            _regionManager.RequestNavigate("MainRegion","WorkplaceView");
        }

	}
}
