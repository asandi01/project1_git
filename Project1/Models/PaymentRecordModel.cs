﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models {
    public class PaymentRecordModel {
        [Display(Name = "Id")]
        public int id { get; set; }

        public int idUser { get; set; }

        [Required(ErrorMessage = "Detail is required.")]
        public string detail { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public double amount { get; set; }

        [Required(ErrorMessage = "Pecurrence is required.")]
        public int recurrence { get; set; }
        
        [Required(ErrorMessage = "Recurrencia Type is required.")]
        public int recurrenciaTypeId { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "Payment Date is required.")]
        public DateTime paymentDate { get; set; }

        [Required(ErrorMessage = "Provider is required.")]
        public int providerId { get; set; }

        [Required(ErrorMessage = "Expense Category is required.")]
        public int expenseCategoryId { get; set; }
        
        public DateTime Now { get; }
    }
}