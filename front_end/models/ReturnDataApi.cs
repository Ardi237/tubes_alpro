using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public class ReturnDataAPI
    {
        public bool Success { get; set; }
        public string Data { get; set; }
        public int RowCount { get; set; }

        public ReturnDataAPI(
            bool success,
            string data,
            int rowCount)
        {
            Success = success;
            Data = data;
            RowCount = rowCount;
        }

        public static ReturnDataAPI FromJson(Dictionary<string, object> json)
        {
            return new ReturnDataAPI(
                success: json.ContainsKey("success") 
                    ? Convert.ToBoolean(json["success"]) 
                    : false,

                data: json.ContainsKey("data") 
                    ? json["data"]?.ToString() ?? "" 
                    : "",

                rowCount: json.ContainsKey("rowcount") 
                    ? Convert.ToInt32(json["rowcount"]) 
                    : 0
            );
        }

        public Dictionary<string, object?> ToJson()
        {
            return new Dictionary<string, object?>()
            {
                { "success", Success },
                { "data", Data },
                { "rowcount", RowCount }
            };
        }
    }
}
