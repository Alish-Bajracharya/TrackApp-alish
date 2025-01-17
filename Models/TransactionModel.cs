using System;

namespace TrackApp_alish.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public string Type { get; set; } // "Credit", "Debit", or "Debt"
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
    }
}
