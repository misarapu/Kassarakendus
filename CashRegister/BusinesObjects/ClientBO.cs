using CashRegister.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BusinesObjects
{
    public class ClientBO
    {
        private int _clientId;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private int _level;
        private DateTime _since;
        private DateTime _to;

        public ClientBO(Client client)
        {
            _clientId = client.ClientId;
            _firstName = client.FirstName;
            _lastName = client.LastName;
            _email = client.Email;
            _phone = client.Phone;
            _level = client.Level;
            _since = client.Since;
        }

        public ClientBO()
        {

        }

        public int ClientId
        {
            get
            {
                return _clientId;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }
        
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
            }
        }

        public DateTime Since
        {
            get
            {
                return _since;
            }

            set
            {
                _since = value;
            }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public DateTime To
        {
            get
            {
                return _to;
            }

            set
            {
                _to = value;
            }
        }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", _firstName, _lastName);
            }
        }

        public Client ParseDomain()
        {
            return new Client
            {
                FirstName = _firstName,
                LastName = _lastName,
                Email = _email,
                Phone = _phone,
                Level = _level,
                Since = DateTime.Now
            };
        }
    }
}
