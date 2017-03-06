using CashRegister.BusinesObjects;
using CashRegister.Domain;
using CashRegister.Services;
using Kassarakendus.BusinesObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.ViewModels
{
    public class MainVM
    {

        /// <summary>
        /// ViewModel konstruktor.
        /// </summary>
        public MainVM()
        {

        }

        /// <summary>
        /// Property, mis tagastab ostukorvi summa sõnena.
        /// </summary>
        public string TotalPrice
        {
            get { return App.TotalPrice.ToString(); }
        }

        /// <summary>
        /// Property, mis tagastab kasutaja ees- ja perenime.
        /// </summary>
        public string LoginUserFullName
        {
            get { return LoginService.GetLoggedInUser().FullName; }
        }
    }

}
