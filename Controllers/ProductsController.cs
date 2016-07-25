using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinhCoffee.Models;
using MinhCoffee.Handler;
using MinhCoffee.App_Start;

namespace MinhCoffee.Controllers
{
    public class ProductsController : MinhBaseController
    {
        // GET: Products
        public ActionResult Index()
        {
            List<ViewItemsModel> viewModel = new List<ViewItemsModel>();
            var file = Server.MapPath("/App_Data/Products_GreenBeans.xml");
            var products = getCommandHandler().GetProductsFromXMLFile(file);
            string basePath = "/Assets/Images/Slides/";
            string pathHrefs = System.Web.HttpContext.Current.Server.MapPath(basePath + "slidehrefs.json");
            string pathSettings = System.Web.HttpContext.Current.Server.MapPath(basePath + "config.json");

            var imgs = getCommandHandler().GetProductImagesFromThumbs(basePath, pathHrefs, pathSettings);
            if (products.Any() && imgs.Any())
            {
                foreach(var product in products)
                {
                 foreach(var img in imgs)
                    {
                        if(product.code == img.code)
                        {
                            product.image = img;
                        }
                    }
                    viewModel.Add(product);
                }
            }

            return View(viewModel);
        }
    }
}