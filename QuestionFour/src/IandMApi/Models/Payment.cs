using System;

namespace IandMApi.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid IoUId { get; set; }
        public Decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}