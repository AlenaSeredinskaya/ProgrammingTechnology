using System;

namespace lesson1.SystemOfBankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            var account1 = new BankAccount("Ben", 1000);
            var account2 = new BankAccount("Anne", 4000);
            Console.WriteLine($"Account {account1.Number.Value} was created for {account1.Owner} " +
                $"with {account1.Balance} initial balance.");
            Console.WriteLine($"Account {account2.Number.Value} was created for {account2.Owner} " +
                $"with {account2.Balance} initial balance.");

        }
    }
}
