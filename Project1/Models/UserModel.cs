using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models {
    public class UserModel {
        [Display(Name = "idUsers")]
        public int idUsers { get; set; }

        [Required(ErrorMessage = "Login name is required.")]
        public string login { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string name { get; set; }
    }
}