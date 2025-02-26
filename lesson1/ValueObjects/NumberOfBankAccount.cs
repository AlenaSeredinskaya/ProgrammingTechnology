using System;

namespace lesson1.ValueObjects
{
 struct NumberOfBankAccount
    {
        public long Value { get; set; }
        public NumberOfBankAccount(long number)
        {
            if (number  < 1000000000 || number >= 10000000000)
                throw new System.ArgumentOutOfRangeException(
                    nameof(number), "Сработало исключение. Некорректный номер счёта.");

            Value = number;
        }
    }
}