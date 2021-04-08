using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDV1.Models
{
    public class TinTuc
    {
        [Key]
        public string id { get; set; }
        public string tieude { get; set; }
        [AllowHtml]
        public string mota { get; set; }
        
    }
}