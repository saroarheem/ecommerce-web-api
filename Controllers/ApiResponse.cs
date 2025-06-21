using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Controllers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }
        public DateTime TimeStamp { get; set; }

        // constructor for successfull response
        public ApiResponse(bool success, string message, T? data, List<string>? errors, int statuscode)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
            StatusCode = statuscode;
            TimeStamp = DateTime.UtcNow;
        }
        // static method for creating successfull response
        public static ApiResponse<T> SuccessResponse(T? data, int statuscode, string message = "")
        {
            return new ApiResponse<T> ( true, message, data, null, statuscode );
        }

        // static method for creating error response
        public static ApiResponse<T> ErrorResponse(List<string> errors, int statuscode, string message = "")
        {
            return new ApiResponse<T>(false, message, default(T), errors, statuscode);
        }


    }
}