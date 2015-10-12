using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    interface IAuctionService
    {
        Response<Auction> CreateAuction(string auctionName, Product product, DateTime start, DateTime expired);

        Response<Auction> GetById(int id);

        Response<Auction> GetAll();

        Response<Auction> UpdateAuctionDetail(int id, string auctionName, Product product, DateTime start, DateTime expired, User winner);

        Response<Auction> DeleteAuction(int id);
    }
}
