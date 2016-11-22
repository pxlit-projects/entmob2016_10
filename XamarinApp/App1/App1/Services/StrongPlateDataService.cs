using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Domain;
using App1.DAL;

namespace App1.Services
{
    public class StrongPlateDataService : IStrongPlateDataService
    {

        private StrongPlateRepository repository = new StrongPlateRepository();

        public StrongPlateDataService()
        {
            this.repository = repository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await repository.GetUsers();
        }

        public async Task<string> GetApiClient(string baseuri)
        {
            return await repository.JsonApiClientGetRequest(baseuri);
        }

        public async Task<User> GetUserDetail(string id)
        {
            return await repository.GetUserById(id);
        }

        public async Task<bool> PostSetData(Plate plate)
        {
            return await repository.PostSetData(plate);
        }
    }
}
