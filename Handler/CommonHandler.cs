using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.IO;
using System.Threading.Tasks;
using MinhCoffee.Handler;
using MinhCoffee.App_Start;
using MinhCoffee.Models;
using MinhCoffee.Controllers;

namespace MinhCoffee.Handler
{
    public class CommonHandler: MinhBaseController 
    {
        /// <summary>
        /// ReOrderImageInList
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public List<Image> ReOrderImageInList(List<Image> images)
        {
            var lst = new List<Image>();
            Image[] arr = new Image[images.Count];
            foreach(var img in images)
            {
                var imgName = img.name;
                string[] separators = { "_n", "" };
                string[] spl = imgName.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
                arr[Int32.Parse(spl[1])] = img;
            }
            
            // Add re-ordered img into List<Image>
            foreach(var a in arr)
            {
                if(arr != null)
                {
                    lst.Add(a);
                }
            }

            return lst;
        }

        /// <summary>
        /// Get products from xml file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<ViewItemsModel> GetProductsFromXMLFile(string filePath)
        {
            List<ViewItemsModel> lst = new List<ViewItemsModel>();
            XDocument doc = XDocument.Load(filePath);
            if(doc != null)
            {
                List<ViewItemsModel> products = doc.Descendants("Product")
                    .Select(d => new ViewItemsModel {
                        Id = double.Parse(d.Element("id").Value),
                        name = d.Element("name").Value,
                        price = double.Parse(d.Element("price").Value),
                        priceWithCurrency = d.Element("price").Value + ViewBaseModelPrice.US,
                        origin = d.Element("origin").Value,
                        stock = (ViewItemsModel.IsAvailable)Enum.Parse(typeof(ViewItemsModel.IsAvailable), d.Element("stock").Value.ToLower()),
                        description = d.Element("description").Value,
                        code = d.Element("code").Value,
                        anchor = d.Element("anchor").Value,
                        quantityWithPrices = FilterPriceWithQuantityFromXMLDocument(doc),
                        tax = double.Parse(d.Element("tax").Value),
                        shipping = double.Parse(d.Element("shipping").Value)
                    }).ToList();

                // Add quantity units to products
               
                if (products != null)
                    lst = products;
            }
            return lst;
        }

        public IEnumerable<ViewPriceWithQuantityModel> FilterPriceWithQuantityFromXMLDocument(XDocument product)
        {
            try
            {
                IEnumerable<ViewPriceWithQuantityModel> prices = new List<ViewPriceWithQuantityModel>();
                var parent = product.Descendants("Product");
                foreach (var ele in parent)
                {
                    XElement package = ele.Element("packages");
                    prices = package.Descendants("package")
                        .Select(h => new ViewPriceWithQuantityModel
                        {
                            price = double.Parse(h.Element("int").Value),
                            unit = double.Parse(h.Element("unit").Value),
                            suffix = h.Element("suffix").Value.ToString()
                        }).ToList();
                }

                return prices;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        /// <summary>
        /// Get product images from thumbs folder
        /// </summary>
        /// <returns></returns>
        public List<Image> GetProductImagesFromThumbs(string basePath, string pathHrefs, string pathSettings)
        {
            List<Image> imgs = new List<Image>();
            List<Image> lstImg = new List<Image>();
            List<Href> hrefs = new List<Href>();
            var lstHrefs = getConvertHandler().ConvertJsonFileOfHref(pathHrefs);
            var lstSettings = getConvertHandler().ConvertJsonFileOfConfigs(pathSettings);

            foreach(var href in lstHrefs)
            {
                if(href.type == "thumb")
                {
                    hrefs.Add(href);
                }
            }

            // Handler images
            foreach (var setting in lstSettings)
            {
                if(setting.Id == 2 && hrefs.Any()) { 
                    string folder = System.Web.HttpContext.Current.Server.MapPath(basePath + setting.folder);
                    String[] files = Directory.GetFiles(folder);

                    for (var i = 0; i < files.Length; i++)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(files[i]);
                        string extension = Path.GetExtension(files[i]);
                        Image img = new Image();
                        img.name = fileName;
                        img.alt = fileName;
                        img.src = basePath + setting.folder + "/" + Path.GetFileName(files[i]);
                        imgs.Add(img);
                    }
                }
            }

            for (var m = 0; m < imgs.Count; m++)
            {
                if (imgs.Count == hrefs.Count)
                {
                    imgs[m].code = hrefs[m].code;
                }
            }

            if (imgs.Any())
            // Set lstImg to value of imgs if imgs is NOT null
            // otherwise set imgs to null and lstImg to lstImg
                lstImg = imgs ?? lstImg;

            return lstImg;
        }

        /// <summary>
        /// GetItemByCode in list of viewItemsModel
        /// </summary>
        /// <param name="code"></param>
        /// <param name="lst"></param>
        /// <returns></returns>
        public ViewItemsModel GetItemByCode(string code, List<ViewItemsModel> lst)
        {
            ViewItemsModel item = new ViewItemsModel();
            try
            {
                if (lst.Any())
                {
                    foreach(var node in lst)
                    {
                        if(node.code == code)
                        {
                            item = node;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return item;
        }

        /// <summary>
        /// Load all products defined in Products_GreenBeans.xml file
        /// </summary>
        /// <returns></returns>
        public List<ViewItemsModel> LoadAllProducts(string file)
        {
            try { 
                List<ViewItemsModel> viewModel = new List<ViewItemsModel>();
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
                return viewModel;
            } catch (Exception e)
            {

            }
            return null;
        }
    }
}