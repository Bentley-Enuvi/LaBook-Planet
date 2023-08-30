using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using IResult =LaBook_Planet.API.Library.Domain.Services.Interfaces.IResult;

namespace LaBook_Planet.API.Library.Domain.Services.Implementations
{
    public class Result<T> : IResult
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; } = Array.Empty<string>();
        public T? Data { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public static Result<T> Fail(IEnumerable<string> errors)
        {
            return new Result<T>
            {
                IsSuccessful = false, 
                Errors = errors
            };
        }


        public static Result<T> Success(T? data)
        {
            return new Result<T>
            {
                IsSuccessful = true,
                Data = data
            };
        }
    }
}
