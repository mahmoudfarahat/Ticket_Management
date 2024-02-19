using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success =true;
        }
        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }
        public BaseResponse(string message, bool success)
        {
           
            Message = message;
            Success = success;
        }

        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }

        public List<string>? ValidationErrors { get; set; } 
    }
}
