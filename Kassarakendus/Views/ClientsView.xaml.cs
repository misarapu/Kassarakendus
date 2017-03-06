using CashRegister.BusinesObjects;
using CashRegister.Domain;
using CashRegister.Services;
using Kassarakendus.UserControls;
using Kassarakendus.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Kassarakendus.Views
{

    public partial class ClientsView : Page
    {
        ClientVM _vm;

        /// <summary>
        /// Vaate konstruktor.
        /// </summary>
        public ClientsView()
        {
            ClientsInit();
            ShowFirstClient();
        }

        public ClientsView(ClientBO client)
        {
            ClientsInit();
            _vm.Client = client;
            ShowClientInfo(_vm.Client);
        }

        /// <summary>
        /// Meetod, mis laeb klientide vaate algomadused. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientsInit()
        {
            InitializeComponent();
            _vm = new ClientVM();
            _vm.LoadClients();
            _vm.LoadLevels();
            this.DataContext = _vm;
        }

        /// <summary>
        /// Klientide loendis nime (nupu) peal vajutamise meetod. Vaatesse
        /// lisatakse uus UserControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                _vm.Client = btn.DataContext as ClientBO;
                ShowClientInfo(_vm.Client);
            }
        }

        /// <summary>
        /// Uue kliendi lisamise vormi kuvamise nupule vajutamise meetod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                ShowAddForm();
            }
        }

        /// <summary>
        /// Uue kliendi lisamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            if (ValidValues())
            {
                ClientBO newClient = new ClientBO
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Phone = tbPhone.Text,
                    Email = tbEmail.Text,
                    Since = DateTime.Now,
                    Level = ((ClientLevelBO)cbClientLevel.SelectedItem).LevelId
                };

                _vm.Client = newClient;
                _vm.AddNewClient(_vm.Client);
                ShowClientInfo(_vm.Client);
            }
            else
            {
                BaseVM.ErrorPopup("Ebakorretsed andmed!");
                ShowAddForm();
            }
        }

        /// <summary>
        /// Valitud kliendi kustutamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            _vm.RemoveClient(_vm.Client);
            ShowFirstClient();
        }

        /// <summary>
        /// Klientide otsimine loendist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearchClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSearchClient.Text == "")
            {
                _vm.LoadClients();
            }
            else
            {
                _vm.SearchClient(tbSearchClient.Text);
            }
        }

        /// <summary>
        /// Eemaldab vaatest UserControl'i objekti.
        /// </summary>
        private void ClearSpUserControl()
        {
            if (spUserControl.Children.Count > 0)
            {
                spUserControl.Children.Clear();
            }
        }

        /// <summary>
        /// Vaatesse UserControl'i lisamine.
        /// </summary>
        /// <param name="uc"></param>
        private void AddToSpUserControl(UserControl uc)
        {
            ClearSpUserControl();
            spUserControl.Children.Add(uc);
        }

        /// <summary>
        /// Kliendi lisamise vormi kuvamine.
        /// </summary>
        private void ShowAddForm()
        {
            ClearSpUserControl();
            spInfoBtns.Visibility = Visibility.Collapsed;
            gridClientAdd.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Kliendi sidumine ostuga.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectClient_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.AllClients.Count != 0)
            {
                App.ClientSelected = _vm.Client;
                App.ResetCart();
                App.CartView.tblClient.Text =
                    String.Format("Klient: {0}", App.ClientSelected.FullName);
                App.CartView.tblDiscount.Text =
                    String.Format("Allahindlus: {0}%", _vm.DiscountPercent(App.ClientSelected));
                App.ClientTotalPrice();
            }
        }

        private void ShowClientInfo(ClientBO client)
        {
            _vm.Client = client;
            gridClientAdd.Visibility = Visibility.Collapsed;
            spInfoBtns.Visibility = Visibility.Visible;
            AddToSpUserControl(new ClientInfoUC(client));
        }

        private bool ValidValues()
        {
            return
                BaseVM.ValidStringInputs(new List<string>() {
                    tbFirstName.Text,
                    tbLastName.Text,
                    tbEmail.Text,
                    tbPhone.Text});
        }

        private void ShowFirstClient()
        {
            if (_vm.AllClients.Count > 0)
            {
                ShowClientInfo(_vm.AllClients[0]);
            }
            else
            {
                ClearSpUserControl();
            }
        }

        private void btnCancelAddUser_Click(object sender, RoutedEventArgs e)
        {
            ShowFirstClient();
        }
    }
}
