using Övningsuppgift_Lektion_3_OOADLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    public class BankService : IBankService
    {
        IBankRepository _repository; // USE  Constructor(15)  so the service does not depends of any DB. 

        public BankService(IBankRepository repository)
        {
            _repository = repository;
        }

        public Response<Bank> CreateBankAccount(string accountNbr, decimal amount)
        {
            var response = new Response<Bank>();

            if (response.Success)
            {
                var bank = new Bank();
                bank.AccountNumber = accountNbr;
                bank.Balance = amount;
                _repository.Save(bank);
                response.Entity = bank;
            }

            return response;
        }

        public Response<Bank> DeleteBankAccount(int id)
        {
            var response = new Response<Bank>();

            if (response.Success)
            {
                _repository.DeleteBank(id);
            }

            return response;
        }

        public Response<Bank> Get(string accountNbr)
        {
            var response = new Response<Bank>();
            response.Entity = _repository.GetByAccountNbr(accountNbr);
            return response;
        }

        public Response<Bank> GetAll()
        {
            var response = new Response<Bank>();
            response.EntityList = _repository.All();
            return response;
        }

        public Response<Bank> GetById(int id)
        {
            var response = new Response<Bank>();
            response.Entity = _repository.Get(id);
            return response;
        }

        public Response<Bank> UpdateBankAccount(int id, string accountNbr, decimal amount)
        {
            var response = new Response<Bank>();

            if (response.Success)
            {
                var bank = new Bank();
                bank.Id = id;
                bank.AccountNumber = accountNbr;
                bank.Balance = amount;
                _repository.UpdateBankDetail(bank);
            }

            return response;
        }
    }
}
