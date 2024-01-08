using SignalMessenger.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Services.Interfaces
{
    public interface IDatabaseService
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUser(int id);

        public Task<List<Friendship>> GetAllFriendships();

        public Task<List<Dialog>> GetAllDialog();
    }   
}
