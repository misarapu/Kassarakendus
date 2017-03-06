using CashRegister.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BusinesObjects
{
    public class ClientLevelBO
    {
        private int _clientLevelId;
        private string _clientLevelName;
        private decimal _discount;

        public ClientLevelBO(ClientLevel level)
        {
            _clientLevelId = level.ClientLevelId;
            _clientLevelName = level.LevelName;
            _discount = level.Discount;
        }

        public int LevelId
        {
            get
            {
                return _clientLevelId;
            }
        }

        public string LevelName {
            get
            {
                return _clientLevelName;
            }
            set
            {
                _clientLevelName = value;
            }
        }

        public decimal Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
            }
        }

        public ClientLevel ParseDomain()
        {
            return new ClientLevel
            {
                ClientLevelId = _clientLevelId,
                LevelName = _clientLevelName,
                Discount = _discount
            };
        }
    }
}
