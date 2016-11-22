using App1.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App1.Services
{
    interface IStrongPlateDataService
    {
        Task<User> GetUserDetail(string id);
        Task<List<User>> GetAllUsers();
        Task<string> GetApiClient(string baseuri);
        Task<bool> PostSetData(Plate plate);

    }
}
