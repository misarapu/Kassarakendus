using CashRegister.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BusinesObjects
{
    public class LoginLogBO
    {
        private int _loginId;
        private int _clerkId;
        private string _loginTime;
        private string _logoutTime;

        public LoginLogBO()
        {

        }

        public int LoginId {
            get
            {
                return _loginId;
            }
        }
        public int ClerkId
        {
            get
            {
                return _clerkId;
            }

            set
            {
                _clerkId = value;
            }
        }
        public string LoginTime
        {
            get
            {
                return _loginTime;
            }

            set
            {
                _loginTime = value;
            }
        }
        public string LogoutTime
        {
            get
            {
                return _logoutTime;
            }

            set
            {
                _logoutTime = value;
            }
        }

        public LoginLog ParseDomain()
        {
            return new LoginLog
            {
                ClerkId = _clerkId,
                LoginTime = DateTime.Now
            };
        }
    }
}
