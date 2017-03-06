using Kassarakendus.BusinesObjects;
using Kassarakendus.UserControls;
using Kassarakendus.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kassarakendus.Views
{
    /// <summary>
    /// Interaction logic for StorageBtnsView.xaml
    /// </summary>
    public partial class StorageBtnsView : Page
    {
        ProductsVM _vm;

        /// <summary>
        /// Vaate konstruktor toodete nuppude jaoks.
        /// </summary>
        /// <param name="category">Valitud kategooria CategpryBO</param>
        public StorageBtnsView(CategoryBO category)
        {
            InitializeComponent();
            _vm = new ProductsVM();
            _vm.SelectedCategory = category;
            _vm.LoadProducts(category.CategoryId);
            this.DataContext = _vm;
        }

        /// <summary>
        /// Vaate konstruktor toodete nuppude jaoks.
        /// </summary>
        /// <param name="text">Otsingulahtrisse sisestatud tekst.</param>
        public StorageBtnsView(string text)
        {
            InitializeComponent();
            _vm = new ProductsVM();
            _vm.LoadProducts(text);
            this.DataContext = _vm;
        }

        /// <summary>
        /// Vaate konstruktor kategooria nuppude jaoks.
        /// </summary>
        /// <param name="text">Otsingulahtrisse sisestatud tekst.</param>
        public StorageBtnsView()
        {
            InitializeComponent();
            dbActionBtns.Visibility = Visibility.Collapsed;
            _vm = new ProductsVM();
            _vm.LoadCategories();
            this.DataContext = _vm;
        }

        /// <summary>
        /// Toote lisamine ostukorvi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                _vm.SelectedProduct = btn.DataContext as ProductBO;

                if (_vm.SelectAction) //nupp on ostukorvi lisamise staatuses
                {
                    _vm.AddProductToCart(_vm.SelectedProduct);
                }
                if (_vm.DeleteAction) //nupp on toote kustutamise staatuses
                {
                    string message = "Kustuta toode\n" + _vm.SelectedProduct.ProductName;
                    BaseVM.AskPopup(message, _vm.DeleteProductClick);
                }
                if (_vm.EditAction) //nupp on toote muutmise staatuses
                {
                    App.MainView.frameMain.NavigationService
                        .Navigate(new AddingView(_vm.SelectedProduct));
                }
            }
        }

        /// <summary>
        /// Kategooria nupule vajutamine, mille tulemusena kuvatakse selle
        /// kategooria toodete nupud toodete vaates.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                CategoryBO selectedCategory = btn.DataContext as CategoryBO;
                if (selectedCategory != null)
                {
                    _vm.SelectedCategory = selectedCategory;
                    this.NavigationService.Navigate(new StorageBtnsView(selectedCategory));
                }
            }
        }

        /// <summary>
        /// Vaades saab tooteid kustutada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnDelete_Checked(object sender, RoutedEventArgs e)
        {
            _vm.DeleteAction = true;
            App.NewCart();
        }

        /// <summary>
        /// Vaates saab tooteid ostukorvi lisada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnSelect_Checked(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
            {
                _vm.SelectAction = true;
            }
        }

        /// <summary>
        /// Vaates saab tooteid muuta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnEdit_Checked(object sender, RoutedEventArgs e)
        {
            _vm.EditAction = true;
            App.NewCart();
        }
    }
}
