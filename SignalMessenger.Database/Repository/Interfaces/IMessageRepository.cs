using SignalMessenger.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Database.Repository.Interfaces
{
    public interface IMessageRepository
    {
        Message GetById(int id);
        IEnumerable<Message> GetAll();
        void Add(Message entity);
        void Update(Message entity);
        void Delete(Message entity);
    }
}
