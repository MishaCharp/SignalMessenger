using Prism.Ioc;
using Prism.Modularity;
using SignalMessenger.Services;
using SignalMessenger.Services.Interfaces;
using SignalMessenger.Views;
using System.Windows;

namespace SignalMessenger
{
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IUserService, UserService>();
            containerRegistry.RegisterSingleton<IServerService, ServerService>();
            containerRegistry.RegisterSingleton<IDatabaseService, DatabaseService>();
            containerRegistry.RegisterSingleton<IChatDialogService, ChatDialogService>();
        }

        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<MainModule>();
        }
    }
}
