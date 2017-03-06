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
    public partial class ErrorMessageUC : UserControl
    {
        /// <summary>
        /// UserControl konstruktor.
        /// </summary>
        public ErrorMessageUC(string message)
        {
            InitializeComponent();
            tbErrText.Text = message;
        }

        /// <summary>
        /// Veateate eemaldamine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelError_Click(object sender, RoutedEventArgs e)
        {
            App.EnableMainView();
        }
    }
}
