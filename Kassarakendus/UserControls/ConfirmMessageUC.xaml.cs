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

namespace Kassarakendus.UserControls
{
    /// <summary>
    /// Interaction logic for ConfirmMessageUC.xaml
    /// </summary>
    public partial class ConfirmMessageUC : UserControl
    {
        public ConfirmMessageUC(string message)
        {
            InitializeComponent();
            tbConfirmText.Text = message;
        }

        /// <summary>
        /// Teate eemaldamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            App.EnableMainView();
        }
    }
}
