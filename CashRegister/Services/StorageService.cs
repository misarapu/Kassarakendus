using CashRegister.Domain;
using Kassarakendus.BusinesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Services
{
    public static class StorageService
    {
        /// <summary>
        /// Tagastab kategooriate loendi BO-dena tabelist Category.
        /// </summary>
        /// <returns></returns>
        public static List<CategoryBO> GetAllCategories()
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                return db.Category.AsEnumerable().Select(x => new CategoryBO(x))
                    .OrderBy(x => x.CategoryName).ToList();
            }
        }

        /// <summary>
        /// Tagastab vastava kategooria toodete loendi BO-dena tabelist Product.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static List<ProductBO> GetProductsByCategoryId(int categoryId)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                return db.Product
                    .Where(x => x.CategoryId == categoryId && x.To == null).ToList()
                    .Select(x => new ProductBO(x))
                    .OrderBy(x => x.ProductName).ToList();
            }
        }

        /// <summary>
        /// Lisab tabelisse Product uue toote.
        /// </summary>
        /// <param name="newProduct"></param>
        public static void AddNewProduct(ProductBO newProduct)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.Product.Add(newProduct.ParseDomain());
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Lisab tabelisse Category uue kategooria.
        /// </summary>
        /// <param name="newCategory"></param>
        public static void AddNewCategory(CategoryBO newCategory)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.Category.Add(newCategory.ParseDomain());
                db.SaveChanges();
            }
        }

        public static void RemoveProduct(ProductBO product)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                db.Product.Where(x => x.ProductId == product.ProductId)
                    .FirstOrDefault().To = DateTime.Now;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Toote otsimine andmebaasist toote koodi või toote nime järgi.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<ProductBO> ProductSearch(string input)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                if (!String.IsNullOrEmpty(input))
                {
                    return db.Product
                        .Where(
                                x => x.Name.ToLower().Contains(input.ToLower()) && x.To == null || 
                                x.Code.ToLower().Contains(input.ToLower()) && x.To == null
                              )
                        .ToList()
                        .Select(x => new ProductBO(x)).ToList(); ;

                } else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Toote andmete muutmine.
        /// </summary>
        /// <param name="product"></param>
        public static void EditProduct(ProductBO product)
        {
            using (Domain.CashregisterDBEntities db = new Domain.CashregisterDBEntities())
            {
                Product productOld = db.Product
                    .Where(x => x.ProductId == product.ProductId)
                    .FirstOrDefault();

                productOld.Name = product.ProductName;
                productOld.Code = product.ProductCode;
                productOld.CategoryId = product.CategoryId;
                productOld.Price = product.ProductPrice;
                productOld.Quantity = product.ProductQuantity;
                productOld.Comment = product.ProductComment;

                db.SaveChanges();
            }
        }
    }
}
