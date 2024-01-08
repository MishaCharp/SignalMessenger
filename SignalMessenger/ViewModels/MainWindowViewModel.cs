using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Mvvm;
using Prism.Regions;
using SignalMessenger.Database.Models;
using System.Collections;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SignalMessenger.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private HubConnection connection;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            
        }
    }
}
