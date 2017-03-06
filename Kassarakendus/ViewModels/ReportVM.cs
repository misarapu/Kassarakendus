using CashRegister.BusinesObjects;
using CashRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.ViewModels
{
    public class ReportVM
    {
        public List<TransactionBO> GetUserTrans(DateTime since, DateTime to, UserBO user)
        {
            return ReportService.GetUsersTransactions(since, to, user);
        }

        public List<TransactionBO> GetAllTrans(DateTime since, DateTime to)
        {
            return ReportService.GetTransactions(since, to);
        }
    }
}
