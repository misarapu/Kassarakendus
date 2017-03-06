using CashRegister.Services;
using Kassarakendus.UserControls;
using Kassarakendus.ViewModels;
using Kassarakendus.Views;
using System.Windows;
using System.Windows.Controls;
using System;
using System.ComponentModel;


namespace Kassarakendus
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Rakenduse akna sulgemisel logitakse kasutaja välja.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (App.LoggedInUser != null)
            {
                LoginVM.LogOutUser();
                if (App.DayOpeningActive)
                {
                    LoginService.RemoveLastLogin();
                }
            }
        }
    }
}
