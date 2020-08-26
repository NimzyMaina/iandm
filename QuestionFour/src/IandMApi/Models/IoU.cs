using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IandMApi.Models
{
    public class IoU
    {
        public Guid Id { get; set; }
        public Guid LenderId { get; set; }
        public Guid BorrowerId { get; set; }
        public Decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Navigation Properties
        public User Lender { get; set; }
        public User Borrower { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public IoU()
        {
            Payments = new Collection<Payment>();
        }
    }
}