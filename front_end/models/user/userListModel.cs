using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public class UserListModel
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        public UserListModel(
            bool success,
            string? message,
            int userId,
            string fullName,
            string email,
            string phoneNumber,
            string passwordHash
        )
        {
            Success = success;
            Message = message;
            UserId = userId;
            FullName = fullName;
            Email = email;

        }

        public static UserListModel FromJson(Dictionary<string, object> data)
        {
            return new UserListModel(
                success: data.ContainsKey("success") && data["success"] != null
                    ? Convert.ToBoolean(data["success"])
                    : false,

                message: data.ContainsKey("message")
                    ? data["message"]?.ToString()
                    : null,

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
                { "Success", Success },
                { "Message", Message },
                { "UserId", UserId },
                { "FullName", FullName },
                { "Email", Email },
                { "PhoneNumber", PhoneNumber },
                { "PasswordHash", PasswordHash },
            };
        }
    }
}
