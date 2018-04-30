using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Scripts
{
    // Super Class / Base Class
    class BankAccount
    {
        public int accountNumber;
        protected float money;

        public BankAccount()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            accountNumber = rand.Next(100000000, 999999999);
        }

        public virtual void Deposit(float amount)
        {
            money += amount;
        }


        public virtual float Withdraw(float amount)
        {
            // Error Check:
            // If money > amount
            if (money > amount)
            {
                // reduce money
                money -= amount;
            }

            // else
            else
            {
                // return all the money (return amount;)
                amount = money;
                money = 0;
            }
            
            return amount;
        }

        // Forms a statement and returns a string containing said statement
        public virtual string GetStatement()
        {
            return GetAccountNo() + "\n" +
                "\t" + GetMoney() + "\n";
        }

        protected string GetAccountNo()
        {
            return "Account No.: " + accountNumber.ToString();
        }

        protected string GetMoney()
        {
            return "Money: $" + money.ToString();
        }
    }
}
