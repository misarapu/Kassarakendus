using CashRegister.BusinesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Services
{
    public class LoginService
    {
        /// <summary>
        /// Kinnitab kasutaja olemasolu andmebaasitabelis Clerk vastavalt parameetrina
        /// kaasa antud kasutajanimele ja salasõnale.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ConfirmLogin(string userName, string password)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                if (db.Clerk.Select(x => x.Username).Contains(userName))
                {
                    var validUser = db.Clerk.Where(x => x.Username == userName)
                        .First();
                    if (validUser.Password == password && validUser.To == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Lisab andmebaasitabelisse LoginLog uue kirje.
        /// </summary>
        /// <param name="user"></param>
        public static void LoginUser(UserBO user)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.LoginLog.Add((new LoginLogBO()
                {
                    ClerkId = user.UserId
                }).ParseDomain());
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Eemaldab tabelist LoginLog viimase kirje.
        /// </summary>
        public static void RemoveLastLogin()
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.LoginLog.Remove(db.LoginLog
                    .Single(x => x.LoginId == db.LoginLog.Max(y => y.LoginId)));
               
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Lisab tabelisse LoginLog viimasele kirjele lõppaja, mis tähendab,
        /// et kasutaja ei ole enam sisse logitud.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cashAmount"></param>
        public static void LogoutUser(UserBO user, decimal cashAmount)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.LoginLog.Where(x => x.LogoutTime == null && x.ClerkId == user.UserId)
                    .FirstOrDefault().LogoutTime = DateTime.Now;

                db.LoginLog.Where(x => x.LogoutTime == null && x.ClerkId == user.UserId)
                    .FirstOrDefault().CashAmount = cashAmount;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Tabelisse LoginLog lisatakse päeva avamise või sulgemise staatus.
        /// </summary>
        /// <param name="status"></param>
        public static void SetDayAction(string status)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                if (status == "open")
                {
                    db.LoginLog.Where(x => x.LoginId == db.LoginLog.Max(y => y.LoginId))
                   .FirstOrDefault().OpenedDay = "t";
                }

                if (status == "close")
                {
                    db.LoginLog.Where(x => x.LoginId == db.LoginLog.Max(y => y.LoginId))
                   .FirstOrDefault().ClosedDay = "t";
                }
               
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Tagastab tabelist Clerk sisseloginud kasutaja BO-na.
        /// </summary>
        /// <returns></returns>
        public static UserBO GetLoggedInUser()
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                return db.Clerk.Where(x => x.ClerkId == db.LoginLog
                               .Where(y => y.LoginId == db.LoginLog.Max(z => z.LoginId))
                               .Select(w => w.ClerkId).FirstOrDefault()).AsEnumerable()
                               .Select(x => new UserBO(x)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Tagastab booleani, kas päev on avatud või mitte vastavalt sellele, kas tabelis
        /// LoginLog leidub veerus LogoutTime väärtus null.
        /// </summary>
        /// <returns></returns>
        public static bool IsOpened()
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                return db.LoginLog.Where(x => x.LogoutTime == db.LoginLog.Max(y => y.LogoutTime)
                    && x.ClosedDay == null).Any();
            }
        }

        /// <summary>
        /// Tagastab aja, millal viimati välja logiti.
        /// </summary>
        /// <returns></returns>
        public static DateTime LastLogOut()
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                try
                {
                    return db.LoginLog.Where(x => x.LogoutTime != null)
                                  .Max(x => x.LogoutTime).Value;
                }
                catch (Exception)
                {
                    return DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Tagastab sularaha väärtuse viimasel välja logimise hetkel.
        /// </summary>
        /// <returns></returns>
        public static decimal LastCash()
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                return db.LoginLog.AsEnumerable().Last().CashAmount.Value;
            }
        }
    }
}
