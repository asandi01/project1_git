using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models {
    public class IncomeRecordModel {
        [Display(Name = "Id")]
        public int id { get; set; }

        public int idUser { get; set; }

        [Required(ErrorMessage = "Detail is required.")]
        public string detail { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public double amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "Payment Date is required.")]
        public DateTime paymentDate { get; set; }

        public DateTime Now { get; }
    }
}