using CashRegister.Domain;
using CashRegister.Services;
using Kassarakendus.BusinesObjects;
//using Kassarakendus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.ViewModels
{
    public class AddingVM : ProductsVM
    {
        private ProductBO _product;
        private CategoryBO _categeory;

        /// <summary>
        /// Property, mis tagastab ja väärtustab toote objekti.
        /// </summary>
        public ProductBO Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
            }
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab kategooria objekti.
        /// </summary>
        public CategoryBO Category
        {
            get
            {
                return _categeory;
            }

            set
            {
                _categeory = value;
            }
        }

        /// <summary>
        /// Lisab uue kategooria.
        /// </summary>
        /// <param name="newCategory"></param>
        public void AddNewCategory(CategoryBO newCategory)
        {
            if (newCategory.CategoryName != "")
            {
                if (ValidCategory(newCategory))
                {
                    StorageService.AddNewCategory(newCategory);
                    LoadCategories();
                    BaseVM.ConfirmPopup("Lisatud kategooria\n" + newCategory.CategoryName);
                }
                else
                {
                    BaseVM.ErrorPopup("Selline kategooria on olemas!");
                }
            }
            else
            {
                BaseVM.ErrorPopup("Ebakorrektsed andmed!");
            }
        }

        /// <summary>
        /// Kontrollib kategooria olemis andmebaasis.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool ValidCategory(CategoryBO category)
        {
            return StorageService.GetAllCategories()
                .Where(x => x.CategoryName == category.CategoryName).ToList().Count == 0;
        }

        /// <summary>
        /// Lisab uue toote.
        /// </summary>
        /// <param name="newProduct"></param>
        public void AddNewProduct(ProductBO newProduct)
        {
            StorageService.AddNewProduct(newProduct);
            BaseVM.ConfirmPopup("Lisatud uus toode\n" + newProduct.ProductName);
        }

        /// <summary>
        /// Kontrollib Toote olemis andmebaasis.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool ValidProduct(ProductBO product)
        {
            return StorageService.ProductSearch(product.ProductCode).Count() == 0;
        }
    }
}
