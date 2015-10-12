using Övningsuppgift_Lektion_3_OOADLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    public class BidService : IBidService
    {
        IBidRepository _repository; // USE  Constructor(15)  so the service does not depends of any DB. 

        public BidService(IBidRepository repository)
        {
            _repository = repository;
        }

        public Response<Bid> CreateBid(decimal amount, User objUser)
        {
            var response = new Response<Bid>();

            if (response.Success)
            {
                var bid = new Bid();
                bid.Amount = amount;
                _repository.Save(bid);
                response.Entity = bid;
            }

            return response;
        }

        public Response<Bid> DeleteBid(int id)
        {
            var response = new Response<Bid>();

            if (response.Success)
            {
                _repository.DeleteBid(id);
            }

            return response;
        }

        public Response<Bid> GetAll()
        {
            var response = new Response<Bid>();
            response.EntityList = _repository.All();
            return response;
        }

        public Response<Bid> GetById(int id)
        {
            var response = new Response<Bid>();
            response.Entity = _repository.Get(id);
            return response;
        }

        public Response<Bid> UpdateBidDetail(int id, decimal amount)
        {
            var response = new Response<Bid>();

            if (response.Success)
            {
                var product = new Bid();
                product.Id = id;
                product.Amount = amount;
                _repository.UpdateBid(product);
            }

            return response;
        }
    }
}
