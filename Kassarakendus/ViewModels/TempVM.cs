using Kassarakendus.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.ViewModels
{
    public class TempVM
    {
        private static UsersClientsView _usersClientsView;

        public static UsersClientsView UsersClientsView
        {
            get { return _usersClientsView; }
            set { _usersClientsView = value; }
        }
    }
}
