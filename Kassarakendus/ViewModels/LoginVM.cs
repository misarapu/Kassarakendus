using CashRegister.BusinesObjects;
using CashRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.ViewModels
{
    public class LoginVM
    {

        /// <summary>
        /// Kasuta sisselogimise andmete kontrollimine.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginConfirm(string userName, string password)
        {
            return LoginService.ConfirmLogin(userName, password);
        }

        /// <summary>
        /// Kasutaja sisselogimine.
        /// </summary>
        /// <param name="user"></param>
        public void Login(UserBO user)
        {
            LoginService.LoginUser(user);
            App.LoggedInUser = user;
        }

        /// <summary>
        /// Kasutaja välja logimine.
        /// </summary>
        public static void LogOutUser()
        {
            CalcVM calcVm = new CalcVM(LoginService.LastLogOut(), DateTime.Now);
            App.LogOutUser(Decimal.Parse(calcVm.TotalCash));
        }

        /// <summary>
        /// Tagastab booleani päeva avatuse kohta.
        /// </summary>
        /// <returns></returns>
        public bool IsDayOpened()
        {
            return LoginService.IsOpened();
        }

        /// <summary>
        /// Tühistab päeva avamise.
        /// </summary>
        public static void CancelOpen()
        {
            LoginService.RemoveLastLogin();
        }
    }
}
