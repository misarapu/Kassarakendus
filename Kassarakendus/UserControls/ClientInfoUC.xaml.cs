using CashRegister.BusinesObjects;
using CashRegister.Domain;
using Kassarakendus.ViewModels;
using Kassarakendus.Views;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kassarakendus.UserControls
{
    public partial class ClientInfoUC : UserControl
    {
        ClientVM _vm;

        /// <summary>
        /// UserControl konstruktor, täidetakse vaate vastavad väljad. 
        /// </summary>
        /// <param name="client"></param>
        public ClientInfoUC(ClientBO client)
        {
            InitializeComponent();
            _vm = new ClientVM();
            _vm.LoadLevels();
            _vm.Client = client;
            cbClientLevel.SelectedItem = _vm.ClientLevel;
            this.DataContext = _vm;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                gridEditBtns.Visibility = Visibility.Visible;
                string tmpValue = "";
                foreach (DependencyObject child in (btn.Parent as StackPanel).Children)
                {
                    if (child is TextBlock)
                    {
                        (child as TextBlock).Visibility = Visibility.Collapsed;
                        tmpValue = (child as TextBlock).Text;
                    }
                    if (child is TextBox)
                    {
                        (child as TextBox).Visibility = Visibility.Visible;
                        (child as TextBox).Text = tmpValue;
                    }
                    if (child is ComboBox)
                    {
                        (child as ComboBox).Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void tbEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                foreach (DependencyObject child in (tb.Parent as StackPanel).Children)
                {
                    if (child is TextBlock)
                    {
                        (child as TextBlock).Text = tb.Text;
                    }
                }
            }
        }

        private void cbClientLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null)
            {
                foreach (DependencyObject child in (cb.Parent as StackPanel).Children)
                {
                    if (child is ComboBox)
                    {
                        (child as ComboBox).SelectedItem = cb.SelectedItem;
                    }
                }
            }
        }

        private void btnEditConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (ValidValues())
            {
                _vm.Client.FirstName = tblFirstName.Text;
                _vm.Client.LastName = tblLastName.Text;
                _vm.Client.Phone = tblPhone.Text;
                _vm.Client.Email = tblEmail.Text;
                _vm.Client.Level = ((ClientLevelBO)(cbClientLevel.SelectedItem)).LevelId;

                _vm.EditClient(_vm.Client);

                //Klientide leht laetakse uuesti
                TempVM.UsersClientsView.frameUsersClients
                    .NavigationService
                    .Navigate(new ClientsView(_vm.Client));
            }
            else
            {
                BaseVM.ErrorPopup("Ebakorretsed andmed!");
            }
        }

        private void btnCancelEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool ValidValues()
        {
            return
                BaseVM.ValidStringInputs(new List<string>() {
                    tblFirstName.Text,
                    tblLastName.Text,
                    tblEmail.Text,
                    tblPhone.Text});
        }
    }
}
