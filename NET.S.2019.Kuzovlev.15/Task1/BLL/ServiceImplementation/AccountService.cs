using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.ServiceImplementation
{
    public class AccountService : IService
    {
        private readonly IStorage _accountStorage;

        public AccountService(IStorage accountStorage)
        {
            _accountStorage = accountStorage;
        }

        public List<Account> GetAllAccounts()
        {
            return _accountStorage.Accounts;
        }

        public void Deposit(int id, decimal amount)
        {
            var account = FindAccount(id);
            if (account.Status == AccountStatus.Close) throw new ArgumentException("Account is closed");
            account.Deposit(amount);
        }


        public void Withdraw(int id, decimal amount)
        {
            var account = FindAccount(id);
            if (account.Status == AccountStatus.Close) throw new ArgumentException("Account is closed");
            account.Withdraw(amount);
        }


        public void CreateAccount(AccountType accounttype, string name, string lastname)
        {
            _accountStorage.Add(accounttype.ToString(), name, lastname);
        }

        public void CloseAccount(int id)
        {
            if (id < 0) throw new ArgumentException();

            var account = FindAccount(id);
            account.Status = AccountStatus.Close;
        }

        public void Save(string filename)
        {
            _accountStorage.SaveAccounts(filename);
        }

        public void Load(string filename)
        {
            _accountStorage.LoadAccounts(filename);
        }

        private Account FindAccount(int id)
        {
            return _accountStorage.GetByID(id);
        }
    }
}
