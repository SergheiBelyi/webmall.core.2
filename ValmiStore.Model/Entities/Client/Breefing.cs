using System;
using System.Web.Mvc;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Entities.Client
{
    /// <summary>
    /// Управляющий класс краткой информации о клиенте
    /// </summary>
    public class Breefing
    {
        private readonly Client _client;

        public Breefing(Client client)
        {
            _client = client;
        }

        /// <summary>
        /// Краткая информация о клиенте
        /// </summary>
        private BreefingData _data = new BreefingData();

        /// <summary>
        /// Время следующего обновления краткой информации 
        /// </summary>
        private DateTime _nextBreefingCall = DateTime.Now;

        /// <summary>
        /// Краткая информация о клиенте
        /// </summary>
        public BreefingData Data
        {
            get
            {
                if (_nextBreefingCall > DateTime.Now) return _data;

                var clientRepository = DependencyResolver.Current.GetService<IClientRepository>();
                _data = clientRepository.GetBreefing(_client.Id);
                _nextBreefingCall = DateTime.Now.AddSeconds(4);

                return _data;
            }
        }

        public void Clear()
        {
            _nextBreefingCall = DateTime.Now.AddSeconds(-1);
        }
    }
}
