namespace LaBook_Planet.Library.Core.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendAsync(string recipientEmail, string subject, string body);
    }
}
