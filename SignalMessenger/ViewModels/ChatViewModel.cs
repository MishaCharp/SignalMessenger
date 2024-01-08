using Prism.Commands;
using Prism.Mvvm;
using SignalMessenger.Presenters;
using SignalMessenger.Services;
using SignalMessenger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace SignalMessenger.ViewModels
{
    public class ChatViewModel : BindableBase
    {
        private bool isEnabled;
        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                SetProperty(ref isEnabled, value);
            }
        }

        private int MeUserId;
        private int FriendUserId;

        private IChatDialogService _chatDialogService;
        private IServerService _serverService;

        public string MessageText { get; set; }
        public DelegateCommand SendCommand {get;set;}

        public ObservableCollection<MessagePresenter> Messages { get; set; } = new();

        public ChatViewModel(IChatDialogService chatDialogService, IServerService serverService, IUserService userService)
        {
            IsEnabled = false;
            MeUserId = userService.GetCurrentUser().Id;
            _chatDialogService = chatDialogService;
            _serverService = serverService;

            _chatDialogService.OnDialogChanged += _chatDialogService_OnDialogChanged;

            _serverService.OnMessageReceived += _serverService_OnMessageReceived;

            SendCommand = new DelegateCommand(sendMessage);
        }

        private void _serverService_OnMessageReceived(string message, int senderId, DateTime dateTime)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(new MessagePresenter
                {
                    Message = message,
                    MeUserId = this.MeUserId,
                    SenderUserId = senderId,
                    DateTime = dateTime
                });
            });
        }

        private async void _chatDialogService_OnDialogChanged(UserPresenter chat)
        {
            IsEnabled = true;
            Messages.Clear();

            var messages = await _serverService.GetMessageHistory(chat.Dialog.Id);
            FriendUserId = chat.User.Id;

            foreach (var message in messages)
            {
                Messages.Add(new MessagePresenter
                {
                    Message = message.Text,
                    MeUserId = this.MeUserId,
                    SenderUserId = message.SenderUser.Id,
                    DateTime = message.DateTime
                });
            }

        }

        public async void sendMessage()
        {
            await _serverService.SendMessage(FriendUserId, MeUserId, MessageText);
        }

    }
}
