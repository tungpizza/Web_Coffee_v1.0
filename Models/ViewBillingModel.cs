using MinhCoffee.Converters;
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
        public string buyerAddressLine1 { get; set; }
        public string buyerAddressLine2 { get; set; }
        public string buyerAddress { get { return buyerAddressLine1 + buyerAddressLine2; } }
        public string buyerCity { get; set; }
        public IEnumerable<country> buyerCountry { get; set; }

        // Receiver's models
        public string receiverName { get; set; }
        public double receiverPhone { get; set; }
        public double receiverMobile { get; set; }
        public string receiverAddressLine1 { get; set; }
        public string receiverAdressLine2 { get; set; }
        public string receiverAddress { get { return receiverAddressLine1 + receiverAdressLine2; } }
        public string receiverCity { get; set; }
        public IEnumerable<country> receiverCountry { get; set; }

        public bool isSame { get; set; }

        public ViewItemsModel item { get; set; }

        public ViewBillingModel() {
            List<country> countries = new List<country>();
            countries.Add(country.canada);
            countries.Add(country.usa);
            countries.Add(country.other);

            this.buyerName = buyerName;
            this.buyerPhone = buyerPhone;
            this.buyerMobile = buyerMobile;
            this.buyerAddressLine1 = buyerAddressLine1;
            this.buyerAddressLine2 = buyerAddressLine2;
            this.buyerCity = buyerCity;
            this.buyerCountry = countries;

            this.receiverName = receiverName;
            this.receiverPhone = receiverPhone;
            this.receiverMobile = receiverMobile;
            this.receiverAddressLine1 = receiverAddressLine1;
            this.receiverAdressLine2 = receiverAdressLine2;
            this.receiverCity = receiverCity;
            this.receiverCountry = countries;

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