namespace LaBook_Planet.Library.Core.Services.Interfaces.External
{
    public interface IUploadService
    {
        Task<Dictionary<string, string>> UploadImage(IFormFile photo, string folderName);
    }
}
