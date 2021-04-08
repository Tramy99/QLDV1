using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDV1.Models
{
    public class HoatDong
    {
        [Key]
        [Required, DisplayName("Mã hoạt động")]
        public int mahd { get; set; }
        [Required, DisplayName("Tên hoạt động")]
        public string tenhd { get; set; }
        [Required, DisplayName("Thời gian tổ chức")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime thoigiantc { get; set; }
        [DisplayName("Ghi chú")]
        public string ghichu { get; set; }
        public ICollection<DiemDanh> DiemDanhs { get; set; }
    }
}