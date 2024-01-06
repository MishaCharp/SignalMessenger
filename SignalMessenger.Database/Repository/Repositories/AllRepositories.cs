using SignalMessenger.Database.Models;
using SignalMessenger.Database.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SignalMessenger.Database.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository { }
    public class RequestOfFriendshipRepository : BaseRepository<RequestOfFriendship>, IRequestOfFriendshipRepository { }
    public class MessageRepository : BaseRepository<Message>, IMessageRepository { }
    public class FriendshipRepository : BaseRepository<Friendship>, IFriendshipRepository { }
    public class DialogMessageRepository : BaseRepository<DialogMessage>, IDialogMessageRepository { }
    public class DialogRepository : BaseRepository<Dialog>, IDialogRepository { }
}
