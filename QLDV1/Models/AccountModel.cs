using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required(ErrorMessage = " Quyền không được để trống ")]
        [DisplayName("Quyền")]
        public int Role_id { get; set; }
        [ForeignKey("Role_id")]
        public virtual Role Role { get; set; }
    }
}