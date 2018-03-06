using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models {
    public class UserModel {
        [Display(Name = "idUsers")]
        public int idUsers { get; set; }

        [Display(Name = "Login Name")]
        [Required(ErrorMessage = "Login name is required.")]
        public string login { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string name { get; set; }
    }
}