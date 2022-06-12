using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homecoming.webapp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult ViewBooking()
        {
            return View();
        }
    }
}
