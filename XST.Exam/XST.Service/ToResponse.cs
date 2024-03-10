using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Service
{
    public class ToResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public ToResponse()
        {
            // 默认构造函数
        }

        public ToResponse(bool success, T data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }
    }
}
