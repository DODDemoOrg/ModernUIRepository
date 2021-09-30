using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModernUIApp.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using ModernUIApp.Services;

namespace ModernUIApp.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerDataService _customerDataService;
        private IFeatureFlagService _featureFlagService;
        private string _userName = "****@****.com";
        public CustomersController(ICustomerDataService customerDataService, IFeatureFlagService featureFlagService)
        {
            _customerDataService = customerDataService;
            _featureFlagService = featureFlagService;
        }
        public IActionResult Index()
        {
            if (_featureFlagService.ViewFeature(_userName))
            {
                var customers = _customerDataService.GetAll();
                return View(customers);
            }
            else
            {
                return View("~/Views/ComingSoon/Index.cshtml");
            }
        }
    }
}