using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.AvaiableServiceDirectory
{
    public class ItemServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
