﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.IO;
using MinhCoffee.Models;
using MinhCoffee.App_Start;
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
                        Id = Int32.Parse(d.Element("id").Value),
                        name = d.Element("name").Value,
                        price = double.Parse(d.Element("price").Value),
                        priceWithCurrency = d.Element("price").Value + ViewBaseModelPrice.US,
                        origin = d.Element("origin").Value,
                        stock = (ViewItemsModel.IsAvailable)Enum.Parse(typeof(ViewItemsModel.IsAvailable), d.Element("stock").Value.ToLower()),
                        description = d.Element("description").Value,
                        code = d.Element("code").Value,
                        anchor = d.Element("anchor").Value
                    }).ToList();
                if (products != null)
                    lst = products;
            }
            return lst;
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
    }
}