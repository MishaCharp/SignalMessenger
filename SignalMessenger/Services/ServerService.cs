using Microsoft.AspNetCore.SignalR.Client;
using SignalMessenger.Database.Models;
using SignalMessenger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Services
{
    public class ServerService : IServerService
    {
        private HubConnection connection;

        public event Action<string, int, DateTime> OnMessageReceived;

        public event Action<int, bool> OnUserConnected;

        public event Action<List<int>> OnFirstConnect;

        public ServerService()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7157/chat")
                .Build();

            connection.On<string, int, DateTime>("Receive", (message, senderId, dateTime) =>
            {
                OnMessageReceived?.Invoke(message, senderId, dateTime);
            });

            connection.On<int, bool>("OnOnline", (idUser, isOnline) =>
            {
                OnUserConnected?.Invoke(idUser, isOnline);
            });

            connection.On<List<int>>("OnFirstOnline", (list) =>
            {
                OnFirstConnect?.Invoke(list);
            });

        }
        public async Task<bool> Connect()
        {
            try
            {
                await connection.StartAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Disconnect()
        {
            try
            {
                await connection.StopAsync();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public async Task SendMessage(int toUserId, int fromUserId, string message)
        {
            await connection.InvokeAsync("SendPrivateMessage", toUserId, fromUserId, message);
        }

        public async Task<List<Message>> GetMessageHistory(int chatId)
        {
             return await connection.InvokeAsync<List<Message>>("GetMessageHistory", chatId);
        }

        public async Task Login(int meId)
        {
            await connection.InvokeAsync("Login", meId);
        }
    }
}
