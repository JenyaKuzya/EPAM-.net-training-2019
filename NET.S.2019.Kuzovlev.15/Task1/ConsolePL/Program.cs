using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IService service = resolver.Get<IService>();

            service.CreateAccount(AccountType.Basic, "Ivan", "Ivanov");
            service.CreateAccount(AccountType.Gold, "Petr", "Petrov");
            service.CreateAccount(AccountType.Platinum, "Sidor", "Sidorov");

            service.Deposit(1000001, 1000);
            service.Deposit(1000002, 2000);
            service.Deposit(1000003, 3000);

            foreach (Account account in service.GetAllAccounts())
            {
                Console.WriteLine(account);
            }

            Console.ReadLine();

            service.Withdraw(1000001, 100);
            service.Withdraw(1000002, 200);
            service.Withdraw(1000003, 300);

            foreach (Account account in service.GetAllAccounts())
            {
                Console.WriteLine(account);
            }

            Console.ReadLine();
        }
    }
}
