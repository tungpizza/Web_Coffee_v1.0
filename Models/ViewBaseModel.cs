using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinhCoffee.Models
{
    public class ViewBaseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public double Id { get; set; }
    }

    public class ViewBaseModelPrice
    {
        public static string US = "$";
    }
}