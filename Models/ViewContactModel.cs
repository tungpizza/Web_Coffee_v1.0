using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinhCoffee.Models
{
    public class ViewContactModel : ViewBaseModel
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set;}
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set;}
        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhomeNumber { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}