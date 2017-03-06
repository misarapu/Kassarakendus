﻿using Kassarakendus.ViewModels;
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
    /// Interaction logic for AskUC.xaml
    /// </summary>
    public partial class AskMessageUC : UserControl
    {
        public AskMessageUC(string message)
        {
            InitializeComponent();
            tbAskText.Text = message;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            App.EnableMainView();
        }
    }
}
