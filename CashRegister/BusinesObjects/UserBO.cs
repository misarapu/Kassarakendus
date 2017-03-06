using CashRegister.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BusinesObjects
{
    public class UserBO
    {
        private int _userId;
        private string _userName;
        private string _password;
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;
        private string _phone;
        private string _email;
        private DateTime _since;
        private string _role;

        public UserBO(Clerk clerk)
        {
            _userId = clerk.ClerkId;
            _userName = clerk.Username;
            _password = clerk.Password;
            _firstName = clerk.FirstName;
            _lastName = clerk.LastName;
            _birthDate = clerk.BirthDate;
            _email = clerk.Email;
            _phone = clerk.Phone;
            _role = clerk.Role;
            _since = clerk.Since;
        }

        public UserBO()
        {

        }

        public int UserId
        {
            get { return _userId; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string BirthDateStr
        {
            get
            {
                return _birthDate.ToString("d");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime Since
        {
            get { return _since; }
            set { _since = DateTime.Now; }
        }

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public string FullName
        {
            get { return String.Format("{0} {1}", _firstName, _lastName); }
        }

        public Clerk ParseDomain()
        {

            return new Clerk
            {
                FirstName = _firstName,
                LastName = _lastName,
                Username = _userName,
                Password = _password,
                BirthDate = _birthDate,
                Phone = _phone,
                Email = _email,
                Since = DateTime.Now,
                Role = _role
            };
        }
    }
}
