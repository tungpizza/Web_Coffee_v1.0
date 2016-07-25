using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinhCoffee.Models
{
    /// <summary>
    /// Get/Set listViewSliderModel
    /// </summary>
    public class ListViewSlideModel: ViewBaseModel
    {
        public List<ViewSliderModel> viewModel { get; set; }
    }

    /// <summary>
    /// Get/Set/ viewSliderModel
    /// </summary>
    public class ViewSliderModel: ViewBaseModel
    {
        public List<Image> images { get; set; }
        public Captions caption { get; set; }
        public bool iscaption { get; set; }
        public double speed { get; set; }
        public string folder { get; set; } 
    }

    /// <summary>
    /// Image
    /// </summary>
    public class Image : ViewBaseModel
    {
        public string name { get; set; }
        public string href { get; set; }
        public string src { get; set; }
        public string alt { get; set; }
        public string code { get; set; }
    }

    /// <summary>
    /// Captions
    /// </summary>
    public class Captions : ViewBaseModel
    {
        public string context { get; set; }
        public string position { get; set; }
    }

    /// <summary>
    /// Configs
    /// </summary>
    public class Configs:ViewBaseModel
    {
        public string type { get; set; }
        public string folder { get; set; }
        public string filetype { get; set; }
        public string transition { get; set; }
        public double speed { get; set; }
        public int max { get; set; }
        public bool IsCaption { get; set; }
    }

    /// <summary>
    /// Get/Set href of images
    /// </summary>
    public class Href: ViewBaseModel
    {
        public string type { get; set; }
        public string href { get; set; }
        public string code { get; set; }
    }
}