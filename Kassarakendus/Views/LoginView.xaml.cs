using CashRegister.Services;
using Kassarakendus.UserControls;
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

namespace Kassarakendus.Views
{

    public partial class LoginView : Page
    {
        LoginVM _vm;

        /// <summary>
        /// Vaate konstruktor.
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
            _vm = new LoginVM();
            this.DataContext = _vm;
        }

        /// <summary>
        /// Kasutaja sisselogimine, kontrollitakse päeva avatust ja
        /// sisestatud andmete õigsust.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmLogin_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && _vm.LoginConfirm(tbUserName.Text, tbPassword.Password))
            {
                if (_vm.IsDayOpened())
                {
                    App.MainView = new MainView("opened");
                    App.LoginCash = LoginService.LastCash();
                }
                else
                {
                    App.MainView = new MainView("closed");
                }

                _vm.Login(UserService.GetUserByUserName(tbUserName.Text));
                this.NavigationService.Navigate(App.MainView);
            }
            else
            {
                if (spLoginErr.Children.Count > 0)
                {
                    spLoginErr.Children.RemoveAt(0);
                }

                tbUserName.Text = "";
                tbPassword.Password = "";
                spLoginErr.Children.Add(new LoginErrUC());
            }
        }

        /// <summary>
        /// Sisselogimise tühistamine, millega suletakse rakendus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelLogin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
