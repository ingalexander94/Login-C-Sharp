using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Model.DAO;
using Login.Model.DTO;

namespace Login.Controller
{
    class AuthController : IDisposable
    {
        private readonly UserDAO UserModel = new UserDAO();

        public UserDTO Login(string Username, string password)
        {
            UserDTO user = UserModel.GetUserByUsernameOrEmail(Username);
            return user == null ? null : user.Password == password ? user : null;
        }

        public UserDTO Register(string Username, string Fullname, string Email, string Password)
        {
            UserDTO newUser = UserModel.GetUserByUsernameOrEmail(Username, Email);
            if (newUser != null)
            {
                newUser = null;
            }else
            {
                newUser = UserModel.Save(Username, Fullname, Email, Password);
            }
            
            return newUser;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
