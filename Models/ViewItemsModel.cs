using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MinhCoffee.Models
{
    public class ViewItemsModel:ViewBaseModel
    {
        public string name { get; set; }
        public double price { get; set; }
        public string priceWithCurrency { get; set; }
        public string origin { get; set; }
        public string description { get; set; }
        public IsAvailable stock { get; set; }
        public Image image { get; set; }
        public string anchor { get; set; }
        public string code { get; set; }


        public ViewItemsModel()
        {
            this.name = name;
            this.price = price;
            this.priceWithCurrency = priceWithCurrency;
            this.origin = origin;
            this.description = description;
            this.stock = stock;
            this.image = image;
            this.anchor = anchor;
            this.code = code;
        }

        public enum IsAvailable
        {
            available = 1,
            outOfstock = 0
        }
    }
}