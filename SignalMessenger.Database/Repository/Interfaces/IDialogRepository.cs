using SignalMessenger.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Database.Repository.Interfaces
{
    public interface IDialogRepository
    {
        Dialog GetById(int id);
        IEnumerable<Dialog> GetAll();
        void Add(Dialog entity);
        void Update(Dialog entity);
        void Delete(Dialog entity);
    }
}
