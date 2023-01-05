using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Responses
{
    public class BaseResponse<TError>
    {
        public BaseResponse()
        {
            Success = true;
            Errors = new List<TError>();
        }
        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
            Errors = new List<TError>();
        }
        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
            Errors = new List<TError>();
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<TError> Errors { get; set; }
    }
}
