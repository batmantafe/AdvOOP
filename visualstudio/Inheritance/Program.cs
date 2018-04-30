using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Inheritance.Scripts;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            accounts.Add(new SavingsAccount());
            accounts.Add(new CheckingAccount());

            accounts[0].Deposit(10);
            accounts[1].Deposit(200);

            accounts[1].Withdraw(100);
            
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc.GetStatement());
            }

            Console.ReadLine();

            /*BankAccount sav1 = new SavingsAccount();
            BankAccount sav2 = new SavingsAccount();

            sav1.Deposit(100);
            sav2.Deposit(100);

            //float amount = savings.Withdraw(99);

            Console.WriteLine(sav1.GetStatement());
            Console.WriteLine(sav2.GetStatement());

            Console.ReadLine();*/
        }
    }
}
