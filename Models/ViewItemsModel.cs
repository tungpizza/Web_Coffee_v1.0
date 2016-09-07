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
        public IEnumerable<ViewPriceWithQuantityModel> quantityWithPrices { get; set; }
        public double quantity { get; set; }
        public double total { get; set; }
        public string totalWithCurrency { get; set; }


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
            this.quantityWithPrices = quantityWithPrices;
            this.code = code;
            this.quantity = quantity;
            this.total = total;
            this.totalWithCurrency = totalWithCurrency;
        }

        public enum IsAvailable
        {
            available = 1,
            outOfstock = 0
        }
    }

    public class ViewPriceWithQuantityModel: ViewBaseModel
    {
        public int price { get; set; }
        public int unit { get; set; }
        public string suffix { get; set; }
        public List<object> mix
        {
            get
            {
                List<object> obj = new List<object>();
                obj.Add(price);
                obj.Add(unit);
                return obj;
            }
        }
    }
}