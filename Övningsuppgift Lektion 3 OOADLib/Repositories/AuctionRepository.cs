using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        DAL.AuctionSystemDBDataContext db = new DAL.AuctionSystemDBDataContext();

        public List<Auction> All()
        {
            var auctions = db.Auctions.Where(x => x.IsDeleted == null || x.IsDeleted == false);

            List<Auction> lstAuctions = new List<Auction>();

            foreach (DAL.Auction pt in auctions)
            {
                Auction pd = new Auction();
                pd.Id = pt.Id;
                pd.Expired = pt.Expired.HasValue ? pt.Expired.Value : DateTime.Now;
                pd.Product = new Product();
                pd.Product.Id = pt.Id;
                pd.Product.BuyoutPrice = pt.Product.BuyoutPrice.HasValue ? pt.Product.BuyoutPrice.Value : 0;
                pd.Product.ProductDesigner = pt.Product.ProductDesigner;
                pd.Product.Provision = pt.Product.Provision.HasValue ? pt.Product.Provision.Value : 0;
                pd.Product.StartPrice = pt.Product.StartPrice.HasValue ? pt.Product.StartPrice.Value : 0;
                pd.Product.SupplierId = pt.Product.SupplierId.HasValue ? pt.Product.SupplierId.Value : 0;
                pd.Product.Type = UtilityHelper.HelperClass.GetProductType(pt.Product.TypeId.HasValue ? pt.Product.TypeId.Value : 0);
                
                if (pt.BidWinnerId.HasValue)
                {

                    DAL.User user = db.Users.Where(x => x.Id == pt.BidWinnerId).FirstOrDefault();

                    if (user != null)
                    {
                        pd.BidWinner = new User();
                        pd.BidWinner.Email = user.Email;
                        pd.BidWinner.Password = user.Password;
                        pd.BidWinner.Address = user.Address;

                        DAL.Bank b = db.Banks.Where(x => x.Id == user.BankDetailId).FirstOrDefault();

                        if (b != null)
                        {
                            pd.BidWinner.BankDetails = new Bank();
                            pd.BidWinner.BankDetails.Id = b.Id;
                            pd.BidWinner.BankDetails.AccountNumber = b.AccountNbr;
                            pd.BidWinner.BankDetails.Balance = b.Balance.HasValue ? b.Balance.Value : 0;

                        }
                    }
                }

                pd.Start = pt.Start.HasValue ? pt.Start.Value : DateTime.MinValue;
                lstAuctions.Add(pd);
            }

            return lstAuctions;
        }

        public void DeleteAuction(int id)
        {
            DAL.Auction p = db.Auctions.Where(x => x.Id == id).FirstOrDefault();

            if (p != null)
            {
                p.IsDeleted = true;
                db.SubmitChanges();
            }
        }

        public Auction Get(string name)
        {
            throw new NotImplementedException();
        }

        public Auction Get(int id)
        {
            var pt = db.Auctions.Where(x => x.Id == id && (x.IsDeleted == null || x.IsDeleted == false)).FirstOrDefault();

            if (pt != null)
            {
                Auction pd = new Auction();
                pd.Id = pt.Id;
                pd.Expired = pt.Expired.HasValue ? pt.Expired.Value : DateTime.Now;
                pd.Product = new Product();
                pd.Product.Id = pt.Id;
                pd.Product.BuyoutPrice = pt.Product.BuyoutPrice.HasValue ? pt.Product.BuyoutPrice.Value : 0;
                pd.Product.ProductDesigner = pt.Product.ProductDesigner;
                pd.Product.Provision = pt.Product.Provision.HasValue ? pt.Product.Provision.Value : 0;
                pd.Product.StartPrice = pt.Product.StartPrice.HasValue ? pt.Product.StartPrice.Value : 0;
                pd.Product.SupplierId = pt.Product.SupplierId.HasValue ? pt.Product.SupplierId.Value : 0;
                pd.Product.Type = UtilityHelper.HelperClass.GetProductType(pt.Product.TypeId.HasValue ? pt.Product.TypeId.Value : 0);

                if (pt.BidWinnerId.HasValue)
                {

                    DAL.User user = db.Users.Where(x => x.Id == pt.BidWinnerId).FirstOrDefault();

                    if (user != null)
                    {
                        pd.BidWinner = new User();
                        pd.BidWinner.Email = user.Email;
                        pd.BidWinner.Password = user.Password;
                        pd.BidWinner.Address = user.Address;

                        DAL.Bank b = db.Banks.Where(x => x.Id == user.BankDetailId).FirstOrDefault();

                        if (b != null)
                        {
                            pd.BidWinner.BankDetails = new Bank();
                            pd.BidWinner.BankDetails.Id = b.Id;
                            pd.BidWinner.BankDetails.AccountNumber = b.AccountNbr;
                            pd.BidWinner.BankDetails.Balance = b.Balance.HasValue ? b.Balance.Value : 0;

                        }
                    }
                }

                pd.Start = pt.Start.HasValue ? pt.Start.Value : DateTime.MinValue;

                return pd;
            }

            return null;
        }

        public void Save(Auction user)
        {
            DAL.Auction auction = new DAL.Auction();

            if (user.BidWinner != null)
            {
                auction.BidWinnerId = user.BidWinner.Id;
     
            }

            auction.Expired = user.Expired;
            auction.ProductId = user.Product.Id;
            auction.Start = user.Start;

            db.Auctions.InsertOnSubmit(auction);
            db.SubmitChanges();
        }

        public void UpdateAuctionDetail(Auction auction)
        {
            DAL.Auction pd = db.Auctions.Where(x => x.Id == auction.Id).FirstOrDefault();

            if (pd != null)
            {
                if (auction.BidWinner != null)
                {
                    pd.BidWinnerId = auction.BidWinner.Id;

                }

                pd.Expired = auction.Expired;
                pd.ProductId = auction.Product.Id;
                pd.Start = auction.Start;

                db.SubmitChanges();
            }
        }
    }
}
