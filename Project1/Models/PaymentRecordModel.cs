using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models {
    public class PaymentRecordModel {
        public int idPaymentRecord { get; set; }
        public int idUser { get; set; }
        public string detail { get; set; }
        public double amount { get; set; }
        public bool recurrence { get; set; }
        public int recurrenceType { get; set; }
        public DateTime paymentDate { get; set; }
        public string provider { get; set; }
        public int serviceType { get; set; }
    }
}