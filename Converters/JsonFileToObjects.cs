using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using MinhCoffee.App_Start;
using MinhCoffee.Models;

namespace MinhCoffee.Handler
{
    public class ConvertJsonFileToObject : MinhBaseController
    {
        /// <summary>
        /// Convert json file of configs to list object
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Configs> ConvertJsonFileOfConfigs(string path)
        {
            var lst = new List<Configs>();
            using (StreamReader file = new StreamReader(path))
            {
                string jsonString = file.ReadToEnd();
                List<Configs> lstSettings = JsonConvert.DeserializeObject<List<Configs>>(jsonString);
                if (lstSettings != null)
                {
                    lst = lstSettings;
                }
            }
            return lst;
        }

        /// <summary>
        /// Convert json file of hrefs to list object
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Href> ConvertJsonFileOfHref(string path)
        {
            var lst = new List<Href>();
            using (StreamReader file = new StreamReader(path))
            {
                string jsonString = file.ReadToEnd();
                List<Href> lstHrefs = JsonConvert.DeserializeObject<List<Href>>(jsonString);
                if (lstHrefs != null)
                {
                    lst = lstHrefs;
                }
            }
            return lst;
        }

        /// <summary>
        /// Convert json file of captions to list object
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Captions> ConvertJsonFileOfCaptions(string path)
        {
            var lst = new List<Captions>();
            using (StreamReader file = new StreamReader(path))
            {
                string jsonString = file.ReadToEnd();
                List<Captions> lstCaptions = JsonConvert.DeserializeObject<List<Captions>>(jsonString);
                if (lstCaptions != null)
                {
                    lst = lstCaptions;
                }
            }
            return lst;
        }
    }
}