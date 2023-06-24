using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MathPractiseApplication.Models
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(User user);
        void Edit(User user);
        void Remove(int id);
        User UserGetById(int id);
        User UserGetByName(string username);
        List<User> GetAllUsers();
    }
}
