using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDV1.Models
{
    public class AccountModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = " Username không được để trống ")]
        [DisplayName("Tên người dùng")]
        public string Username { get; set; }
        [Required(ErrorMessage = " Password không được để trống ")]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
    }
}