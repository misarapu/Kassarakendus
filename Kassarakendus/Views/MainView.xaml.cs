using Kassarakendus.UserControls;
using Kassarakendus.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Kassarakendus.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        private MainVM _vm;
        private CartUC _cartUC;

        /// <summary>
        /// Vaate konstruktor.
        /// </summary>
        /// <param name="status">
        /// String tüüpi väärtus, mis viitab päeva avatusele.
        /// </param>
        public MainView(string status)
        {
            this.InitializeComponent();
            _vm = new MainVM();
            this.DataContext = _vm;

            if (status == "closed")
            {
                spPopup.Children.Add(new CashCalcUC("open"));
                spPopup.Visibility = Visibility.Visible;
            }

            StorageBtnsView catView = new StorageBtnsView();
            frameMain.NavigationService.Navigate(catView);
        }

        /// <summary>
        /// Kuvatakse kategooria ja toote lisamise vorm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToAddingFrame_Click(object sender, RoutedEventArgs e)
        {
            frameMain.NavigationService.Navigate(new AddingView());
        }

        /// <summary>
        /// Toodete otsimine vastavalt teksti muutumisele otsingu lahtris.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                string input = txt.Text;
                if (!input.Equals(""))
                {
                    frameMain.NavigationService.Navigate(new StorageBtnsView(input));
                }
                else
                {
                    frameMain.NavigationService.Navigate(new StorageBtnsView());
                }
            }
        }

        /// <summary>
        /// Tagasi kategooriate vaatele navigeerimine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToCategories_Click(object sender, RoutedEventArgs e)
        {
            frameMain.NavigationService.Navigate(new StorageBtnsView());
        }

        /// <summary>
        /// Ostukorvi kinnitamine ja maksmise vaate kuvamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommitCart_Click(object sender, RoutedEventArgs e)
        {
            if (App.UserCart.Count == 0)
            {
                spPopup.Children.Add(new ErrorMessageUC("Ostukorv on tühi!"));
            }
            else
            {
                spPopup.Children.Add(new PurchaseUC(App.TotalPrice.ToString()));
            }
            App.DisableMainView();
        }

        /// <summary>
        /// Ostukorvi tühistamine põhivaates.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelCart_Click(object sender, RoutedEventArgs e)
        {
            App.NewCart();
        }

        /// <summary>
        /// Kasutaja/klientide vaate kuvamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToUsersClient_Click(object sender, RoutedEventArgs e)
        {
            UsersClientsView ucView = new UsersClientsView();
            TempVM.UsersClientsView = ucView;
            frameMain.NavigationService.Navigate(ucView);
        }

        /// <summary>
        /// Päeva sulgemise vaate kuvamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseDay_Click(object sender, RoutedEventArgs e)
        {
            spPopup.Children.Add(new CashCalcUC("close"));
            App.DisableMainView();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginVM.LogOutUser();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            frameMain.NavigationService.Navigate(new ReportView());
        }
    }
}
