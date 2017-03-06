using CashRegister.Services;
using Kassarakendus.BusinesObjects;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Collections.Generic;
using Kassarakendus.Views;
using System.Windows.Controls;

namespace Kassarakendus.ViewModels
{
    public class ProductsVM : CategoriesVM
    {
        public List<ProductBO> _products;
        private ProductBO _selectedProduct;
        private bool _selectProduct;
        private bool _deleteProduct;
        private bool _editProduct;

        /// <summary>
        /// ViewModel konstruktor.
        /// </summary>
        public ProductsVM()
        {
            _products = new List<ProductBO>();
            DeactivateActions();
            _selectProduct = true;
        }

        /// <summary>
        /// Vastava kategooria toodete laadimine.
        /// </summary>
        /// <param name="categoryId"></param>
        public void LoadProducts(int categoryId)
        {
            var products = StorageService.GetProductsByCategoryId(categoryId);
            foreach (var item in products)
            {
                _products.Add(item);
            }
        }

        /// <summary>
        /// Toodete laadimine vastavalt parameetri tekstile.
        /// </summary>
        /// <param name="input"></param>
        public void LoadProducts(string input)
        {
            var products = StorageService.ProductSearch(input);
            foreach (var item in products)
            {
                _products.Add(item);
            }
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab toodete loendi.
        /// </summary>
        public List<ProductBO> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public ProductBO SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; }
        }

        public bool DeleteAction
        {
            get { return _deleteProduct; }
            set
            {
                DeactivateActions();
                _deleteProduct = value;
            }
        }

        public bool EditAction
        {
            get { return _editProduct; }
            set
            {
                DeactivateActions();
                _editProduct = value;
            }
        }

        public bool SelectAction
        {
            get { return _selectProduct; }
            set
            {
                DeactivateActions();
                _selectProduct = value;
            }
        }

        /// <summary>
        /// Muudab kõikide nupu aktsionite väärtused vääraks.
        /// </summary>
        private void DeactivateActions()
        {
            _deleteProduct = false;
            _editProduct = false;
            _selectProduct = false;
        }

        /// <summary>
        /// Toote objekti lisamine ostukorvi loendisse.
        /// </summary>
        /// <param name="selectedProduct"></param>
        public void AddProductToCart(ProductBO selectedProduct)
        {
            ProductBO productToCart = selectedProduct.Copy();
            productToCart.ProductQuantity = 1;
            App.UserCartInit.Add(selectedProduct);

            if (App.ClientSelected != null)
            {
                decimal discount = ClientService
                    .GetClientLevel(App.ClientSelected.Level).Discount;
                productToCart.ProductPrice *= discount;
            }
            App.UserCart.Add(productToCart);
        }

        private void DeleteProduct(ProductBO product)
        {
            StorageService.RemoveProduct(product);
            App.MainView.frameMain.NavigationService
               .Navigate(new StorageBtnsView(SelectedCategory));
            App.EnableMainView();
        }

        public void DeleteProductClick(object sender, EventArgs e)
        {
            DeleteProduct(SelectedProduct);
        }

        public void EditProduct(ProductBO product)
        {
            StorageService.EditProduct(product);
        }
    }
}
