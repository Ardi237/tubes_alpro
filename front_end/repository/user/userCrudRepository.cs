using System.Threading.Tasks;
using FrontEnd.API;
using FrontEnd.Models;

namespace FrontEnd.Repository
{
    public class UserCrudRepository
    {
        private readonly UserCrudApi _api;

        public UserCrudRepository()
        {
            _api = new UserCrudApi();
        }

        public async Task<ReturnDataAPI> Create(UserCrudModel record)
        {
            return await _api.CreateUser(record);
        }

        public async Task<ReturnDataAPI> Update(UserCrudModel record)
        {
            return await _api.UpdateUser(record);
        }

        public async Task<ReturnDataAPI> Delete(int userId)
        {
            return await _api.DeleteUser(userId);
        }
    }
}
