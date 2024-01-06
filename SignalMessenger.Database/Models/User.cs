using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Database.Models
{
    public class User : NativeEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }


        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimyc { get; set; }

        public List<Friendship> Friendship { get; set; }
        public List<Friendship> Friendship1 { get; set; }

        public List<RequestOfFriendship> RequestOfFriendship { get; set;}
        public List<RequestOfFriendship> RequestOfFriendship1 { get; set;}

        public override void UpdateProperties(NativeEntity entity)
        {
            if (entity is User user)
            {
                Login = user.Login;
                Password = user.Password;
                Surname = user.Surname;
                Name = user.Name;
                Patronimyc = user.Patronimyc;
            }

        }
    }
}
