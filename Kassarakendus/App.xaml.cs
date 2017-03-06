using CashRegister.BusinesObjects;
using CashRegister.Services;
using Kassarakendus.BusinesObjects;
using Kassarakendus.UserControls;
using Kassarakendus.ViewModels;
using Kassarakendus.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Kassarakendus
{

    public partial class App : Application
    {
        private static MainView _mainView;
        private static ObservableCollection<ProductBO> _cart;
        private static ObservableCollection<ProductBO> _cartInit;
        private static decimal _totalPrice;
        private static UserBO _loggedInUser;
        private static decimal _loginCash;
        private static bool _dayOpeningActive;
        private static ClientBO _clientSelected;
        private static CartUC _cartUC;

        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab põhivaate objekti
        /// pärast sisselogimist.
        /// </summary>
        public static MainView MainView
        {
            get { return _mainView; }
            set
            {
                _mainView = value;
                NewCart();
            }
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab ostukorvi vaate objekti.
        /// </summary>
        public static CartUC CartView
        {
            get { return _cartUC; }
            set { _cartUC = value; }
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab sisselogimisel kassas oleva
        /// sularaha summa.
        /// </summary>
        public static decimal LoginCash
        {
            get { return _loginCash; }
            set { _loginCash = value; }
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab tõeväärtuse selle kohta, kas päev
        /// on avatud või mitte.
        /// </summary>
        public static bool DayOpeningActive
        {
            get { return _dayOpeningActive; }
            set { _dayOpeningActive = value; }
        }

        /// <summary>
        /// Property, mis tagastab ostukorvi toodete listi kliendi hindadega. 
        /// </summary>
        public static ObservableCollection<ProductBO> UserCart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new ObservableCollection<ProductBO>();
                }
                return _cart;
            }
        }

        /// <summary>
        /// Property, mis tagastab ostukorvi toodete listi andmebaasi hindadega. 
        /// </summary>
        public static ObservableCollection<ProductBO> UserCartInit
        {
            get
            {
                if (_cartInit == null)
                {
                    _cartInit = new ObservableCollection<ProductBO>();
                }
                return _cartInit;
            }
        }

        /// <summary>
        /// Arvutatakse ümber kõik ostukorvis olevate toodete hinnad vastavalt
        /// kliendi allahindluskoefitsendile.
        /// </summary>
        public static void ResetPrices()
        {
            if (ClientSelected != null)
            {
                decimal discount = ClientService.GetClientLevel(ClientSelected.Level).Discount;
                for (int i = 0; i < _cart.Count; i++)
                {
                    _cart[i].ProductPrice = _cartInit[i].ProductPrice * discount;
                }
            }
        }

        /// <summary>
        /// Eemaldab toote nii kliendi hindadega ostukorvist kui ka õigest ostukorvist.
        /// </summary>
        /// <param name="product"></param>
        public static void RemoveFromCart(ProductBO product)
        {
            UserCart.Remove(product);
            UserCartInit.Remove(product);
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab ostukorvi summa
        /// vastavalt kliendi staatusele. 
        /// </summary>
        public static decimal TotalPrice
        {
            get
            {
                if (UserCart.Count() > 0)
                {
                    return UserCart.Sum(x => x.ProductPrice * x.ProductQuantity);
                }
                return 0;
            }
            set { _totalPrice = value; }
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab viimati sisse loginud
        /// kasutaja.
        /// </summary>
        public static UserBO LoggedInUser
        {
            get
            {
                if (_loggedInUser == null)
                {
                    return LoginService.GetLoggedInUser();
                }
                else
                {
                    return _loggedInUser;
                }
            }
            set { _loggedInUser = value; }
        }

        /// <summary>
        /// Property, mis väärtustab ja tagastab kasutaja poolt valitud
        /// kliendi.
        /// </summary>
        public static ClientBO ClientSelected
        {
            get { return _clientSelected; }
            set { _clientSelected = value; }
        }

        /// <summary>
        /// Meetod, mis sätestab põhivaatesse uue ostukorvi vaate.
        /// </summary>
        public static void NewCart()
        {
            if (_mainView != null)
            {
                UserCart.Clear();
                UserCartInit.Clear();
                ClientSelected = null;
                ResetCart();
            }
        }

        /// <summary>
        /// Luuakse uus ostukorvi vaade ning tühjendatakse ostukorvi list.
        /// </summary>
        public static void ResetCart()
        {
            ResetPrices();
            _cartUC = new CartUC();
            _cartUC.DataContext = new CartVM();
            _mainView.gridLeft.Children.Clear();
            _mainView.gridLeft.Children.Add(CartView);
            CartView = _cartUC;
        }

        /// <summary>
        /// Meetod, mis logib kasutaja välja.
        /// </summary>
        /// <param name="cashAmount">
        /// Kassas olev sularaha summa.
        /// </param>
        public static void LogOutUser(decimal cashAmount)
        {
            if (MainView != null)
            {
                LoginService.LogoutUser(LoggedInUser, cashAmount);
                App.LoggedInUser = null;
                MainView.NavigationService.Navigate(new LoginView());
                MainView = null;
            }
        }

        /// <summary>
        /// Meetod, mis sätestab ostukorvi summa stringina.
        /// </summary>
        public static void ClientTotalPrice()
        {
            CartView.tblTotalPriceCart.Text = TotalPrice.ToString("F");
        }

        /// <summary>
        /// Põhivaate põhigridi kasutatavaks muutmine.
        /// </summary>
        public static void EnableMainView()
        {
            _mainView.spPopup.Children.Clear();
            _mainView.spPopup.Visibility = Visibility.Collapsed;
            _mainView.gridMain.IsEnabled = true;
        }

        /// <summary>
        /// Põhivaate põhigridi kasutamatuks muutmine.
        /// </summary>
        public static void DisableMainView()
        {
            _mainView.spPopup.Visibility = Visibility.Visible;
            _mainView.gridMain.IsEnabled = false;
        }
    }
}
