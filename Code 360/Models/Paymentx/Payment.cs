using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.Paymentx
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public double AmountPaid { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public Student Student { get; set; }
    }
}
