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
    public class ClientService
    {
        /// <summary>
        /// Tagastab klientide tabelist kõikide klientide loendi BO-dena.
        /// </summary>
        /// <returns></returns>
        public static List<ClientBO> AllClients()
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                return db.Client.Where(x => x.To == null).ToList().Select(x => new ClientBO(x)).ToList();
            }
        }

        /// <summary>
        /// Lisab andmebaasi tabelisse Client uue kliendi.
        /// </summary>
        /// <param name="newClient"></param>
        public static ClientBO AddNewClient(ClientBO newClient)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.Client.Add(newClient.ParseDomain());
                db.SaveChanges();

                return new ClientBO(db.Client.AsEnumerable().Last());
            }
        }

        /// <summary>
        /// Määratakse kliendiks olemise lõppaeg, mis tähendab, et tegemist ei ole enam kliendiga.
        /// </summary>
        /// <param name="client"></param>
        public static void RemoveClient(ClientBO client)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.Client.Where(x => x.ClientId == client.ClientId)
                    .FirstOrDefault().To = DateTime.Now;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Kliendi otsimine andmebaasist.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// Kliendi BO.
        /// </returns>
        public static List<ClientBO> SearchClient(string input)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                if (!String.IsNullOrEmpty(input))
                {
                    return db.Client
                        .Where(x => (x.FirstName.ToLower().Contains(input.ToLower()) 
                        || x.LastName.ToLower().Contains(input.ToLower()))
                        && x.To == null).ToList()
                        .Select(x => new ClientBO(x)).ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Tagastab andmebaasi tabelist ClientLevel klientide staatuste loendi.
        /// </summary>
        /// <returns></returns>
        public static List<ClientLevelBO> AllClientLevels()
        {
            using(Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                return db.ClientLevel.AsEnumerable().Select(x => new ClientLevelBO(x)).ToList();
            }
        }

        public static ClientBO EditClient(ClientBO client)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                Client clientOld = db.Client.Where(x => x.ClientId == client.ClientId)
                    .FirstOrDefault();

                clientOld.FirstName = client.FirstName;
                clientOld.LastName = client.LastName;
                clientOld.Phone = client.Phone;
                clientOld.Email = client.Email;
                clientOld.Level = client.Level;

                db.SaveChanges();

                return new ClientBO(clientOld);
            }
        }

        /// <summary>
        /// Tagastab tabelist ClientLevel vastava staatuse objekti.
        /// kliendi taseme nimetusele.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static ClientLevelBO GetClientLevel(int level)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                return db.ClientLevel.AsEnumerable().Where(x => x.ClientLevelId == level)
                    .Select(x => new ClientLevelBO(x)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Kui tabel on tühi, siis täidetaks vaikimis väärtustega.
        /// </summary>
        /// <param name="level"></param>
        public static void FillClientLevels()
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                if (db.ClientLevel.Count() == 0)
                {
                    db.ClientLevel.AddRange(new List<ClientLevel>()
                    { new ClientLevel{LevelName = "Regular", Discount = 1 },
                      new ClientLevel{LevelName = "Silver", Discount = (decimal)0.95 },
                      new ClientLevel{LevelName = "Gold", Discount = (decimal)0.9 } }
                    );
                    db.SaveChanges();
                }
            }
        }
    }
}
