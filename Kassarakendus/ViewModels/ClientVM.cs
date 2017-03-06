using CashRegister.BusinesObjects;
using CashRegister.Domain;
using CashRegister.Services;
using System.Collections.Generic;
using System.Linq;

namespace Kassarakendus.ViewModels
{
    public class ClientVM : BaseVM
    {
        private int _clientId;
        private ClientBO _client;
        private ClientLevelBO _clientLevel;
        private List<ClientBO> _clients;
        private List<ClientLevelBO> _levels;
        
        /// <summary>
        /// ViewModel konstruktor.
        /// </summary>
        public ClientVM()
        {
            _clients = new List<ClientBO>();
            _levels = new List<ClientLevelBO>();
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab klientide loendi.
        /// </summary>
        public List<ClientBO> AllClients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
                base.NotifyPropertyChanged("AllClients");
            }
        }

        /// <summary>
        /// Laeb klientide loendi.
        /// </summary>
        public void LoadClients()
        {
            AllClients = ClientService.AllClients();
        }

        /// <summary>
        /// Laeb kliendi staatuste loendi.
        /// </summary>
        public void LoadLevels()
        {
            Levels = ClientService.AllClientLevels();
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab kliendi ID.
        /// </summary>
        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab kliendi objekti.
        /// </summary>
        public ClientBO Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
                base.NotifyPropertyChanged("Client");
            }
        }

        public ClientLevelBO ClientLevel
        {
            get
            {
                return Levels.Where(x => x.LevelId == Client.Level)
                    .FirstOrDefault();
            }
            set
            {
                _clientLevel = value;
            }
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab kliendi staatuste loendi.
        /// </summary>
        public List<ClientLevelBO> Levels
        {
            get { return _levels; }
            set { _levels = value; }
        }

        /// <summary>
        /// Lisab uue kliendi.
        /// </summary>
        /// <param name="newClient"></param>
        public void AddNewClient(ClientBO newClient)
        {
            Client = ClientService.AddNewClient(newClient);
            LoadClients();
        }

        public void EditClient(ClientBO client)
        {
            Client = ClientService.EditClient(client);
            LoadClients();
        }

        /// <summary>
        /// Kustutab kliendi.
        /// </summary>
        /// <param name="client"></param>
        public void RemoveClient(ClientBO client)
        {
            ClientService.RemoveClient(client);
            LoadClients();
        }

        /// <summary>
        /// Kliendi otsimine loendist.
        /// </summary>
        /// <param name="clientName"></param>
        public void SearchClient(string clientName)
        {
            AllClients = ClientService.SearchClient(clientName);
        }

        /// <summary>
        /// Tagastab kliendi allahindlus protsendi sõnena.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public string DiscountPercent(ClientBO client)
        {
            decimal coef = ClientService.GetClientLevel(client.Level).Discount;
            return ((1 - coef) * 100).ToString("0.#");
        }
    }
}
