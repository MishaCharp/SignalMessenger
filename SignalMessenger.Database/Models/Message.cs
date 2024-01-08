using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Database.Models
{
    public class Message : NativeEntity
    {
        public User SenderUser { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public List<Dialog> Dialogs { get; set; }
        public List<DialogMessage> DialogMessages { get; set; }

        public override void UpdateProperties(NativeEntity entity)
        {
            if (entity is Message item)
            {
                SenderUser = item.SenderUser;
                Text = item.Text;
                DateTime = item.DateTime;
            }
        }
    }
}
