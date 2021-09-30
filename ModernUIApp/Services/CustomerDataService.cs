using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using ModernUIApp.Models;
using Newtonsoft.Json;

namespace ModernUIApp.Services {
    public class CustomerDataService : ICustomerDataService {
        private string _customerApiUrl;
        public CustomerDataService (IConfiguration configuration) {
            _customerApiUrl = configuration.GetValue<string> ("ApiURL");
        }
        public IEnumerable<Customer> GetAll () {
            HttpClient customersApiClient = new HttpClient ();
            HttpResponseMessage response = customersApiClient.GetAsync (_customerApiUrl).Result;
            response.EnsureSuccessStatusCode ();
            string jsonResponse = response.Content.ReadAsStringAsync ().Result;
            var customers = JsonConvert.DeserializeObject<List<Customer>> (jsonResponse);
            return customers;
        }
    }
}