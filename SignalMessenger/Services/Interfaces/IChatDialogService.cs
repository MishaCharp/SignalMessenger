using SignalMessenger.Presenters;
using System;

namespace SignalMessenger.Services.Interfaces
{
    public interface IChatDialogService
    {
        public event Action<UserPresenter> OnDialogChanged;

        public void ChangeDialog(UserPresenter sender);
    }
}
