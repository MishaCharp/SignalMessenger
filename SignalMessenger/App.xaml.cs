using Prism.Ioc;
using Prism.Modularity;
using SignalMessenger.Database.Repository.Interfaces;
using SignalMessenger.Database.Repository.Repositories;
using SignalMessenger.Views;
using System.Windows;

namespace SignalMessenger
{
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IUserRepository, UserRepository>();
            containerRegistry.Register<IRequestOfFriendshipRepository, RequestOfFriendshipRepository>();
            containerRegistry.Register<IMessageRepository, MessageRepository>();
            containerRegistry.Register<IFriendshipRepository, FriendshipRepository>();
            containerRegistry.Register<IDialogRepository, DialogRepository>();
            containerRegistry.Register<IDialogMessageRepository, DialogMessageRepository>();
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
