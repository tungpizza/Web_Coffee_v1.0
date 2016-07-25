using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinhCoffee.App_Start;
using MinhCoffee.Models;

namespace MinhCoffee.Controllers
{
    public class CoffeeBeansController : MinhBaseController
    {
        // GET: CoffeeBeans
        public ActionResult GreenBeans()
        {
            return View();
        }
    }
}
