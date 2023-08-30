namespace LaBook_Planet.API.Library.Domain.Services.Interfaces
{
    public interface IResult
    {
        public bool IsSuccessful { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
