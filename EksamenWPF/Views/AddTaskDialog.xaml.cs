﻿using System;
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
using System.Windows.Shapes;

namespace EksamenWPF.Views
{
    /// <summary>
    /// Interaction logic for AddTaskDialog.xaml
    /// </summary>
    public partial class AddTaskDialog : Window
    {
        public AddTaskDialog()
        {
            InitializeComponent();
            StarDateTxtBttn.Text = DateTime.Today.ToShortDateString();
        }

        private void AddBttn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
