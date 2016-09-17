using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinhCoffee.Models
{
    public class ViewBillingModel
    {
        // Buyer's models
        public string buyerName { get; set; }
        public double buyerPhone { get; set; }
        public double buyerMobile { get; set; }
        public string buyerStreet { get; set; }
        public string buyerCity { get; set; }
        public IEnumerable<country> buyerCountry { get; set; }

        // Receiver's models
        public string receiverName { get; set; }
        public double receiverPhone { get; set; }
        public double receiverMobile { get; set; }
        public string receiverStreet { get; set; }
        public string receiverCity { get; set; }
        public IEnumerable<country> receiverCountry { get; set; }

        public bool isSame { get; set; }

        public ViewItemsModel item { get; set; }

        public ViewBillingModel() {
            this.buyerName = buyerName;
            this.buyerPhone = buyerPhone;
            this.buyerMobile = buyerMobile;
            this.buyerStreet = buyerStreet;
            this.buyerCity = buyerCity;
            this.buyerCountry = buyerCountry;

            this.receiverName = receiverName;
            this.receiverPhone = receiverPhone;
            this.receiverMobile = receiverMobile;
            this.receiverStreet = receiverStreet;
            this.receiverCity = receiverCity;
            this.receiverCountry = receiverCountry;

            this.isSame = isSame;
            this.item = item;
        }
    }

    public enum country
    {
        canada = 0,
        usa = 1, 
        other = 2
    }
}