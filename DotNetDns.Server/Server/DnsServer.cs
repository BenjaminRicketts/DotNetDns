using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetDns.Server.Server.Listeners;

namespace DotNetDns.Server.Server
{
    public class DnsServer : IDnsServer
    {
        private readonly IList<IDnsListener> _listeners;
        private IList<Task> _listenerTasks;
        private Task _mainServiceTask;

        public DnsServer(IList<IDnsListener> listeners)
        {
            _listeners = listeners;

            ValidateListeners();
            CreateListenerTasks();
        }

        public void StartListening()
        {
            _mainServiceTask = new Task(ListenForDnsQueries);
            _mainServiceTask.Start();
        }

        public void StopListening()
        {
            throw new NotImplementedException();
        }

        private void CreateListenerTasks()
        {
            _listenerTasks = _listeners
                                .Select(listener => new Task(listener.StartListening))
                                .ToList();
        }

        private void ListenForDnsQueries()
        {
            foreach (var task in _listenerTasks)
                task.Start();
        }

        private void ValidateListeners()
        {
            if (_listeners == null || _listeners.Count == 0)
                throw new Exception("DNS server cannot listen for DNS queries without any listeners configured.");
        }
    }
}