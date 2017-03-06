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

namespace Kassarakendus.UserControls
{
    public partial class UserInfoUC : UserControl
    {
        UserVM _vm;
        /// <summary>
        /// UserControl konstruktor, täidetakse vaate vastavad väljad.
        /// </summary>
        /// <param name="user"></param>
        public UserInfoUC(UserBO user)
        {
            InitializeComponent();
            _vm = new UserVM();
            this.DataContext = _vm;
            _vm.User = user;
        }
    }
}
