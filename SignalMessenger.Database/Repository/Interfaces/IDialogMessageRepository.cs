using SignalMessenger.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Database.Repository.Interfaces
{
    public interface IDialogMessageRepository
    {
        DialogMessage GetById(int id);
        IEnumerable<DialogMessage> GetAll();
        void Add(DialogMessage entity);
        void Update(DialogMessage entity);
        void Delete(DialogMessage entity);
    }
}
