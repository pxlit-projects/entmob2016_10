using App1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.DAL
{
    public interface IApp1Repository
    {
        Task<string> JsonApiClientGetRequest(string baseUri);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
    }
}
