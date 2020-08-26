using System;
using System.ComponentModel.DataAnnotations;

namespace IandMApi.Models
{
    public class PaymentDto
    {
        [Required]
        public string Lender { get; set; }

        [Required]
        public string Borrower { get; set; }

        [Required]
        public Decimal Amount { get; set; }
    }
}