using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMessenger.Services
{
    public class HeaderToolService
    {
        private static HeaderToolService instance;
        public static HeaderToolService Instance
        {
            get => instance ?? (instance = new HeaderToolService());
        }

        public event Action OnMinimized;
        public event Action OnMaximized;
        public event Action OnNormal;
        public event Action OnClosed;

        public void Minimize() => OnMinimized?.Invoke();
        public void Maximize() => OnMaximized?.Invoke();
        public void Normal() => OnNormal?.Invoke();
        public void Close() => OnClosed?.Invoke();
    }
}
