using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lesson2.Base;

namespace lesson2
{
    class GiftCardAccount : BankAccount
    {
        public GiftCardAccount(string owner, decimal initialBalance)
            : base(owner, initialBalance)
        {

        }

        public override void PerformMonthEndTransactions()
            => MakeWithdrawal(-Balance, DateTime.Now, ":(");

    }
}
