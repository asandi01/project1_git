using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WS.Models {
    public class PaymentRecordModel {
        [Display(Name = "Id")]
        public int id { get; set; }

        public int idUser { get; set; }

        [Display(Name = "Detail")]
        [Required(ErrorMessage = "Detail is required.")]
        public string detail { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required.")]
        public double amount { get; set; }

        [Display(Name = "Recurrence")]
        public bool recurrence { get; set; }

        [Display(Name = "Recurrence Option")]
        public int recurrenciaTypeId { get; set; }

        [Display(Name = "Payment date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "Payment Date is required.")]
        public DateTime paymentDate { get; set; }

        [Display(Name = "Provider Option")]
        public int providerId { get; set; }

        [Display(Name = "Expense Category Option")]
        public int expenseCategoryId { get; set; }
        
        public DateTime Now { get; }
    }
}