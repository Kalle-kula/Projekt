using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    interface IBankRepository
    {
        Bank Get(int id);
        Bank Get(string name);
        void Save(Auction user);
        List<Bank> All();

        void UpdateAuctionDetails(Bank product);
        void DeleteBank(int id);
    }
}
