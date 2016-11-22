using App1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.DAL
{
    public interface IStrongPlateRepository
    {
        Task<bool> PostSetData(Plate plate);
        Task<string> JsonApiClientGetRequest(string baseUri);
        Task<User> GetUserById(string id);
        Task<List<User>> GetUsers();

        
    }
}
