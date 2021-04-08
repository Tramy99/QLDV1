using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDV1.Models
{
    public class KhenThuong
    {
        [Key]
        [Required, DisplayName("Mã khen thưởng")]
        public int makt { get; set; }
        [Required, DisplayName("Tên khen thưởng")]
        public string tenkt { get; set; }
        [Required, DisplayName("Mã đoàn viên")]
        public string madv { get; set; }
        [Required, DisplayName("Thành tích")]
        public string thanhtich { get; set; }
        [Required, DisplayName("Năm học")]
        public int namhoc { get; set; }
        [ForeignKey("madv")]
        public DoanVien DoanViens { get; set; }
    }
}