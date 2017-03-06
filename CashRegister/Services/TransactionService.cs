using CashRegister.BusinesObjects;
using CashRegister.Domain;
using Kassarakendus.BusinesObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Services
{
    public class TransactionService
    {
        /// <summary>
        /// Lisab uue ostutehingu andmebaasitabelisse Transaction ja iga müüdud toote kohta
        /// uue ostutehingurea tabelisse TransactionLine.
        /// </summary>
        /// <param name="list">Toodete list</param>
        /// <param name="trans">Ostutehingu objekt</param>
       public static void AddNewTransaction(ObservableCollection<ProductBO> list, TransactionBO trans)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.Transaction.Add(trans.ParseDomain());
                db.SaveChanges();

                foreach (ProductBO product in list)
                {
                    db.TransactionLine.Add(new TransactionLine()
                    {
                        ProductId = product.ProductId,
                        TransactionId = db.Transaction.Max(x => x.TransactionId),
                        Quantity = product.ProductQuantity,
                        SalePrice = product.ProductPrice
                    });
                }
                db.SaveChanges();
            }
        }
    }
}
