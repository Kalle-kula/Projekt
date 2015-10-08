using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    class BankService : IBankService
    {
        public Response<Bank> CreateBankAccount(string accountNbr, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Response<Bank> DeleteBankAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Response<Bank> Get(string accountNbr)
        {
            throw new NotImplementedException();
        }

        public Response<Bank> GetAll()
        {
            throw new NotImplementedException();
        }

        public Response<Bank> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Response<Bank> UpdateBankAccount(int id, string accountNbr, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
