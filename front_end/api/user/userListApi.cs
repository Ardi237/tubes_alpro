    using FrontEnd.Common;
    using FrontEnd.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    namespace FrontEnd.API
    {
        public class UserListApi
        {
            private readonly HttpClient _http;

            public UserListApi()
            {
                _http = new HttpClient();
            }

            public async Task<List<UserListModel>> GetUserList(string searchText)
            {
                var url = $"{AppData.BaseApiUrl}/user/userlist/find?searchText={searchText}";

                var response = await _http.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Failed to load user list");

                var body = await response.Content.ReadAsStringAsync();

                var list = JsonConvert.DeserializeObject<List<UserListModel>>(body);

                return list ?? new List<UserListModel>();
            }

            public async Task<UserListModel?> GetUserById(int userId)
            {
                var url = $"{AppData.BaseApiUrl}/user/userlist/byid/{userId}";

                var response = await _http.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return null;

                var body = await response.Content.ReadAsStringAsync();

                var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(body);

                if (dict == null)
                    return null;

                return UserListModel.FromJson(dict);
            }
        }
    }
