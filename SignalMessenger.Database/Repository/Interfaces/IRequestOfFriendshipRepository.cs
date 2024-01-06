using SignalMessenger.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Database.Repository.Interfaces
{
    public interface IRequestOfFriendshipRepository
    {
        RequestOfFriendship GetById(int id);
        IEnumerable<RequestOfFriendship> GetAll();
        void Add(RequestOfFriendship entity);
        void Update(RequestOfFriendship entity);
        void Delete(RequestOfFriendship entity);
    }
}
