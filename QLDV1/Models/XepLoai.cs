using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDV1.Models
{
    public class XepLoai
    {
        [Key]
        [DisplayName("ID")]
        public int id { get; set; }
        [Required, DisplayName("Mã đoàn viên")]
        public string madv { get; set; }
        [Required, DisplayName("Năm học")]
        public int namhoc { get; set; }
        [DisplayName("Nhận xét")]
        public string nhanxet { get; set; }
        [Required, DisplayName("Xếp loại")]
        public string xeploai { get; set; }
        public int mahd { get; set; }
        [ForeignKey("madv")]
        public DoanVien DoanViens { get; set; }
        [ForeignKey("mahd")]
        public HoatDong HoatDongs { get; set; }
    }
}