using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SignalMessenger.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var region = containerProvider.Resolve<IRegionManager>();
            region.RegisterViewWithRegion("MainRegion", typeof(LoginView));
            region.RegisterViewWithRegion("HeaderRegion", typeof(HeaderView));
            region.RegisterViewWithRegion("DialogsRegion", typeof(DialogsView));
            region.RegisterViewWithRegion("ChatRegion", typeof(ChatView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<WorkplaceView>();
        }
    }
}
