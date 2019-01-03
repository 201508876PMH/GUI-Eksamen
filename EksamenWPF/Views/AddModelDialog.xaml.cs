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
using System.Windows.Shapes;

namespace EksamenWPF.Views
{
    /// <summary>
    /// Interaction logic for AddModelDialog.xaml
    /// </summary>
    public partial class AddModelDialog : Window
    {
        public AddModelDialog()
        {
            InitializeComponent();
        }

        private void NameTxtBttn_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTxtBttn.Text == "" ||
                TeleTxtBttn.Text == "" ||
                AddressTxtBttn.Text == "" ||
                HeightTxtBttn.Text == "" ||
                WeightTxtBttn.Text == "" ||
                HairTxtbttn.Text == "" ||
                CommentsTxtBttn.Text == "" )
            {
                AddBttn.IsEnabled = false;
            }
            else
            {
                AddBttn.IsEnabled = true;
            }
        }

        private void TeleTxtBttn_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int parsedValue;
            if (NameTxtBttn.Text == "" ||
                TeleTxtBttn.Text == "" ||
                AddressTxtBttn.Text == "" ||
                HeightTxtBttn.Text == "" ||
                WeightTxtBttn.Text == "" ||
                HairTxtbttn.Text == "" ||
                CommentsTxtBttn.Text == "")
            {
                AddBttn.IsEnabled = false;
            }
            
            else if (!int.TryParse(TeleTxtBttn.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }

            else
            {
                AddBttn.IsEnabled = true;
            }
        }

        private void AddressTxtBttn_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTxtBttn.Text == "" ||
                TeleTxtBttn.Text == "" ||
                AddressTxtBttn.Text == "" ||
                HeightTxtBttn.Text == "" ||
                WeightTxtBttn.Text == "" ||
                HairTxtbttn.Text == "" ||
                CommentsTxtBttn.Text == "")
            {
                AddBttn.IsEnabled = false;
            }
            else
            {
                AddBttn.IsEnabled = true;
            }
        }

        private void HeightTxtBttn_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int parsedValue;
            if (NameTxtBttn.Text == "" ||
                TeleTxtBttn.Text == "" ||
                AddressTxtBttn.Text == "" ||
                HeightTxtBttn.Text == "" ||
                WeightTxtBttn.Text == "" ||
                HairTxtbttn.Text == "" ||
                CommentsTxtBttn.Text == "")
            {
                AddBttn.IsEnabled = false;
            }
            
            else if (!int.TryParse(HeightTxtBttn.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
            else
            {
                AddBttn.IsEnabled = true;
            }
        }

        private void WeightTxtBttn_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int parsedValue;
            if (NameTxtBttn.Text == "" ||
                TeleTxtBttn.Text == "" ||
                AddressTxtBttn.Text == "" ||
                HeightTxtBttn.Text == "" ||
                WeightTxtBttn.Text == "" ||
                HairTxtbttn.Text == "" ||
                CommentsTxtBttn.Text == "")
            {
                AddBttn.IsEnabled = false;
            }
            else if (!int.TryParse(WeightTxtBttn.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
            else
            {
                AddBttn.IsEnabled = true;
            }
        }

        private void HairTxtbttn_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTxtBttn.Text == "" ||
                TeleTxtBttn.Text == "" ||
                AddressTxtBttn.Text == "" ||
                HeightTxtBttn.Text == "" ||
                WeightTxtBttn.Text == "" ||
                HairTxtbttn.Text == "" ||
                CommentsTxtBttn.Text == "")
            {
                AddBttn.IsEnabled = false;
            }
            else
            {
                AddBttn.IsEnabled = true;
            }
        }

        private void CommentsTxtBttn_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTxtBttn.Text == "" ||
                TeleTxtBttn.Text == "" ||
                AddressTxtBttn.Text == "" ||
                HeightTxtBttn.Text == "" ||
                WeightTxtBttn.Text == "" ||
                HairTxtbttn.Text == "" ||
                CommentsTxtBttn.Text == "")
            {
                AddBttn.IsEnabled = false;
            }
            else
            {
                AddBttn.IsEnabled = true;
            }
        }

        private void AddBttn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
