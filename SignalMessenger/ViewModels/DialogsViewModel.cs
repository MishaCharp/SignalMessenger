using Prism.Mvvm;
using SignalMessenger.Presenters;
using SignalMessenger.Services;
using SignalMessenger.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalMessenger.ViewModels
{
    public class DialogsViewModel : BindableBase
    {
        private IDatabaseService _databaseService;
        private IChatDialogService _chatDialogService;

        public List<UserPresenter> Friends { get; set; }
        private UserPresenter selectedFriend;
        public UserPresenter SelectedFriend
        {
            get => selectedFriend;
            set
            {
                if (SetProperty(ref selectedFriend, value)) _chatDialogService.ChangeDialog(value);
            }
        }
        public DialogsViewModel(
            IDatabaseService databaseService,
            IUserService userService, 
            IChatDialogService chatDialogService, 
            IServerService serverService)
        {
            _databaseService = databaseService;
            _chatDialogService = chatDialogService;

            var meUserId = userService.GetCurrentUser();

            var allFriendships = Task.Run(_databaseService.GetAllFriendships).Result;
            var myFriendships = allFriendships.Where(x => x.FirstFriendUserId == meUserId.Id || x.SecondFriendUserId == meUserId.Id);

            var allDialogs = Task.Run(_databaseService.GetAllDialog).Result;

            List<UserPresenter> myFriends = new();

            foreach (var friendship in myFriendships)
            {
                var user = new UserPresenter();
                user.meUserId = meUserId.Id;

                var dialog = allDialogs.FirstOrDefault(x => x.Friendship.Id == friendship.Id);

                if (friendship.FirstFriendUserId != meUserId.Id) user.User = friendship.FirstFriend;
                else user.User = friendship.SecondFriend;

                user.Dialog = dialog;

                myFriends.Add(user);
            }

            Friends = myFriends;

            serverService.OnUserConnected += ServerService_OnUserConnected;
            serverService.OnFirstConnect += ServerService_OnFirstConnect;

            serverService.Connect();

            serverService.Login(meUserId.Id);

        }

        private void ServerService_OnFirstConnect(List<int> connectedUsers)
        {
            foreach(var friend in Friends)
            {
                if(connectedUsers.Contains(friend.User.Id)) friend.IsOnline = true;
            }
        }

        private void ServerService_OnUserConnected(int idUser, bool isConnected)
        {
            var friend = Friends.FirstOrDefault(x=>x.User.Id == idUser);
            if(friend != null)
            {
                friend.IsOnline = isConnected;
            }
        }
    }
}
