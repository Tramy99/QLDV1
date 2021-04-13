using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDV1.Models
{
    public class TinTuc
    {
        [Key]
        [DisplayName("ID")]
        public string id { get; set; }
        [DisplayName("Tiêu đề")]
        public string tieude { get; set; }
        [AllowHtml]
        [DisplayName("Mô tả")]
        public string mota { get; set; }
        
    }
}