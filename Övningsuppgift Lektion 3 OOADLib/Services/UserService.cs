using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    class UserService : IUserService
    {
        public Response<User> CreateUser(string name, string email, string password, string confirmPassword, Bank objBank, Enum type, string address)
        {
            throw new NotImplementedException();
        }

        public Response<User> Get(string email)
        {
            throw new NotImplementedException();
        }

        public Response<User> Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
