using System.Collections.Generic;
using ModernUIApp.Models;
using ModernUIApp.Services;
using Moq;

namespace ModernUIApp.Tests.Mocks
{
    public class MockCustomerDataService : ICustomerDataService
    {
        private Mock<ICustomerDataService> _mock;
        public MockCustomerDataService()
        {
            _mock = new Mock<ICustomerDataService>();  
            _mock.Setup(cds => cds.GetAll()).Returns(getSampleCustomerList());  
        }
        public IEnumerable<Customer> GetAll()
        {
            return _mock.Object.GetAll();
        }
        private IList<Customer> getSampleCustomerList()
        {
            var customers = new List<Customer>();
            for (int i = 0; i < 10; i++)
            {
                var customer = new Customer(){Id = i+1, Name = $"Customer name {i+1}", Address =  $"Customer address {i+1}"};
                customers.Add(customer);
            }
            return customers;
        }
    }

}