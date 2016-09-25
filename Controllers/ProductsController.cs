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
using System.Collections.Specialized;

namespace MinhCoffee.Controllers
{
    public class ProductsController : MinhBaseController
    {
        public string path { get; set; }
        public ProductsController()
        {
            string file = System.Web.Hosting.HostingEnvironment.MapPath("/App_Data/Products_GreenBeans.xml");
            path = file;
        }

        private List<ViewItemsModel> _temps;
        public List<ViewItemsModel> Temps
        {
            get
            {
                if (_temps == null)
                {
                    var products = getCommandHandler().LoadAllProducts(path);
                    _temps = new List<ViewItemsModel>();
                    if (products.Any())
                        _temps = products;
                }
                return _temps;
            }
        }

        // GET: Products
        public ActionResult Index(int? page)
        {
            IPagedList<ViewItemsModel> temp = null;
            var viewModel = getCommandHandler().LoadAllProducts(path);

            // store temp viewModel
            if (viewModel.Any())
            {
                _temps = viewModel;
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
            var item = getCommandHandler().GetItemByCode(code, Temps);
            if(item != null)
            {
                view = item;
            }
            return View(view);
        }

        /// <summary>
        /// Handle item order submit
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ItemProcess(ViewItemsModel item)
        {
            try
            {
                ViewBillingModel billing = new ViewBillingModel();
                if(item != null)
                {
                    billing.item = item;
                }
                return RedirectToAction("Billing", billing);
            }
            catch(Exception ex)
            {

            }

            return null;
        }

        [HttpGet]
        public ActionResult Billing(ViewItemsModel item)
        {
            return View();
        }

        /// <summary>
        /// Method to process the post data from Billing Page
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public ActionResult BillingProcess(ViewBillingModel model)
        {


            return View();
        }
    }
}