using Övningsuppgift_Lektion_3_OOADLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    class UserService : IUserService
    {
        private UserRepository _repository;
        private PasswordHandler _passworHandler;
        public UserService()
        {
            _passworHandler = new PasswordHandler();
            _repository = new UserRepository();
        }
        public Response<User> CreateUser(string name, string email, string password, string confirmPassword, Bank objBank, Enum type, string address)
        {
            var response = new Response<User>();
            if (_repository.Get(email) != null) response.Error = ErrorCode.DuplicateEntity;
            if (password != confirmPassword || password.Length < 6) response.Error = ErrorCode.InvalidState;
            if (response.Success)
            {
                _passworHandler = new PasswordHandler();
                var user = new User();
                user.Address = address;
                user.BankDetails = objBank;
                user.Email = email;
                user.Name = name;
                user.Role = type;
                user.Password = _passworHandler.HashPassword(password);
                _repository.Save(user);
                response.Entity = user;
            }
            return response;
        }

        public Response<User> Get(string email)
        {
            return new Response<User>() { Entity = _repository.Get(email) };
        }

        public Response<User> Login(string email, string password)
        {
            var response = new Response<User>();
            var user = _repository.Get(email);

            if (user == null)
            {
                response.Error = ErrorCode.InvalidLogin;
                return response;
            }
            if(!_passworHandler.ValidatePassword(password, user.Password))
            {
                response.Error = ErrorCode.InvalidLogin;
                return response;
            }
            response.Entity = user;
            return response;
            
        }
    }
}
