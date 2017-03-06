using CashRegister.BusinesObjects;
using CashRegister.Domain;
using CashRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.ViewModels
{
    public class PurchaseVM
    {
        private string _paymentType = "cash";

        /// <summary>
        /// Property, mis tagastab ja väärtustab makse tüübi
        /// (kaardi- või sularahamakse)
        /// </summary>
        public string PaymentType
        {
            get { return _paymentType; }
            set { _paymentType = value; }
        }

        /// <summary>
        /// Uue ostutehingu lisamine andmebaasi.
        /// </summary>
        /// <param name="trans"></param>
        public void AddNewTransaction(TransactionBO trans)
        {
            TransactionService.AddNewTransaction(App.UserCart, trans);
        }
    }
}
