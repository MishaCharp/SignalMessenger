using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SignalMessenger.Database.Models
{
    public class Friendship : NativeEntity
    {
        
        public int FirstFriendUserId { get; set; }
        public int SecondFriendUserId { get; set; }

        public User FirstFriend { get; set; }
        public User SecondFriend { get; set; }

        public DateTime Date { get; set; }

        public List<Dialog> Dialogs { get; set; }

        public override void UpdateProperties(NativeEntity entity)
        {
            if (entity is Friendship item)
            {
                FirstFriend = item.FirstFriend;
                SecondFriend = item.SecondFriend;
                Date = item.Date;
            }
        }
    }
}
