using System;

namespace lesson1.ValueObjects
{
    struct Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }

        public string Note { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Note = note;
        }
    }
}

