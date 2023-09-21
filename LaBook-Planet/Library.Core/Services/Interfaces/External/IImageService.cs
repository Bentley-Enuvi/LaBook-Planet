namespace LaBook_Planet.Library.Core.Services.Interfaces.External
{
    public interface IImageService
    {
        public Task<Dictionary<string, string>> UploadImage(IFormFile photo, string folderName);
    }
}
