using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWork.Models;
namespace TestWork.Controllers
{
    public class MainController:Controller
    {
         public IActionResult Main()
        {
            return View();
        } 
    }
}