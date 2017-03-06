using CashRegister.BusinesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Services
{
    public class ReportService
    {
        /// <summary>
        /// Tagastab teatud perioodi jooksul tehtud ostutehingute read. 
        /// </summary>
        /// <param name="lastOpened">Perioodi algusaeg.</param>
        /// <param name="closing">Perioodi lõppaeg.</param>
        /// <returns></returns>
        public static List<TransactionLineBO> TransactionlinesInPeriod(DateTime lastOpened, DateTime closing)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                List<TransactionBO> trans = GetTransactions(lastOpened, closing);
                if (trans != null && trans.Count() > 0)
                {
                    int firstLineId = trans.Min(x => x.TransactionId);
                    int lastLineId = trans.Max(x => x.TransactionId);
                    return db.TransactionLine
                             .Where(x => x.TransactionId >= firstLineId && x.TransactionId <= lastLineId)
                             .ToList().Select(y => new TransactionLineBO(y)).ToList();
                }
                return null;
            }
        }

        /// <summary>
        /// Tagastab teatud perioodi jooksul kõik ostutehingud vastavalt maksetüübile.
        /// </summary>
        /// <param name="since"></param>
        /// <param name="to"></param>
        /// <param name="paymentType"></param>
        /// <returns></returns>
        public static List<TransactionBO> GetTransactions(DateTime since, DateTime to)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                if (db.Transaction.Count() > 0)
                {
                    return db.Transaction.Where(x => x.Date >= since && x.Date <= to)
                                .ToList().Select(x => new TransactionBO(x)).ToList();
                }
                return null;
            }
        }

        public static List<TransactionBO> GetUsersTransactions(DateTime since, DateTime to, UserBO user)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                if (db.Transaction.Count() > 0)
                {
                    return db.Transaction.Where(x => x.Date >= since && x.Date <= to && x.ClerkId == user.UserId)
                        .AsEnumerable().Select(x => new TransactionBO(x)).ToList();
                }
                return null;
            }
        }
    }
}
