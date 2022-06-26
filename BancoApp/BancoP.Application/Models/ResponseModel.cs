using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Models
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public ResponseModel(bool success, string message, T result)
        {
            Success = success;
            Message = message;
            Result = result;
        }
    }
}
