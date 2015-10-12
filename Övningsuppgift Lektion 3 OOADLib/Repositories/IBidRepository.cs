using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    public interface IBidRepository
    {
        Bid Get(int id);

        Bid Get(string name);

        void Save(Bid user);

        List<Bid> All();

        void UpdateBid(Bid product);

        void DeleteBid(int id);
    }
}
