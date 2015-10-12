using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    public interface IBankRepository
    {
        Bank Get(int id);

        Bank GetByAccountNbr(string accountNbr);

        void Save(Bank user);

        List<Bank> All();

        void UpdateBankDetail(Bank product);

        void DeleteBank(int id);

    }
}
