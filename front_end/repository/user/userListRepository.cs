using System.Collections.Generic;
using System.Threading.Tasks;
using FrontEnd.API;
using FrontEnd.Models;

namespace FrontEnd.Repository
{
    public class UserListRepository
    {
        private readonly UserListApi _api;

        public UserListRepository()
        {
            _api = new UserListApi();
        }

        public async Task<List<UserListModel>> GetUserList(string searchText)
        {
            return await _api.GetUserList(searchText);
        }

        public async Task<UserListModel?> GetUserById(int userId)
        {
            return await _api.GetUserById(userId);
        }
    }
}
