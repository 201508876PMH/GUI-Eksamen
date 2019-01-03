using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EksamenWPF.Models;

namespace EksamenWPF.DAL
{
    public class DataAccessLayer
    {
        private HttpClient _HttpClient = new HttpClient();
        private Uri _localUri = new Uri("http://localhost:57346");

        public DataAccessLayer()
        {
            _HttpClient.BaseAddress = _localUri;
        }

        public Task<HttpResponseMessage> POSTAddNewModel(Model model)
        {
            return _HttpClient.PostAsJsonAsync("api/Models", model);
        }

        public Task<string> GETList()
        {
            return _HttpClient.GetStringAsync("api/Models");
        }

        public Task<HttpResponseMessage> DELETESpecifikModel(Model model)
        {
            var result =_HttpClient.DeleteAsync($"api/Models/{model.ModelId}");
            return result;
        }

        /*********************************************/

        public Task<HttpResponseMessage> POSTAddNewOpgave(Opgave opgave)
        {
            return _HttpClient.PostAsJsonAsync("api/Opgaves", opgave);
        }
        public Task<string> GETListOpgaver()
        {
            return _HttpClient.GetStringAsync("api/Opgaves");
        }

        /*********************************************/
        public Task<HttpResponseMessage> POSTAddNewAssignment(Assignment assignment)
        {
            return _HttpClient.PostAsJsonAsync("api/Assignments", assignment);
        }
        public Task<string> GETListAssignment()
        {
            return _HttpClient.GetStringAsync("api/Assignments");
        }
    }
}
