using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.DTOs
{
    public class CustomResponseDto<T> where T : class
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }

        public static CustomResponseDto<T> Success(T data, List<string> errors)
        {
            return new CustomResponseDto<T>() { Data = data, Errors = errors };
        }

        public static CustomResponseDto<T> Success(T data)
        {
            return new CustomResponseDto<T>() { Data = data };
        }

        public static CustomResponseDto<T> Success()
        {
            return new CustomResponseDto<T>() { StatusCode = 200 };
        }

        public static CustomResponseDto<T> Fail(List<string> errors)
        {
            return new CustomResponseDto<T>() { Errors = errors };
        }
    }
}

