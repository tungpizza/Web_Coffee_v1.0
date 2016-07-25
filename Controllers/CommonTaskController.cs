using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinhCoffee.Controllers
{
    public class CommonTaskController: Controller
    {
        [HttpPost]
        public ContentResult LanguageHandler(string url, string keyName, string keyValue)
        {
            try
            {
                if(url != null && keyValue != null)
                {
                    HttpCookie cookie = new HttpCookie("CoffeeLanguage");
                    cookie.Value = keyValue;
                    cookie.Expires = DateTime.Now.AddDays(10d);
                    Response.Cookies.Add(cookie);
                   return Content("OK");
                }
            } catch(Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
            return null;
        }
    }
}