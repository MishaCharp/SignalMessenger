using Microsoft.AspNetCore.SignalR.Client;
using SignalMessenger.Database.Models;
using SignalMessenger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SignalMessenger.Services
{
    class DatabaseService : IDatabaseService
    {
        private Action<List<User>> OnUsersReceived;
        private Action<User> OnUserReceived;
        private Action<List<Friendship>> OnFriendshipReceived;
        private Action<List<Dialog>> OnDialogReceived;

        private HubConnection hubConnection;
        public DatabaseService()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7157/db")
                .Build();

            Connect();

        }

        public async void Connect()
        {
            await hubConnection.StartAsync();
        }

        #region User
        public async Task<List<User>> GetAllUsers()
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                return await hubConnection.InvokeAsync<List<User>>("GetAllUsers");
            }
            else throw new Exception("Hub not connected");
        }
        public async Task<User> GetUser(int id)
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                return await hubConnection.InvokeAsync<User>("GetUser");
            }
            else throw new Exception("Hub not connected");
        }
        #endregion

        #region Friendship
        public async Task<List<Friendship>> GetAllFriendships()
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                return await hubConnection.InvokeAsync<List<Friendship>>("GetAllFriendship");
            }
            else throw new Exception("Hub not connected");
        }
        #endregion

        #region Dialog
        public async Task<List<Dialog>> GetAllDialog()
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                return await hubConnection.InvokeAsync<List<Dialog>>("GetAllDialog");
            }
            else throw new Exception("Hub not connected");
        }
        #endregion
    }
}
