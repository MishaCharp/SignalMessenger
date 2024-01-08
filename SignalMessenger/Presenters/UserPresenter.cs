using Prism.Mvvm;
using SignalMessenger.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Presenters
{
    public class UserPresenter : BindableBase
    {
        public int meUserId;
        public User User { get; set; }
        public Dialog Dialog { get; set; }

        public string LastMessage
        {
            get
            {
                string preText = string.Empty;
                string message = Dialog?.LastMessage.Text;

                if (Dialog?.LastMessage.SenderUser.Id == meUserId) preText = "Вы: ";

                var res = preText + message;

                if (res == string.Empty) res = "--- Нет сообщений ---";

                return res;
            }
        }

        private bool isOnline;
        public bool IsOnline
        {
            get => isOnline;
            set
            {
                SetProperty(ref isOnline, value);
                IsOnlineColor = value ? "yellow" : "red";
            }
        }

        public string isOnlineColor = "red";
        public string IsOnlineColor
        {
            get => isOnlineColor;
            set
            {
                SetProperty(ref isOnlineColor, value);
            }
        }
    }
}
