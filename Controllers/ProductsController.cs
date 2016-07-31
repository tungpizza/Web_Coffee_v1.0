using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinhCoffee.Models;
using MinhCoffee.Handler;
using MinhCoffee.App_Start;
using PagedList;
using PagedList.Mvc;

namespace MinhCoffee.Controllers
{
    public class ProductsController : MinhBaseController
    {

        private List<ViewItemsModel> temps;

        // GET: Products
        public ActionResult Index(int? page)
        {
            IPagedList<ViewItemsModel> temp = null;
            List<ViewItemsModel> viewModel = new List<ViewItemsModel>();
            var file = Server.MapPath("/App_Data/Products_GreenBeans.xml");
            var products = getCommandHandler().GetProductsFromXMLFile(file);
            string basePath = "/Assets/Images/Slides/";
            string pathHrefs = System.Web.HttpContext.Current.Server.MapPath(basePath + "slidehrefs.json");
            string pathSettings = System.Web.HttpContext.Current.Server.MapPath(basePath + "config.json");

            var imgs = getCommandHandler().GetProductImagesFromThumbs(basePath, pathHrefs, pathSettings);
            if (products.Any() && imgs.Any())
            {
                foreach (var product in products)
                {
                    foreach (var img in imgs)
                    {
                        if (product.code == img.code)
                        {
                            product.image = img;
                        }
                    }
                    viewModel.Add(product);
                }
            }

            // store temp viewModel
            if (viewModel.Any())
            {
                temps = viewModel;
            }

            // define page numbers
            int pageSize = 4;
            int pageNumber = page ?? 1;
            temp = viewModel.OrderByDescending(m => m.Id).ToPagedList(pageNumber, pageSize);
            return View(temp);
        }

        /// <summary>
        /// Product detail page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult Item(string code)
        {
            ViewItemsModel view = new ViewItemsModel();
            var item = getCommandHandler().GetItemByCode(code, temps);
            if(item != null)
            {
                view = item;
            }
            return View(view);
        }
    }
}