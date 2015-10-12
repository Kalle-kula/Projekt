using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    interface IBankService
    {
        Response<Bank> CreateBankAccount(string accountNbr, decimal amount);


        Response<Bank> Get(string accountNbr);

        Response<Bank> GetById(int id);

        Response<Bank> GetAll();

        Response<Bank> UpdateBankAccount(int id, string accountNbr, decimal amount);

        Response<Bank> DeleteBankAccount(int id);
    }
}
