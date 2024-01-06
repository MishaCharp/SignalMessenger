using SignalMessenger.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Database.Repository.Interfaces
{
    public interface IFriendshipRepository
    {
        Friendship GetById(int id);
        IEnumerable<Friendship> GetAll();
        void Add(Friendship entity);
        void Update(Friendship entity);
        void Delete(Friendship entity);
    }
}
