using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    interface IUserRepository
    {
        User Get(int id);

        User Get(string loginname);

        void Save(User user);
    }
}
