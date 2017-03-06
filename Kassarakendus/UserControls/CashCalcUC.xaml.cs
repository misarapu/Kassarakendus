using CashRegister.Services;
using Kassarakendus.ViewModels;
using System;
using System.Collections;
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

namespace Kassarakendus.UserControls
{
    public partial class CashCalcUC : UserControl
    {
        CalcVM _vm;

        /// <summary>
        /// UserControl konstruktor, kassa avatakse või suletakse vastavalt parameetrile.
        /// </summary>
        /// <param name="status"></param>
        public CashCalcUC(string status)
        {
            InitializeComponent();
            
            if (status == "open")
            {
                App.DayOpeningActive = true;

                tblCashCalcTitle.Text = "Ava päev";
                btnConfirm.Content = "Ava päev";
                btnConfirm.Click += btnOpenDay_Click;
                btnCancel.Click += BtnCancelOpen_Click;
            }

            if (status == "close")
            {
                spClosingReview.Visibility = Visibility.Visible;
                tblCashCalcTitle.Text = "Sulge päev";
                btnConfirm.Content = "Sulge päev";
                tblRemider.Text = String.Format("-{0}", tblTotalCash.Text);
                btnConfirm.Click += btnClose_Click;
                btnCancel.Click += btnCancelClose_Click;
                tbTotalCounted.TextChanged += tbTotalCounted_TextChanged;
            }

            _vm = new CalcVM(LoginService.LastLogOut(), DateTime.Now);
            this.DataContext = _vm;
        }

        /// <summary>
        /// Tühistab kassa avamise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelOpen_Click(object sender, RoutedEventArgs e)
        {
            LoginVM.LogOutUser();
            LoginVM.CancelOpen();
        }

        /// <summary>
        /// Loetud sularaha sisendi muutusele muutuvad ka teiste
        /// elementide väärtused.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTotalCounted_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbTotalCounted.Text == "")
            {
                tblCounted.Text = "0.00";
                tblRemider.Text = String.Format("-{0}", tblTotalCash.Text);
            }
            else
            {
                tblCounted.Text = tbTotalCounted.Text;
                tblRemider.Text = (Decimal.Parse(tblCounted.Text)
                    - Decimal.Parse(tblTotalCash.Text)).ToString("F");
            }
        }

        /// <summary>
        /// Avab päeva.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenDay_Click(object sender, RoutedEventArgs e)
        {
            if (tbTotalCounted.Text != "")
            {
                App.LoginCash = Decimal.Parse(tbTotalCounted.Text);
            }
            else
            {
                App.LoginCash = 0;
            }

            App.DayOpeningActive = false;
            _vm.UserOpensDay();
            App.EnableMainView();
        }

        /// <summary>
        /// Sulgeb päeva.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            _vm.UserClosesDay();
        }

        /// <summary>
        /// Arvutatakse kassas olev sularaha summa vastavalt
        /// rahaühikute koguse muutusele.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spNumbers_KeyUp(object sender, KeyEventArgs e)
        {
            Hashtable table = new Hashtable();
            table.Add(0.01, tbOneCent as TextBox);
            table.Add(0.02, tbTwoCent as TextBox);
            table.Add(0.05, tbFiveCent as TextBox);
            table.Add(0.1, tbTenCent as TextBox);
            table.Add(0.2, tbTwentyCent as TextBox);
            table.Add(0.5, tbFiftyCent as TextBox);
            table.Add(1.0, tbOne as TextBox);
            table.Add(2.0, tbTwo as TextBox);
            table.Add(5.0, tbFive as TextBox);
            table.Add(10.0, tbTen as TextBox);
            table.Add(20.0, tbTwenty as TextBox);
            table.Add(50.0, tbFifty as TextBox);

            double sum = 0;
            int unit;
            foreach (double key in table.Keys)
            {
                if (int.TryParse((table[key] as TextBox).Text, out unit))
                {
                    sum += (key * unit);
                }
                else
                {
                    (table[key] as TextBox).Text = "";
                }
            }
            tbTotalCounted.Text = sum.ToString("F");

        }

        /// <summary>
        /// Tühistab päeva sulgemise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelClose_Click(object sender, RoutedEventArgs e)
        {
            App.EnableMainView();
        }
    }
}
