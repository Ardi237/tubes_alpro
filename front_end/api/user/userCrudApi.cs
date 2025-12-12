using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using FrontEnd.Models;
using FrontEnd.Common;

namespace FrontEnd.API
{
    public class UserCrudApi
    {
       private readonly HttpClient _http;

        public UserCrudApi()
        {
            _http = new HttpClient();
        }

        public async Task<ReturnDataAPI> CreateUser(UserCrudModel user)
        {
            var url = $"{AppData.BaseApiUrl}/user/usercrud/create";

            var jsonBody = JsonConvert.SerializeObject(user.ToJson());
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return new ReturnDataAPI(false, "", 0);

            var responseBody = await response.Content.ReadAsStringAsync();
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

            return ReturnDataAPI.FromJson(dict!);
        }

        public async Task<ReturnDataAPI> UpdateUser(UserCrudModel user)
        {
            var url = $"{AppData.BaseApiUrl}/user/usercrud/update";

            var jsonBody = JsonConvert.SerializeObject(user.ToJson());
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return new ReturnDataAPI(false, "", 0);

            var responseBody = await response.Content.ReadAsStringAsync();
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

            return ReturnDataAPI.FromJson(dict!);
        }

        public async Task<ReturnDataAPI> DeleteUser(int userId)
        {
            var url = $"{AppData.BaseApiUrl}/user/usercrud/delete/{userId}";

            var response = await _http.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return new ReturnDataAPI(false, "", 0);

            var responseBody = await response.Content.ReadAsStringAsync();
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

            return ReturnDataAPI.FromJson(dict!);
        }
    }
}
