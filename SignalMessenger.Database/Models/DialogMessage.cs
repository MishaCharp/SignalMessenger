using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SignalMessenger.Database.Models
{
    public class DialogMessage : NativeEntity
    {
        public Dialog Dialog { get; set; }
        public string LastMessage { get; set; }

        public override void UpdateProperties(NativeEntity entity)
        {
            if (entity is DialogMessage item)
            {
                Dialog = item.Dialog;
                LastMessage = item.LastMessage;
            }
        }
    }
}
