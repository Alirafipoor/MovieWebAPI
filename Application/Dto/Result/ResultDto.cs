using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.ResultDto
{
    public class ResultDto<T>
    {
        public ResultDto(T? data,bool isSuccess,string message)
        {
            this.Data = data;
            this.IsSuccess = isSuccess;
            this.Message = message;
            
        }
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class ResultDto
    {
        public ResultDto(bool isSuccess, string message)
        {
           
            this.IsSuccess = isSuccess;
            this.Message = message;

        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

}
