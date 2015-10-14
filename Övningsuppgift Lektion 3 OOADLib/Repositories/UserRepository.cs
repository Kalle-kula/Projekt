using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    public class UserRepository : IUserRepository
    {
        DAL.AuctionSystemDBDataContext db = new DAL.AuctionSystemDBDataContext();

        public User Get(string loginname)
        {
            var user = db.Users.Where(x => x.Email == loginname).FirstOrDefault();

            if (user != null)
            {
                User u = new User();
                u.Id = u.Id;
                u.Email = user.Email;
                u.Password = user.Password;
                u.Address = user.Address;

                DAL.Bank b= db.Banks.Where(x => x.Id == user.BankDetailId).FirstOrDefault();

                if (b != null)
                {
                    u.BankDetails = new Bank();
                    u.BankDetails.Id = b.Id;
                    u.BankDetails.AccountNumber = b.AccountNbr;
                    u.BankDetails.Balance = b.Balance.HasValue ? b.Balance.Value : 0;
                    
                }

                u.Role = UtilityHelper.HelperClass.GetRoleType(user.RoleId.HasValue ? user.RoleId.Value : user.RoleId.Value);
           
                return u;

            }

            return null;
        }

        public User Get(int id)
        {
            var user = db.Users.Where(x => x.Id == id).FirstOrDefault();

            if (user != null)
            {
                User u = new User();
                u.Id = u.Id;
                u.Email = user.Email;
                u.Password = user.Password;
                u.Address = user.Address;

                DAL.Bank b = db.Banks.Where(x => x.Id == user.BankDetailId).FirstOrDefault();

                if (b != null)
                {
                    u.BankDetails = new Bank();
                    u.BankDetails.Id = b.Id;
                    u.BankDetails.AccountNumber = b.AccountNbr;
                    u.BankDetails.Balance = b.Balance.HasValue ? b.Balance.Value : 0;

                }

                u.Role = UtilityHelper.HelperClass.GetRoleType(user.RoleId.HasValue ? user.RoleId.Value : user.RoleId.Value);

                return u;

            }

            return null;
        }

        public void Save(User user)
        {
            DAL.User u = new DAL.User();
            
            u.Email = user.Email;
            u.Password = user.Password;
            u.RoleId = (int)user.Role;
            u.Address = user.Address;
            u.Bank = new DAL.Bank();
            u.Bank.AccountNbr = user.BankDetails.AccountNumber;
            u.Bank.Balance = user.BankDetails.Balance;
            db.Banks.InsertOnSubmit(u.Bank);
            db.SubmitChanges();
            u.BankDetailId = u.Bank.Id;
            db.Users.InsertOnSubmit(u);
            db.SubmitChanges();
        }
    }
}
