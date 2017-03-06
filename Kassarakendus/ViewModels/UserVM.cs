using CashRegister.BusinesObjects;
using CashRegister.Domain;
using CashRegister.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.ViewModels
{
    public class UserVM : BaseVM
    {
        private int _userId;
        private UserBO _user;
        private List<UserBO> _users;

        /// <summary>
        /// ViewModel konstruktor.
        /// </summary>
        public UserVM()
        {
            _users = new List<UserBO>();        
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab kõikide kasutajate loendi.
        /// </summary>
        public List<UserBO> AllUsers
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                base.NotifyPropertyChanged("AllUsers");
            }
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab kasutaja objekti.
        /// </summary>
        public UserBO User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                base.NotifyPropertyChanged("User");
            }
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab kasutaja ID.
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// Laeb kasutajate loendi.
        /// </summary>
        public void LoadUsers()
        {
            AllUsers = UserService.AllClerks();
        }

        /// <summary>
        /// Lisab uue kasutaja.
        /// </summary>
        /// <param name="newUser"></param>
        public void AddNewUser(UserBO newUser)
        {
            UserService.AddNewClerk(newUser);
            LoadUsers();
        }

        /// <summary>
        /// Kontrollib, kas kasutajanimi on juba andmebaasis olemas.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ValidUserName(string userName)
        {
            return UserService.AllClerks()
                .Where(x => x.UserName == userName).ToList().Count == 0;
        }

        /// <summary>
        /// Kustutab kasutaja.
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(UserBO user)
        {
            UserService.RemoveUser(user);
            LoadUsers();
        }

        /// <summary>
        /// Kasutaja otsimine loendist.
        /// </summary>
        /// <param name="text"></param>
        public void SearchUser(string text)
        {
            AllUsers = UserService.SearchUser(text);
        }

        /// <summary>
        /// Kasutaja rolli määramine.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal string RoleMatcher(string input)
        {
            string role = "admin";
            if (input == "Müüja")
            {
                role = "clerk";
            }
            return role;
        }
    }
}
