using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public class UserCrudModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        public UserCrudModel(
            int userId,
            string fullName,
            string email,
            string phoneNumber,
            string passwordHash)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
        }

        public static UserCrudModel FromJson(Dictionary<string, object> data)
        {
            return new UserCrudModel(
                userId: data.ContainsKey("user_id") ? Convert.ToInt32(data["user_id"]) : 0,
                fullName: data.ContainsKey("full_name") ? data["full_name"]?.ToString() ?? "" : "",
                email: data.ContainsKey("email") ? data["email"]?.ToString() ?? "" : "",
                phoneNumber: data.ContainsKey("phone_number") ? data["phone_number"]?.ToString() ?? "" : "",
                passwordHash: data.ContainsKey("password_hash") ? data["password_hash"]?.ToString() ?? "" : ""
            );
        }

        public Dictionary<string, object?> ToJson()
        {
            return new Dictionary<string, object?>()
            {
                { "UserId", UserId },
                { "FullName", FullName },
                { "Email", Email },
                { "PhoneNumber", PhoneNumber },
                { "PasswordHash", PasswordHash },
            };
        }
    }
}
