using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    public class BankRepository : IBankRepository
    {
        DAL.AuctionSystemDBDataContext db = new DAL.AuctionSystemDBDataContext();
        public List<Bank> All()
        {
            throw new NotImplementedException();
        }

        public void DeleteBank(int id)
        {
            DAL.Bank p = db.Banks.Where(x => x.Id == id).FirstOrDefault();

            if (p != null)
            {
                db.Banks.DeleteOnSubmit(p);
                db.SubmitChanges();
            }
        }

        public Bank GetByAccountNbr(string accountNbr)
        {
            throw new NotImplementedException();
        }

        public Bank Get(int id)
        {
            var pt = db.Banks.Where(x => x.Id == id).FirstOrDefault();

            if (pt != null)
            {
                Bank pd = new Bank();
                pd.Id = pt.Id;
                pd.AccountNumber = pt.AccountNbr;
                pd.Balance = pt.Balance.HasValue ? pt.Balance.Value : 0;
                return pd;
            }

            return null;
        }

        public void Save(Bank bank)
        {
            DAL.Bank pd = new DAL.Bank();
            pd.AccountNbr = bank.AccountNumber;
            pd.Balance = bank.Balance;
            db.Banks.InsertOnSubmit(pd);
            db.SubmitChanges();
        }

        public void UpdateBankDetail(Bank bank)
        {
            DAL.Bank pd = db.Banks.Where(x => x.Id == bank.Id).FirstOrDefault();

            if (pd != null)
            {
                pd.AccountNbr = bank.AccountNumber;
                pd.Balance = bank.Balance;
                db.SubmitChanges();
            }
        }
        
    }
}
