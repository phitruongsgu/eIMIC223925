using eIMIC223925.DATA.Enum;
using System;

namespace eIMIC223925.DATA.Entities
{
    public class Transaction
    {
        public int Id { set; get; }
        public DateTime TransactionDate { set; get; }
        public string ExternalTransactionId { set; get; }
        public decimal Amount { set; get; }
        public decimal Fee { set; get; }
        public string Result { set; get; }
        public string Message { set; get; }
        public string Provider { set; get; }

        public TransactionStatus Status { set; get; }
    }
}
