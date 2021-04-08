using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDV1.Models
{
    public class DiemDanh
    {
        [Key]
        [DisplayName("ID")]
        public int id { get; set; }
        [Required, DisplayName("Mã đoàn viên")]
        public string madv { get; set; }
        [Required, DisplayName("Mã hoạt động")]
        public int mahd { get; set; }
        [DisplayName("Ghi chú")]
        public string ghichu { get; set; }
        [ForeignKey("madv")]
        public DoanVien DoanViens { get; set; }
        [ForeignKey("mahd")]
        public HoatDong HoatDongs { get; set; }
    }
}
