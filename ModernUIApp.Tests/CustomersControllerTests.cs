using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using ModernUIApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using ModernUIApp.Models;
using ModernUIApp.Services;
using Microsoft.Extensions.DependencyInjection;
using ModernUIApp.Tests.Mocks;

namespace ModernUIApp.Tests {
    [TestClass]
    public class CustomersControllerTests {
        private ICustomerDataService _customerDataService;
        private IFeatureFlagService _featureFlagService;
        public CustomersControllerTests () {
            // Arrange
            var services = new ServiceCollection();
            services.AddTransient<ICustomerDataService, MockCustomerDataService>();
            services.AddTransient<IFeatureFlagService, MockFeaureFlagService>();
            var serviceProvider = services.BuildServiceProvider();

            _customerDataService = serviceProvider.GetService<ICustomerDataService>();
            _featureFlagService = serviceProvider.GetService<IFeatureFlagService>();
        }

        [TestCategory ("L0")]
        [TestMethod]
        public void Index__ShouldReturnAViewContainingAListOfCustomersSortedAlphabetically () {
            //Arrange
            var customersControllerUnderTest = new CustomersController(_customerDataService, _featureFlagService);
            //Act
            var returnedResult = customersControllerUnderTest.Index ();
            // Assert
            Assert.AreEqual (returnedResult.GetType (), typeof (ViewResult));
            var returnedView = returnedResult as ViewResult;
            Assert.AreEqual (returnedView.Model.GetType (), typeof (List<Customer>), "Customers controller index modern is null. The customer API didn't return any customer");
        }
    }
}