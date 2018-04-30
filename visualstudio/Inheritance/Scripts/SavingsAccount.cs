using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Scripts
{
    // Inherits from BankAccount
    class SavingsAccount : BankAccount
    {
        public float interest = 0.01f;

        public void Credit(float amount)
        {
            money += amount * interest;
        }

        private string GetInterest()
        {
            return "Interest: " + (interest * 100).ToString() + "%";
        }

        public override void Deposit(float amount)
        {
            base.Deposit(amount);

            // Credited every time you deposit! YAY!
            Credit(amount);
        }

        public override string GetStatement()
        {
            return base.GetStatement() + "\n" +
                "\t" + GetInterest() + "\n";
        }
    }
}
