using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class Model
    {
        // Primary key
        public int ModelId { get; set; }

        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string HairColor { get; set; }
        public string Comments { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

    }

    public class Models : ObservableCollection<Model>
    {
        DataAccessLayer DAL = new DataAccessLayer();


        private Model _currentModel = new Model();

        

        public Model CurrentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
               
            }
        }


        ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand<object>(addModel)); }
        }

        public void addModel(object parameter)
        {
            object[] array = (object[])parameter;   
            var name = array[0].ToString();
            var telephonenumber = array[1].ToString();
            var address = array[2].ToString();
            var height = array[3].ToString();
            var weight = array[4].ToString();
            var haircolor = array[5].ToString();
            var comments = array[6].ToString();
           
            

            Model newModel = new Model();
            newModel.Name = name;
            newModel.TelephoneNumber = telephonenumber;
            newModel.Address = address;
            newModel.Height = Int32.Parse(height);
            newModel.Weight = Int32.Parse(weight);
            newModel.HairColor = haircolor;
            newModel.Comments = comments;

            

            var respons = DAL.POSTAddNewModel(newModel);

            if (respons.Result.StatusCode == HttpStatusCode.Created)
            {
                MessageBox.Show("Item added successfully, with statuscode: " + respons.Result.StatusCode);

                var holder = respons.Result.Content.ReadAsStringAsync();
                var DeserialisedHolder = JsonConvert.DeserializeObject<Model>(holder.Result);

               newModel.ModelId = DeserialisedHolder.ModelId;
                Add(newModel);
            }
            else
            {
                MessageBox.Show("An error occurred, with statuscode: " + respons.Result.StatusCode);
            }

        }


        ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(deleteModel)); }
        }

        public void deleteModel(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("By doing this, the model will be permantly deleted", "Delete model", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
           
            switch (result)
            {
                case MessageBoxResult.Yes:

                    int id = CurrentModel.ModelId;

                    Model newModel = new Model();
                    newModel.ModelId = id;

                    var respons = DAL.DELETESpecifikModel(newModel);

                    if (respons.Result.StatusCode == HttpStatusCode.OK)
                    {
                        MessageBox.Show("Item removed successfully, with statuscode: " + respons.Result.StatusCode);
                        
                        Remove(CurrentModel);
                    }
                    else
                    {
                        MessageBox.Show("An error occurred, with statuscode: " + respons.Result.StatusCode);
                    }

                    break;
                case MessageBoxResult.No:
                    // User pressed No button
                    // ...
                    break;
                case MessageBoxResult.Cancel:
                    // User pressed Cancel button
                    // ...
                    break;
            }
        }
    }
}
