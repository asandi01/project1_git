﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models {
    public class ExpenseCategoryModel {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Detail is required.")]
        public string detail { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        public int priority { get; set; }
    }
}