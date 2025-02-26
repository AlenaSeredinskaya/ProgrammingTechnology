using lesson1.ValueObjects;
using System;

class BankAccount
{
    private static NumberOfBankAccount s_accountNumberSeed = new NumberOfBankAccount(1000000000);

    private List<Transaction> _AllTransaction = new List<Transaction>();

    public NumberOfBankAccount Number { get; }

    public string Owner { get; private set; }

    private decimal _balance = 0;

    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _AllTransaction)
            {
                balance += item.Amount;
            }
            _balance = balance;
            return balance;
        }
        private set
        {

        }
    }

    public BankAccount(string fullname, decimal initialBalance)
    {
        Number = s_accountNumberSeed;
        s_accountNumberSeed.Value++;
        Owner = fullname;
        Balance = initialBalance;
        Balance += 10m;

    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Amount of deposit must be positive");
        var deposit = new Transaction(amount, date, note);
        _AllTransaction.Add(deposit);

    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (Balance - amount >= 0)
            throw new InvalidOperationException("Not suffucuent rubbls for  this operation");
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Amount of deposit must be positive");
        var deposit = new Transaction(-amount, date, note);
        _AllTransaction.Add(deposit);
    }

}
