using SignalMessenger.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Presenters
{
    public class MessagePresenter
    {
        public int MeUserId { get; set; }
        public int SenderUserId { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsMyMessage
        {
            get
            {
                if(SenderUserId == MeUserId) return true;
                else return false;
            }
        }
        public string Alignment 
        {
            get => IsMyMessage ? "Left" : "Right";
        }
    }
}
