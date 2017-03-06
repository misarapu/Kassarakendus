using CashRegister.BusinesObjects;
using CashRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.ViewModels
{
    public class CalcVM
    {
        List<TransactionBO> _transCash;

        /// <summary>
        /// ViewModel konstruktor.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public CalcVM(DateTime start, DateTime end)
        {
            _transCash = ReportService.GetTransactions(start, end);
        }

        /// <summary>
        /// Property, mis tagastab kassas oleva summa vastavalt sellele,
        /// kas päeva jooksul on olnud sularahatehinguid.
        /// </summary>
        public string TotalCash
        {
            get
            {
                if (_transCash != null)
                {
                    return (_transCash.Where(x => x.PaymentType == "cash")
                       .Select(x => x.TotalCost).Sum() + App.LoginCash).ToString("F");
                }
                else
                {
                    return App.LoginCash.ToString("F");
                }
            }
        }

        /// <summary>
        /// Kasutaja avab päeva.
        /// </summary>
        public void UserOpensDay()
        {
            LoginService.SetDayAction("open");
        }

        /// <summary>
        /// Kasutaja sulgeb päeva.
        /// </summary>
        public void UserClosesDay()
        {
            LoginService.SetDayAction("close");
            LoginVM.LogOutUser();
        }
    }
}
