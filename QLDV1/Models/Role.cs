﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDV1.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Rolename { get; set; }
    }
}