using CashRegister.Domain;
using Kassarakendus.BusinesObjects;
using Kassarakendus.UserControls;
using Kassarakendus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kassarakendus.Views
{

    public partial class AddingView : Page
    {
        private AddingVM _vm;

        /// <summary>
        /// Konstruktor uue toote lisamiseks.
        /// </summary>
        public AddingView()
        {
            InitializeComponent();
            _vm = new AddingVM();
            this.DataContext = _vm;
            _vm.LoadCategories();
        }

        /// <summary>
        /// Konstruktor toote andmete muutmiseks.
        /// </summary>
        /// <param name="product"></param>
        public AddingView(ProductBO product)
        {
            InitializeComponent();
            _vm = new AddingVM();
            _vm.LoadCategories();
            _vm.SelectedProduct = product;
            this.DataContext = _vm;

            cbNewProductCategory.SelectedItem = _vm.Categories
                .Where(x => x.CategoryId == product.CategoryId)
                .FirstOrDefault();

            btnEditProduct.Visibility = Visibility.Visible;
            btnNewProduct.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Uue kategooria lisamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryBO newCategory = new CategoryBO
            {
                CategoryName = tbNewCategory.Text
            };

            _vm.AddNewCategory(newCategory);
            tbNewCategory.Clear();
        }

        /// <summary>
        /// Uue toote lisamine, pärast lisamist tühjendatakse vormi väljad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ValidValues())
            {
                ProductBO newProduct = new ProductBO
                {
                    ProductName = tbNewProductName.Text,
                    ProductCode = tbNewProductCode.Text,
                    CategoryId = ((CategoryBO)cbNewProductCategory.SelectedValue).CategoryId,
                    ProductPrice = Convert.ToDecimal(tbNewProductPrice.Text),
                    ProductQuantity = Convert.ToInt32(tbNewProductQuanity.Text),
                    ProductComment = tbNewProductComment.Text
                };

                if (_vm.ValidProduct(newProduct))
                {
                    _vm.AddNewProduct(newProduct);

                    cbNewProductCategory.SelectedIndex = 0;
                    foreach (var c in spProductForm.Children)
                    {
                        if (c.GetType() == typeof(TextBox))
                        {
                            ((TextBox)(c)).Clear();
                        }
                    }
                }
                else
                {
                    BaseVM.ErrorPopup("Selline toode on olemas!");
                }
            }
            else
            {
                BaseVM.ErrorPopup("Ebakorrektsed andmed!");
            }
        }

        /// <summary>
        /// Kontrollib sisestatud andmete korrektsust.
        /// </summary>
        /// <returns></returns>
        private bool ValidValues()
        {
            return
                BaseVM.ValidStringInputs(new List<string>() {
                tbNewProductName.Text, tbNewProductCode.Text })
                &&
                BaseVM.ValidIntegerInputs(new List<string>() {
                tbNewProductQuanity.Text})
                &&
                BaseVM.ValidDecimalInputs(new List<string>() {
                    tbNewProductPrice.Text });
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            _vm.SelectedProduct.ProductName = tbNewProductName.Text;
            _vm.SelectedProduct.ProductCode = tbNewProductCode.Text;
            _vm.SelectedProduct.CategoryId = ((CategoryBO)cbNewProductCategory.SelectedValue).CategoryId;
            _vm.SelectedProduct.ProductPrice = Convert.ToDecimal(tbNewProductPrice.Text);
            _vm.SelectedProduct.ProductQuantity = Convert.ToInt32(tbNewProductQuanity.Text);
            _vm.SelectedProduct.ProductComment = tbNewProductComment.Text;

            _vm.EditProduct(_vm.SelectedProduct);

            //parast toote muutmist navigeeritakse vastava toote kategooriasse
            App.MainView.frameMain
                .NavigationService
                .Navigate(new StorageBtnsView(cbNewProductCategory.SelectedItem as CategoryBO));
        }

        private void btnCancelProduct_Click(object sender, RoutedEventArgs e)
        {
            App.MainView.frameMain
                .NavigationService
                .Navigate(new StorageBtnsView());
        }
    }
}
