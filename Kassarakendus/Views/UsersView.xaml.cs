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
   
    public partial class UsersView : Page
    {
        UserVM _vm;
        public UsersView()
        {
            InitializeComponent();
            this.Loaded += UsersView_Loaded;
        }

        /// <summary>
        /// Meetod, mis laeb kasutajate vaate algomadused. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersView_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = new UserVM();
            _vm.LoadUsers();
            this.DataContext = _vm;
            ClearSpUserControl();
            ShowFirstUser();
        }

        /// <summary>
        /// Kasutajate loendis nime (nupu) peal vajutamise meetod. Vaatesse
        /// lisatakse uus UserControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                _vm.User = btn.DataContext as UserBO;
                AddToSpUserControl(new UserInfoUC(_vm.User));
            }
        }

        /// <summary>
        /// Uue kasutaja lisamise vormi kuvamise nupule vajutamise meetod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                ShowAddForm();
            }
        }

        /// <summary>
        /// Valitud kasutaja kustutamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            _vm.RemoveUser(_vm.User);
            ShowFirstUser();
        }

        /// <summary>
        /// Kasutajate otsimine loendist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearchUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSearchUser.Text == "")
            {
                _vm.LoadUsers();
            }
            else
            {
                _vm.SearchUser(tbSearchUser.Text);
            }
        }

        /// <summary>
        /// Uue kasutaja lisamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            if (ValidValues())
            {
                UserBO newUser = new UserBO
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    UserName = tbUserName.Text,
                    Password = pbPassword.Password,
                    BirthDate = Convert.ToDateTime(
                        String.Format("{0}/{1}/{2}",
                        tbMonth.Text, tbDay.Text, tbYear.Text)),
                    Phone = tbPhone.Text,
                    Email = tbEmail.Text,
                    Role = _vm.RoleMatcher(cbUserRole.Text)
                };

                if (_vm.ValidUserName(tbUserName.Text))
                {
                    _vm.AddNewUser(newUser);
                    AddToSpUserControl(new UserInfoUC(newUser));
                }
                else
                {
                    BaseVM.ErrorPopup("Selline kasutajanimi on kasutusel.");
                }
            }
            else
            {
                BaseVM.ErrorPopup("Ebakorrektsed andmed!");
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
        /// Kasutaja lisamise vormi kuvamine.
        /// </summary>
        private void ShowAddForm()
        {
            if (App.LoggedInUser.Role == "admin")
            {
                ClearSpUserControl();
                spInfoBtns.Visibility = Visibility.Collapsed;
                gridUserAdd.Visibility = Visibility.Visible;
            }
            else
            {
                BaseVM.ErrorPopup("Õigused puuduvad!");
            }
        }

        /// <summary>
        /// Vaatesse UserControl'i lisamine.
        /// </summary>
        /// <param name="uc"></param>
        private void AddToSpUserControl(UserControl uc)
        {
            ClearSpUserControl();
            gridUserAdd.Visibility = Visibility.Collapsed;
            spInfoBtns.Visibility = Visibility.Visible;
            spUserControl.Children.Add(uc);
        }

        private void ShowFirstUser()
        {
            gridUserAdd.Visibility = Visibility.Collapsed;
            spInfoBtns.Visibility = Visibility.Visible;
            AddToSpUserControl(new UserInfoUC(_vm.AllUsers[0]));
        }

        /// <summary>
        /// Kontrollib andmete korrektsust.
        /// </summary>
        /// <returns></returns>
        private bool ValidValues()
        {
            return
                BaseVM.ValidStringInputs(new List<string>() {
                tbFirstName.Text, tbLastName.Text, tbUserName.Text})
                &&
                BaseVM.ValidIntegerInputs(new List<string>() {
                tbMonth.Text, tbDay.Text, tbYear.Text})
                &&
                pbPassword.Password != "";
        }

        private void btnCancelAddUser_Click(object sender, RoutedEventArgs e)
        {
            ShowFirstUser();
        }
    }
}
