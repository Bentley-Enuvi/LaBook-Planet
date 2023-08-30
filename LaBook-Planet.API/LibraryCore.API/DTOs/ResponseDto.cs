using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using System.Net;
using Newtonsoft.Json;

namespace LaBook_Planet.API.LibraryCore.API.DTOs
{
    public class ResponseDto<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string> Errors { get; set; }
        public T? Data { get; set; }

        public static ResponseDto<T> Fail(IEnumerable<string> errors, int statusCode = (int)HttpStatusCode.OK)
        {
            return new ResponseDto<T>
            {
                IsSuccessful = false,
                Errors = errors,
                StatusCode = statusCode
            };
        }

        public static ResponseDto<T> Success(T data, string successMessage = "", int statusCode = (int)HttpStatusCode.OK)
        {
            return new ResponseDto<T>
            {
                IsSuccessful = true,
                Message = successMessage,
                Data = data,
                StatusCode = statusCode
            };
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
