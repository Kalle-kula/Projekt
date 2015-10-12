using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    public interface IAuctionRepository
    {
        Auction Get(int id);

        Auction Get(string name);

        void Save(Auction user);

        List<Auction> All();

        void UpdateAuctionDetail(Auction product);

        void DeleteAuction(int id);
    }
}
