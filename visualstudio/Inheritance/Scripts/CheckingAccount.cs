using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Scripts
{
    class CheckingAccount : BankAccount
    {
        public float transactionFee = 0.01f;

        public void Fee(float amount)
        {
            money -= amount * transactionFee;
        }

        public string GetFee()
        {
            return "Fee: " + (transactionFee * 100).ToString() + "%";
        }

        public override float Withdraw(float amount)
        {
            amount = base.Withdraw(amount);
            Fee(amount);
            return amount;
        }

        public override string GetStatement()
        {
            return base.GetStatement() + "\n" +
                "\t" + GetFee() + "\n";
        }
        }
    }
