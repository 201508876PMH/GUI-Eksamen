using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using EksamenWPF.Annotations;
using EksamenWPF.DAL;
using EksamenWPF.Models;
using EksamenWPF.Views;
using Newtonsoft.Json;

namespace EksamenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     

        public class Datacontexts 
        {
            public Models.Models Models { get; set; } = new Models.Models();
            public Opgaver Opgaver { get; set; } = new Opgaver();

            public Assignments Assignments { get; set; } = new Assignments();


        }


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Datacontexts();
        }

        private void SwitchToPageTwo(object sender, RoutedEventArgs e)
        {
            DataContext = new TermsAndServices();
        }


        private void AddModelBttn_OnClick(object sender, RoutedEventArgs e)
        {
            AddModelDialog dlg = new AddModelDialog();
            dlg.Owner = this;


            dlg.DataContext =  ((Datacontexts)this.DataContext).Models;

            if (dlg.ShowDialog() == true)
            {
                
            }
        }

        private async void ItemList_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataAccessLayer DAL = new DataAccessLayer();
           
            var result = await DAL.GETList();

            Model[] array = JsonConvert.DeserializeObject<Model[]>(result);
            foreach (var item in array)
            {
               
                ((Datacontexts)DataContext).Models.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTaskDialog dlg = new AddTaskDialog();
            dlg.Owner = this;


            dlg.DataContext = ((Datacontexts)this.DataContext).Opgaver;

            if (dlg.ShowDialog() == true)
            {
                
            }

        }

        private async void ListView2_OnLoaded(object sender, RoutedEventArgs e)
        {
            //ItemList.FontSize = 14;
            DataAccessLayer DAL = new DataAccessLayer();
           
            var result = await DAL.GETListOpgaver();

            Opgave[] array = JsonConvert.DeserializeObject<Opgave[]>(result);
            foreach (var item in array)
            {
                ((Datacontexts)DataContext).Opgaver.Add(item);
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            AssignModelDialog dlg = new AssignModelDialog();
            dlg.Owner = this;
            dlg.DataContext = ((Datacontexts)this.DataContext).Assignments;


            Opgave selectedOpgave = (Opgave)ListView2.SelectedItems[0];
            dlg.ChosenCustomerTxtField.Text = selectedOpgave.Customer;

            Models.Models modelsToChooseFrom = (Models.Models) ItemList.ItemsSource;
            dlg.listOfAllModels.ItemsSource = modelsToChooseFrom.ToList();


            if (dlg.ShowDialog() == true)
            {
                
            }
        }

        private async void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataAccessLayer DAL = new DataAccessLayer();

            var result = await DAL.GETListAssignment();

            Assignment[] array = JsonConvert.DeserializeObject<Assignment[]>(result);
            foreach (var item in array)
            {
                ((Datacontexts)DataContext).Assignments.Add(item);
            }
        }
    }
}
