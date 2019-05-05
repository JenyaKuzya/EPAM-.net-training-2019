using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Interface.Interfaces
{
    public interface IService
    {
        void CreateAccount(AccountType acctype, string name, string lastname);
        void CloseAccount(int id);
        void Deposit(int id, decimal amount);
        List<Account> GetAllAccounts();
        void Withdraw(int id, decimal amount);
        void Save(string filename);
        void Load(string filename);
    }
}
