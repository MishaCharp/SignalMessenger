using SignalMessenger.Database.Models;

namespace SignalMessenger.Services
{
    public interface IUserService
    {
        public void SetCurrentUser(User user);
        public User GetCurrentUser();
    }
}