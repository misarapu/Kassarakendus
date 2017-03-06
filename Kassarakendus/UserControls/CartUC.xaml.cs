using Kassarakendus.BusinesObjects;
using Kassarakendus.ViewModels;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Kassarakendus.UserControls
{
    public partial class CartUC : UserControl
    {
        CartVM _vm;

        /// <summary>
        /// UserControl konstruktor.
        /// </summary>
        public CartUC()
        {
            InitializeComponent();
            this.Loaded += ShoppingCart_Loaded;
            tblTotalPriceCart.Text = "0.00";
            ((INotifyCollectionChanged)App.UserCart).CollectionChanged += ListView_CollectionChanged;
        }

        /// <summary>
        /// Laetakse ostukorvi loend.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShoppingCart_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = new CartVM();
            _vm.LoadCart();
            this.DataContext = _vm;
        }

        /// <summary>
        /// Eemaldab toote ostukorvist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductBO product = (sender as Button).DataContext as ProductBO;
            _vm.RemoveProduct(product);
        }

        /// <summary>
        /// Ostukorvi summa arvutamine vastavalt ostukorvi loendi muutusele.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add ||
                e.Action == NotifyCollectionChangedAction.Remove)
            {
                tblTotalPriceCart.Text = App.TotalPrice.ToString("F");
            }
        }
    }
}
