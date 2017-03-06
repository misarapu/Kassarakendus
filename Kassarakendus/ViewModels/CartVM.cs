using CashRegister.Services;
using Kassarakendus.BusinesObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using CashRegister.BusinesObjects;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kassarakendus.ViewModels
{
    public class CartVM
    {
        private ObservableCollection<ProductBO> _cart;
        private string _totalPrice;

        /// <summary>
        /// ViewModel konstruktor.
        /// </summary>
        public CartVM()
        {
            _cart = new ObservableCollection<ProductBO>();
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab ostukorvi toodete loendi.
        /// </summary>
        public ObservableCollection<ProductBO> ShoppingCart
        {
            get
            {   
                return _cart;
            }
            set
            {
                _cart = value;
            }
        }

        public string TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = value;
            }
        }

        /// <summary>
        /// Eemaldab ostukorvist toote.
        /// </summary>
        /// <param name="selectedProduct"></param>
        public void RemoveProduct(ProductBO selectedProduct)
        {
            App.RemoveFromCart(selectedProduct);
            LoadCart();
        }

        /// <summary>
        /// Laeb ostukorvi loendi.
        /// </summary>
        public void LoadCart()
        {
            ShoppingCart = App.UserCart;
            TotalPrice = App.TotalPrice.ToString();
        }
    }
}
