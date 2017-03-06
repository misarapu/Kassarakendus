using CashRegister.BusinesObjects;
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
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : Page
    {
        UserVM _uvm;
        ReportVM _vm;

        UserBO _user;
        DateTime _since;
        DateTime _to;

        public ReportView()
        {
            InitializeComponent();
            _uvm = new UserVM();
            _vm = new ReportVM();
            _uvm.LoadUsers();
            cbClerk.DataContext = _uvm;
            this.DataContext = _vm;

            dPickSince.SelectedDate = DateTime.Today;
            dPickTo.SelectedDate = DateTime.Today;
        }

        /// <summary>
        /// Näidatakse kasutajaspetsiifilist raportit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResultsUser_Click(object sender, RoutedEventArgs e)
        {
            _user = cbClerk.SelectedItem as UserBO;
            SetPeriod();
            List<TransactionBO> trans = _vm.GetUserTrans(_since, _to, _user);
            FillFields(trans);
        }

        /// <summary>
        /// Näidatakse üldist raportit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResults_Click(object sender, RoutedEventArgs e)
        {
            SetPeriod();
            List<TransactionBO> trans = _vm.GetAllTrans(_since, _to);
            FillFields(trans);
            tblClerk.Text = "Pole valitud.";
        }

        /// <summary>
        /// Väärtustatakse perioodi algus- ja lõppaeg.
        /// </summary>
        private void SetPeriod()
        {
            _since = dPickSince.SelectedDate.Value.Date;
            _to = dPickTo.SelectedDate.Value.Date.AddDays(1);
        }

        /// <summary>
        /// Täidetakse TextBlockid.
        /// </summary>
        /// <param name="trans"></param>
        private void FillFields(List<TransactionBO> trans)
        {
            tblClerk.Text = ((UserBO)cbClerk.SelectedItem).FullName;
            tblSince.Text = dPickSince.SelectedDate.Value.Date.ToString("MMMM dd, yyyy");
            tblTo.Text = dPickTo.SelectedDate.Value.Date.ToString("MMMM dd, yyyy");
            tblSales.Text = trans.Sum(x => x.TotalCost).ToString();
            tblTotal.Text = trans.Count.ToString();
        }
    }
}
