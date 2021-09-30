using System.Collections.Generic;
using ModernUIApp.Models;

namespace ModernUIApp.Services {
    public interface ICustomerDataService {
        IEnumerable<Customer> GetAll ();
    }
}