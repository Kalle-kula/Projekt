using Övningsuppgift_Lektion_3_OOADLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    public class AuctionService : IAuctionService
    {

        IAuctionRepository _repository; // USE  Constructor(15)  so the service does not depends of any DB. 

        public AuctionService(IAuctionRepository repository)
        {
            _repository = repository;
        }

        public Response<Auction> CreateAuction(string auctionName,Product product, DateTime start, DateTime expired)
        {

            var response = new Response<Auction>();

            if (response.Success)
            {
                var auction = new Auction();
                auction.Product = product;
                auction.Start = start;
                auction.Expired = expired;
                auction.Name = auctionName;
                //auction.AskingPrice = askingPrice;
                _repository.Save(auction);
                response.Entity = auction;
            }

            return response;
        }

        public Response<Auction> DeleteAuction(int id)
        {
            var response = new Response<Auction>();

            if (response.Success)
            {
                _repository.DeleteAuction(id);
            }

            return response;
        }

        public Response<Auction> GetAll()
        {
            var response = new Response<Auction>();
            response.EntityList = _repository.All();
            return response;
        }

        public Response<Auction> GetById(int id)
        {
            var response = new Response<Auction>();
            response.Entity = _repository.Get(id);
            return response;
        }

        public Response<Auction> UpdateAuctionDetail(int id,string auctionName, Product product, DateTime start, DateTime expired, User winner)
        {
            var response = new Response<Auction>();

            if (_repository.Get(auctionName) != null) response.Error = ErrorCode.DuplicateEntity;

            if (response.Success)
            {
                var auction = new Auction();
                auction.Id = id;
                auction.Name = auctionName;
                auction.Product = product;
                //auction.AskingPrice = askingPrice;
                auction.Start = start;
                auction.Expired = expired;
                auction.BidWinner = winner;
                _repository.UpdateAuctionDetail(auction);
            }

            return response;
        }
    }
}
