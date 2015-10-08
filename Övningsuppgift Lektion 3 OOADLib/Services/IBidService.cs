using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    interface IBidService
    {
        Response<Bid> CreateBid(decimal amount, int userId);
        Response<Bid> GetById(int id);
        Response<Bid> GetAll();
        Response<Bid> UpdateBidDetail(int id, decimal amount);
        Response<Bid> DeleteBid(int id);

    }
}
