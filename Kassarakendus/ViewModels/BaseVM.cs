using Kassarakendus.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kassarakendus.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Kuulab property väärtuse muutumist.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Kontrollib vormi teksti korrektsust.
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static bool ValidStringInputs(List<string> inputs)
        {
            foreach (string str in inputs)
            {
                if (str == "")
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Kontrollib vormi täisarvude korrektsust.
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static bool ValidIntegerInputs(List<string> inputs)
        {
            int tmp;
            foreach (string str in inputs)
            {
                if (str == "" || !Int32.TryParse(str, out tmp))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Kontrollib vormi murdarvude korrektsust.
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static bool ValidDecimalInputs(List<string> inputs)
        {
            decimal tmp;
            foreach (string str in inputs)
            {
                if (str == "" || !Decimal.TryParse(str, out tmp))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Kuvatakse põhivaates errori popup.
        /// </summary>
        /// <param name="message"></param>
        public static void ErrorPopup(string message)
        {
            App.MainView.spPopup.Children.Add(new ErrorMessageUC(message));
            App.DisableMainView();
        }

        /// <summary>
        /// Kuvatakse põhivaates kinnituse popup.
        /// </summary>
        /// <param name="message"></param>
        public static void ConfirmPopup(string message)
        {
            App.MainView.spPopup.Children.Add(new ConfirmMessageUC(message));
            App.DisableMainView();
        }

        /// <summary>
        /// Kuvatakse põhivaates küsimuse popup.
        /// </summary>
        /// <param name="message"></param>
        public static void AskPopup(string message, RoutedEventHandler reh)
        {
            AskMessageUC ask = new AskMessageUC(message);
            App.MainView.spPopup.Children.Add(ask);
            App.DisableMainView();
            ask.btnConfirm.Click += reh;
        }
    }
}
