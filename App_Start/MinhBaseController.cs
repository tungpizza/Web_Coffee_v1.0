using System;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;
using MinhCoffee.Handler;

namespace MinhCoffee.App_Start
{
    /// <summary>
    /// Add the function of global inheritance into
    /// this base controller.
    /// </summary>
    public class MinhBaseController: Controller
    {
        protected MinhBaseController()
        {
            // Define Localizing Windows Forms
            // Source: https://msdn.microsoft.com/en-us/library/y99d1cd3(v=vs.100).aspx
            try
            {
                string defaultCulture = "en-US";
                HttpContext context = System.Web.HttpContext.Current;
                HttpCookie htp = context.Request.Cookies["CoffeeLanguage"];
                if(htp != null && htp.Value != "en-US")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(htp.Value);
                } else
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(defaultCulture);
                }
            } catch(Exception ex)
            {
                // Should be an exception handler here
                Console.WriteLine("{0} - Exception catched !", ex.Message);
            }
        }

        /// <summary>
        /// Create instance of CommonHandler
        /// </summary>
        /// <returns></returns>
        public CommonHandler getCommandHandler()
        {
            CommonHandler command = new CommonHandler();
            return command;
        }

        /// <summary>
        /// Create instance of GetConvertHandler
        /// </summary>
        /// <returns></returns>
        public ConvertJsonFileToObject getConvertHandler()
        {
            ConvertJsonFileToObject convert = new ConvertJsonFileToObject();
            return convert;
        }
    }
}