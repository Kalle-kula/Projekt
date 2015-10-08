using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    interface IAuctionService
    {
        Response<Auction> CreateAuction(int productId, DateTime start, DateTime expired);
        Response<Auction> GetById(int id);
        Response<Auction> GetAll();
        Response<Auction> UpdateAuctionDetail(int id, int productId, DateTime start, DateTime expired, int winnerId);
        Response<Auction> DeleteAuction(int id);
    }
}
