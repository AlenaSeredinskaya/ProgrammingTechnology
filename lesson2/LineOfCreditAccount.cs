using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lesson2.Base;

namespace lesson2
{
    class LineOfCreditAccount : BankAccount
    {

        public LineOfCreditAccount(string owner, decimal initialBalance)
            : base(owner, initialBalance)
        {

        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                MakeWithdrawal(-Balance * 0.07m, DateTime.Now, "Charge monthly interest");
            }
        }
    }
}
