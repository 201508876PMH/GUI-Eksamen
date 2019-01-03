using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EksamenWPF.DAL;
using Newtonsoft.Json;

namespace EksamenWPF.Models
{
    public class Opgave
    {
        // Primary key from db
        public int OpgaveId { get; set; }

        public string Customer { get; set; }
        public string StartDate { get; set; }
        public int NumberOfDays { get; set; }
        public string Location { get; set; }
        public int NumberOfModels { get; set; }
        public string Comments { get; set; }
    }


    public class Opgaver : ObservableCollection<Opgave>
    {
        DataAccessLayer DAL = new DataAccessLayer();


        ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand<object>(addOpgave)); }
        }

        public void addOpgave(object parameter)
        {
            object[] array = (object[])parameter;

            var customer = array[0].ToString();
            var startDate = array[1].ToString();
            var numberOfDays = array[2].ToString();
            var location = array[3].ToString();
            var numberOfModels = array[4].ToString();
            var comments = array[5].ToString();
           


            Opgave newOpgave = new Opgave();
            newOpgave.Customer = customer;
            newOpgave.StartDate = startDate;
            newOpgave.NumberOfDays = Int32.Parse(numberOfDays);
            newOpgave.Location = location;
            newOpgave.NumberOfModels = Int32.Parse(numberOfModels);
            newOpgave.Comments = comments;
      

           


            var respons = DAL.POSTAddNewOpgave(newOpgave);

            if (respons.Result.StatusCode == HttpStatusCode.Created)
            {
                MessageBox.Show("Item added successfully, with statuscode: " + respons.Result.StatusCode);

                var holder = respons.Result.Content.ReadAsStringAsync();
                var DeserialisedHolder = JsonConvert.DeserializeObject<Opgave>(holder.Result);

                newOpgave.OpgaveId = DeserialisedHolder.OpgaveId;
                Add(newOpgave);
            }
            else
            {
                MessageBox.Show("An error occurred, with statuscode: " + respons.Result.StatusCode);
            }

        }
    }
}
