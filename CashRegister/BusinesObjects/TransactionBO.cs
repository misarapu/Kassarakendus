using CashRegister.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BusinesObjects
{
    public class TransactionBO
    {
        private int _transactionId;
        private string _paymentType;
        private decimal _totalCost;
        private int _clerkId;
        private int _clientId;
        private DateTime _time;

        public TransactionBO(Transaction trans)
        {
            _transactionId = trans.TransactionId;
            _totalCost = trans.TotalCost;
            _paymentType = trans.PaymentType;
            _clerkId = trans.ClerkId.Value;
            _clientId = trans.ClerkId.Value;
            _time = trans.Date.Value;
        }

        public TransactionBO()
        {

        }

        public int TransactionId
        {
            get { return _transactionId; }
        }

        public decimal TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        public string PaymentType
        {
            get { return _paymentType; }
            set { _paymentType = value; }
        }

        public int ClerkId
        {
            get { return _clerkId; }
            set { _clerkId = value; }
        }

        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        public Transaction ParseDomain()
        {
            Transaction transaction = new Transaction();
            transaction.PaymentType = "cash";
            transaction.ClerkId = _clerkId;
            transaction.TotalCost = _totalCost;
            transaction.Date = DateTime.Now;

            if (_clientId != 0)
            {
                transaction.ClientId = _clientId;
            }
            return transaction;
        }
    }
}



