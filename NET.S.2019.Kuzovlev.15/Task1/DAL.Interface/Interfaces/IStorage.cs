using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IStorage
    {
        List<Account> Accounts { get; }

        void Add(string accountType, string name, string lastname);
        void Remove(int id);
        void SaveAccounts(string filename);
        void LoadAccounts(string filename);
        Account GetByID(int id);
    }
}
