using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WS.Models {
    public class AlertModel {

        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Payment Date")]
        public DateTime paymentDate { get; set; }

        [Display(Name = "Detail")]
        public string detail { get; set; }

        [Display(Name = "Amount")]
        public double amount { get; set; }

        [Display(Name = "Days")]
        public int days { get; set; }

        [Display(Name = "Sum Date")]
        public DateTime sumDate { get; set; }

        [Display(Name = "Payments current Month")]
        public double paymentCurrentMonth { get; set; }

        [Display(Name = "Payments previous  Month")]
        public double paymentPreviousMonth { get; set; }

    }
}