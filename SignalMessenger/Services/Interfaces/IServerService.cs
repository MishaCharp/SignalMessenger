using SignalMessenger.Database.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalMessenger.Services.Interfaces
{
    public interface IServerService
    {
        /// <summary>
        /// Событие получения сообщения
        /// string - сообщение
        /// </summary>
        public event Action<string, int, DateTime> OnMessageReceived;
        /// <summary>
        /// Событие подключения какого-либо пользователя
        /// </summary>
        public event Action<int, bool> OnUserConnected;
        /// <summary>
        /// Когда сам клиент авторизовался, с целью прогрузки всех кто уже в сети
        /// Возвращает id тех, кто в сети
        /// </summary>
        public event Action<List<int>> OnFirstConnect;

        public Task<bool> Connect();
        public Task<bool> Disconnect();

        public Task<List<Message>> GetMessageHistory(int chatId);
        public Task Login(int meId);
        public Task SendMessage(int toUserId, int fromUserId, string message);
    }
}
