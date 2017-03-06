using CashRegister.BusinesObjects;
using CashRegister.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Services
{
    public class UserService
    {
        /// <summary>
        /// Tagastatakse andmebaasi tabelist Clerk kasutaja BO vastavalt kasutajanimele.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static UserBO GetUserByUserName(string userName)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                return db.Clerk.Where(x => x.Username == userName).AsEnumerable()
                    .Select(x => new UserBO(x)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Kasutaja otsimine andmebaasist.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<UserBO> SearchUser(string text)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                if (!String.IsNullOrEmpty(text))
                {
                    return db.Clerk
                        .Where(x => (x.FirstName.ToLower().Contains(text.ToLower())
                        || x.LastName.ToLower().Contains(text.ToLower()))
                        && x.To == null).ToList()
                        .Select(x => new UserBO(x)).ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Määratakse kasutajaks olemise lõppaeg, mis tähendab, et tegemist ei ole enam kasutajaga.
        /// </summary>
        /// <param name="user"></param>
        public static void RemoveUser(UserBO user)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.Clerk.Where(x => x.ClerkId == user.UserId)
                    .FirstOrDefault().To = DateTime.Now;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Tagastab kasutajate tabelist kõikide kasutajate loendi BO-dena.
        /// </summary>
        /// <returns></returns>
        public static List<UserBO> AllClerks()
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                return db.Clerk.Where(x => x.To == null).ToList().Select(x => new UserBO(x)).ToList();
            }
        }

        /// <summary>
        /// Lisab andmebaasi tabelisse Clerk uue kasutaja.
        /// </summary>
        /// <param name="user"></param>
        public static void AddNewClerk(UserBO user)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.Clerk.Add(user.ParseDomain());
                db.SaveChanges();
            }
        }
    }
}
