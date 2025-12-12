using Newtonsoft.Json;

namespace BackEnd.Models
{
    public class UserCrud
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("password_hash")]
        public string PasswordHash { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }


        [JsonProperty("is_active")]
        public bool? IsActive { get; set; }
    }
}
