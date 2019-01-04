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
    public class Assignment
    {
        public int AssignmentId { get; set; }

        public string ModelName { get; set; }
        public string Customer { get; set; }
    }

    public class Assignments : ObservableCollection<Assignment>
    {
        DataAccessLayer DAL = new DataAccessLayer();


        ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand<object>(addAssignment)); }
        }

        public void addAssignment(object parameter)
        {
            object[] array = (object[])parameter;
            var customer = array[0].ToString();
            var modelName = array[1].ToString();
           
            


            Assignment newAssignment = new Assignment();
            newAssignment.Customer = customer;

            newAssignment.ModelName = modelName;
            

            var respons = DAL.POSTAddNewAssignment(newAssignment);

            if (respons.Result.StatusCode == HttpStatusCode.Created)
            {
                MessageBox.Show("Assignment added successfully, with statuscode: " + respons.Result.StatusCode);

                var holder = respons.Result.Content.ReadAsStringAsync();
                var DeserialisedHolder = JsonConvert.DeserializeObject<Assignment>(holder.Result);

                newAssignment.AssignmentId = DeserialisedHolder.AssignmentId;
                Add(newAssignment);
            }
            else
            {
                MessageBox.Show("An error occurred, with statuscode: " + respons.Result.StatusCode);
            }

        }
    }


}
