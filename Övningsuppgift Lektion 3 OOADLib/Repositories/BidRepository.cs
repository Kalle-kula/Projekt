using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    public class BidRepository : IBidRepository
    {
        DAL.AuctionSystemDBDataContext db = new DAL.AuctionSystemDBDataContext();

        public List<Bid> All()
        {
            throw new NotImplementedException();
        }

        public void DeleteBid(int id)
        {
            DAL.Bid p = db.Bids.Where(x => x.Id == id).FirstOrDefault();

            if (p != null)
            {
                db.Bids.DeleteOnSubmit(p);
                db.SubmitChanges();
            }
        }

        public Bid Get(string name)
        {
            throw new NotImplementedException();
        }

        public Bid Get(int id)
        {
            var pt = db.Bids.Where(x => x.Id == id).FirstOrDefault();

            if (pt != null)
            {
                Bid pd = new Bid();
                pd.Id = pt.Id;
                pd.Amount = pt.Amount.HasValue ? pt.Amount.Value : 0;
                DAL.User user = db.Users.Where(x => x.Id == pt.BidderId).FirstOrDefault();

                if (user != null)
                {
                    pd.User = new User();
                    pd.User.Email = user.Email;
                    pd.User.Password = user.Password;
                    pd.User.Address = user.Address;

                    DAL.Bank b = db.Banks.Where(x => x.Id == user.BankDetailId).FirstOrDefault();

                    if (b != null)
                    {
                        pd.User.BankDetails = new Bank();
                        pd.User.BankDetails.Id = b.Id;
                        pd.User.BankDetails.AccountNumber = b.AccountNbr;
                        pd.User.BankDetails.Balance = b.Balance.HasValue ? b.Balance.Value : 0;

                    }
                }
                pd.AuctionId = pt.AuctionId.HasValue ? pt.AuctionId.Value : 0;

                return pd;
            }

            return null;
        }

        public void Save(Bid bid)
        {
            DAL.Bid pd = new DAL.Bid();
            pd.BidderId = bid.User.Id;
            pd.AuctionId = bid.AuctionId;
            pd.Amount = bid.Amount;
            db.Bids.InsertOnSubmit(pd);
            db.SubmitChanges();
        }

        public void UpdateBid(Bid bid)
        {
            DAL.Bid pd = db.Bids.Where(x => x.Id == bid.Id).FirstOrDefault();

            if (pd != null)
            {
                pd.Id = bid.Id;
                pd.BidderId = bid.User.Id;
                pd.AuctionId = bid.AuctionId;
                pd.Amount = bid.Amount;
                db.SubmitChanges();
            }
        }
    }
}
