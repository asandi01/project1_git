using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models {
    public class RecurenceTypeModel {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Detail")]
        [Required(ErrorMessage = "Detail is required.")]
        public string detail { get; set; }

        [Display(Name = "Day numbres")]
        [Required(ErrorMessage = "Days numbers is required.")]
        public int days { get; set; }
    }
}