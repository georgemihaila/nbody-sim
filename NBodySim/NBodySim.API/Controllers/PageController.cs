using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NBodySim.API.Controllers
{
    public class PageController : Controller
    {
        [Route("/simulator")]
        public IActionResult Index()
        {
            return View();
        }
    }
}