using CashRegister.BusinesObjects;
using CashRegister.Domain;
using Kassarakendus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kassarakendus.UserControls
{
    public partial class PurchaseUC : UserControl
    {
        PurchaseVM _vm;

        /// <summary>
        /// UserControl konstruktor.
        /// </summary>
        /// <param name="totalCost"></param>
        public PurchaseUC(string totalCost)
        {
            InitializeComponent();
            tblTotalPrice.Text = totalCost;
            _vm = new PurchaseVM();
            _vm.PaymentType = "cash";
            btnCash.Background = Brushes.DeepSkyBlue;
            this.DataContext = _vm;
        }

        /// <summary>
        /// Muudetakse maksetüüp kaardimakseks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCard_Click(object sender, RoutedEventArgs e)
        {
            btnCard.Background = Brushes.DeepSkyBlue;
            btnCash.Background = Brushes.LightBlue;
            _vm.PaymentType = "card";
            tbPaid.Text = tblTotalPrice.Text;
        }

        /// <summary>
        /// Muudetakse maksetüüp sularahamakseks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCash_Click(object sender, RoutedEventArgs e)
        {
            btnCard.Background = Brushes.LightBlue;
            btnCash.Background = Brushes.DeepSkyBlue;
            _vm.PaymentType = "cash";
            tbPaid.Text = "";
        }

        /// <summary>
        /// Kinnitatakse ostutehing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmPurchase_Click(object sender, RoutedEventArgs e)
        {
            TransactionBO trans = new TransactionBO();

            trans.ClerkId = App.LoggedInUser.UserId;
            trans.PaymentType = _vm.PaymentType;
            trans.TotalCost = App.TotalPrice;
            if (App.ClientSelected != null)
            {
                trans.ClientId = App.ClientSelected.ClientId;
            }

            _vm.AddNewTransaction(trans);
            App.NewCart();
            App.EnableMainView();
        }

        /// <summary>
        /// Tühistatakse ostutehing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelPurchase_Click(object sender, RoutedEventArgs e)
        {
            App.EnableMainView();
        }

        /// <summary>
        /// Kliendile tagastatava sularaha summa arvutamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPaid_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal paid;
            if (Decimal.TryParse(tbPaid.Text, out paid))
            {
                tblMoneyBack.Text = (paid - App.TotalPrice).ToString("F");
            }
            else
            {
                tbPaid.Text = "";
                tblMoneyBack.Text = "";
            }
        }
    }
}
