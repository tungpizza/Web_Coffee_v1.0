using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.IO;
using MinhCoffee.App_Start;
using MinhCoffee.Models;
using MinhCoffee.Handler;

namespace MinhCoffee.Controllers
{
    public class HomePageController : MinhBaseController
    {
        // GET: HomePage
        public ActionResult Index()
        {
            // Read settings
            var jsonSettings = new List<object>();
            string basePath = "Assets/Images/Slides/";
            string pathSettings = Server.MapPath("/" + basePath + "config.json");
            string pathHrefs = Server.MapPath("/" + basePath + "slidehrefs.json");
            List<Image> main = new List<Image>();
            List<Image> thumb = new List<Image>();
            ViewSliderModel viewModel = new ViewSliderModel();
            ViewSliderModel viewModelThumb = new ViewSliderModel();
            List<ViewSliderModel> listModel = new List<ViewSliderModel>(); 

            // Get data of settings, hrefs from json files
            var lstSettings = getConvertHandler().ConvertJsonFileOfConfigs(pathSettings);
            var lstHrefs = getConvertHandler().ConvertJsonFileOfHref(pathHrefs);
            var hrefsForMain = new List<Href>();
            var hrefsForThumb = new List<Href>();

            foreach(var href in lstHrefs)
            {
                if(href.type == "main")
                {
                    hrefsForMain.Add(href);
                } else
                {
                    hrefsForThumb.Add(href);
                }
            }

            // Handler images
            foreach (var setting in lstSettings)
            {
               
                    string folder = Server.MapPath(basePath + setting.folder);
                    String[] files = Directory.GetFiles(folder);
                    for (var i = 0; i < files.Length; i++)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(files[i]);
                        string extension = Path.GetExtension(files[i]);
                        Image img = new Image();
                        img.name = fileName;
                        img.alt = fileName;
                        img.src = basePath + setting.folder + "/" + Path.GetFileName(files[i]);

                        if (files.Length == hrefsForMain.Count && setting.Id == 1)
                        {
                            img.href = hrefsForMain[i].href;
                            if(extension == setting.filetype)
                            {
                                main.Add(img);
                            }
                           
                            viewModel.speed = setting.speed;
                            viewModel.iscaption = setting.IsCaption;
                        }

                        if (files.Length == hrefsForThumb.Count && setting.Id == 2)
                        {
                            img.href = hrefsForThumb[i].href;
                            if (extension.ToLower() == setting.filetype)
                            {
                                thumb.Add(img);
                            }

                            viewModelThumb.speed = setting.speed;
                            viewModelThumb.iscaption = setting.IsCaption;
                        }
                }
            }

            viewModel.images = getCommandHandler().ReOrderImageInList(main);
            viewModelThumb.images = getCommandHandler().ReOrderImageInList(thumb);
            listModel.Add(viewModel);
            listModel.Add(viewModelThumb);

            return View(listModel);
        }
    }
}
