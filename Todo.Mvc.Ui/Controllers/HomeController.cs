using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Todo.Mvc.Ui.Models;
using ToDoItems.Interfaces;
using Todo.API.Controllers.v1;

namespace Todo.Mvc.Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _host;
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostenvironment, IHttpClientHelper httpClientHelper, IConfiguration configuration)
        {
            _logger = logger;
            _host = hostenvironment;
            _httpClientHelper = httpClientHelper;
            _configuration = configuration;
        }

        [AllowAnonymous]
        public  IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "TodoItems");
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
