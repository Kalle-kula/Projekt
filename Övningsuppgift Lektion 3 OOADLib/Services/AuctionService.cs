using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    class AuctionService : IAuctionService
    {
        public Response<Auction> CreateAuction(int productId, DateTime start, DateTime expired)
        {
            throw new NotImplementedException();
        }

        public Response<Auction> DeleteAuction(int id)
        {
            throw new NotImplementedException();
        }

        public Response<Auction> GetAll()
        {
            throw new NotImplementedException();
        }

        public Response<Auction> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Response<Auction> UpdateAuctionDetail(int id, int productId, DateTime start, DateTime expired, int winnerId)
        {
            throw new NotImplementedException();
        }
    }
}
