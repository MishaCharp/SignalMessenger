using SignalMessenger.Database.Models;

namespace SignalMessenger.Services
{
    public class UserService : IUserService
    {
        private User CurrentUser;

        public User GetCurrentUser() => CurrentUser;

        public void SetCurrentUser(User user)
        {
            if (user != null) CurrentUser = user;
        }
    }
}
