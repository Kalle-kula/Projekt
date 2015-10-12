using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    interface IUserService
    {
        Response<User> CreateUser(string name, string email, string password, string confirmPassword, Bank objBank, RoleType type, string address);


        Response<User> Login(string email, string password);


        Response<User> Get(string email);

    }
}
