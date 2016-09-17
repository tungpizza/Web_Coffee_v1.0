using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinhCoffee.Models;
using MinhCoffee.Resource;

namespace MinhCoffee.Converters
{
    public class EnumToString
    {
        public string CountryEnumToString(country nation)
        {
            try
            {
                string output = string.Empty;
                switch (nation)
                {
                    case country.usa:
                        output = Resource.MinhCoffee.Usa;
                        break;
                    case country.canada:
                        output = Resource.MinhCoffee.Canada;
                        break;
                    default:
                        output = Resource.MinhCoffee.Other;
                        break;
                }
                return output;
            }

            catch(Exception ex)
            {

            }
            return null;
        }
    }
}