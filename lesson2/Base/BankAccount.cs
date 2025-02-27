using System;
using System.Collections.Generic;
using System.Text;
using lesson2.ValueObjects;

namespace lesson2.Base
{
    abstract class BankAccount // Абстрактный класс, нам не нужно создавать экземпляр класса
    {
        private List<Transaction> _allTransaction = new List<Transaction>(); // Список транзакций, List тип Generic

        private static int s_accountNumberSeed = 1000000000;
        public NumberOfBankAccount Number { get; }

        public string Owner { get; set; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransaction)
                    balance += item.Amount;
                return balance;
            }

        }

        public BankAccount(string owner, decimal initialBalance)
        {
            Number = new NumberOfBankAccount(s_accountNumberSeed); //передаём поле static
            s_accountNumberSeed++;// увеличиваем поле на 1
            Owner = owner;

            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");
            }

            var deposit = new Transaction(amount, date, note);
            _allTransaction.Add(deposit); // Добавили транзакцию в список транзакций

        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note) // Списание
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of Withdrawal must be positive.");
            }

            if (Balance - amount <= 0)
            {
                throw new InvalidOperationException("Not sufficient rubls for this withdrawal.");
            }


            _allTransaction.Add(new Transaction(-amount, date, note)); // Добавили транзакцию в список транзакций
        }

        public string GetAccountHistory() // string - неизменяемый класс, нельзя поменять какой-то элемент в строчке
        {
            var str = new StringBuilder();
            foreach (var elem in _allTransaction)
                str.AppendLine(elem.ToString());

            return str.ToString();
        }

        public abstract void PerformMonthEndTransactions(); // обязаны реализовать метод в наследуемых классах

    }
}
