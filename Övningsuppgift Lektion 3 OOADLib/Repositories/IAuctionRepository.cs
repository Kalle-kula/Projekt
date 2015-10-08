using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    interface IAuctionRepository
    {
        Auction Get(int id);
        Auction Get(string name);
        void Save(Auction user);
        List<Auction> All();
        
        void UpdateAuctionDetails(Bank product);
    }
}
