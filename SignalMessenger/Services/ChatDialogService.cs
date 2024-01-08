using SignalMessenger.Presenters;
using SignalMessenger.Services.Interfaces;
using SignalMessenger.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Services
{
    public class ChatDialogService : IChatDialogService
    {
        public event Action<UserPresenter> OnDialogChanged;

        public void ChangeDialog(UserPresenter sender) => OnDialogChanged?.Invoke(sender);
    }
}
