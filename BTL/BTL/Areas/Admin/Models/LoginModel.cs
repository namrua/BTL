
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTL.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "nhap username")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "nhap password ")]
        public String Password { get; set; }
        public bool RememberMe { get; set; }
     
    }
}