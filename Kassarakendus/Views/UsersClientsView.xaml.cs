using CashRegister.BusinesObjects;
using CashRegister.Services;
using Kassarakendus.UserControls;
using Kassarakendus.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace Kassarakendus.Views
{
    /// <summary>
    /// Interaction logic for UsersClientsView.xaml
    /// </summary>
    public partial class UsersClientsView : Page
    {
        /// <summary>
        /// Vaate konstruktor.
        /// </summary>
        public UsersClientsView()
        {
            InitializeComponent();
            BtnActive(btnClerks);
            BtnPassive(btnClients);
            frameUsersClients.NavigationService.Navigate(new UsersView());
        }

        /// <summary>
        /// Kasutajate vaate kuvamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClerks_Click(object sender, RoutedEventArgs e)
        {
            BtnActive(btnClerks);
            BtnPassive(btnClients);
            frameUsersClients.NavigationService.Navigate(new UsersView());
        }

        /// <summary>
        /// Klientide vaate kuvamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            ClientService.FillClientLevels();
            BtnActive(btnClients);
            BtnPassive(btnClerks);
            frameUsersClients.NavigationService.Navigate(new ClientsView());
        }

        /// <summary>
        /// Aktiivse nupu välimuse muutmine.
        /// </summary>
        /// <param name="btn"></param>
        private void BtnActive(Button btn)
        {
            btn.Background = Brushes.White;
            btn.Foreground = Brushes.Navy;
        }

        /// <summary>
        /// Passiivse nupu välimuse muutmine.
        /// </summary>
        /// <param name="btn"></param>
        private void BtnPassive(Button btn)
        {
            btn.Background = Brushes.Navy;
            btn.Foreground = Brushes.White;
        }
    }
}
